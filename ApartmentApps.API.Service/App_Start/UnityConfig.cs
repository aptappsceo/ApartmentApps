using System.Data.Entity;
using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Areas.HelpPage.Controllers;
using ApartmentApps.API.Service.Controllers;
using ApartmentApps.API.Service.Models;
using ApartmentApps.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Unity.WebApi;

namespace ApartmentApps.API.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            // Push notifications
            //container.RegisterType<IPushNotifiationHandler, AzurePushNotificationHandler>();
            //container.RegisterType<IService, AlertsService>("PushNotifications");
            //container.RegisterType<IBlobStorageService, BlobStorageService>();

            //container.RegisterType<IMaintenanceService, MaintenanceService>();
            //container.RegisterType<ICourtesyService, CourtesyService>();
            //container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            //container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
          
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));
            //container.RegisterType<ISecureDataFormat<AuthenticationTicket>, SecureDataFormat<AuthenticationTicket>>();
            //container.RegisterType<ApplicationUserManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()));
            //container.RegisterType<UserManager<ApplicationUser>>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()));


            //container.RegisterType<MaitenanceController>(new InjectionConstructor());
            //container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<HelpController>(new InjectionConstructor());
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            //ServiceExtensions.GetServices = () => container.ResolveAll<IService>();
        }
    }
}