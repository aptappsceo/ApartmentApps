using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;

namespace ApartmentApps.Portal.Controllers
{
    public class PropertyMapper : BaseMapper<Property, PropertyFormBindingModel>
    {
        public PropertyMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(PropertyFormBindingModel viewModel, Property model)
        {
            model.Name = viewModel.Name;
            model.CorporationId = viewModel.CorporationId;
            model.State = viewModel.State;
        }

        public override void ToViewModel(Property model, PropertyFormBindingModel viewModel)
        {
            viewModel.Name = model.Name;
            viewModel.Id = model.Id.ToString();
            viewModel.State = model.State;
            viewModel.CorporationId = model.CorporationId;
        }
    }
}