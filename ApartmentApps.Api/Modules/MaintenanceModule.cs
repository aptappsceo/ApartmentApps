using System.Collections.Generic;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api.Modules
{
    public class MaintenanceModule : Module<MaintenanceConfig>, IMenuItemProvider, IAdminConfigurable
    {
        public string SettingsController => "MaintenanceConfig";
        public MaintenanceModule(IRepository<MaintenanceConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {

            var menuItem = new MenuItemViewModel("Maintenance", "fa-briefcase");
            menuItem.Children.Add(new MenuItemViewModel("New Request", "fa-plus-square", "NewRequest", "MaitenanceRequests"));
            if (UserContext.IsInRole("PropertyAdmin"))
            {
                menuItem.Children.Add(new MenuItemViewModel("Requests","fa-folder","Index","MaitenanceRequests"));
            }
            if (UserContext.IsInRole("Maintenance") || UserContext.IsInRole("PropertyAdmin"))
            {
                menuItem.Children.Add(new MenuItemViewModel("Schedule", "fa-folder", "MySchedule", "MaitenanceRequests"));
            }
            menuItems.Add(menuItem);
        }
    }
}