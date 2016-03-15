﻿using System;
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
        //public GeneralViewsController(IMaintenanceService maitenanceService)
        //{
        //}
        protected ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationUser CurrentUser
        {
            get
            {
                var uName = User.Identity.GetUserName();
                return db.Users.FirstOrDefault(p => p.Email == uName);
            }
        }

        public Property Property
        {
            get { return CurrentUser.Property; }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.MaitenanceRequests.Include(p=>p.User).Include(p=>p.Unit).Include(p=>p.MaitenanceRequestType).Where(p=>p.User.PropertyId == Property.Id));
        }
    }
}