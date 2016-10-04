using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class CourtesyModule : Module<CourtesyConfig>, IMenuItemProvider, IAdminConfigurable, IFillActions
    {
        public string SettingsController => "CourtesyConfig";
        public CourtesyModule(IRepository<CourtesyConfig> configRepo, IUserContext userContext, IKernel kernel) : base(kernel, configRepo, userContext)
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

        public void FillActions(List<ActionLinkModel> actions, object viewModel)
        {
            //<li><a class="btn btn-white btn-xs" href="@Url.Action("Details", "IncidentReports", new {id = item.Id})"><i class="fa fa-info"></i> Details</a></li>
            // <li><a class="btn btn-white btn-xs modal-link" href="@Url.Action("Entry", "IncidentReports", new {id = item.Id})"><i class="fa fa-edit"></i> Edit</a></li>
            var vm = viewModel as IncidentReportViewModel;
            if (vm != null)
            {
                actions.Add(new ActionLinkModel("Details", "Details", "IncidentReports", new { id = vm.Id }));
                actions.Add(new ActionLinkModel("Edit", "Entry", "IncidentReports", new { id = vm.Id })
                {
                    IsDialog = true
                });
            }
            
        }
    }
}