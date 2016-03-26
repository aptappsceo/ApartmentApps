using System.Web;
using System.Web.Http;
using ApartmentApps.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ApartmentApps.API.Service.Controllers
{
    public class ApartmentAppsApiController : ApiController
    {
        public ApplicationDbContext Context { get; }

        public ApplicationUserManager UserManager
        {
            get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }
        public ApplicationUser CurrentUser
        {
            get
            {
                var user = UserManager.FindByName(User.Identity.Name);
                return user;//user.Email
            }
        }

        public ApartmentAppsApiController(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}