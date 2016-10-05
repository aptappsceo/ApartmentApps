using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class MaintenanceModule : Module<MaintenanceConfig>, IMenuItemProvider, IAdminConfigurable, IFillActions
    {
        public string SettingsController => "MaintenanceConfig";
        public MaintenanceModule(IRepository<MaintenanceConfig> configRepo, IUserContext userContext, IKernel kernel) : base(kernel, configRepo, userContext)
        {
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {

            var menuItem = new MenuItemViewModel("Maintenance", "fa-briefcase");
            menuItem.Children.Add(new MenuItemViewModel("New Request", "fa-plus-square", "NewRequest", "MaitenanceRequests"));
            if (UserContext.IsInRole("Maintenance") || UserContext.IsInRole("PropertyAdmin"))
            {
                menuItem.Children.Add(new MenuItemViewModel("Requests","fa-folder","Index","MaitenanceRequests"));
            }
            if (UserContext.IsInRole("Maintenance") || UserContext.IsInRole("PropertyAdmin"))
            {
                menuItem.Children.Add(new MenuItemViewModel("Schedule", "fa-folder", "MySchedule", "MaitenanceRequests"));
            }
            if (UserContext.IsInRole("Maintenance") || UserContext.IsInRole("PropertyAdmin"))
            {
                menuItem.Children.Add(new MenuItemViewModel("Monthly Report", "fa-folder", "MonthlyReport", "MaitenanceRequests"));
            }
            menuItems.Add(menuItem);
        }

        public void FillActions(List<ActionLinkModel> actions, object viewModel)
        {
            var mr = viewModel as MaintenanceRequestViewModel;
            if (mr != null)
            {
                actions.Add(new ActionLinkModel("Details", "Details", "MaitenanceRequests", new { id = mr.Id }));
                if (UserContext.IsInRole("MaintenanceSupervisor"))
                {
                    actions.Add(new ActionLinkModel("Edit", "Entry", "MaitenanceRequests", new { id = mr.Id })
                    {
                        IsDialog = true
                    });
                }
            }
            // If its actions for a maintenance request
            if (mr != null && Config.SupervisorMode) // Only allow maintenance assigning when in supervisor mode
            {
                actions.Add(new ActionLinkModel("Assign To", "AssignRequest", "MaitenanceRequests",new {id=mr.Id}));
            }
        }
    }
}