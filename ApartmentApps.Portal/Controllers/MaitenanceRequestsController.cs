using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.IoC;
using ApartmentApps.Modules.Payments.BindingModels;
using ApartmentApps.Portal.App_Start;
using Korzh.EasyQuery.Services;
using Ninject;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using RazorEngine.Templating;

namespace ApartmentApps.Portal.Controllers
{
    public class ReportController : AAController
    {
        public ReportController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        
    }
    public class BaseViewModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (typeof(BaseViewModel).IsAssignableFrom(modelType))
            {
                return new BaseViewModelBinder();
            }
            return null;
        }

    }
    public class BaseViewModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            return Register.Kernel.Get(modelType);
        }
    }
    public class MaitenanceRequestModel
    {
        private readonly IRepository<Unit> _unitRepo;
        private readonly IRepository<ApplicationUser> _userRepo;
        private readonly IRepository<MaitenanceRequestType> _requestTypeRepo;

        public MaitenanceRequestModel()
        {
        }
        [Inject]
        public MaitenanceRequestModel(IRepository<Unit> unitRepo, IRepository<ApplicationUser> userRepo ,IRepository<MaitenanceRequestType> requestTypeRepo )
        {
            _unitRepo = unitRepo;
            _userRepo = userRepo;
            _requestTypeRepo = requestTypeRepo;
        }


        public IEnumerable<FormPropertySelectItem> UnitId_Items
        {
            get
            {
                var items =
                    _unitRepo.ToArray();
                var users = _userRepo;
                return items.Select(p =>
                {
                    if (!string.IsNullOrEmpty(p.CalculatedTitle))
                        return new FormPropertySelectItem(p.Id.ToString(), p.CalculatedTitle, UnitId == p.Id);

                    var name = $"[{ p.Building.Name }] {p.Name}";
                    var user = users.GetAll().FirstOrDefault(x => !x.Archived && x.UnitId == p.Id);
                    if (user != null)
                        name += $" ({user.FirstName} {user.LastName})";

                    return new FormPropertySelectItem(p.Id.ToString(), name, UnitId == p.Id);
                }).OrderByAlphaNumeric(p => p.Value);


            }
        }
        public IEnumerable<FormPropertySelectItem> MaitenanceRequestTypeId_Items
        {
            get
            {
                return
                    _requestTypeRepo
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, MaitenanceRequestTypeId == p.Id));


            }
        }

        public IEnumerable<SelectListItem> MaitenanceRequestTypeId_choices()
        {
            return Enumerable.Empty<SelectListItem>();
        }

        //#endregion



        [DisplayName("Unit"), DisplayForRoles(Roles = "Admin,Maintenance,PropertyAdmin,MaintenanceSupervisor")]
        [SelectFrom(nameof(UnitId_Items))]
        [Required]
        public int UnitId { get; set; }

        [DisplayName("Type")]
        [SelectFrom(nameof(MaitenanceRequestTypeId_Items))]
        [Required]
        public int MaitenanceRequestTypeId { get; set; }


        [DisplayName("Permission To Enter")]
        [Required]
        public bool PermissionToEnter { get; set; }

        [DisplayName("Pet Status")]
        [Required]
        public PetStatus PetStatus { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Comments { get; set; }

        [DisplayName("Is Emergency?")]
        [Required]
        public bool Emergency { get; set; }

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

        [DataType("Hidden")]
        public string Id { get; set; }

        [DisplayName("Assigned To")]
        [SelectFrom(nameof(PossibleAssignees))]
        public string AssignedToId { get; set; }

        public List<UserLookupBindingModel> PossibleAssignees { get; set; }
    }


    [Authorize]
    public class MaitenanceRequestsController : AutoGridController
            <MaintenanceService, MaintenanceService, MaintenanceRequestViewModel, MaintenanceRequestEditModel>
    {
        //public MaitenanceRequestsController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        //{
            
        //}
        private readonly UserService _usersService;
        private PdfDocument _document;
        public IMaintenanceService MaintenanceService { get; set; }



        //public override ActionResult Index()
        //{
        //    return View(Service.GetAll< MaintenanceRequestViewModel>().OrderByDescending(p => p.RequestDate));
        //}

        public override ActionResult GridResult(GridList<MaintenanceRequestViewModel> grid)
        {
            if (Request != null && Request.IsAjaxRequest())
            {
                return View("OverviewListPartial", grid);
            }
            return View("Overview", new MaintenanceRequestOverviewViewModel()
            {
                FeedItems = grid
            });
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
            ViewBag.Title = "Submit Maintenance Request";

            var model = Kernel.Get<MaitenanceRequestModel>();
            
          


            return AutoForm(model,nameof(SubmitRequest),"Submit maintenance request");
        }

        public ActionResult AssignRequest(string id)
        {
            var request = Service.Find<MaintenanceRequestViewModel>(id);
            var assignMaintenanceEditModel = new AssignMaintenanceEditModel()
            {
                Id = id,
                AssignedToId = request.AssignedToId,
                PossibleAssignees = _usersService.GetUsersInRole<UserLookupBindingModel>("Maintenance")
                    .OrderBy(p => p.Title).ToList()

            };
            Success("Work order has been assigned.");
            return AutoForm(assignMaintenanceEditModel,"AssignRequestSubmit", "Assign Maintenance Request");
        }


        [HttpPost]
        public ActionResult SubmitRequest(MaitenanceRequestModel model)
        {

            if (ModelState.IsValid)
            {

                var id = MaintenanceService.SubmitRequest(
                model.Comments,
                model.MaitenanceRequestTypeId,
                (int)model.PetStatus,
                model.Emergency,
                model.PermissionToEnter,
                null,
                Convert.ToInt32(model.UnitId), SubmittedVia.Portal);
                
                if (Request != null && Request.IsAjaxRequest())
                {
                    return JsonUpdate();
                }
                else
                {
                    return RedirectToAction("Details", new { id = id });
                }
            }


            return AutoForm(model, nameof(SubmitRequest), "Submit maintenance request");
        }


        public ActionResult AssignRequestSubmit(AssignMaintenanceEditModel model)
        {
            if (ModelState.IsValid && model.Id != null)
            {
                MaintenanceService.AssignRequest(Convert.ToInt32(model.Id), model.AssignedToId);
                Success("Your request has been submitted!");
                if (Request != null && Request.IsAjaxRequest())
                {
                    return JsonUpdate();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            Error("Oops! Request not submitted.  Please fix the errors and try again.");
            return AutoForm(model, "AssignRequestSubmit", "Assign Maintenance Request");
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
#if DEBUG
            model.StartDate = DateTime.Now.AddYears(-5);
            model.EndDate = DateTime.Now;
#endif
            if (UserContext.CurrentUser == null) // hack for caching the current user httpcontext.current is not available in thread
            {
                return RedirectToAction("MonthlyReport");
            }
            var httpContext = System.Web.HttpContext.Current;
            var result = GetReport(model);
            Thread thread = new Thread(() => { CreateDocument(result, httpContext); });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            var stream = new MemoryStream();
            _document.Save(stream);
            _document.Close(true);
            return File(stream.ToArray(), "application/pdf", $"MonthlyReport{model.StartDate.Value.Month}{model.StartDate.Value.Day}-{model.EndDate.Value.Month}{model.EndDate.Value.Day}.pdf");
        }

        private IQueryable<MaitenanceRequest> WorkOrdersByRange(DateTime? startDate, DateTime? endDate)
        {
            return Context.MaitenanceRequests.Where(p => p.SubmissionDate > startDate && p.SubmissionDate < endDate);
        }
        private IQueryable<MaintenanceRequestCheckin> CheckinsByRange(DateTime? startDate, DateTime? endDate)
        {
            return Context.MaintenanceRequestCheckins.Where(p => p.Date > startDate && p.Date < endDate);
        }


        public MaintenanceReportViewModel GetReport(MaintenanceReportModel model)
        {
            var result = new MaintenanceReportViewModel();
            var startDate = model.StartDate;
            var endDate = model.EndDate;
            if (startDate == null)
                startDate = CurrentUser.TimeZone.Now().Subtract(new TimeSpan(30, 0, 0, 0));

            if (endDate == null)
                endDate = CurrentUser.TimeZone.Now().AddDays(1);

            result.StartDate = startDate.Value;
            result.EndDate = endDate.Value;

            var todayEnd = CurrentUser.TimeZone.Now().AddDays(1);
            var todayStart = CurrentUser.TimeZone.Now();


            var StartDate = startDate;
            var EndDate = endDate;
            //var NumberEntered = WorkOrdersByRange(startDate, endDate).Count(p => p.StatusId == "Submitted");
            //var NumberOutstanding = WorkOrdersByRange(startDate, endDate).Count(p => p.StatusId != "Complete");
            //var NumberCompleted = WorkOrdersByRange(startDate, endDate).Count(p => p.StatusId == "Complete");

            //var MaintenanceTotalOutstanding = Context.MaitenanceRequests.Count(p => p.StatusId != "Complete");
            //var MaintenanceScheduledToday = Context.MaitenanceRequests.Count(p => p.ScheduleDate > todayStart && p.ScheduleDate < todayEnd && p.StatusId == "Scheduled");
            //var IncidentReportsTotalOutstanding = Context.IncidentReports.Count(x => x.StatusId != "Complete");

            var checkInList = CheckinsByRange(startDate, endDate).Where(p => p.StatusId == "Complete");
                            
            result.WorkOrdersPerEmployee = checkInList.GroupBy(p => p.Worker).ToArray();

            result.WorkOrdersPerUnit = checkInList.GroupBy(c => c.MaitenanceRequest.Unit.Name).ToArray();

            result.within24 = Context.MaitenanceRequests.GetAll()
                .Count(p => p.CompletionDate != null &&
                            p.SubmissionDate >= StartDate && p.SubmissionDate <= EndDate &&
                            DbFunctions.DiffHours(p.SubmissionDate, p.CompletionDate) <= 24
                            );
            result.within48 = Context.MaitenanceRequests.GetAll()
                                    .Count(p => p.CompletionDate != null &&
                                                p.SubmissionDate >= StartDate && p.SubmissionDate <= EndDate &&
                                                DbFunctions.DiffHours(p.SubmissionDate, p.CompletionDate) > 24 && DbFunctions.DiffHours(p.SubmissionDate, p.CompletionDate) <= 48
                                                );
            result.within72 = Context.MaitenanceRequests.GetAll()
                                  .Count(p => p.CompletionDate != null &&
                                              p.SubmissionDate >= StartDate && p.SubmissionDate <= EndDate &&
                                              DbFunctions.DiffHours(p.SubmissionDate, p.CompletionDate) > 48 && DbFunctions.DiffHours(p.SubmissionDate, p.CompletionDate) <= 72
                                              );

            result.greaterThan72 = Context.MaitenanceRequests.GetAll()
                    .Count(p => p.CompletionDate != null &&
                          p.SubmissionDate >= StartDate && p.SubmissionDate <= EndDate &&
                          DbFunctions.DiffHours(p.SubmissionDate, p.CompletionDate) > 72
                  );
            result.paused = Context.MaitenanceRequests.GetAll()
                 .Count(p => p.CompletionDate != null &&
               p.SubmissionDate >= StartDate && p.SubmissionDate <= EndDate && p.StatusId == "Paused"

               );
            result.completed = CheckinsByRange(startDate, endDate).Count(p => p.StatusId == "Complete");
            result.PropertyName = UserContext.CurrentUser.Property.Name;
            return result;
        }
        

        public void CreateDocument(MaintenanceReportViewModel model, HttpContext httpContext)
        {  
            var razorService = Kernel.Get<IRazorEngineService>();
            var templateType = model.GetType();
            var templateName = "MonthlyReport";   

            if (!razorService.IsTemplateCached(templateName, templateType))
            {
                razorService.AddTemplate(templateName,
                    LoadHtmlFile($"ApartmentApps.Portal.Views.MaitenanceRequests.{templateName}.cshtml"));
            }

            var reportHtml = razorService.RunCompile(templateName, templateType, model);
            if(!string.IsNullOrEmpty(reportHtml))
            {
                //inject css
                var baseUrl = string.Empty;
#if DEBUG
                baseUrl = $"{Request.Url.Scheme}://{Request.Url.Host}:{Request.Url.Port}";                
#else
                baseUrl = $"{Request.Url.Scheme}://{Request.Url.Host}";
#endif
                reportHtml = reportHtml.Replace("/Content/bootstrap.min.css", baseUrl + "/Content/bootstrap.min.css");
                reportHtml = reportHtml.Replace("/Content/style.css", baseUrl + "/Content/style.css");

                HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
                var reportMargins = new Syncfusion.Pdf.Graphics.PdfMargins();
                reportMargins.Top = 60;
                reportMargins.Left = 50;
                reportMargins.Right = 50;
                reportMargins.Bottom = 40;
                htmlConverter.ConverterSettings.Margin = reportMargins;
                _document = htmlConverter.Convert(reportHtml, string.Empty);
            }
        }

        private static string LoadHtmlFile(string resourceName)
        {
            using (Stream stream = typeof(MaitenanceRequestsController).Assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }

        //public override string ExportFileName
        //{
        //    get { return "MaintenanceRequests"; }
        //}

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
            Success("Work Order Paused.");
            return RedirectToAction("Details", new { id = request.Id });
        }

        [System.Web.Http.HttpPost]
        public ActionResult ScheduleRequest(MaintenanceScheduleRequestModel request)
        {
            if (!request.Date.HasValue)
            {
                Error("No Date was seleceted");
                return AutoForm(request, "ScheduleRequest");
                //throw new Exception("No date was selected.");
            }
           
            MaintenanceService.ScheduleRequest(
                CurrentUser,
                request.Id,
                request.Date.Value

                );

            Success("Work Order Scheduled");
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

            Success("Work Order Completed!");
            return RedirectToAction("Details", new { id = request.Id });
        }
        public ActionResult Print(string id)
        {
            var item = Service.Find<MaintenanceRequestViewModel>(id);
            return View(item);
        }

        public MaitenanceRequestsController(IKernel kernel, UserService usersService, MaintenanceService formService, MaintenanceService indexService, PropertyContext context, IUserContext userContext, MaintenanceService service) : base(kernel, formService, indexService, context, userContext, service)
        {
            _usersService = usersService;
            MaintenanceService = formService;
    
        }
    }

    public class MaintenanceReportViewModel
    {
        public IGrouping<ApplicationUser, MaintenanceRequestCheckin>[] WorkOrdersPerEmployee { get; set; }
        public IGrouping<string, MaintenanceRequestCheckin>[] WorkOrdersPerUnit { get; set; }
        public int within24 { get; set; }
        public int within48 { get; set; }
        public int within72 { get; set; }
        public int greaterThan72 { get; set; }
        public int paused { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int completed { get; set; }
        public string PropertyName { get; set; }
    }

    public class MaintenanceRequestOverviewViewModel
    {
        public IPagedList<MaintenanceRequestViewModel>  Requests { get; set; }
        public GridList<MaintenanceRequestViewModel> FeedItems { get; set; }
    }

    public class PaymentsRequestOverviewViewModel
    {
        public IPagedList<UserLeaseInfoBindingModel>  Requests { get; set; }
        public GridList<UserLeaseInfoBindingModel> FeedItems { get; set; }
    }

    public class AutoGridModel<TItem> : AutoGridModel
    {
        public AutoGridModel() : base()
        {
        }

       // public IEnumerable<TItem> ModelTyped => Model.Cast<TItem>();
    }
    public class AutoGridModel
    {
        private string _title;
        //public IEnumerable<object> Model { get; set; }
        //public IPaging Paging => Model as IPaging;

        public string Title
        {
            get { return _title ?? (_title = Type.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? Type.Name); }
            set { _title = value; }
        }
        public Type Type { get; set; }
        public AutoGridModel()
        {
            //Model = model;
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

}
