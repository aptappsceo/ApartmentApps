using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api
{

    public class IncidentService : StandardCrudService<IncidentReport, IncidentReportViewModel>
    {

        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
        public PropertyContext Context { get; set; }

        private IBlobStorageService _blobStorageService;
        private readonly IUserContext _userContext;

        public IncidentService(IMapper<ApplicationUser, UserBindingModel> userMapper, IBlobStorageService blobStorageService, PropertyContext context, IUserContext userContext) : base(context.IncidentReports)
        {
            UserMapper = userMapper;
            Context = context;
            _blobStorageService = blobStorageService;
            _userContext = userContext;
        }

        public IncidentService(IRepository<IncidentReport> repository, IMapper<IncidentReport, IncidentReportViewModel> mapper) : base(repository, mapper)
        {
        }

        public override void ToModel(IncidentReportViewModel viewModel, IncidentReport model)
        {
           
        }

        public override void ToViewModel(IncidentReport model, IncidentReportViewModel viewModel)
        {
            viewModel.Title = model.IncidentType.ToString();
            viewModel.RequestDate = model.CreatedOn;
            viewModel.Comments = model.Comments;
            viewModel.SubmissionBy = UserMapper.ToViewModel(model.User);
            viewModel.StatusId = model.StatusId;
            viewModel.Id = model.Id.ToString();
            viewModel.UnitName = model.Unit?.Name;
            viewModel.BuildingName = model.Unit?.Building?.Name;

            viewModel.LatestCheckin = model.LatestCheckin?.ToIncidentCheckinBindingModel(_blobStorageService);
            viewModel.Checkins = model.Checkins.Select(p => p.ToIncidentCheckinBindingModel(_blobStorageService));
        }
    }
   
    public class MaintenanceService : StandardCrudService<MaitenanceRequest, MaintenanceRequestViewModel> ,IMaintenanceService
    {
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
            viewModel.StatusId = model.StatusId;
            viewModel.Id = model.Id.ToString();
            viewModel.UnitName = model.Unit?.Name;
            viewModel.BuildingName = model.Unit?.Building?.Name;
            viewModel.PermissionToEnter = model.PermissionToEnter;
            viewModel.PetStatus = model.PetStatus;
            viewModel.HasPet = model.PetStatus > 1;
            viewModel.StartDate = model.Checkins.FirstOrDefault(p => p.StatusId == "Started")?.Date;
            viewModel.CompleteDate = model.Checkins.FirstOrDefault(p => p.StatusId == "Complete")?.Date;

            viewModel.LatestCheckin = model.LatestCheckin?.ToMaintenanceCheckinBindingModel(_blobStorageService);
            viewModel.Checkins = model.Checkins.Select(p => p.ToMaintenanceCheckinBindingModel(_blobStorageService));
            //if (viewModel.LatestCheckin != null)
            //{
            //    viewModel.MainImage = model.Message.T
            //} 
        }

        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
        public PropertyContext Context { get; set; }

        private IBlobStorageService _blobStorageService;
        private readonly IUserContext _userContext;

        public MaintenanceService(IMapper<ApplicationUser, UserBindingModel> userMapper,IBlobStorageService blobStorageService, PropertyContext context, IUserContext userContext) : base(context.MaitenanceRequests)
        {
            UserMapper = userMapper;
            Context = context;
            _blobStorageService = blobStorageService;
            _userContext = userContext;
        }

        public IEnumerable<MaintenanceRequestViewModel> GetAppointments()
        {
            var tz = _userContext.CurrentUser.TimeZone.Now().Subtract(new TimeSpan(15,0,0,0));
            return
                Context.MaitenanceRequests.Where(p => p.ScheduleDate != null).ToArray()
                    .Select(ToViewModel);
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

            this.InvokeEvent<IMaintenanceSubmissionEvent>( _ => _.MaintenanceRequestSubmited(maitenanceRequest));

            return maitenanceRequest.Id;

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
                $"Schedule date set to {scheduleDate.ToString("g",CultureInfo.GetCultureInfo("en-US"))}", "Scheduled", null);
        }
    }
}
