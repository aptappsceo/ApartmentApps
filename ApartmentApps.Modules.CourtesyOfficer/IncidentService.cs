//using System.Linq;
//using ApartmentApps.Api.BindingModels;
//using ApartmentApps.Api.ViewModels;
//using ApartmentApps.Data;
//using ApartmentApps.Data.Repository;
//using ApartmentApps.Portal.Controllers;
//using ApartmentApps.Modules.CourtesyOfficer;
//namespace ApartmentApps.Api
//{
//    public class IncidentService : StandardCrudService<IncidentReport, IncidentReportViewModel>
//    {

//        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
//        public PropertyContext Context { get; set; }

//        private IBlobStorageService _blobStorageService;
//        private readonly IUserContext _userContext;

//        public IncidentService(IMapper<ApplicationUser, UserBindingModel> userMapper, IBlobStorageService blobStorageService, PropertyContext context, IUserContext userContext) : base(context.IncidentReports)
//        {
//            UserMapper = userMapper;
//            Context = context;
//            _blobStorageService = blobStorageService;
//            _userContext = userContext;
//        }

//        public IncidentService(IRepository<IncidentReport> repository, IMapper<IncidentReport, IncidentReportViewModel> mapper) : base(repository, mapper)
//        {
//        }

//        public override void ToModel(IncidentReportViewModel viewModel, IncidentReport model)
//        {
           
//        }

//        public override void ToViewModel(IncidentReport model, IncidentReportViewModel viewModel)
//        {
//            viewModel.Title = model.IncidentType.ToString();
//            viewModel.RequestDate = model.CreatedOn;
//            viewModel.Comments = model.Comments;
//            viewModel.SubmissionBy = UserMapper.ToViewModel(model.User);
//            viewModel.StatusId = model.StatusId;
//            viewModel.Id = model.Id.ToString();
//            viewModel.UnitName = model.Unit?.Name;
//            viewModel.BuildingName = model.Unit?.Building?.Name;

//            viewModel.LatestCheckin = model.LatestCheckin?.ToIncidentCheckinBindingModel(_blobStorageService);
//            viewModel.Checkins = model.Checkins.Select(p => ApartmentApps.Modules.CourtesyOfficer.ModelExtensions.ToIncidentCheckinBindingModel(p, _blobStorageService));
//        }
//    }
//}