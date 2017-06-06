using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;

namespace ApartmentApps.Portal.Controllers
{
    public class UserListMapper : BaseMapper<ApplicationUser, UserListModel>
    {
        public UserListMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(UserListModel viewModel, ApplicationUser model)
        {


        }

        public override void ToViewModel(ApplicationUser user, UserListModel viewModel)
        {
            if (user == null) return;
            viewModel.Id = user.Id;
        
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
         
            viewModel.UnitName = user.Unit?.Name;
            viewModel.BuildingName = user.Unit?.Building.Name;
        
            viewModel.PhoneNumber = user.PhoneNumber;
            viewModel.Email = user.Email;
        }
    }
}