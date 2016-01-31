using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApartmentApps.API.Service.Models;

namespace ApartmentApps.API.Service.Controllers
{
    [Authorize]
    public class MaitenanceController : ApiController
    {
        public ApplicationDbContext Context { get; set; }

        public MaitenanceController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IEnumerable<MaitenanceRequest> GetByWorker(string workerId)
        {
            return Context.MaitenanceRequests.Where(p => p.WorkerId == workerId);
        }
    }


}
