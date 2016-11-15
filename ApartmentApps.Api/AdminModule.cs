using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public interface IDashboardComponentProvider
    {
        void PopulateComponents(List<DashboardComponentViewModel> dashboardComponents);
    }

    public enum DashboardComponentPosition
    {
        Left,
        Center,
        Right
    }

    public class DashboardStatViewModel : DashboardComponentViewModel
    {
        public string Subtitle { get; set; }
        public string Value { get; set; }
    }
    public class DashboardComponentViewModel : BaseViewModel
    {
        public string Col { get; set; }
        public string Stretch { get; set; }
        public int Row { get; set; }
    }

    public class AdminModule : Module<PortalConfig>, IMenuItemProvider, IFillActions, IDashboardComponentProvider
    {

        public void PopulateComponents(List<DashboardComponentViewModel> dashboardComponents)
        {
            
        }

        public override PortalConfig Config => new PortalConfig()
        {
            Enabled = true,
            PropertyId = UserContext.PropertyId,
            Id = 0
        };

        public AdminModule(IKernel kernel, IUserContext userContext) : base(kernel, null, userContext)
        {
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            if (UserContext.IsInRole("PropertyAdmin"))
            {
                var checkins = new MenuItemViewModel("Settings", "fa-cog", 30);

                checkins.Children.Add(new MenuItemViewModel("Users", "fa-user", "Index", "UserManagement"));
                checkins.Children.Add(new MenuItemViewModel("Courtesy Locations", "fa-location-arrow", "Index",
                    "CourtesyOfficerLocations"));
                checkins.Children.Add(new MenuItemViewModel("Buildings", "fa-building", "Index", "Buildings"));
                checkins.Children.Add(new MenuItemViewModel("Units", "fa-bed", "Index", "Units"));
                menuItems.Add(checkins);
            }
            if (UserContext.IsInRole("Admin"))
            {


                var checkins = new MenuItemViewModel("AA Admin", "fa-heartbeat") {Index = Int32.MaxValue};
                foreach (var module in Kernel.GetAll<IModule>().OfType<IAdminConfigurable>())
                {
                    checkins.Children.Add(new MenuItemViewModel(module.Name, "fa-gear", "Index",
                        module.SettingsController));
                }

                checkins.Children.Add(new MenuItemViewModel("Corporations", "fa-suitcase", "Index", "Corporations"));
                checkins.Children.Add(new MenuItemViewModel("Properties", "fa-cubes", "Index", "Property"));
                checkins.Children.Add(new MenuItemViewModel("Entrata Accounts", "fa-group", "Index",
                    "PropertyEntrataInfo"));
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
                actions.Add(new ActionLinkModel("Archive", "Delete", "UserManagement", new {id = vm.Id})
                {
                    Icon = "fa-remove"
                });
                actions.Add(new ActionLinkModel("Edit", "Entry", "UserManagement", new {id = vm.Id})
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });

                if (vm.Archived)
                {
                    actions.Add(new ActionLinkModel("Unarchive", "Unarchive", "UserManagement", new { id = vm.Id })
                    {
                        
                    });
                }
            }

            if (!UserContext.IsInRole("Admin")) return;

            var unitViewModel = viewModel as UnitViewModel;
            if (unitViewModel != null)
            {
                actions.Add(new ActionLinkModel("Delete", "Delete", "Units", new {id = unitViewModel.Id})
                {
                    Icon = "fa-remove",
                });
                actions.Add(new ActionLinkModel("Edit", "Entry", "Units", new {id = unitViewModel.Id})
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });
            }
            var buildingViewModel = viewModel as BuildingViewModel;
            if (buildingViewModel != null)
            {
                actions.Add(new ActionLinkModel("Delete", "Delete", "Buildings", new {id = buildingViewModel.Id})
                {
                    Icon = "fa-remove",
                });
                actions.Add(new ActionLinkModel("Edit", "Entry", "Buildings", new {id = buildingViewModel.Id})
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });
            }
            var propertyViewModel = viewModel as PropertyBindingModel;
            if (propertyViewModel != null)
            {

                //actions.Add(new ActionLinkModel("Delete", "Delete", "Property", new { id = vm.Id }));
                actions.Add(new ActionLinkModel("Edit", "Entry", "Property", new {id = propertyViewModel.Id})
                {
                    Icon = "fa-edit",
                    IsDialog = true
                });

                actions.Add(new ActionLinkModel("Switch To Property", "ChangeProperty", "Account",
                    new {id = propertyViewModel.Id})
                {
                    Icon = "fa-sign-in",
                });
              actions.Add(new ActionLinkModel("Import Residents/Units", "ImportResidentCSV", "Property", new { propertyId = propertyViewModel.Id }));

            }
        }
    }
}