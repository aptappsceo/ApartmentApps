using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public class AAController : Controller
    {
        public IUserContext UserContext { get; }

        public AAController(PropertyContext context, IUserContext userContext)
        {
            Context = context;
            UserContext = userContext;
        }

        protected PropertyContext Context { get; }

        public ApplicationUser CurrentUser => UserContext.CurrentUser;
        public int PropertyId => UserContext.PropertyId;

        public Data.Property Property => CurrentUser?.Property;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Property != null)
            {
                ViewBag.Property = Property;
                if (User.IsInRole("Admin"))
                {
                    ViewBag.Properties = Context.Properties.GetAll().ToArray();

                }
            }
           
        }
    }
}