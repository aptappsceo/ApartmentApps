using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;

namespace ApartmentApps.Portal.Controllers
{
    public class ApplicationUserLookupMapper : BaseMapper<ApplicationUser, LookupBindingModel>
    {

        public override void ToModel(LookupBindingModel viewModel, ApplicationUser model)
        {
            
        }

        public override void ToViewModel(ApplicationUser model, LookupBindingModel viewModel)
        {
            viewModel.Id = model.Id;
            viewModel.Title = $"{model.FirstName} {model.LastName}";
            viewModel.TextPrimary = model.Email;
            viewModel.TextPrimary = model.PhoneNumber;
            viewModel.ImageUrl = model.ImageUrl;
        }

        public ApplicationUserLookupMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }
    }
}