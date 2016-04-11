using System;
using System.Collections.Generic;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api
{
    public class MaintenanceService : IMaintenanceService
    {
        public PropertyContext Context { get; set; }

        private IBlobStorageService _blobStorageService;
        private readonly IUserContext _userContext;

        public MaintenanceService(IBlobStorageService blobStorageService, PropertyContext context, IUserContext userContext)
        {
            Context = context;
            _blobStorageService = blobStorageService;
            _userContext = userContext;
        }

        public int SubmitRequest( string comments, int requestTypeId, int petStatus, bool permissionToEnter, List<byte[]> images, int unitId = 0)
        {

            var maitenanceRequest = new MaitenanceRequest()
            {
                PermissionToEnter = permissionToEnter,
                PetStatus = petStatus,
                UserId = _userContext.UserId,
                User =  _userContext.CurrentUser,
                Message = comments,
                UnitId = unitId,
                MaitenanceRequestTypeId = requestTypeId,
                StatusId = "Submitted",
                SubmissionDate = _userContext.CurrentUser.TimeZone.Now(),
                GroupId = Guid.NewGuid()
            };
        
            if (maitenanceRequest.UnitId == 0)
            {
                if (_userContext.CurrentUser.Tenant?.UnitId != null)
                    maitenanceRequest.UnitId = _userContext.CurrentUser.Tenant.UnitId.Value;
            }
            if (maitenanceRequest.UnitId == 0)
                maitenanceRequest.UnitId = null;

            Context.MaitenanceRequests.Add(maitenanceRequest);
            if (images != null)
                foreach (var image in images)
                {
                    var imageKey = $"{Guid.NewGuid()}.{_userContext.CurrentUser.UserName.Replace('@', '_').Replace('.', '_')}".ToLowerInvariant();
                    var filename = _blobStorageService.UploadPhoto(image, imageKey);
                    Context.ImageReferences.Add(new ImageReference()
                    {
                        GroupId = maitenanceRequest.GroupId,
                        Url = filename,
                        ThumbnailUrl = filename
                    });
                }

            Context.SaveChanges();
            this.InvokeEvent<IMaintenanceSubmissionEvent>( _ => _.MaintenanceRequestSubmited(maitenanceRequest));

            return maitenanceRequest.Id;

        }

        public bool PauseRequest(ApplicationUser worker, int requestId, string comments, List<byte[]> images)
        {
            return Checkin(worker, requestId, comments, "Paused", images);
        }

        private bool Checkin(ApplicationUser worker, int requestId, string comments, string status, List<byte[]> photos)
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
                    Context.ImageReferences.Add(new ImageReference()
                    {
                        GroupId = checkin.GroupId,
                        Url = filename,
                        ThumbnailUrl = filename
                    });
                }
            Context.MaintenanceRequestCheckins.Add(checkin);
            Context.SaveChanges();
            var request =
                Context.MaitenanceRequests.Find(requestId);
            request.StatusId = status;
            if (status == "Complete")
            {
                request.CompletionDate = worker.TimeZone.Now();
            }
            Context.SaveChanges();
            this.InvokeEvent<IMaintenanceRequestCheckinEvent>( _ => _.MaintenanceRequestCheckin(checkin, request));

            return true;

        }

        public bool CompleteRequest(ApplicationUser worker, int requestId, string comments, List<byte[]> images)
        {
            Checkin(worker, requestId, comments, "Complete", images);
            return true;
        }


        public void StartRequest(ApplicationUser worker, int id, string comments, List<byte[]> images)
        {
            Checkin(worker, id, comments, "Started", images);
        }

        public void ScheduleRequest(ApplicationUser currentUser, int id, DateTime scheduleDate)
        {

            var mr = Context.MaitenanceRequests.Find(id);
            mr.ScheduleDate = scheduleDate;
            Context.SaveChanges();


            Checkin(currentUser, id,
                $"Schedule date set to {scheduleDate.DayOfWeek} at {scheduleDate.Hour}:{scheduleDate.Minute}", "Scheduled", null);
        }
    }
}
