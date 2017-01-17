using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
//using System.Web.Http.Cors;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject;

namespace ApartmentApps.API.Service.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApartmentAppsApiController : ApiController
    {
        public IKernel Kernel { get; set; }
        public PropertyContext Context { get; }
        public IUserContext UserContext { get; set; }

        //public ApplicationUserManager UserManager
        //{
        //    get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        //}
        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            if (UserContext.CurrentUser != null)
            {
                if (UserContext.CurrentUser.LastMobileLoginTime == null || UserContext.CurrentUser.LastMobileLoginTime.Value.Add(new TimeSpan(1, 0, 0)) < DateTime.UtcNow)
                {
                    UserContext.CurrentUser.LastMobileLoginTime = DateTime.UtcNow;
                    Kernel.Get<ApplicationDbContext>().SaveChanges();
                }
            }
            
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }

        [NonAction]
        public TConfig GetConfig<TConfig>() where TConfig : PropertyModuleConfig, new()
        {
            var config = UserContext.GetConfig<TConfig>();
            return config;
        }

        public ApplicationUser CurrentUser => UserContext.CurrentUser;

        public ApartmentAppsApiController(IKernel kernel, PropertyContext context, IUserContext userContext)
        {
            Kernel = kernel;
            Context = context;
            UserContext = userContext;
        }
        
    }
}