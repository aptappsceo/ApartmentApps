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
                    UnitId = unitId,
                    MaitenanceRequestTypeId = requestTypeId,
                    StatusId = "Submitted"
                };
                var localCtxUser = ctx.Users.Find(user.Id);
                if (maitenanceRequest.UnitId == 0)
                {
                    if (user.Tenant?.UnitId != null)
                        maitenanceRequest.UnitId = user.Tenant.UnitId.Value;
                }
                if (maitenanceRequest.UnitId == 0)
                    maitenanceRequest.UnitId = null;
                //if (maitenanceRequest.UnitId == 0)
                //    throw new Exception("Unit Id Required.");

                ctx.MaitenanceRequests.Add(maitenanceRequest);
                ctx.SaveChanges();
                this.InvokeEvent<IMaintenanceSubmissionEvent>(ctx, localCtxUser, _ => _.MaintenanceRequestSubmited(maitenanceRequest));
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
                ctx.MaintenanceRequestCheckins.Add(checkin);
                ctx.SaveChanges();
                var request = 
                    ctx.MaitenanceRequests.Find(requestId);
                request.StatusId = status;
              
                ctx.SaveChanges();
                this.InvokeEvent<IMaintenanceRequestCheckinEvent>(ctx, worker, _ => _.MaintenanceRequestCheckin(checkin, request));
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

        public void ScheduleRequest(ApplicationUser currentUser, int id, DateTime scheduleDate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var mr = ctx.MaitenanceRequests.Find(id);
                mr.ScheduleDate = scheduleDate;
                ctx.SaveChanges();
            }
            Checkin(currentUser, id,
                $"Schedule date set to {scheduleDate.DayOfWeek} at {scheduleDate.Hour}:{scheduleDate.Minute}", "Scheduled");
        }
    }
}
