using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
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

    public class SettingsController<T> : AAController where T : ModuleConfig
    {
        private readonly IRepository<T> _configRepo;


        public SettingsController(IRepository<T> configRepo, IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            _configRepo = configRepo;

        }

        public ActionResult Index()
        {
            var moduleType = ModuleType;
            ViewBag.ActiveModule = Modules.First();
            return AutoForm(moduleType.ModuleConfig, "SaveSettings", moduleType.Name);

        }

        private IModule ModuleType
        {
            get { return Kernel.GetAll<IModule>().First(p => p.ConfigType == typeof(T)); }
        }

        public ActionResult SaveSettings(T config)
        {
            if (ModelState.IsValid)
            {
                config.PropertyId = UserContext.PropertyId;
                Context.Entry(config);
                Context.SaveChanges();
                ViewBag.SuccessMessage = "Settings Saved";
                return RedirectToAction("Index");
            }
            return AutoForm(ModuleType.ModuleConfig, "SaveSettings", ModuleType.Name);
        }
    }

    public class PaymentsConfigController : SettingsController<PaymentsConfig>
    {
        public PaymentsConfigController(IRepository<PaymentsConfig> configRepo, IKernel kernel, PropertyContext context, IUserContext userContext) : base(configRepo, kernel, context, userContext)
        {
        } 
    }
    public class CourtesyConfigController : SettingsController<CourtesyConfig>
    {
        public CourtesyConfigController(IRepository<CourtesyConfig> configRepo, IKernel kernel, PropertyContext context, IUserContext userContext) : base(configRepo, kernel, context, userContext)
        {
        }
    }
    public class MaintenanceConfigController : SettingsController<MaintenanceConfig>
    {
        public MaintenanceConfigController(IRepository<MaintenanceConfig> configRepo, IKernel kernel, PropertyContext context, IUserContext userContext) : base(configRepo, kernel, context, userContext)
        {
        }
    }
    public class MessagingConfigController : SettingsController<MessagingConfig>
    {
        public MessagingConfigController(IRepository<MessagingConfig> configRepo, IKernel kernel, PropertyContext context, IUserContext userContext) : base(configRepo, kernel, context, userContext)
        {
        }
    }
}