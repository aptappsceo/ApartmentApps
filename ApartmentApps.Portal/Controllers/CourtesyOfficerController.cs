using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class CourtesyOfficerController : AAController
    {
        public CourtesyOfficerService Service { get; set; }

        public CourtesyOfficerController(IKernel kernel, CourtesyOfficerService service, PropertyContext context, IUserContext userContext) : base(kernel,context,userContext)
        {
            Service = service;
        }

        public ActionResult Index()
        {
            return View("Index",Service.ForDay(UserContext.CurrentUser.TimeZone.Now()));
        }
        public ActionResult Yesterday()
        {
            return View("Index", Service.ForDay(UserContext.CurrentUser.TimeZone.Now().Subtract(new TimeSpan(1,0,0,0))));
        }
        public ActionResult ThisWeek()
        {
            return View("Index", Service.ForWeek(UserContext.CurrentUser.TimeZone.Now()));
        }

    }
}