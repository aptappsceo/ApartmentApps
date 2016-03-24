using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public IEnumerable<string> Photos { get; set; }
        public string Requester { get; set; }
        public string RequesterId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public string Status { get; set; }
    }
    [System.Web.Http.RoutePrefix("api/Courtesy")]
    [System.Web.Http.Authorize]
    public class CourtesyController : ApartmentAppsApiController
    {

        public IBlobStorageService BlobStorageService { get; set; }
        public ICourtesyService CourtesyService { get; set; }
        public ApplicationDbContext Context { get; set; }

        public CourtesyController(ICourtesyService courtesyService, IBlobStorageService blobStorageService)
        {
            CourtesyService = courtesyService;
            BlobStorageService = blobStorageService;
        }

        public CourtesyController()
        {
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("List")]
        public IEnumerable<IncidentIndexBindingModel> ListRequests()
        {
            using (Context = new ApplicationDbContext())
            {
                var propertyId = this.CurrentUser.PropertyId;

                return
                    Context.IncidentReports.Include(r => r.IncidentReportStatus).Where(p => p.User.PropertyId == propertyId).Select(
                        x => new IncidentIndexBindingModel()
                        {
                            Title = x.IncidentType.ToString(),
                            Comments = x.Comments,
                            RequestDate = x.CreatedOn,
                            StatusId = x.StatusId,
                            Id = x.Id
                        }).ToArray();
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetIncidentReport")]
        public async Task<IncidentReportBindingModel> Get(int id)
        {

            using (Context = new ApplicationDbContext())
            {
                var result = await Context.IncidentReports
                    .Include(p=>p.User.Tenant)
                    .Include(p=>p.User.Tenant.Unit)
                    .Include(p=>p.User.Tenant.Unit.Building)
                    .FirstOrDefaultAsync(p => p.Id == id);
                //var userId = CurrentUser.UserName;
                //var user = Context.Users.FirstOrDefault(p => p.UserName == userId);
                var photos = Context.ImageReferences.Where(r => r.GroupId == result.GroupId).ToList();

                var response = new IncidentReportBindingModel()
                {
                    Comments = result.Comments,
                    Requester = result.User.FirstName + " " + result.User.LastName,
                    RequesterId = result.UserId,
                    BuildingName = result.User.Tenant?.Unit?.Building?.Name,
                    UnitName = result.User.Tenant?.Unit?.Name,
                    Status = result.StatusId,
                    CreatedOn = result.CreatedOn,
                    IncidentType = result.IncidentType.ToString(),
                    Photos = photos.Select(key => BlobStorageService.GetPhotoUrl(key.Url))
                };
                return response;
            }

        }

       

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SubmitIncidentReport")]
        public void SubmitIncidentReport(IncidentReportModel request)
        {
            CourtesyService.SubmitIncidentReport(CurrentUser, request.Comments, request.IncidentReportTypeId,
                request.Images);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("OpenIncidentReport")]
        public void OpenIncidentReport(int id, string comments, List<Byte[]> images)
        {
            CourtesyService.OpenIncidentReport(CurrentUser, id, comments, images);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PauseIncidentReport")]
        public void PauseIncidentReport(int id, string comments, List<Byte[]> images)
        {
            CourtesyService.PauseIncidentReport(CurrentUser, id, comments, images);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CloseIncidentReport")]
        public void CloseIncidentReport(int id, string comments, List<Byte[]> images)
        {
            CourtesyService.CloseIncidentReport(CurrentUser, id, comments, images);
        }



    }

    public class IncidentIndexBindingModel
    {
        public string Title { get; set; }
        public string Comments { get; set; }
        public string StatusId { get; set; }
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
    }
}