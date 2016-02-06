using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ApartmentApps.API.Service.Addons;
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

       
    }

    [RoutePrefix("api/Maitenance")]
    [Authorize]
    public class MaitenanceController : ApartmentAppsApiController
    {
        public ApplicationDbContext Context { get; set; }

        //public MaitenanceController(ApplicationDbContext context)
        //{

        //}

        [HttpPost]
        [Route("SubmitRequest")]
        public MaitenanceRequest SubmitRequest(MaitenanceRequestModel request)
        {
            using (Context = new ApplicationDbContext())
            {
                var maitenanceRequest = new MaitenanceRequest()
                {
                    UserId = User.Identity.GetUserId(),
                    WorkerId = null,
                    Date = DateTime.UtcNow,
                    Message = request.Comments,
                    MaitenanceRequestTypeId = request.MaitenanceRequestTypeId
                };

                Context.MaitenanceRequests.Add(maitenanceRequest);
                Context.SaveChanges();
                HandleIntegration(x=>x.MaintenanceRequestSubmited(maitenanceRequest));
                return maitenanceRequest;
            }
        }

        [HttpGet]
        [Route("GetMaitenanceRequestTypes")]
        public IEnumerable<LookupPairModel> GetMaitenanceRequestTypes()
        {
            using (Context = new ApplicationDbContext())
            {
                return Context.MaitenanceRequestTypes.Select(x => new LookupPairModel() { Key = x.Id.ToString(), Value = x.Name }).ToArray();
            }
        }

        [HttpGet]
        [Route("GetWorkOrders")]
        public IEnumerable<MaitenanceRequest> GetWorkOrders(string workerId)
        {
            using (Context = new ApplicationDbContext())
            {
                return Context.MaitenanceRequests.Where(p => p.WorkerId == workerId).ToArray();
            }
        }

        [HttpGet]
        [Route("GetByResident")]
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
