using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Prospect;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class SettingsModel
    {
        public string TimeZone { get; set; }


    }

    //    [RoutePrefix("PropertySettings")]
    //    public class PropertySettings : AAController
    //    {
    //        public PropertySettings(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
    //        {
    //        }

    ////        [Route("{moduleType}")]
    //        public ActionResult Index()
    //        {
    //            ViewBag.ActiveModule = Modules.FirstOrDefault();
    //            return View(Modules);
    //        }
    //    }
    public class SettingsController<T> : AAController where T : class, new()
    {
        private readonly ConfigProvider<T> _configProvider;

        public SettingsController(ConfigProvider<T> configProvider, IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            _configProvider = configProvider;
        }

        public ActionResult Index()
        {
            //ViewBag.ActiveModule = Modules.First();
            return AutoForm(_configProvider.Config, "SaveSettings", _configProvider.ConfigType.Name);
        }

        public ActionResult SaveSettings(T config)
        {
            if (ModelState.IsValid)
            {
                var propertyEntity = config as IPropertyEntity;
                if (propertyEntity != null)
                {
                    propertyEntity.PropertyId = UserContext.PropertyId;
                }
                var userEntity = config as IUserEntity;
                if (userEntity != null)
                {
                    userEntity.UserId = UserContext.UserId;
                }
                
                Context.Entry(config);
                Context.SaveChanges();
                ViewBag.SuccessMessage = "Settings Saved";
                return RedirectToAction("Index");
            }
            return AutoForm(_configProvider.Config, "SaveSettings", _configProvider.ConfigType.Name);
        }
    }

    [Authorize]
    public class UserAlertsConfigController : SettingsController<UserAlertsConfig>
    {
        public UserAlertsConfigController( ConfigProvider<UserAlertsConfig> configProvider, IKernel kernel, PropertyContext context, IUserContext userContext) : base( configProvider, kernel, context, userContext)
        {
        }
    }
    [Authorize(Roles="Admin")]
    public class PaymentsConfigController : SettingsController<PaymentsConfig>
    {
        public PaymentsConfigController(IRepository<PaymentsConfig> configRepo, ConfigProvider<PaymentsConfig> configProvider, IKernel kernel, PropertyContext context, IUserContext userContext) : base( configProvider, kernel, context, userContext)
        {
        }
    }
    [Authorize(Roles = "Admin")]
    public class CourtesyConfigController : SettingsController<CourtesyConfig>
    {
        public CourtesyConfigController(IRepository<CourtesyConfig> configRepo, ConfigProvider<CourtesyConfig> configProvider, IKernel kernel, PropertyContext context, IUserContext userContext) : base( configProvider, kernel, context, userContext)
        {
        }
    }
    [Authorize(Roles = "Admin")]
    public class ProspectConfigController : SettingsController<ProspectModuleConfig>
    {
        public ProspectConfigController(IRepository<ProspectModuleConfig> configRepo, ConfigProvider<ProspectModuleConfig> configProvider, IKernel kernel, PropertyContext context, IUserContext userContext) : base( configProvider, kernel, context, userContext)
        {
        }
    }
    [Authorize(Roles = "Admin")]
    public class MarketingConfigController : SettingsController<MarketingModuleConfig>
    {
        public MarketingConfigController(IRepository<MarketingModuleConfig> configRepo, ConfigProvider<MarketingModuleConfig> configProvider, IKernel kernel, PropertyContext context, IUserContext userContext) : base(configProvider, kernel, context, userContext)
        {
        }
    }
    [Authorize(Roles = "Admin")]
    public class MaintenanceConfigController : SettingsController<MaintenanceConfig>
    {
        public MaintenanceConfigController(IRepository<MaintenanceConfig> configRepo, ConfigProvider<MaintenanceConfig> configProvider, IKernel kernel, PropertyContext context, IUserContext userContext) : base( configProvider, kernel, context, userContext)
        {
        }
    }
    [Authorize(Roles = "Admin")]
    public class MessagingConfigController : SettingsController<MessagingConfig>
    {
        public MessagingConfigController(IRepository<MessagingConfig> configRepo, ConfigProvider<MessagingConfig> configProvider, IKernel kernel, PropertyContext context, IUserContext userContext) : base( configProvider, kernel, context, userContext)
        {
        }
    }
    [Authorize(Roles = "Admin")]
    public class CompanySettingsConfigController : SettingsController<CompanySettingsConfig>
    {
        public CompanySettingsConfigController(IRepository<CompanySettingsConfig> configRepo, ConfigProvider<CompanySettingsConfig> configProvider, IKernel kernel, PropertyContext context, IUserContext userContext) : base( configProvider, kernel, context, userContext)
        {
        }
    }
}