using System.Linq;
using System.Web;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject;

namespace ApartmentApps.API.Service.Controllers
{
    public class ApartmentAppsApiController : ApiController
    {
        public IKernel Kernel { get; set; }
        public PropertyContext Context { get; }
        public IUserContext UserContext { get; set; }

        //public ApplicationUserManager UserManager
        //{
        //    get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        //}

        [NonAction]
        public TConfig GetConfig<TConfig>() where TConfig : ModuleConfig, new()
        {
            var config = Kernel.Get<Module<TConfig>>().Config;
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