﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ApartmentApps.Data;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
#if DEBUG
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext,ApartmentApps.Data.Migrations.Configuration>());
#endif   
          ModelBinderProviders.BinderProviders.Insert(0, new BaseViewModelBinderProvider());
            //ModelBinders.Binders.RegisterUploadedFileModelBinder((file, controllerContext, modelBindingContext) => MyFileStore.StoreFile(file))
            AreaRegistration.RegisterAllAreas();
            //UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
