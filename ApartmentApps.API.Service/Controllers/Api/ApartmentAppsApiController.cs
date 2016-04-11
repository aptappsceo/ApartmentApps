using System.Linq;
using System.Web;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ApartmentApps.API.Service.Controllers
{
    public class ApartmentAppsApiController : ApiController
    {
        public PropertyContext Context { get; }
        public IUserContext UserContext { get; set; }

        //public ApplicationUserManager UserManager
        //{
        //    get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        //}


        public ApplicationUser CurrentUser => UserContext.CurrentUser;

        public ApartmentAppsApiController(PropertyContext context, IUserContext userContext)
        {
            Context = context;
            UserContext = userContext;
        }
    }
}