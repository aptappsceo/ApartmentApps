using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.IoC;
using ApartmentApps.Portal.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ApartmentApps.Portal.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ApartmentApps.Portal.App_Start.NinjectWebCommon), "Stop")]

namespace ApartmentApps.Portal.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Threading;
    using System.Web.Hosting;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
           
            bootstrapper.Initialize(CreateKernel);
        }

        public static IKernel Kernel { get; set; }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel =  Kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                DependencyResolver.SetResolver(new Ninject.Web.Mvc.NinjectDependencyResolver(kernel));
                return kernel;
            }
            catch(Exception ex)
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            Register.RegisterServices(kernel);
            //kernel.Bind<IIdentityMessageService>().To<EmailService>().InRequestScope();
            kernel.Bind<IBackgroundScheduler>().To<DefaultBackgroundScheduler>().InRequestScope();

            kernel.Bind<IUserContext>().To<WebUserContext>().InRequestScope();
            kernel.Bind<ILogger>().To<LoggerModule>().InRequestScope();
            //kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().InRequestScope();
            kernel.Bind<UserManager<ApplicationUser>>().ToSelf().InRequestScope();

            kernel.Bind<IAuthenticationManager>()
                .ToMethod(o => HttpContext.Current.GetOwinContext().Authentication)
                .InRequestScope();
        }
    }
    public class BackgroundScheduler : IBackgroundScheduler
    {
        public void QueueBackgroundItem(Action<CancellationToken> backgroundAction)
        {
            HostingEnvironment.QueueBackgroundWorkItem(backgroundAction);
        }

        public void QueueBackgroundItem(Func<CancellationToken, System.Threading.Tasks.Task> backgroundAction)
        {
            HostingEnvironment.QueueBackgroundWorkItem(backgroundAction);
        }
    }

    public class WebUserContext : IUserContext
    {
        private readonly ApplicationDbContext _db;
        private ApplicationUser _user;
        private IKernel _kernel;
        public DateTime Now => CurrentUser.Property.TimeZone.Now();
        public DateTime Today => new DateTime(Now.Year, Now.Month, Now.Day);
        public WebUserContext(ApplicationDbContext context, IKernel kernel)
        {
            _kernel = kernel;
            _db = context;
        }
        
        public ConfigProvider<T> GetConfigProvider<T>() where T : class, new()
        {
        
            return _kernel.Get<ConfigProvider<T>>();
        }

        public T GetConfig<T>() where T : class, new()
        {
            return GetConfigProvider<T>().Config;
        }

        public ApplicationUser CurrentUser
        {
            get
            {
                if (_user != null) return _user;
                if (!User.IsAuthenticated) return null;
                return _user ?? (_user = _db.Users.FirstOrDefault(p => p.Email == Email));
            }
        }


        public IIdentity User => HttpContext != null ? HttpContext.User.Identity : System.Web.HttpContext.Current.User.Identity;

        public bool IsInRole(string roleName)
        {
            if (HttpContext != null)
            {
                HttpContext.User.IsInRole(roleName);
            }
            return HttpContext.Current.User.IsInRole(roleName);
        }

        public string UserId => CurrentUser.Id;
        public string Email => User.GetUserName();
        public string Name => CurrentUser.FirstName + " " + CurrentUser.LastName;
        public int PropertyId
        {
            get
            {
                if (CurrentUser?.PropertyId != null) return CurrentUser.PropertyId.Value;
                return 1;
            }
        }

        public HttpContext HttpContext { get; set; }
    }
}
