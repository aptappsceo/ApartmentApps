using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FormFactory.AspMvc.UploadedFiles;

namespace ApartmentApps.Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders.RegisterUploadedFileModelBinder();
            //ModelBinders.Binders.RegisterUploadedFileModelBinder((file, controllerContext, modelBindingContext) => MyFileStore.StoreFile(file))
            AreaRegistration.RegisterAllAreas();
            //UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
