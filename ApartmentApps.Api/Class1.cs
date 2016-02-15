using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Data;
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
        int SubmitRequest(string user, string comments, int requestTypeId);
        bool PauseRequest( int requestId, string comments);
        bool CompleteRequest( int requestId, string comments);
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
                this.InvokeEvent<IMaintenanceSubmissionEvent>(ctx, ctx.Users.First(p=>p.Id == user), _=>_.MaintenanceRequestSubmited(maitenanceRequest));
                return maitenanceRequest.Id;
            }
        }

        public bool PauseRequest( int requestId, string comments)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.MaitenanceRequests.FirstOrDefault(p => p.Id == requestId);
                if (request != null)
                {
                    request.StatusId = "Paused";
                    ctx.SaveChanges();
                    this.InvokeEvent<IMaintenanceRequestPausedEvent>(ctx, request.Worker, _ => _.MaintenanceRequestPaused(requestId));
                    return true;
                }
                return false;
            }
        }

        public bool CompleteRequest( int requestId, string comments)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.MaitenanceRequests.FirstOrDefault(p => p.Id == requestId);
                if (request != null)
                {
                    request.StatusId = "Complete";
                    ctx.SaveChanges();
                    this.InvokeEvent<IMaintenanceRequestCompletedEvent>(ctx, request.Worker, _ => _.MaintenanceRequestCompleted(requestId));
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
        void MaintenanceRequestPaused(object maitenanceRequest);
    }
    public interface IMaintenanceRequestCompletedEvent
    {
        void MaintenanceRequestCompleted(object maitenanceRequest);
    }
    public interface IAddonFilter
    {
        bool Filter(ApplicationUser user);
    }

    public abstract class PropertyIntegrationAddon : IService, IApartmentAppsAddon, IAddonFilter
    {
        public abstract bool Filter(ApplicationUser user);

    }

    

}
