using System.Linq;
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

        private ApplicationUser _currentUser;
        public ApplicationUser CurrentUser
        {
            get
            {
                var username = User.Identity.Name;
                if (_currentUser == null)
                {
                    _currentUser = Context.Users.FirstOrDefault(p => p.UserName == username);
                }
                return _currentUser;//user.Email
            }
        }

        public ApartmentAppsApiController(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}