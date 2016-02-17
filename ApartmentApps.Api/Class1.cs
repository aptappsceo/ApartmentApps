using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Data;
using Entrata.Client;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;

namespace ApartmentApps.Api
{
    public interface IService
    {

    }

    public static class ServiceExtensions
    {
        public static Func<IEnumerable<IService>> GetServices { get; set; }


        public static void InvokeEvent<TEventInterface>(ApplicationDbContext ctx, ApplicationUser user, Action<TEventInterface> evt) where TEventInterface : class
        {
            InvokeEvent<TEventInterface>(null, ctx, user, evt);
        }

        public static void InvokeEvent<TEventInterface>(this IService service, ApplicationDbContext ctx, ApplicationUser user, Action<TEventInterface> evt) where TEventInterface : class
        {
            foreach (var item in GetServices())
            {
                var item1 = item as TEventInterface;
                if (item1 == null) continue;
                var filter = item as IAddonFilter;
                if (filter != null)
                {
                    if (!filter.Filter(user))
                    {
                        continue;
                    }
                }
                evt(item1);
            }
        }

    }
    public interface IMaintenanceService : IService
    {
        int SubmitRequest(string user, string comments, int requestTypeId);
        bool PauseRequest(int requestId, string comments);
        bool CompleteRequest(int requestId, string comments);
    }

    public class MaintenanceService : IMaintenanceService
    {
        public int SubmitRequest(string user, string comments, int requestTypeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var maitenanceRequest = new MaitenanceRequest()
                {
                    UserId = user,
                    WorkerId = null,
                    SubmissionDate = DateTime.UtcNow,
                    StatusId = "Scheduled",
                    Message = comments,
                    MaitenanceRequestTypeId = requestTypeId
                };
                ctx.MaitenanceRequests.Add(maitenanceRequest);
                ctx.SaveChanges();
                this.InvokeEvent<IMaintenanceSubmissionEvent>(ctx, ctx.Users.First(p => p.Id == user), _ => _.MaintenanceRequestSubmited(maitenanceRequest));
                return maitenanceRequest.Id;
            }
        }

