using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data;
using Microsoft.AspNet.Identity;

namespace ApartmentApps.API.Service.Controllers.MobileClientViewApi
{
    public class GeneralViewsController : Controller
    {
        public ApplicationDbContext Context { get; set; }

        public GeneralViewsController(ApplicationDbContext context)
        {
            Context = context;
        }

  
        public ApplicationUser CurrentUser
        {
            get
            {
                var uName = User.Identity.GetUserName();
                return Context.Users.FirstOrDefault(p => p.Email == uName);
            }
        }

        public Property Property
        {
            get { return CurrentUser.Property; }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(Context.MaitenanceRequests.Include(p=>p.User).Include(p=>p.Unit).Include(p=>p.MaitenanceRequestType).Where(p=>p.User.PropertyId == Property.Id));
        }
    }
}