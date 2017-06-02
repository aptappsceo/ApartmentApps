using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Modules.CourtesyOfficer;

namespace ApartmentApps.Api
{
    public class IncidentReportMapper : BaseMapper<IncidentReport, IncidentReportViewModel>
    {
        private readonly IBlobStorageService _blobStorageService;
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }

        public IncidentReportMapper(IMapper<ApplicationUser, UserBindingModel> userMapper,
            IBlobStorageService blobStorageService, IUserContext userContext, IModuleHelper helper) : base(userContext, helper)
        {
            _blobStorageService = blobStorageService;
            UserMapper = userMapper;
        }

        public override void ToModel(IncidentReportViewModel viewModel, IncidentReport model)
        {
            model.Comments = viewModel.Comments;
            model.StatusId = viewModel.StatusId;
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
            viewModel.Checkins = model.Checkins.Select(p => ModelExtensions.ToIncidentCheckinBindingModel(p, _blobStorageService));
            //viewModel.Title = x.IncidentType.ToString();
            //viewModel.Comments = x.Comments;
            //viewModel.UnitName = x.Unit?.Name;
            //viewModel.BuildingName = x.Unit?.Building?.Name;
            //viewModel.RequestDate = x.CreatedOn;
            //viewModel.SubmissionBy = _userMapper.ToViewModel(x.User);// x.User.ToUserBindingModel(BlobStorageService);
            //viewModel.StatusId = x.StatusId;
            //viewModel.LatestCheckin = x.LatestCheckin?.ToIncidentCheckinBindingModel(_blobStorageService);
            viewModel.Id = model.Id.ToString();

        }
    }
}