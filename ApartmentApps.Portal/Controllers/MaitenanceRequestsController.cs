using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.App_Start;
using Ninject;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.MVC;
using Syncfusion.OfficeChartToImageConverter;

namespace ApartmentApps.Portal.Controllers
{

    public class MaitenanceRequestModel
    {

        //[DataType()]
        [DisplayName("Unit")]
        public int UnitId { get; set; }

        public IEnumerable<FormPropertySelectItem> UnitId_Items
        {
            get
            {
                var items =
                    NinjectWebCommon.Kernel.Get<IRepository<Unit>>()
                        .ToArray().OrderByAlphaNumeric(p => p.Name);


                return items.Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, UnitId == p.Id));


            }
        }
        public IEnumerable<FormPropertySelectItem> MaitenanceRequestTypeId_Items
        {
            get
            {
                return
                    NinjectWebCommon.Kernel.Get<IRepository<MaitenanceRequestType>>()
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, MaitenanceRequestTypeId == p.Id));


            }
        }

        [DisplayName("Type")]
        public int MaitenanceRequestTypeId { get; set; }

        public IEnumerable<SelectListItem> MaitenanceRequestTypeId_choices()
        {
            return Enumerable.Empty<SelectListItem>();
        }
        [DisplayName("Permission To Enter")]
        public bool PermissionToEnter { get; set; }

        [DisplayName("Pet Status")]
        public PetStatus PetStatus { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

    }

    [DisplayName("Maintenance Requests Report")]
    public class MaintenanceReportModel
    {

        [DataType(DataType.MultilineText)]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    [DisplayName("Update Maintenance Request")]
    public class MaintenanceStatusRequestModel
    {
        [DataType("Hidden")]
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }

    [DisplayName("Schedule Maintenance Request")]
    public class MaintenanceScheduleRequestModel
    {
        [DataType("Hidden")]
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Date { get; set; }
    }

    public class AssignMaintenanceEditModel
    {
        private readonly IRepository<ApplicationUser> _userRepository;

        public AssignMaintenanceEditModel()
        {
        }

        public AssignMaintenanceEditModel(IRepository<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }

        [DataType("Hidden")]
        public string Id { get; set; }


        //[DataType()]
        [DisplayName("Assigned To")]
        public string AssignedToId { get; set; }

        public IEnumerable<FormPropertySelectItem> AssignedToId_Items => _userRepository.ToArray()
                    .Where(p => p.Roles.Any(x => x.RoleId == "Maintenance"))
                    .OrderByAlphaNumeric(p => p.LastName)
                    .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.FirstName, AssignedToId == p.Id));

    }
    public class MaintenanceRequestEditModel
    {



        //[DataType()]
        [DisplayName("Unit")]
        public int UnitId { get; set; }

        public IEnumerable<FormPropertySelectItem> UnitId_Items
        {
            get
            {
                var items =
                    NinjectWebCommon.Kernel.Get<IRepository<Unit>>()
                        .ToArray().OrderByAlphaNumeric(p => p.Name);


                return items.Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, UnitId == p.Id));


            }
        }
        public IEnumerable<FormPropertySelectItem> MaitenanceRequestTypeId_Items
        {
            get
            {
                return
                    NinjectWebCommon.Kernel.Get<IRepository<MaitenanceRequestType>>()
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, MaitenanceRequestTypeId == p.Id));


            }
        }

        [DisplayName("Type")]
        public int MaitenanceRequestTypeId { get; set; }

        [DisplayName("Permission To Enter")]
        public bool PermissionToEnter { get; set; }

        [DisplayName("Pet Status")]
        public PetStatus PetStatus { get; set; }

        [DataType("Hidden")]
        public int? Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }


    }

    public enum PetStatus
    {
        NoPet,
        YesContained,
        YesFree
    }
    [Authorize]
    public class MaitenanceRequestsController : CrudController<MaintenanceRequestViewModel, MaitenanceRequest>
    {
        private PdfDocument _document;
        public IMaintenanceService MaintenanceService { get; set; }
        public override ActionResult Index()
        {
            return View(Service.GetAll< MaintenanceRequestViewModel>().OrderByDescending(p => p.RequestDate));
        }

        public MaitenanceRequestsController(IKernel kernel, IMaintenanceService maintenanceService, IRepository<MaitenanceRequest> repository, StandardCrudService<MaitenanceRequest> service, PropertyContext context, IUserContext userContext) : base(kernel, repository, service, context, userContext)
        {
            MaintenanceService = maintenanceService;
        }

        public ActionResult MySchedule()
        {
            return View();
        }

        public JsonResult MyScheduleData()
        {
            return Json(MaintenanceService.GetAppointments<MaintenanceRequestViewModel>(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult NewRequest()
        {

            return View(new MaitenanceRequestModel()
            {
                //MaitenanceRequestTypeId_choices =
                //    Context.MaitenanceRequestTypes.ToArray()
                //        .Select(p => new SelectListItem() {Value = p.Id.ToString(), Text = p.Name}),
                //UnitId_items = Context.Units.ToArray().Select(p=>new SelectListItem() {Value = p.Id.ToString(),Text = p.Name})
            });
        }

        public ActionResult AssignRequest(string id)
        {
            var request = Service.Find<MaintenanceRequestViewModel>(id);
            return AutoForm(new AssignMaintenanceEditModel(Kernel.Get<IRepository<ApplicationUser>>())
            {
                Id = id,
                AssignedToId = request.AssignedToId
            },
                "AssignRequestSubmit", "Assign Maintenance Request");
        }

        public ActionResult AssignRequestSubmit(AssignMaintenanceEditModel model)
        {
            if (ModelState.IsValid && model.Id != null)
            {
                MaintenanceService.AssignRequest(model.Id, model.AssignedToId);
                return new EmptyResult();
            }
            return AutoForm(model, "AssignRequestSubmit", "Assign Maintenance Request");
        }

        // GET: /MaitenanceRequests/Edit/5
        public ActionResult EditRequest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitenanceRequest maitenanceRequest = Context.MaitenanceRequests.Find(id.Value);
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            return View(new MaintenanceRequestEditModel()
            {
                Id = id.Value,
                MaitenanceRequestTypeId = maitenanceRequest.MaitenanceRequestTypeId,
                PermissionToEnter = maitenanceRequest.PermissionToEnter,
                UnitId = maitenanceRequest.UnitId ?? 0,
                PetStatus = (PetStatus)maitenanceRequest.PetStatus,
                Comments = maitenanceRequest.Message
            });
        }

        // POST: /MaitenanceRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRequest(MaintenanceRequestEditModel editModel)
        {

            if (ModelState.IsValid)
            {
                var id = editModel.Id;
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                MaitenanceRequest maitenanceRequest = Context.MaitenanceRequests.Find(id.Value);
                if (maitenanceRequest == null)
                {
                    return HttpNotFound();
                }

                maitenanceRequest.PetStatus = (int)editModel.PetStatus;
                maitenanceRequest.MaitenanceRequestTypeId = editModel.MaitenanceRequestTypeId;
                maitenanceRequest.PermissionToEnter = editModel.PermissionToEnter;
                maitenanceRequest.UnitId = editModel.UnitId;
                maitenanceRequest.Message = editModel.Comments;
                Context.SaveChanges();

                return RedirectToAction("Details", new { id = id });
            }

            return View(editModel);
        }


        public ActionResult Pause(int id)
        {
            return AutoForm(new MaintenanceStatusRequestModel() { Id = id }, "PauseRequest");
        }

        public ActionResult Complete(int id)
        {
            return AutoForm(new MaintenanceStatusRequestModel() { Id = id }, "CompleteRequest");
        }

        public ActionResult Schedule(int id)
        {
            return AutoForm(new MaintenanceScheduleRequestModel() { Id = id }, "ScheduleRequest");
        }

        public ActionResult Start(int id)
        {
            return AutoForm(new MaintenanceStatusRequestModel() { Id = id }, "StartRequest");
        }

        public ActionResult MonthlyReport()
        {
            return AutoForm(new MaintenanceReportModel(), "CreateMonthlyReport", "MaitenanceRequests");
        }
        [HttpPost]
        public ActionResult CreateMonthlyReport(MaintenanceReportModel model)
        {
            //var doc =
            //    new WordDocument(
            //        typeof (MaitenanceRequestsController).Assembly.GetManifestResourceStream(
            //            "ApartmentApps.Portal.MaintenanceReport.docx"));

            //doc.ChartToImageConverter = new ChartToImageConverter();

            ////Create an instance of DocToPDFConverter

            //DocToPDFConverter converter = new DocToPDFConverter();

            ////Convert Word document into PDF document

            //_document = converter.ConvertToPDF(doc);

            Thread thread = new Thread(() => { CreateDocument(model); });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();


            //HTML string and base URL

            //if (Browser == "Browser")
            //{

            var stream = new MemoryStream();
            _document.Save(stream);
            _document.Close(true);
            return File(stream.ToArray(), "application/pdf", $"MonthlyReport{model.StartDate.Value.Month}{model.StartDate.Value.Day}-{model.EndDate.Value.Month}{model.EndDate.Value.Day}.pdf");




            ////                return doc.ExportAsActionResult("sample.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Open);
            //            }
            //            else
            //            {
            //                return doc.ExportAsActionResult("sample.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);
            //            }
        }
        private IQueryable<MaitenanceRequest> WorkOrdersByRange(DateTime? startDate, DateTime? endDate)
        {
            return Context.MaitenanceRequests.Where(p => p.SubmissionDate > startDate && p.SubmissionDate < endDate);
        }
        private IQueryable<MaintenanceRequestCheckin> CheckinsByRange(DateTime? startDate, DateTime? endDate)
        {
            return Context.MaintenanceRequestCheckins.Where(p => p.Date > startDate && p.Date < endDate);
        }
        private void CreateDocument(MaintenanceReportModel model)
        {
            var startDate = model.StartDate;
            var endDate = model.EndDate;
            if (startDate == null)
                startDate = CurrentUser.TimeZone.Now().Subtract(new TimeSpan(30, 0, 0, 0));

            if (endDate == null)
                endDate = CurrentUser.TimeZone.Now().AddDays(1);

            var todayEnd = CurrentUser.TimeZone.Now().AddDays(1);
            var todayStart = CurrentUser.TimeZone.Now();


            var StartDate = startDate;
            var EndDate = endDate;
            var NumberEntered = WorkOrdersByRange(startDate, endDate).Count(p => p.StatusId == "Submitted");
            var NumberOutstanding = WorkOrdersByRange(startDate, endDate).Count(p => p.StatusId != "Complete");
            var NumberCompleted = WorkOrdersByRange(startDate, endDate).Count(p => p.StatusId == "Complete");

            var MaintenanceTotalOutstanding = Context.MaitenanceRequests.Count(p => p.StatusId != "Complete");
            var MaintenanceScheduledToday = Context.MaitenanceRequests.Count(p => p.ScheduleDate > todayStart && p.ScheduleDate < todayEnd && p.StatusId == "Scheduled");
            var IncidentReportsTotalOutstanding = Context.IncidentReports.Count(x => x.StatusId != "Complete");

            var WorkOrdersPerEmployee = CheckinsByRange(startDate, endDate).Where(p => p.StatusId == "Complete")
                .GroupBy(p => p.Worker)
                .ToArray();

            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            string htmlText = $"<html><body style='padding: 40px;font-family: Arial, Helvetica, sans-serif;'>" +
                              $"<div style='text-align: center; font-size: 32px; font-weight: bold'>{UserContext.CurrentUser.Property.Name} Monthly Maintenance Report</div>" +
                              $"<div style='text-align: center; font-size: 20px;'>For {model.StartDate} {model.EndDate}</div>" +
                              $"<br/><br/><table style='width: 100%'>";

            htmlText += $"<tr><td style='font-weight: bold; width: 50%;'>Total Work Orders</td><td>{CheckinsByRange(startDate, endDate).Count(p => p.StatusId == "Complete")} Work Orders</td></tr> ";
            foreach (var item in WorkOrdersPerEmployee)
            {
                htmlText += $"<tr><td>{item.Key.FirstName} {item.Key.LastName} Completed</td><td>{item.Count()} Work Orders</td></tr> ";
            }
            htmlText += $"" +
                              $"</table>" +
                              $"</body></html>";

            string baseUrl = "";

            //Convert HTML to PDF document

            _document = htmlConverter.Convert(htmlText, baseUrl);
        }

        public override string ExportFileName
        {
            get { return "MaintenanceRequests"; }
        }

        [HttpPost]
        public ActionResult SubmitRequest(MaitenanceRequestModel request)
        {

            var id = MaintenanceService.SubmitRequest(
                request.Comments,
                request.MaitenanceRequestTypeId,
                (int)request.PetStatus,
                request.PermissionToEnter,
                null,
                Convert.ToInt32(request.UnitId)
                );
            return RedirectToAction("Details", new { id = id });

        }

        [HttpPost]
        public ActionResult StartRequest(MaintenanceStatusRequestModel request)
        {

            MaintenanceService.StartRequest(
                CurrentUser,
                request.Id,
                request.Comments, null
                );
            return RedirectToAction("Details", new { id = request.Id });

        }

        [System.Web.Http.HttpPost]
        public ActionResult PauseRequest(MaintenanceStatusRequestModel request)
        {

            MaintenanceService.PauseRequest(
                CurrentUser,
                request.Id,
                request.Comments, null

                );
            return RedirectToAction("Details", new { id = request.Id });

        }

        [System.Web.Http.HttpPost]
        public ActionResult ScheduleRequest(MaintenanceScheduleRequestModel request)
        {
            if (!request.Date.HasValue) throw new Exception("No date was selected.");
            MaintenanceService.ScheduleRequest(
                CurrentUser,
                request.Id,
                request.Date.Value

                );
            return RedirectToAction("Details", new { id = request.Id });

        }

        [System.Web.Http.HttpPost]
        public ActionResult CompleteRequest(MaintenanceStatusRequestModel request)
        {

            MaintenanceService.CompleteRequest(
                CurrentUser,
                request.Id,
                request.Comments, null
                );
            return RedirectToAction("Details", new { id = request.Id });
        }
        public ActionResult Print(string id)
        {
            var item = Service.Find<MaintenanceRequestViewModel>(id);
            return View(item);
        }

    }
    public class AutoGridModel
    {
        private string _title;
        public object[] Model { get; set; }

        public string Title
        {
            get { return _title ?? (_title = Model.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? Model.GetType().Name); }
            set { _title = value; }
        }

        public Type Type { get; set; }
        public int Count { get; set; }
        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; } = 20;

        public int Pages => (int) Math.Ceiling((double) Count/RecordsPerPage);
        public string OrderBy { get; set; }
        public bool Descending { get; set; }


        public AutoGridModel(object[] model)
        {
            Model = model;
        }
    }
    public class AutoFormModel
    {
        private string _title;
        public object Model { get; set; }

        public string Title
        {
            get { return _title ?? (_title = Model.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? Model.GetType().Name); }
            set { _title = value; }
        }

        public string PostAction { get; set; }
        public string PostController { get; set; }

        public AutoFormModel(object model, string postAction, string postController)
        {
            PostController = postController;
            Model = model;

            PostAction = postAction;
        }
    }

    public class MaitenanceRequests2Controller : AAController
    {
        // GET: /MaitenanceRequests/
        public MaitenanceRequests2Controller(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        public ActionResult Index()
        {
            var maitenancerequests = Context.MaitenanceRequests.GetAll();
            return View(maitenancerequests.ToList());
        }

        // GET: /MaitenanceRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitenanceRequest maitenanceRequest = Context.MaitenanceRequests.Find(id.Value);
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            return View(maitenanceRequest);
        }

        // GET: /MaitenanceRequests/Create
        public ActionResult Create()
        {
            ViewBag.MaitenanceRequestTypeId = new SelectList(Context.MaitenanceRequestTypes.GetAll(), "Id", "Name");
            ViewBag.StatusId = new SelectList(Context.MaintenanceRequestStatuses.GetAll(), "Name", "Name");
            ViewBag.UnitId = new SelectList(Context.Units.GetAll(), "Id", "Name");
            ViewBag.UserId = new SelectList(Context.Users.GetAll(), "Id", "FirstName");
            return View();
        }

        // POST: /MaitenanceRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,MaitenanceRequestTypeId,PermissionToEnter,PetStatus,UnitId,ScheduleDate,Message,StatusId,ImageDirectoryId,SubmissionDate,CompletionDate")] MaitenanceRequest maitenanceRequest)
        {
            if (ModelState.IsValid)
            {
                Context.MaitenanceRequests.Add(maitenanceRequest);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaitenanceRequestTypeId = new SelectList(Context.MaitenanceRequestTypes.GetAll(), "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
            ViewBag.StatusId = new SelectList(Context.MaintenanceRequestStatuses.GetAll(), "Name", "Name", maitenanceRequest.StatusId);
            ViewBag.UnitId = new SelectList(Context.Units.GetAll(), "Id", "Name", maitenanceRequest.UnitId);
            ViewBag.UserId = new SelectList(Context.Users.GetAll(), "Id", "FirstName", maitenanceRequest.UserId);
            return View(maitenanceRequest);
        }



        // GET: /MaitenanceRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitenanceRequest maitenanceRequest = Context.MaitenanceRequests.Find(id);
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            return View(maitenanceRequest);
        }

        // POST: /MaitenanceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaitenanceRequest maitenanceRequest = Context.MaitenanceRequests.Find(id);
            Context.MaitenanceRequests.Remove(maitenanceRequest);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
