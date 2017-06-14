using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Schema;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.API.Service.Models;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.CourtesyOfficer;
using ApartmentApps.Modules.Inspections;
using ApartmentApps.Portal.Controllers;
using ExporterObjects;
using Newtonsoft.Json;
using Ninject;

namespace ApartmentApps.API.Service.Controllers.Api
{
    public class ServiceController<TService, TBindingModel, TFormBindingModel> : ApartmentAppsApiController 
        where TService : IService 
        where TBindingModel : BaseViewModel, new() 
        where TFormBindingModel :  BaseViewModel, new()
    {

        readonly string templateFolder;
     
        protected byte[] ToExcel<T>(IEnumerable<T> list)
        {
            return this.To(list, ExportToFormat.Excel2007);
        }
        protected byte[] ToPdf<T>(IEnumerable<T> list)
        {
            return this.To(list, ExportToFormat.PDFtextSharpXML);
        }

        protected byte[] To<T>(IEnumerable<T> list, ExportToFormat exportToFormat)
        {
            var exportList = new ExportList<T>();

            var tmpFileName = Path.Combine(templateFolder, Guid.NewGuid().ToString() + ".xlsx");
            exportList.PathTemplateFolder = templateFolder;

            exportList.ExportTo(list, exportToFormat, tmpFileName);

            using (var ms = new MemoryStream(System.IO.File.ReadAllBytes(tmpFileName)))
            {
                try
                {
                    return ms.ToArray();
                }
                finally
                {
                    System.IO.File.Delete(tmpFileName);
                }
            }
        }
        public ServiceController( IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
    
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("fetch")]
        public virtual async Task<QueryResult<TBindingModel>> Fetch(Query query)
        {
            var result = Kernel.Get<TService>().Query<TBindingModel>(query);
            return result;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("pdf")]
        public virtual async Task<IHttpActionResult> ToPDF(Query query)
        {
            query.Navigation = null;

            var result = Kernel.Get<TService>().Query<TBindingModel>(query);
            ToExcel(result.Result);
            return new FileResult(ToPdf(result.Result),"pdf","application/pdf");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("excel")]
        public virtual IHttpActionResult ToExcel(Query query)
        {
            query.Navigation = null;

            var result = Kernel.Get<TService>().Query<TBindingModel>(query);
            ToExcel(result.Result);
            return new FileResult(ToPdf(result.Result), "xlsx", "application/excel");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("entry")]

        public virtual TFormBindingModel Entry(string id)
        {
            try
            {
                var item = Kernel.Get<TService>().Find<TFormBindingModel>(id);
                if (item == null)
                {
                    return null;
                }
                return item;
            }
            catch (Exception ex)
            {
                return null;
                //return new ExceptionResult(ex, this);
            }

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("delete")]
        public virtual async Task<IHttpActionResult> Delete(string id)
        {
            try
            {
                Kernel.Get<TService>().Remove(id);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
            return Ok();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("save")]
        public virtual async Task<IHttpActionResult> Save(TFormBindingModel entry)
        {
            try
            {
             
                Kernel.Get<TService>().Save(entry);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
            return Ok(entry);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("schema")]
        public virtual HttpResponseMessage Schema()
        {
            var type = typeof(TFormBindingModel);
            var jObject = CreateSchema(type);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jObject.ToString(Formatting.Indented), Encoding.UTF8, "application/json");
            return response;
            //return Ok(jObject.ToString(Formatting.Indented));
        }
    }


    [System.Web.Http.RoutePrefix("api/Inspections")]
    [System.Web.Http.Authorize]
    public class InspectionsController : ApartmentAppsApiController
    {
        private readonly InspectionsService _inspectionsService;

        public InspectionsController(IKernel kernel, InspectionsService inspectionsService, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
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
    public class CourtesyController : ServiceController<IncidentsService, IncidentReportViewModel, IncidentReportFormModel>
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("schema")]
        public override HttpResponseMessage Schema()
        {
            return base.Schema();
        }

        public IBlobStorageService BlobStorageService { get; set; }
        public IIncidentsService IncidentsService { get; set; }

        public CourtesyController(IKernel kernel, IIncidentsService incidentsService, IBlobStorageService blobStorageService, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            IncidentsService = incidentsService;
            BlobStorageService = blobStorageService;
        }

        //[System.Web.Http.HttpPost]
        //[System.Web.Http.Route("fetch")]
        //[ResponseType(typeof(QueryResult<IncidentReportViewModel>))]
        //public async Task<IHttpActionResult> Fetch(Query query)
        //{
        //    return Ok(IncidentsService.Query<IncidentReportViewModel>(query));
        //}
        [Route("fetch", Name = nameof(Fetch))]
        [HttpPost]
        [ResponseType(typeof(QueryResult<IncidentReportViewModel>))]
        public override Task<QueryResult<IncidentReportViewModel>> Fetch(Query query)
        {
            return base.Fetch(query);
        }


        [Route("IncidentStatuses", Name = nameof(IncidentStatuses))]
        [HttpGet]
        [ResponseType(typeof(QueryResult<LookupBindingModel>))]
        public IHttpActionResult IncidentStatuses(string query = null)
        {
            var incidentTypes = Kernel.Get<IDataSheet<IncidentReportStatus>>();

            if (string.IsNullOrEmpty(query))
            {
                return Ok(incidentTypes.Query().Get<LookupBindingModel>());
            }
            else
            {
                return Ok(incidentTypes.Query()
                    .Search<IncidentStatusesSearchEngine>((eng, set) => eng.CommonSearch(set, query))
                    .Get<LookupBindingModel>());
            }
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


            var result = Context.IncidentReports.Find(id);
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