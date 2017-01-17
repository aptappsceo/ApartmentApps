using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Modules.Maintenance;
using ApartmentApps.Portal.Controllers;
using Korzh.EasyQuery.Db;
using Ninject;

namespace ApartmentApps.Api
{


    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(HttpActionExecutedContext context)
    {
        var exception = context.Exception as ApiException;
        if (exception != null) {
            context.Response = context.Request.CreateErrorResponse(exception.StatusCode, exception.Message);
            context.Exception = exception;
        }
    }
}

    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
 public class MaintenanceRequestEditModel : BaseViewModel
   
    {
        private readonly IRepository<Unit> _unitRepo;
        private readonly IRepository<ApplicationUser> _userRepo;
        private readonly IRepository<MaitenanceRequestType> _requestTypeRepo;


        //[DataType()]
        [DisplayName("Unit"), DisplayForRoles(Roles="Admin,PropertyAdmin,Maintenance")]
        public int UnitId { get; set; }

        public MaintenanceRequestEditModel()
        {
        }
        [Inject]
        public MaintenanceRequestEditModel(IRepository<Unit> unitRepo, IRepository<ApplicationUser> userRepo, IRepository<MaitenanceRequestType> requestTypeRepo)
        {
            _unitRepo = unitRepo;
            _userRepo = userRepo;
            _requestTypeRepo = requestTypeRepo;
        }

        public IEnumerable<FormPropertySelectItem> UnitId_Items
        {
            get
            {
                var items =
                    _unitRepo.ToArray();
                var users = _userRepo;
                return items.Select(p =>
                {
                    var name = $"[{ p.Building.Name }] {p.Name}";
                    var user = users.FirstOrDefault(x=>!x.Archived && x.UnitId == p.Id);
                    if (user != null)
                        name += $" ({user.FirstName} {user.LastName})";
                    
                    return new FormPropertySelectItem(p.Id.ToString(), name, UnitId == p.Id);
                }).OrderByAlphaNumeric(p => p.Value);

            }
        }

        public IEnumerable<FormPropertySelectItem> MaitenanceRequestTypeId_Items
        {
            get
            {
                return
                    _requestTypeRepo
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, MaitenanceRequestTypeId == p.Id));


            }
        }

        [DisplayName("Type")]
        [Required]
        public int MaitenanceRequestTypeId { get; set; }

        [DisplayName("Permission To Enter")]
        public bool PermissionToEnter { get; set; }

        [DisplayName("Pet Status")]
        public PetStatus PetStatus { get; set; }



        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }


    }
    public enum PetStatus
    {
        NoPet,
        YesContained,
        YesFree
    }

    public class MaintenanceRequestEditMapper : BaseMapper<MaitenanceRequest, MaintenanceRequestEditModel> 
    {
        public MaintenanceRequestEditMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(MaintenanceRequestEditModel editModel, MaitenanceRequest maitenanceRequest)
        {
            if (string.IsNullOrEmpty(editModel.Id))
                maitenanceRequest.SubmissionDate = DateTime.Now;

            maitenanceRequest.PetStatus = (int)editModel.PetStatus;
            maitenanceRequest.MaitenanceRequestTypeId = editModel.MaitenanceRequestTypeId;
            maitenanceRequest.PermissionToEnter = editModel.PermissionToEnter;
            maitenanceRequest.UnitId = editModel.UnitId;
            maitenanceRequest.Message = editModel.Comments;
        }

        public override void ToViewModel(MaitenanceRequest maitenanceRequest, MaintenanceRequestEditModel viewModel)
        {
            viewModel.Id = maitenanceRequest.Id.ToString();
            viewModel.MaitenanceRequestTypeId = maitenanceRequest.MaitenanceRequestTypeId;
            viewModel.PermissionToEnter = maitenanceRequest.PermissionToEnter;
            viewModel.UnitId = maitenanceRequest.UnitId ?? 0;
            viewModel.PetStatus = (PetStatus) maitenanceRequest.PetStatus;
            viewModel.Comments = maitenanceRequest.Message;
        }
    }
    public class MaintenanceRequestIndexMapper : BaseMapper<MaitenanceRequest, MaintenanceRequestIndexBindingModel>
    {
        public MaintenanceRequestIndexMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(MaintenanceRequestIndexBindingModel viewModel, MaitenanceRequest model)
        {
           
        }

        public override void ToViewModel(MaitenanceRequest model, MaintenanceRequestIndexBindingModel viewModel)
        {
            viewModel.RequestType = model.MaitenanceRequestType.Name;
        }
    }

    public class MaintenanceRequestTypeLookupMapper : BaseMapper<MaitenanceRequestType, LookupBindingModel>
    {
        public MaintenanceRequestTypeLookupMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(LookupBindingModel viewModel, MaitenanceRequestType model)
        {
            throw new NotImplementedException();
        }

        public override void ToViewModel(MaitenanceRequestType model, LookupBindingModel viewModel)
        {
            viewModel.Id = model.Id.ToString();
            viewModel.Title = model.Name;
        }
    }
    public class MaintenanceRequestStatusLookupMapper : BaseMapper<MaintenanceRequestStatus, LookupBindingModel>
    {

        public override void ToModel(LookupBindingModel viewModel, MaintenanceRequestStatus model)
        {

        }

        public override void ToViewModel(MaintenanceRequestStatus model, LookupBindingModel viewModel)
        {
            viewModel.Id = viewModel.Title = model.Name;
        }

        public MaintenanceRequestStatusLookupMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }
    }

    public class MaintenanceRequestMapper : BaseMapper<MaitenanceRequest, MaintenanceRequestViewModel>
    {

        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
        public IBlobStorageService BlobStorageService { get; set; }

        public MaintenanceRequestMapper(IUserContext userContext, IModuleHelper moduleHelper, IMapper<ApplicationUser, UserBindingModel> userMapper, IBlobStorageService blobStorageService) : base(userContext, moduleHelper)
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

            if (viewModel.AssignedToId == null && viewModel.LatestCheckin != null)
            {
                viewModel.AssignedToId = viewModel.LatestCheckin.Worker.Id;
                viewModel.AssignedTo = viewModel.LatestCheckin.Worker;

            }
            if (model.Unit?.Users != null)
            {
                viewModel.Tenants =
                    model.Unit.Users.Where(p => p.Archived == false).ToArray().Select(UserMapper.ToViewModel).ToArray();
            }

            viewModel.Checkins = model.Checkins.Select(p => p.ToMaintenanceCheckinBindingModel(BlobStorageService));
            viewModel.Description = model.Description;
          
            viewModel.AssignLink = new ActionLinkModel()
            {
                Allowed = UserContext.IsInRole("MaintenanceSupervisor"),
                Action = "AssignRequest",
                Controller = "MaitenanceRequests",
                Label = "Assign Maintenance Request",
                Parameters = new  { id= model.Id }
            };

 
        }

    }
    
    public class MaintenanceService : StandardCrudService<MaitenanceRequest> ,IMaintenanceService
    {
 
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
        public ConfigProvider<MaintenanceConfig> Config { get; }
        public PropertyContext Context { get; set; }

        private readonly IModuleHelper _moduleHelper;
        private IBlobStorageService _blobStorageService;
        private readonly IUserContext _userContext;

        public MaintenanceService(ConfigProvider<MaintenanceConfig> config, IModuleHelper moduleHelper, PropertyContext propertyContext, IRepository<MaitenanceRequest> repository, IBlobStorageService blobStorageService, IUserContext userContext, IKernel kernel) : base(kernel, repository)
        {
            _moduleHelper = moduleHelper;
            _blobStorageService = blobStorageService;
            _userContext = userContext;
            Config = config;
            Context = propertyContext;
        }

        public IEnumerable<TViewModel> GetAppointments<TViewModel>()
        {
            var tz = _userContext.CurrentUser.TimeZone.Now().Subtract(new TimeSpan(15,0,0,0));
            var mapper = _kernel.Get<IMapper<MaitenanceRequest, TViewModel>>();
            return
                Context.MaitenanceRequests.Where(p => p.ScheduleDate != null).ToArray()
                    .Select(mapper.ToViewModel);
        }

        public DbQuery Submitted()
        {
            return CreateQuery("Submitted", new ConditionItem("MaitenanceRequest.StatusId", "Equal", "Submitted"));
        }
        public DbQuery Scheduled()
        {
            return CreateQuery("Scheduled", new ConditionItem("MaitenanceRequest.StatusId", "Equal", "Scheduled"));
        }
        public DbQuery Started()
        {
            return CreateQuery("Started", new ConditionItem("MaitenanceRequest.StatusId", "Equal", "Started"));
        }
        public DbQuery Paused()
        {
            return CreateQuery("Paused", new ConditionItem("MaitenanceRequest.StatusId", "Equal", "Paused"));
        }
        public DbQuery Complete()
        {
            return CreateQuery("Complete", new ConditionItem("MaitenanceRequest.StatusId", "Equal", "Complete"), new ConditionItem("MaitenanceRequest.CompletionDate", "DateWithinThisMonth"));
        }
        public void AssignRequest(int id, string assignedToId)
        {
            var request = Repository.Find(id);
            if (request != null)
            {
                request.WorkerAssignedId = assignedToId;
                Repository.Save();
            }
        }

        public int SubmitRequest(string comments, int requestTypeId, int petStatus, bool emergrency, bool permissionToEnter, List<byte[]> images, int unitId = 0, SubmittedVia mobile = SubmittedVia.Other)
        {

            var maitenanceRequest = new MaitenanceRequest()
            {
                PermissionToEnter = permissionToEnter,
                PetStatus = petStatus,
                UserId = _userContext.UserId,
                User =  _userContext.CurrentUser,
                Message = comments,
                Emergency = emergrency,
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

            _moduleHelper.SignalToEnabled<IMaintenanceSubmissionEvent>( _ => _.MaintenanceRequestSubmited(maitenanceRequest));

            return maitenanceRequest.Id;

        }

        public override void Remove(string id)
        {
            var intId = Convert.ToInt32(id);
            RemoveAllWith<MaintenanceRequestCheckin>(x=>x.MaitenanceRequestId == intId);
            base.Remove(id);
        }

        public void RemoveAllWith<TSet>(Expression<Func<TSet, bool>> filter)
        {
            var set = Repo<TSet>();
            var items = set.Where(filter).ToArray();
            foreach (var item in items)
            {
                set.Remove(item);
                set.Save();
            }
        }
        
        public IEnumerable<TViewModel> GetAllUnassigned<TViewModel>()
        {
            return Repository.Where(p => p.WorkerAssignedId == null).ToArray().Select(Map<TViewModel>().ToViewModel);
        }

        public void AssignRequest(string requestId, string userId)
        {
            var request = Repository.Find(requestId);
            request.WorkerAssignedId = userId;
            Repository.Save();
            _moduleHelper.SignalToEnabled<IMaintenanceRequestAssignedEvent>(_ => _.MaintenanceRequestAssigned(request));
             
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
            _moduleHelper.SignalToEnabled<IMaintenanceRequestCheckinEvent>( _ => _.MaintenanceRequestCheckin(checkin, request));

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
        
        public override bool DefaultOrderByDesc => true;
    }



    public static class MaitenanceRequestProtocol
    {
        public static bool CanBeStarted(this MaitenanceRequest request)
        {
            return request.StatusId == MaintenanceRequestStatuses.Scheduled ||
                   request.StatusId == MaintenanceRequestStatuses.Submitted ||
                   request.StatusId == MaintenanceRequestStatuses.Paused;
        }
        public static bool CanBePaused(this MaitenanceRequest request)
        {
            return request.StatusId == MaintenanceRequestStatuses.Started;
        }
        public static bool CanBeComplete(this MaitenanceRequest request)
        {
            return request.StatusId == MaintenanceRequestStatuses.Started;
        }
        public static bool CanBeScheduled(this MaitenanceRequest request)
        {
            return request.StatusId == MaintenanceRequestStatuses.Submitted || request.StatusId == MaintenanceRequestStatuses.Paused;
        }

        public static bool CanControl(ApplicationUser user, MaitenanceRequest request)
        {
            return user.Roles.Any(
                    role =>
                        role.RoleId == UserRoles.Maintenance || role.RoleId == UserRoles.MaintenanceSupervisor ||
                        role.RoleId == UserRoles.PropertyAdmin || role.RoleId == UserRoles.Admin);
        }

        public static bool CanStart(this ApplicationUser user, MaitenanceRequest request)
        {
            return CanControl(user, request);
        }
        public static bool CanPause(this ApplicationUser user, MaitenanceRequest request)
        {
            return CanControl(user, request);
        }
        public static bool CanComplete(this ApplicationUser user, MaitenanceRequest request)
        {
            return CanControl(user, request);
        }
        public static bool CanSchedule(this ApplicationUser user, MaitenanceRequest request)
        {
            return CanControl(user, request);
        }
    }


}
