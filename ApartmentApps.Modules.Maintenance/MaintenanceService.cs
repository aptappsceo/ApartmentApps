using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Maintenance;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api
{
    public class MaintenanceRequestMapper : BaseMapper<MaitenanceRequest, MaintenanceRequestViewModel>
    {
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
        public IBlobStorageService BlobStorageService { get; set; }

        public MaintenanceRequestMapper(IMapper<ApplicationUser, UserBindingModel> userMapper,
            IBlobStorageService blobStorageService)
        {
            UserMapper = userMapper;
            BlobStorageService = blobStorageService;
        }

        public override void ToModel(MaintenanceRequestViewModel viewModel, MaitenanceRequest model)
        {

        }

        public override void ToViewModel(MaitenanceRequest model, MaintenanceRequestViewModel viewModel)
        {
            viewModel.Title = model.MaitenanceRequestType.Name;
            viewModel.RequestDate = model.SubmissionDate;
            viewModel.ScheduleDate = model.ScheduleDate;
            if (model.ScheduleDate != null)
                viewModel.EndDate = model.ScheduleDate.Value.Add(new TimeSpan(0, 0, 30, 0));
            viewModel.Comments = model.Message;
            viewModel.SubmissionBy = UserMapper.ToViewModel(model.User);
            if (model.LatestCheckin != null && model.LatestCheckin.StatusId == "Complete")
            {
                var user = model.LatestCheckin.Worker;
                if (user != null)
                {
                    viewModel.CompletedBy = UserMapper.ToViewModel(user);
                }
            }
            viewModel.StatusId = model.StatusId;
            viewModel.Id = model.Id.ToString();
            viewModel.UnitName = model.Unit?.Name;
            viewModel.BuildingName = model.Unit?.Building?.Name;
            viewModel.PermissionToEnter = model.PermissionToEnter;
            viewModel.PetStatus = model.PetStatus;
            viewModel.HasPet = model.PetStatus > 1;
            viewModel.StartDate = model.Checkins.FirstOrDefault(p => p.StatusId == "Started")?.Date;
            viewModel.CompleteDate = model.Checkins.FirstOrDefault(p => p.StatusId == "Complete")?.Date;
            viewModel.AssignedToId = model.WorkerAssignedId;
            viewModel.AssignedTo = model.WorkerAssigned == null ? null : UserMapper.ToViewModel(model.WorkerAssigned);
            viewModel.LatestCheckin = model.LatestCheckin?.ToMaintenanceCheckinBindingModel(BlobStorageService);
            viewModel.Checkins = model.Checkins.Select(p => p.ToMaintenanceCheckinBindingModel(BlobStorageService));
        }

    }
    public class MaintenanceService : StandardCrudService<MaitenanceRequest, MaintenanceRequestViewModel> ,IMaintenanceService
    {
 
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
        public PropertyContext Context { get; set; }

        private IBlobStorageService _blobStorageService;
        private readonly IUserContext _userContext;

        public MaintenanceService(IRepository<MaitenanceRequest> repository, IMapper<MaitenanceRequest, MaintenanceRequestViewModel> mapper, IBlobStorageService blobStorageService, IUserContext userContext) : base(repository, mapper)
        {
            _blobStorageService = blobStorageService;
            _userContext = userContext;
        }

        public IEnumerable<MaintenanceRequestViewModel> GetAppointments()
        {
            var tz = _userContext.CurrentUser.TimeZone.Now().Subtract(new TimeSpan(15,0,0,0));
            return
                Context.MaitenanceRequests.Where(p => p.ScheduleDate != null).ToArray()
                    .Select(Mapper.ToViewModel);
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
                if (_userContext.CurrentUser?.UnitId != null)
                    maitenanceRequest.UnitId = _userContext.CurrentUser.UnitId.Value;
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

            Checkin(_userContext.CurrentUser, maitenanceRequest.Id, maitenanceRequest.Message,
                maitenanceRequest.StatusId, null, maitenanceRequest.GroupId);

            Modules.ModuleHelper.EnabledModules.Signal<IMaintenanceSubmissionEvent>( _ => _.MaintenanceRequestSubmited(maitenanceRequest));

            return maitenanceRequest.Id;

        }

        public IEnumerable<MaintenanceRequestViewModel> GetAllUnassigned()
        {
            return Repository.Where(p => p.WorkerAssignedId == null).ToArray().Select(Mapper.ToViewModel);
        }

        public void AssignRequest(string requestId, string userId)
        {
            var request = Repository.Find(requestId);
            request.WorkerAssignedId = userId;
            Repository.Save();
            Modules.ModuleHelper.EnabledModules.Signal<IMaintenanceRequestAssignedEvent>(_ => _.MaintenanceRequestAssigned(request));
             
        }
        public bool PauseRequest(ApplicationUser worker, int requestId, string comments, List<byte[]> images)
        {
            return Checkin(worker, requestId, comments, "Paused", images);
        }

        private bool Checkin(ApplicationUser worker, int requestId, string comments, string status, List<byte[]> photos, Guid? groupId = null)
        {

            var checkin = new MaintenanceRequestCheckin
            {
                MaitenanceRequestId = requestId,
                Comments = comments,
                StatusId = status,
                WorkerId = worker.Id,
               
                Date = worker.TimeZone.Now(),
                GroupId = groupId ?? Guid.NewGuid()
            };
            if (photos != null && groupId == null)
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
            Modules.ModuleHelper.EnabledModules.Signal<IMaintenanceRequestCheckinEvent>( _ => _.MaintenanceRequestCheckin(checkin, request));

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
                $"Schedule date set to {scheduleDate.ToString("g",CultureInfo.GetCultureInfo("en-US"))}", "Scheduled", null);
        }
    }
}
