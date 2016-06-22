using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Api.Modules
{
 
    public class PortalConfig : ModuleConfig
    {
    
    }

    public class AdminModule : Module<PortalConfig>, IMenuItemProvider
    {
        public IKernel Kernel { get; set; }


        public override PortalConfig Config => new PortalConfig()
        {
            Enabled = true,
            PropertyId = UserContext.PropertyId,
            Id = 0
        };

        public AdminModule(IKernel kernel, IUserContext userContext) : base(null, userContext)
        {
            Kernel = kernel;
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            if (UserContext.IsInRole("PropertyAdmin"))
            {

                var checkins = new MenuItemViewModel("Settings", "fa-cog", 30);
                checkins.Children.Add(new MenuItemViewModel("Buildings", "fa-building", "Index", "Buildings"));
                checkins.Children.Add(new MenuItemViewModel("Units", "fa-bed", "Index", "Units"));
                checkins.Children.Add(new MenuItemViewModel("Users", "fa-user", "Index", "UserManagement"));
                checkins.Children.Add(new MenuItemViewModel("Courtesy Locations", "fa-location-arrow", "Index", "CourtesyOfficerLocations"));

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
    }
  
    public class PaymentsModule : Module<PaymentsConfig>, IMenuItemProvider, IAdminConfigurable
    {
        public PaymentsModule(IRepository<PaymentsConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
           // menuItems.Add(new MenuItemViewModel("Payments", "payments","Index", "Payments"));
        }

        public string SettingsController => "PaymentsConfig";
    }


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

    public interface ILogger
    {
        void Error(string str, params object[] args);
        void Warning(string str, params object[] args);
        void Info(string str, params object[] args);
    }
    public interface IWebJob
    {
        void Execute(ILogger logger);
    }

    [Persistant]
    public class LoggerSettings : ModuleConfig
    {
        
    }

    [Persistant]
    public class Log : PropertyEntity
    {
        public string Message { get; set; }
        public LogSeverity Severity { get; set; }
    }

    public enum LogSeverity
    {
        Error,
        Warning,
        Info
    }
    public class LoggerModule : Module<LoggerSettings>, ILogger
    {
        private readonly IRepository<Log> _log;

        public LoggerModule(IRepository<Log> log, IRepository<LoggerSettings> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
            _log = log;
        }

        public void Error(string str, params object[] args)
        {
             _log.Add(new Log()
            {
                Message = args != null && args.Length > 0 ? string.Format(str, args) : str,
                Severity = LogSeverity.Error
            });
            _log.Save();
        }
        public void Warning(string str, params object[] args)
        {
            _log.Add(new Log()
            {
                Message = args != null && args.Length > 0 ? string.Format(str, args) : str,
                Severity = LogSeverity.Warning
            });
            _log.Save();
        }
        public void Info(string str, params object[] args)
        {
            _log.Add(new Log()
            {
                Message = args != null && args.Length > 0 ? string.Format(str, args) : str,
                Severity = LogSeverity.Info
            });
            _log.Save();
        }
    }
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
    [Persistant]
    public class CourtesyConfig : ModuleConfig
    {
    }

    [Persistant]
    public class MaintenanceConfig : ModuleConfig
    {
    }

    [Persistant]
    public class MessagingConfig : ModuleConfig
    {
    }
}