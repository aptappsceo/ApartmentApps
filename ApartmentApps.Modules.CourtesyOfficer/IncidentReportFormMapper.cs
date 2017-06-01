using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class IncidentReportFormMapper : BaseMapper<IncidentReport, IncidentReportFormModel>
    {
        private readonly IBlobStorageService _blobStorageService;
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }

        public IncidentReportFormMapper(IMapper<ApplicationUser, UserBindingModel> userMapper,
            IBlobStorageService blobStorageService, IUserContext userContext, IModuleHelper helper) : base(userContext, helper)
        {
            _blobStorageService = blobStorageService;
            UserMapper = userMapper;
        }

        public override void ToModel(IncidentReportFormModel viewModel, IncidentReport model)
        {
            model.Comments = viewModel.Comments;
            model.IncidentType = viewModel.ReportType;
            model.UnitId = viewModel.UnitId;
        }

        public override void ToViewModel(IncidentReport model, IncidentReportFormModel viewModel)
        {
            viewModel.Comments = model.Comments;
            viewModel.ReportType = model.IncidentType;
            viewModel.UnitId = model.UnitId ?? 0;
            viewModel.Id = model.Id.ToString();

        }
    }
}