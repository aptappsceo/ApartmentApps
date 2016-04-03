using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Controllers.Api
{


    [System.Web.Http.RoutePrefix("api/Courtesy")]
    [System.Web.Http.Authorize]
    public class CourtesyController : ApartmentAppsApiController
    {

        public IBlobStorageService BlobStorageService { get; set; }
        public ICourtesyService CourtesyService { get; set; }

        public CourtesyController(ICourtesyService courtesyService, IBlobStorageService blobStorageService, ApplicationDbContext context) : base(context)
        {
            CourtesyService = courtesyService;
            BlobStorageService = blobStorageService;
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("List")]
        public IEnumerable<IncidentIndexBindingModel> ListRequests()
        {

            var propertyId = this.CurrentUser.PropertyId;

            return
                Context.IncidentReports.Include(r => r.IncidentReportStatus)
                .Where(p => p.User.PropertyId == propertyId).OrderByDescending(p => p.CreatedOn).ToArray().Select(
                    x => new IncidentIndexBindingModel()
                    {
                        Title = x.IncidentType.ToString(),
                        Comments = x.Comments,
                        UnitName = x.Unit?.Name,
                        BuildingName = x.Unit?.Building?.Name,
                        RequestDate = x.CreatedOn,
                        ReportedBy = x.User.ToUserBindingModel(BlobStorageService),
                        StatusId = x.StatusId,
                        LatestCheckin = x.LatestCheckin?.ToIncidentCheckinBindingModel(BlobStorageService),
                        Id = x.Id
                    }).ToArray();

        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetIncidentReport")]
        public async Task<IncidentReportBindingModel> Get(int id)
        {


            var result = await Context.IncidentReports
                .Include(p => p.User.Tenant)
                .Include(p => p.User.Tenant.Unit)
                .Include(p => p.User.Tenant.Unit.Building)
                .Include(p => p.Checkins)
                .FirstOrDefaultAsync(p => p.Id == id);
            //var userId = CurrentUser.UserName;
            //var user = Db.Users.FirstOrDefault(p => p.UserName == userId);
            var photos = Context.ImageReferences.Where(r => r.GroupId == result.GroupId).ToList();

            var response = new IncidentReportBindingModel()
            {
                Comments = result.Comments,

                Requester = result.User.ToUserBindingModel(BlobStorageService),
                Status = result.StatusId,
                CreatedOn = result.CreatedOn,
                IncidentType = result.IncidentType.ToString(),
                Checkins = result.Checkins.ToArray().Select(x => new IncidentCheckinBindingModel
                {
                    StatusId = x.StatusId,
                    Date = x.CreatedOn,
                    Comments = x.Comments,
                    Officer = x.Officer.ToUserBindingModel(BlobStorageService),


                    Photos = Context.ImageReferences.Where(r => r.GroupId == x.GroupId).ToList()
                }).ToArray(),
                Photos = photos.Select(key => BlobStorageService.GetPhotoUrl(key.Url))
            };
            return response;


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
}