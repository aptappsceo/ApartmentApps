using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public class SettingsModel
    {
        public string TimeZone { get; set; }


    }
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            //var integrations = ServiceExtensions.GetServices().OfType<IApartmentAppsAddon>();
            //var models = integrations.Select(x=>x.GetSettingsModel()).ToArray();
            
            return View();
        }
    }


}