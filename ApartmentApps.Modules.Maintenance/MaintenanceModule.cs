using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class MaintenanceModule : Module<MaintenanceConfig>, IMenuItemProvider, IAdminConfigurable, IFillActions, IDashboardComponentProvider
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
                menuItem.Children.Add(new MenuItemViewModel("Requests", "fa-folder", "Index", "MaitenanceRequests"));
            }
            if (UserContext.IsInRole("Maintenance") || UserContext.IsInRole("PropertyAdmin"))
            {
                menuItem.Children.Add(new MenuItemViewModel("Schedule", "fa-calendar-o", "MySchedule", "MaitenanceRequests"));
            }
            if (UserContext.IsInRole("Maintenance") || UserContext.IsInRole("PropertyAdmin"))
            {
                menuItem.Children.Add(new MenuItemViewModel("Monthly Report", "fa-area-chart", "MonthlyReport", "MaitenanceRequests"));
            }
            menuItems.Add(menuItem);
        }

        public void FillActions(List<ActionLinkModel> actions, object viewModel)
        {
            var mr = viewModel as MaintenanceRequestViewModel;
            if (mr != null)
            {
                actions.Add(new ActionLinkModel("Details", "Details", "MaitenanceRequests", new { id = mr.Id }));

                if (UserContext.IsInRole("MaintenanceSupervisor") || UserContext.IsInRole("PropertyAdmin"))
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
                actions.Add(new ActionLinkModel("Assign To", "AssignRequest", "MaitenanceRequests", new { id = mr.Id }) { IsDialog = true });
            }
        }

        public void PopulateComponents(DashboardArea area, List<ComponentViewModel> dashboardComponents)
        {
            /*
            if (!UserContext.IsInRole("Admin") && !UserContext.IsInRole("PropertyAdmin"))
                return;

            var startDate = UserContext.CurrentUser.TimeZone.Now().Subtract(new TimeSpan(30, 0, 0, 0));
            var endDate = UserContext.CurrentUser.TimeZone.Now().AddDays(1);
            var mr = Kernel.Get<IRepository<MaitenanceRequest>>();
            if (area == DashboardArea.LeftTop)
            {
                dashboardComponents.Add(new DashboardTitleViewModel($"Maintenance - {UserContext.CurrentUser.Property.Name}", null, 1));
                dashboardComponents.Add(new DashboardStatViewModel()
                {
                    Row = 1,
                    Stretch = "col-md-4",
                    Title = "New",
                    Value = WorkOrdersByRange(mr, startDate, endDate).Count(p => p.StatusId == "Submitted").ToString(),
                    Subtitle = "Last 30 Days"
                });
                dashboardComponents.Add(new DashboardStatViewModel()
                {
                    Row = 1,
                    Stretch = "col-md-4",
                    Title = "Open",
                    Value = WorkOrdersByRange(mr, startDate, endDate).Count(p => p.StatusId != "Complete").ToString(),
                    Subtitle = "Last 30 Days"
                });
                dashboardComponents.Add(new DashboardStatViewModel()
                {
                    Row = 1,
                    Stretch = "col-md-4",
                    Title = "Complete",
                    Value = WorkOrdersByRange(mr, startDate, endDate).Count(p => p.StatusId != "Complete").ToString(),
                    Subtitle = "Last 30 Days"
                });
                dashboardComponents.Add(new DashboardPieViewModel("Maintenance By User", "This Month", 3, CheckinsByRange(startDate, endDate).Where(p => p.StatusId == "Complete")
                    .GroupBy(p => p.Worker)
                    .Select(p => new DashboardPieViewModel.ChartData() { label = p.Key.FirstName + " " + p.Key.LastName, data = p.Count() })
                    .ToArray())
                {
                    Row = 1,
                    Stretch = "col-md-12",
                    Title = "Complete",

                    Subtitle = "Last 30 Days"
                });
            }
            */

        }
        private IQueryable<MaintenanceRequestCheckin> CheckinsByRange(DateTime? startDate, DateTime? endDate)
        {
            var mrc = Kernel.Get<IRepository<MaintenanceRequestCheckin>>();
            return mrc.Where(p => p.Date > startDate && p.Date < endDate);
        }

        private IQueryable<MaitenanceRequest> WorkOrdersByRange(IRepository<MaitenanceRequest> mr, DateTime? startDate, DateTime? endDate)
        {
            return mr.Where(p => p.SubmissionDate > startDate && p.SubmissionDate < endDate);
        }

    }
}