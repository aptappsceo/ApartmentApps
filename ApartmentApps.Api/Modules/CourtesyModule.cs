using System.Collections.Generic;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api.Modules
{
    public class CourtesyModule : Module<CourtesyConfig>, IMenuItemProvider, IAdminConfigurable
    {
        public string SettingsController => "CourtesyConfig";
        public CourtesyModule(IRepository<CourtesyConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            var menuItem = new MenuItemViewModel("Incidents", "fa-shield");
            menuItem.Children.Add(new MenuItemViewModel("New Request", "fa-plus-square", "NewRequest", "IncidentReports"));
            if (UserContext.IsInRole("PropertyAdmin"))
            {
                menuItem.Children.Add(new MenuItemViewModel("Requests", "fa-folder", "Index", "IncidentReports"));
            }
            menuItems.Add(menuItem);
           
            if (UserContext.IsInRole("PropertyAdmin"))
            {
                var checkins = new MenuItemViewModel("Checkins", "fa-location-arrow");
                checkins.Children.Add(new MenuItemViewModel("Today", "fa-clock-o", "Index", "CourtesyOfficer"));
                checkins.Children.Add(new MenuItemViewModel("Yesterday", "fa-history", "Yesterday", "CourtesyOfficer"));
                checkins.Children.Add(new MenuItemViewModel("This Week", "fa-history", "ThisWeek", "CourtesyOfficer"));
                menuItems.Add(checkins);
            }
         
        }
    }
}