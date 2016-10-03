using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.API.Service.Models;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.CourtesyOfficer;
using ApartmentApps.Modules.Inspections;
using Ninject;

namespace ApartmentApps.API.Service.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/Inspections")]
    [System.Web.Http.Authorize]
    public class InspectionsController : ApartmentAppsApiController
    {
        private readonly InspectionsService _inspectionsService;

        public InspectionsController(IKernel kernel, InspectionsService inspectionsService,PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            _inspectionsService = inspectionsService;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("List")]
        public IEnumerable<InspectionViewModel> Get()
        {
            
            var propertyId = this.CurrentUser.PropertyId;

            return _inspectionsService.GetAllForUser<InspectionViewModel>(this.CurrentUser.Id);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("StartInspection")]
        public void StartInspection(int id)
        {
            _inspectionsService.StartInspection(id);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PauseInspection")]
        public void PauseInspection(int id)
        {
            _inspectionsService.PauseInspection(id);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("FinishInspection")]
        public void FinishInspection(FinishInspectionViewModel finishInspectionViewModel)
        {
            _inspectionsService.FinishInspection(finishInspectionViewModel);
        }
    }

    [System.Web.Http.RoutePrefix("api/Courtesy")]
    [System.Web.Http.Authorize]
    public class CourtesyController : ApartmentAppsApiController
    {

        public IBlobStorageService BlobStorageService { get; set; }
        public IIncidentsService IncidentsService { get; set; }

        public CourtesyController(IKernel kernel, IIncidentsService incidentsService, IBlobStorageService blobStorageService,PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            IncidentsService = incidentsService;
            BlobStorageService = blobStorageService;
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("List")]
        public IEnumerable<IncidentIndexBindingModel> ListRequests()
        {

            var propertyId = this.CurrentUser.PropertyId;

            return
                Context.IncidentReports
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
                        Id = x.Id.ToString()
                    }).ToArray();

        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetIncidentReport")]
        public IncidentReportBindingModel Get(int id)
        {


            var result =  Context.IncidentReports.Find(id);
            //var userId = CurrentUser.UserName;
            //var user = Db.Users.FirstOrDefault(p => p.UserName == userId);
            var photos = Context.ImageReferences.Where(r => r.GroupId == result.GroupId).ToList();

            var response = new IncidentReportBindingModel()
            {
                Comments = result.Comments,
                Id = result.Id,
                Requester = result.User.ToUserBindingModel(BlobStorageService),
                Status = result.StatusId,
                CreatedOn = result.CreatedOn,
                UnitId = result.UnitId,
                UnitName = result.Unit?.Name,
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
        [System.Web.Http.Route("AssignUnitToIncidentReport")]
        public void AssignUnitToIncidentReport(int id, int unitId)
        {
            var incidentReport = Context.IncidentReports.Find(id);
            if (incidentReport != null)
            {
                incidentReport.UnitId = unitId;
                Context.SaveChanges();
            }
            
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SubmitIncidentReport")]
        public void SubmitIncidentReport(IncidentReportModel request)
        {
            IncidentsService.SubmitIncidentReport(CurrentUser, request.Comments, request.IncidentReportTypeId,
                request.Images);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("OpenIncidentReport")]
        public void OpenIncidentReport(int id, string comments, List<Byte[]> images)
        {
            IncidentsService.OpenIncidentReport(CurrentUser, id, comments, images);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PauseIncidentReport")]
        public void PauseIncidentReport(int id, string comments, List<Byte[]> images)
        {
            IncidentsService.PauseIncidentReport(CurrentUser, id, comments, images);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CloseIncidentReport")]
        public void CloseIncidentReport(int id, string comments, List<Byte[]> images)
        {
            IncidentsService.CloseIncidentReport(CurrentUser, id, comments, images);
        }



    }
}