using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class MaintenanceService : IMaintenanceService
    {
        public int SubmitRequest(ApplicationUser user, string comments, int requestTypeId, int unitId = 0)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var maitenanceRequest = new MaitenanceRequest()
                {
                    UserId = user.Id,
                    Message = comments,
                    MaitenanceRequestTypeId = requestTypeId,
                    StatusId = "Started"
                };
                ctx.MaitenanceRequests.Add(maitenanceRequest);
                ctx.SaveChanges();
                this.InvokeEvent<IMaintenanceSubmissionEvent>(ctx, user, _ => _.MaintenanceRequestSubmited(maitenanceRequest));
                return maitenanceRequest.Id;
            }
        }

        public bool PauseRequest(ApplicationUser worker, int requestId, string comments, List<byte[]> images)
        {
            return Checkin(worker, requestId, comments, "Paused");
        }

        private bool Checkin(ApplicationUser worker, int requestId, string comments, string status)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var checkin = new MaintenanceRequestCheckin
                {
                    MaitenanceRequestId = requestId,
                    Comments = comments,
                    StatusId = status,
                    WorkerId = worker.Id,
                    Date = DateTime.UtcNow,
                };
                
                ctx.SaveChanges();
                checkin.MaitenanceRequest.StatusId = status;
                ctx.SaveChanges();
                this.InvokeEvent<IMaintenanceRequestCheckinEvent>(ctx, worker, _ => _.MaintenanceRequestCheckin(checkin));
                return true;
            }
        }

        public bool CompleteRequest(ApplicationUser worker, int requestId, string comments)
        {
            Checkin(worker, requestId, comments, "Complete");
            return true;
        }

     
        public void StartRequest(ApplicationUser worker, int id, string comments, List<byte[]> images)
        {
            Checkin(worker, id, comments, "Started");
        }
    }
}