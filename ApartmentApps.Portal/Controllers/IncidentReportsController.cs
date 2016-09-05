using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    [DisplayName("Update Incident Request")]
    public class IncidentStatusRequestModel
    {
        [DataType("Hidden")]
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }

    public class IncidentReportsController : CrudController<IncidentReportViewModel, IncidentReport>
    {
        public ActionResult Print(string id)
        {
            var item = Service.Find(id);
            return View(item);
        }
        public IncidentsService OfficerService { get; set; }

        public IncidentReportsController(IKernel kernel, IncidentsService officerService, IRepository<IncidentReport> repository, StandardCrudService<IncidentReport, IncidentReportViewModel> service, PropertyContext context, IUserContext userContext) : base(kernel, repository, service, context, userContext)
        {
            OfficerService = officerService;
        }
        public ActionResult NewRequest()
        {

            return AutoForm(new IncidentReportFormModel(), "SubmitRequest", "New Incident Report");
        }
        public ActionResult Pause(int id)
        {
            return AutoForm(new IncidentStatusRequestModel() { Id = id }, "PauseRequest");
        }
        public ActionResult Complete(int id)
        {
            return AutoForm(new IncidentStatusRequestModel() { Id = id }, "CompleteRequest");
        }

        [HttpPost]
        public ActionResult SubmitRequest(IncidentReportFormModel request)
        {

            OfficerService.SubmitIncidentReport(
                CurrentUser,
                request.Comments,
                request.ReportType,
                null,
                Convert.ToInt32(request.UnitId)
                );
            return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]
        public ActionResult PauseRequest(IncidentStatusRequestModel request)
        {
            OfficerService.PauseIncidentReport(
                CurrentUser,
                request.Id,
                request.Comments, null

                );
            return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]
        public ActionResult CompleteRequest(IncidentStatusRequestModel request)
        {

            OfficerService.CloseIncidentReport(
                CurrentUser,
                request.Id,
                request.Comments, null
                );
            return RedirectToAction("Index");
        }
    }
  //  public class IncidentReports2Controller : AAController
  //  {
        
		//public IncidentReports2Controller(PropertyContext context, IUserContext userContext) : base(context, userContext)
  //      {
            
  //      }
  //      // GET: /IncidentReports/
  //      public ActionResult Index()
  //      {
  //          var incidentreports = Context.IncidentReports.GetAll();
  //          return View(incidentreports);
  //      }

  //      // GET: /IncidentReports/Details/5
  //      public ActionResult Details(int? id)
  //      {
  //          if (id == null)
  //          {
  //              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
  //          }
  //          IncidentReport incidentReport = Context.IncidentReports.Find(id.Value);
  //          if (incidentReport == null)
  //          {
  //              return HttpNotFound();
  //          }
  //          return View(incidentReport);
  //      }

  //      // GET: /IncidentReports/Create
  //      public ActionResult Create()
  //      {
  //          ViewBag.StatusId = new SelectList(Context.IncidentReportStatuses.GetAll(), "Name", "Name");
  //          ViewBag.PropertyId = new SelectList(Context.Properties.GetAll(), "Id", "Name");
  //          ViewBag.UnitId = new SelectList(Context.Units.GetAll(), "Id", "Name");
  //          ViewBag.UserId = new SelectList(Context.Users.GetAll(), "Id", "ImageUrl");
  //          return View();
  //      }
	
  //      // POST: /IncidentReports/Create
  //      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
  //      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
  //      [HttpPost]
  //      [ValidateAntiForgeryToken]
  //      public ActionResult Create([Bind(Include="Id,UserId,GroupId,Comments,UnitId,IncidentType,CreatedOn,StatusId,CompletionDate,PropertyId")] IncidentReport incidentReport)
  //      {
  //          if (ModelState.IsValid)
  //          {
  //              Context.IncidentReports.Add(incidentReport);
  //              Context.SaveChanges();
  //              return RedirectToAction("Index");
  //          }

  //          ViewBag.StatusId = new SelectList(Context.IncidentReportStatuses.GetAll(), "Name", "Name", incidentReport.StatusId);
  //          ViewBag.PropertyId = new SelectList(Context.Properties.GetAll(), "Id", "Name", incidentReport.PropertyId);
  //          ViewBag.UnitId = new SelectList(Context.Units.GetAll(), "Id", "Name", incidentReport.UnitId);
  //          ViewBag.UserId = new SelectList(Context.Users.GetAll(), "Id", "ImageUrl", incidentReport.UserId);
  //          return View(incidentReport);
  //      }

  //      // GET: /IncidentReports/Edit/5
  //      public ActionResult Edit(int? id)
  //      {
  //          if (id == null)
  //          {
  //              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
  //          }
  //          IncidentReport incidentReport = Context.IncidentReports.Find(id);
  //          if (incidentReport == null)
  //          {
  //              return HttpNotFound();
  //          }
  //          ViewBag.StatusId = new SelectList(Context.IncidentReportStatuses.GetAll(), "Name", "Name", incidentReport.StatusId);
  //          ViewBag.PropertyId = new SelectList(Context.Properties.GetAll(), "Id", "Name", incidentReport.PropertyId);
  //          ViewBag.UnitId = new SelectList(Context.Units.GetAll(), "Id", "Name", incidentReport.UnitId);
  //          ViewBag.UserId = new SelectList(Context.Users.GetAll(), "Id", "Username", incidentReport.UserId);
  //          return View(incidentReport);
  //      }

  //      // POST: /IncidentReports/Edit/5
  //      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
  //      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
  //      [HttpPost]
  //      [ValidateAntiForgeryToken]
  //      public ActionResult Edit([Bind(Include="Id,UserId,GroupId,Comments,UnitId,IncidentType,CreatedOn,StatusId,CompletionDate,PropertyId")] IncidentReport incidentReport)
  //      {
  //          if (ModelState.IsValid)
  //          {
  //              Context.Entry(incidentReport);
  //              Context.SaveChanges();
  //              return RedirectToAction("Index");
  //          }
  //          ViewBag.StatusId = new SelectList(Context.IncidentReportStatuses.GetAll(), "Name", "Name", incidentReport.StatusId);
  //          ViewBag.PropertyId = new SelectList(Context.Properties.GetAll(), "Id", "Name", incidentReport.PropertyId);
  //          ViewBag.UnitId = new SelectList(Context.Units.GetAll(), "Id", "Name", incidentReport.UnitId);
  //          ViewBag.UserId = new SelectList(Context.Users.GetAll(), "Id", "Username", incidentReport.UserId);
  //          return View(incidentReport);
  //      }

  //      // GET: /IncidentReports/Delete/5
  //      public ActionResult Delete(int? id)
  //      {
  //          if (id == null)
  //          {
  //              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
  //          }
  //          IncidentReport incidentReport = Context.IncidentReports.Find(id.Value);
  //          if (incidentReport == null)
  //          {
  //              return HttpNotFound();
  //          }
  //          return View(incidentReport);
  //      }

  //      // POST: /IncidentReports/Delete/5
  //      [HttpPost, ActionName("Delete")]
  //      [ValidateAntiForgeryToken]
  //      public ActionResult DeleteConfirmed(int id)
  //      {
  //          IncidentReport incidentReport = Context.IncidentReports.Find(id);
  //          Context.IncidentReports.Remove(incidentReport);
  //          Context.SaveChanges();
  //          return RedirectToAction("Index");
  //      }
  //  }
}
