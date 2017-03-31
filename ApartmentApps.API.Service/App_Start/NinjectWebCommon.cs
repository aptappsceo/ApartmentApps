using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.IoC;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Ninject.Web.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ApartmentApps.API.Service.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ApartmentApps.API.Service.App_Start.NinjectWebCommon), "Stop")]

namespace ApartmentApps.API.Service.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
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
            kernel.Bind<IBackgroundScheduler>().To<DefaultBackgroundScheduler>().InRequestScope();
            kernel.Bind<ILogger>().To<LoggerModule>().InRequestScope();
            kernel.Bind<IUserContext>().To<WebUserContext>().InRequestScope();
            kernel.Bind<IAuthenticationManager>().ToMethod(p => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            kernel.Bind<ApplicationUserManager>().ToMethod(o => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()).InRequestScope();

           
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
        }        
    }


    public class WebUserContext : IUserContext
    {
        private readonly ApplicationDbContext _db;
        private ApplicationUser _user;
        private IKernel _kernel;
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

                return _user ?? (_user = _db.Users.FirstOrDefault(p => p.Email == Email));
            }
        }

        public IIdentity User => System.Web.HttpContext.Current.User.Identity;

        public bool IsInRole(string roleName)
        {
            return HttpContext.Current.User.IsInRole(roleName);
        }

        public string UserId => CurrentUser.Id;
        public string Email => User.GetUserName();
        public string Name => CurrentUser.FirstName + " " + CurrentUser.LastName;
        public int PropertyId
        {
            get
            {
                if (CurrentUser.PropertyId != null) return CurrentUser.PropertyId.Value;
                return 1;
            }
        }
    }

    public class BackgroundScheduler : IBackgroundScheduler
    {
        public void QueueBackgroundItem(Action<CancellationToken> backgroundAction)
        {
            HostingEnvironment.QueueBackgroundWorkItem(backgroundAction);
        }

        public void QueueBackgroundItem(Func<CancellationToken, Task> backgroundAction)
        {
            HostingEnvironment.QueueBackgroundWorkItem(backgroundAction);
        }
    }
}
