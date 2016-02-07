using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.API.Service.Providers;
using Microsoft.AspNet.Identity;

namespace ApartmentApps.API.Service.Controllers
{
    public class ApartmentAppsApiController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApartmentAppsApiController()
        {
        }

        public ApartmentAppsApiController(UserManager<ApplicationUser> userManager )
        {
            this._userManager = userManager;
        }

        public ApplicationUser AppUser => _userManager.FindById(User.Identity.GetUserId());
    }

    [System.Web.Http.RoutePrefix("api/Maitenance")]
    [System.Web.Http.Authorize]
    public class MaitenanceController : ApartmentAppsApiController
    {
        public IMaintenanceService MaintenanceService { get; set; }
        public ApplicationDbContext Context { get; set; }

        public MaitenanceController(IMaintenanceService maintenanceService)
        {
            MaintenanceService = maintenanceService;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SubmitRequest")]
        public void SubmitRequest(MaitenanceRequestModel request)
        {
            MaintenanceService.SubmitRequest(AppUser, request.Comments, request.MaitenanceRequestTypeId);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetMaitenanceRequestTypes")]
        public IEnumerable<LookupPairModel> GetMaitenanceRequestTypes()
        {
            using (Context = new ApplicationDbContext())
            {
                return Context.MaitenanceRequestTypes.Select(x => new LookupPairModel() { Key = x.Id.ToString(), Value = x.Name }).ToArray();
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWorkOrders")]
        public IEnumerable<MaitenanceRequest> GetWorkOrders(string workerId)
        {
            using (Context = new ApplicationDbContext())
            {
                return Context.MaitenanceRequests.Where(p => p.WorkerId == workerId).ToArray();
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetByResident")]
        public IEnumerable<MaitenanceRequest> GetByResident(string workerId)
        {
            using (Context = new ApplicationDbContext())
            {
                return Context.MaitenanceRequests.Where(p => p.WorkerId == workerId);
            }
        }
        public MaitenanceController() :base()
        {
        }

        public MaitenanceController(UserManager<ApplicationUser> userManager) : base(userManager)
        {
        }
    }


}
