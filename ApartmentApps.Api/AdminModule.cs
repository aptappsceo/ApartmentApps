using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class AdminModule : Module<PortalConfig>, IMenuItemProvider, IFillActions
    {
        public IKernel Kernel { get; set; }


        public override PortalConfig Config => new PortalConfig()
        {
            Enabled = true,
            PropertyId = UserContext.PropertyId,
            Id = 0
        };

        public AdminModule(IKernel kernel, IUserContext userContext) : base(kernel, null, userContext)
        {
            Kernel = kernel;
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            if (UserContext.IsInRole("PropertyAdmin"))
            {

                var checkins = new MenuItemViewModel("Settings", "fa-cog", 30);

                checkins.Children.Add(new MenuItemViewModel("Users", "fa-user", "Index", "UserManagement"));
                checkins.Children.Add(new MenuItemViewModel("Courtesy Locations", "fa-location-arrow", "Index", "CourtesyOfficerLocations"));
                checkins.Children.Add(new MenuItemViewModel("Buildings", "fa-building", "Index", "Buildings"));
                checkins.Children.Add(new MenuItemViewModel("Units", "fa-bed", "Index", "Units"));
                menuItems.Add(checkins);


            }
            if (UserContext.IsInRole("Admin"))
            {

                var checkins = new MenuItemViewModel("AA Admin", "fa-heartbeat");
                foreach (var module in Kernel.GetAll<IModule>().OfType<IAdminConfigurable>())
                {
                    checkins.Children.Add(new MenuItemViewModel(module.Name, "fa-gear", "Index", module.SettingsController));
                }

                checkins.Children.Add(new MenuItemViewModel("Corporations", "fa-suitcase", "Index", "Corporations"));
                checkins.Children.Add(new MenuItemViewModel("Properties", "fa-cubes", "Index", "Property"));
                checkins.Children.Add(new MenuItemViewModel("Entrata Accounts", "fa-group", "Index", "PropertyEntrataInfo"));
                menuItems.Add(checkins);
            }
            if (UserContext.IsInRole("PropertyAdmin") || UserContext.IsInRole("Admin"))
            {
                menuItems.Add(new MenuItemViewModel("Dashboard", "fa-group", "Index", "Dashboard"));
            }



        }

        public void FillActions(List<ActionLinkModel> actions, object viewModel)
        {
            //   <a class="btn btn-white btn-xs modal-link" href="@Url.Action("Entry", "UserManagement", new {id = item.Id})"><i class="fa fa-edit"></i> Edit</a>
            //< a class="btn btn-white btn-xs" href="@Url.Action("Delete", "UserManagement", new {id = item.Id})"><i class="fa fa-remove"></i> Delete</a>
            var vm = viewModel as UserBindingModel;
            if (vm != null)
            {
                actions.Add(new ActionLinkModel("Delete", "Delete", "UserManagement", new { id = vm.Id }));
                actions.Add(new ActionLinkModel("Edit", "Entry", "UserManagement", new { id = vm.Id })
                {
                    IsDialog = true
                });
            }
            

        }
    }
}