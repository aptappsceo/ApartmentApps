using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class MaintenanceService : IMaintenanceService
    {

        private IBlobStorageService _blobStorageService;

        public MaintenanceService(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        public int SubmitRequest(ApplicationUser user, string comments, int requestTypeId, int petStatus, bool permissionToEnter, List<byte[]> images, int unitId = 0)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var maitenanceRequest = new MaitenanceRequest()
                {
                    PermissionToEnter =  permissionToEnter,
                    PetStatus = petStatus,
                    UserId = user.Id,
                    Message = comments,
                    UnitId = unitId,
                    MaitenanceRequestTypeId = requestTypeId,
                    StatusId = "Submitted",
                    SubmissionDate = user.TimeZone.Now(),
                    GroupId = Guid.NewGuid()
                };
                var localCtxUser = ctx.Users.Find(user.Id);
                if (maitenanceRequest.UnitId == 0)
                {
                    if (user.Tenant?.UnitId != null)
                        maitenanceRequest.UnitId = user.Tenant.UnitId.Value;
                }
                if (maitenanceRequest.UnitId == 0)
                    maitenanceRequest.UnitId = null;

                ctx.MaitenanceRequests.Add(maitenanceRequest);

                foreach (var image in images)
                {
                    var imageKey = $"{Guid.NewGuid()}.{user.UserName.Replace('@', '_').Replace('.', '_')}".ToLowerInvariant();
                    var filename = _blobStorageService.UploadPhoto(image, imageKey);
                    ctx.ImageReferences.Add(new ImageReference()
                    {
                        GroupId = maitenanceRequest.GroupId,
                        Url = filename,
                        ThumbnailUrl = filename
                    });
                }

                ctx.SaveChanges();
                this.InvokeEvent<IMaintenanceSubmissionEvent>(ctx, localCtxUser, _ => _.MaintenanceRequestSubmited(maitenanceRequest));
                return maitenanceRequest.Id;
            }
        }

        public bool PauseRequest(ApplicationUser worker, int requestId, string comments, List<byte[]> images)
        {
            return Checkin(worker, requestId, comments, "Paused",images);
        }

        private bool Checkin(ApplicationUser worker, int requestId, string comments, string status, List<byte[]> photos)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var checkin = new MaintenanceRequestCheckin
                {
                    MaitenanceRequestId = requestId,
                    Comments = comments,
                    StatusId = status,
                    WorkerId = worker.Id,
                    Date = worker.TimeZone.Now(),
                    GroupId = Guid.NewGuid()
                };
                if (photos != null)
                foreach (var image in photos)
                {
                    var imageKey = $"{Guid.NewGuid()}.{worker.UserName.Replace('@', '_').Replace('.', '_')}".ToLowerInvariant();
                    var filename = _blobStorageService.UploadPhoto(image, imageKey);
                    ctx.ImageReferences.Add(new ImageReference()
                    {
                        GroupId = checkin.GroupId,
                        Url = filename,
                        ThumbnailUrl = filename
                    });
                }
                ctx.MaintenanceRequestCheckins.Add(checkin);
                ctx.SaveChanges();
                var request = 
                    ctx.MaitenanceRequests.Find(requestId);
                request.StatusId = status;
                if (status == "Complete")
                {
                    request.CompletionDate = worker.TimeZone.Now();
                }
                ctx.SaveChanges();
                this.InvokeEvent<IMaintenanceRequestCheckinEvent>(ctx, worker, _ => _.MaintenanceRequestCheckin(checkin, request));
                return true;
            }
        }

        public bool CompleteRequest(ApplicationUser worker, int requestId, string comments, List<byte[]> images)
        {
            Checkin(worker, requestId, comments, "Complete",images);
            return true;
        }

     
        public void StartRequest(ApplicationUser worker, int id, string comments, List<byte[]> images)
        {
            Checkin(worker, id, comments, "Started",images);
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
                $"Schedule date set to {scheduleDate.DayOfWeek} at {scheduleDate.Hour}:{scheduleDate.Minute}", "Scheduled", null);
        }
    }

    public static class DateTimeUtil
    {
        public static DateTime Now(this TimeZoneInfo zone, DateTime time)
        {
            return TimeZoneInfo.ConvertTime(time, zone);
        }
        public static DateTime Now(this TimeZoneInfo zone)
        {
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, zone );
        }
    }
}
