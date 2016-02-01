using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ApartmentApps.API.Service.Models;
using ApartmentApps.API.Service.Models.VMS;
using Microsoft.AspNet.Identity;

namespace ApartmentApps.API.Service.Controllers
{
    [Authorize]
    public class MaitenanceController : ApiController
    {
        public ApplicationDbContext Context { get; set; }

        //public MaitenanceController(ApplicationDbContext context)
        //{

        //}

        [HttpPost]
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
                return maitenanceRequest;
            }
        }

        [HttpGet]
        public IEnumerable<LookupPairModel> GetMaitenanceRequestTypes()
        {
            using (Context = new ApplicationDbContext())
            {
                return Context.MaitenanceRequestTypes.Select(x => new LookupPairModel() { Key = x.Id.ToString(), Value = x.Name }).ToArray();
            }
        }

        [HttpGet]
        public IEnumerable<MaitenanceRequest> GetByWorker(string workerId)
        {
            using (Context = new ApplicationDbContext())
            {
                return Context.MaitenanceRequests.Where(p => p.WorkerId == workerId).ToArray();
            }
        }

        [HttpGet]
        public IEnumerable<MaitenanceRequest> GetByResident(string workerId)
        {
            using (Context = new ApplicationDbContext())
            {
                return Context.MaitenanceRequests.Where(p => p.WorkerId == workerId);
            }
        }

    }


}
