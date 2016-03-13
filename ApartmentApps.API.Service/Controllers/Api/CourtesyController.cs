using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Controllers.Api
{


    public class IncidentReportBindingModel
    {
        public string Comments { get; set; }
        public string IncidentType { get; set; }
    }

    public class CourtesyController : ApartmentAppsApiController
    {


        public IMaintenanceService MaintenanceService { get; set; }
        public ApplicationDbContext Context { get; set; }

        public CourtesyController(IMaintenanceService maintenanceService)
        {
            MaintenanceService = maintenanceService;
        }

        public CourtesyController()
        {
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetIncidentReport")]
        public async Task<IncidentReportBindingModel> Get(int id)
        {

            using (Context = new ApplicationDbContext())
            {
                //var userId = CurrentUser.UserName;
                //var user = Context.Users.FirstOrDefault(p => p.UserName == userId);
                throw new NotImplementedException();
            }

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SubmitIncidentReport")]
        public void SubmitIncidentReport(IncidentReportModel request)
        {
            throw new NotImplementedException();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("OpenIncidentReport")]
        public void OpenIncidentReport(int id, string comments, List<Byte[]> images)
        {
            throw new NotImplementedException();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PauseIncidentReport")]
        public void PauseIncidentReport(int id, string comments, List<Byte[]> images)
        {
            throw new NotImplementedException();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CloseIncidentReport")]
        public void CloseIncidentReport(int id, string comments, List<Byte[]> images)
        {
            throw new NotImplementedException();
        }



    }
}