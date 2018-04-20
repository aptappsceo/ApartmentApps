using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApartmentApps.Api.NewFolder1;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules
{
 
    public class CourtesyModule : Module<CourtesyConfig>, IMenuItemProvider, IAdminConfigurable, IFillActions, IWebJob
    {
        public string SettingsController => "CourtesyConfig";
        public CourtesyModule(IRepository<CourtesyConfig> configRepo, IUserContext userContext, IKernel kernel) : base(kernel, configRepo, userContext)
        {
        }

        protected override CourtesyConfig CreateDefaultConfig()
        {

            var def =  base.CreateDefaultConfig();
            
            return def;
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            var menuItem = new MenuItemViewModel("Incidents", "fa-shield");
            menuItem.Children.Add(new MenuItemViewModel("New Incident", "fa-plus-square", "NewRequest", "IncidentReports"));
            if (UserContext.IsInRole("PropertyAdmin"))
            {
                menuItem.Children.Add(new MenuItemViewModel("Incidents", "fa-folder", "Index", "IncidentReports"));
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

        public void Execute(ILogger logger)
        {
            // Schedule the all morning emails.
            SendEmail();
        }

        public void SendEmail(DateTime? d = null)
        {
            EmailQueuer queuer = Kernel.Get<EmailQueuer>();
            UserService service = Kernel.Get<UserService>();
            var courtesyOfficerService = Kernel.Get<CourtesyOfficerService>();
            var propertyAdmins = service.GetUsersInRole<UserBindingModel>("PropertyAdmin");
            var date = UserContext.Today;
            date = date.Add(new TimeSpan(1, 8, 0, 0, 0));
            date = d ?? date;

#if DEBUG
            if (propertyAdmins.Count > 0)
            {
                var propertyAdmin = propertyAdmins.First();
                queuer.QueueEmail(new DailyOfficerReport()
                {
                    ToEmail = "xasan2006@mail.ru",
                    User = propertyAdmin,
                    FromEmail = "info@apartmentapps.com",

                    Subject = $"Daily officer report for {UserContext.CurrentUser.Property.Name}",
                    Checkins = courtesyOfficerService.ForRange(UserContext.Today.Subtract(new TimeSpan(500, 0, 0, 0)), UserContext.Now)

                });
            }
#else
            foreach (var propertyAdmin in propertyAdmins)
            {
                var email = propertyAdmin.Email;
                queuer.QueueEmail(new DailyOfficerReport()
                {
                    ToEmail = email,
                    User = propertyAdmin,
                    FromEmail = "info@apartmentapps.com",                  
                    Subject = $"Daily officer report for {UserContext.CurrentUser.Property.Name}",
                    Checkins = courtesyOfficerService.ForDay(UserContext.CurrentUser.TimeZone.Today().Subtract(new TimeSpan(1, 0, 0, 0)))
  
                }, date);
            }
#endif
        }
    }
}