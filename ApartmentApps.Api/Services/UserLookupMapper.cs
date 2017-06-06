using System;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;

namespace ApartmentApps.Portal.Controllers
{
    public class UserLookupMapper : BaseMapper<ApplicationUser, UserLookupBindingModel>
    {
        public UserLookupMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(UserLookupBindingModel viewModel, ApplicationUser model)
        {
            throw new NotImplementedException();
        }

        public override void ToViewModel(ApplicationUser model, UserLookupBindingModel viewModel)
        {
            if (model == null) return;
            viewModel.Id = model.Id;
            viewModel.Title = $"{model.FirstName} {model.LastName}";
            if (model.Unit != null) viewModel.Title+=$" [ {model.Unit?.Building.Name} {model.Unit?.Name} ]";
        }
    }
}