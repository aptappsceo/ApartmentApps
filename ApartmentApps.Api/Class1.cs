using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.API.Service.Models;
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


        public static void InvokeEvent<TEventInterface>(ApplicationDbContext ctx, ApplicationUser user, Action<TEventInterface> evt ) where TEventInterface : class
        {
            InvokeEvent<TEventInterface>(null, ctx, user, evt);
        }

        public static void InvokeEvent<TEventInterface>(this IService service, ApplicationDbContext ctx, ApplicationUser user, Action<TEventInterface> evt ) where TEventInterface : class
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
        int SubmitRequest(ApplicationUser user, string comments, int requestTypeId);
    }

    public class MaintenanceService : IMaintenanceService
    {
        public int SubmitRequest(ApplicationUser user, string comments, int requestTypeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var maitenanceRequest = new MaitenanceRequest()
                {
                    UserId = user.Id,
                    WorkerId = null,
                    Date = DateTime.UtcNow,
                    Message = comments,
                    MaitenanceRequestTypeId = requestTypeId
                };
                ctx.MaitenanceRequests.Add(maitenanceRequest);
                ctx.SaveChanges();
                this.InvokeEvent<IMaintenanceSubmissionEvent>(ctx, user, _=>_.MaintenanceRequestSubmited(maitenanceRequest));
                return maitenanceRequest.Id;
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

    public interface IAddonFilter
    {
        bool Filter(ApplicationUser user);
    }

    public class PropertyIntegrationAddon : IService, IApartmentAppsAddon, IAddonFilter
    {
        public string PropertyAddonName { get; set; }

        public bool Filter(ApplicationUser user)
        {
            return user.Tenant.Property.PropertyAddons.Any(p=>p.AddonType.Name == PropertyAddonName);
        }
    }

    

}
