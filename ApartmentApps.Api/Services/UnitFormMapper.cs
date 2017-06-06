using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;

namespace ApartmentApps.Portal.Controllers
{
    public class UnitFormMapper : BaseMapper<Unit, UnitFormModel>
    {
        public UnitFormMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(UnitFormModel viewModel, Unit model)
        {
            model.Name = viewModel.Name;
            model.BuildingId = viewModel.BuildingId;
        }

        public override void ToViewModel(Unit model, UnitFormModel viewModel)
        {
            viewModel.Id = model.Id.ToString();
            viewModel.Name = model.Name;

            viewModel.BuildingId = model.BuildingId;

        }
    }
}