        public bool PauseRequest(int requestId, string comments)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.MaitenanceRequests.FirstOrDefault(p => p.Id == requestId);
                if (request != null)
                {
                    request.StatusId = "Paused";
                    ctx.SaveChanges();
                    this.InvokeEvent<IMaintenanceRequestPausedEvent>(ctx, request.Worker, _ => _.MaintenanceRequestPaused(request));
                    return true;
                }
                return false;
            }
        }

        public bool CompleteRequest(int requestId, string comments)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.MaitenanceRequests.FirstOrDefault(p => p.Id == requestId);
                if (request != null)
                {
                    request.StatusId = "Complete";
                    ctx.SaveChanges();
                    this.InvokeEvent<IMaintenanceRequestCompletedEvent>(ctx, request.Worker, _ => _.MaintenanceRequestCompleted(request));
                    return true;
                }
                return false;
            }
        }
    }

    public interface IApartmentAppsAddon
    {

    }

    public interface IMaintenanceSubmissionEvent
    {
        void MaintenanceRequestSubmited(MaitenanceRequest maitenanceRequest);
    }

    public interface IMaintenanceRequestPausedEvent
    {
        void MaintenanceRequestPaused(MaitenanceRequest maitenanceRequest);
    }

    public interface IMaintenanceRequestCompletedEvent
    {
        void MaintenanceRequestCompleted(MaitenanceRequest maitenanceRequest);
    }

    public interface IAddonFilter
    {
        bool Filter(ApplicationUser user);
    }

    public abstract class PropertyIntegrationAddon : IService, IApartmentAppsAddon, IAddonFilter
    {
        public abstract bool Filter(ApplicationUser user);

    }

    /// <summary>
    /// This service is used to handle when push notifications should be sent out.
    /// </summary>
    public class PushNotificationsService : IService, IMaintenanceRequestCompletedEvent, IMaintenanceRequestPausedEvent, IMaintenanceSubmissionEvent
    {
        public void MaintenanceRequestCompleted(MaitenanceRequest maitenanceRequest)
        {

        }

        public void MaintenanceRequestPaused(MaitenanceRequest maitenanceRequest)
        {

        }

        public void MaintenanceRequestSubmited(MaitenanceRequest maitenanceRequest)
        {

        }
    }

    public interface ICreateUser
    {
        Task<ApplicationUser> CreateUser(string email, string password);
    }
    /// <summary>
    /// Handles the synchronization of entrata and apartment apps.
    /// </summary>
    public class EntrataIntegration : PropertyIntegrationAddon, IMaintenanceRequestCompletedEvent, IMaintenanceRequestPausedEvent, IMaintenanceSubmissionEvent
    {
        public override bool Filter(ApplicationUser user)
        {

            return user.Property.EntrataInfo != null;
        }

        public static async Task<bool> ImportData(ICreateUser createUser, ApplicationDbContext ctx, Property property)
        {
            var client = new EntrataClient();
            var info = property.EntrataInfo;
            client.EndPoint = info.Endpoint;
            client.Username = info.Username;
            client.Password = info.Password;
            var result = await client.GetCustomers(info.EntrataPropertyId);
            foreach (var item in result.Response.Result.Customers.Customer)
            {

                // Create the building
                var building =
                   await ctx.Buildings.FirstOrDefaultAsync(p => p.PropertyId == property.Id && p.Name == item.BuildingName);

                if (building == null)
                {
                    building = new Building()
                    {
                        Name = item.BuildingName,
                        PropertyId = property.Id
                    };
                    ctx.Buildings.Add(building);
                    await ctx.SaveChangesAsync();
                }

                var unit =
                    await ctx.Units.FirstOrDefaultAsync(p => p.BuildingId == building.Id && p.Name == item.UnitNumber);
                if (unit == null)
                {
                    unit = new Unit()
                    {
                        Name = item.UnitNumber,
                        BuildingId = building.Id
                    };
                    ctx.Units.Add(unit);
                    await ctx.SaveChangesAsync();
                }

                var user = await ctx.Users.FirstOrDefaultAsync(p => p.Email.ToLower() == item.Email.ToLower());

                if (user == null)
                {
                    user = await createUser.CreateUser(item.Email, item.FirstName[0].ToString().ToLower() + item.LastName.ToLower());


                }
                if (user == null)
                {
                    continue;
                }
                user.PropertyId = property.Id;
                var tenantInfo = await ctx.Tenants.FirstOrDefaultAsync(p => p.UserId == user.Id);
                if (tenantInfo == null)
                {
                    tenantInfo = new Tenant();
                    ctx.Tenants.Add(tenantInfo);
                }
                
               
                tenantInfo.BuildingName = item.BuildingName;
                tenantInfo.City = item.City;
                tenantInfo.Email = item.Email;
                tenantInfo.FirstName = item.FirstName;
                tenantInfo.LastName = item.LastName;
                tenantInfo.Gender = item.Gender;
                tenantInfo.MiddleName = item.MiddleName;
                tenantInfo.PostalCode = item.PostalCode;
                tenantInfo.State = item.State;
                tenantInfo.UserId = user.Id;
                tenantInfo.UnitId = unit.Id;
                tenantInfo.Address = item.Address;

               
                await ctx.SaveChangesAsync();
                
            }
            return true;
        }

        public void MaintenanceRequestCompleted(MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }

        public void MaintenanceRequestPaused(MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }

        public void MaintenanceRequestSubmited(MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }
    }

    /// <summary>
    /// Handles the syncronization of data between yardi and apartment apps.
    /// </summary>
    public class YardiIntegration : PropertyIntegrationAddon, IMaintenanceRequestCompletedEvent, IMaintenanceRequestPausedEvent, IMaintenanceSubmissionEvent
    {
        public override bool Filter(ApplicationUser user)
        {

            return user.Property.YardiInfo != null;
        }

        public void MaintenanceRequestCompleted(MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }

        public void MaintenanceRequestPaused(MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }

        public void MaintenanceRequestSubmited(MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }
    }


}
