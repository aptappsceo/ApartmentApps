using System;
using System.Linq;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
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
}