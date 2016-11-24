using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ClientServices;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{

    public class UserFeedBindingModel
    {
        public UserBindingModel User { get; set; }
        public List<FeedItemBindingModel> MaintenanceCheckins { get; set; }
        public List<FeedItemBindingModel> IncidentCheckings { get; set; }
        public List<FeedItemBindingModel> MaintenanceRequests { get; set; }
        public List<FeedItemBindingModel> IncidentReports { get; set; }
        public List<FeedItemBindingModel> CourtesyCheckins { get; set; }

        public bool HasIncidentsSubmitted => IncidentReports?.Any() ?? false;
        public bool HasMaintenanceRequestsSubmitted => MaintenanceRequests?.Any() ?? false;
        public bool HasIncidentsCheckins => IncidentCheckings?.Any() ?? false;
        public bool HasMaintenanceChekins => MaintenanceCheckins?.Any() ?? false;
        public bool HasCourtesyCheckins=> CourtesyCheckins?.Any() ?? false;

    }

    public class DashboardBindingModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int NumberEntered { get; set; }
        public int NumberOutstanding { get; set; }
        public int NumberCompleted { get; set; }
        public IQueryable<MaitenanceRequest> Entered { get; set; }
        public IQueryable<MaitenanceRequest> Outstanding { get; set; }
        public IQueryable<MaitenanceRequest> Completed { get; set; }
        public object[] WorkOrdersPerEmployee { get; set; }
        public int IncidentReportsNew { get; set; }
        public int IncidentReportsOutstanding { get; set; }
        public int IncidentReportsComplete { get; set; }
        public int MaintenanceTotalOutstanding { get; set; }
        public int IncidentReportsTotalOutstanding { get; set; }
        public int MaintenanceScheduledToday { get; set; }
        public IEnumerable<FeedItemBindingModel> FeedItems { get; set; }
    }

    public class DashboardController : AAController
    {
        private ApplicationUserManager _userManager;
        public IFeedSerivce FeedService { get; set; }
        // GET: Dashboard
        public DashboardController(IKernel kernel, PropertyContext context, IUserContext userContext, IFeedSerivce feedService, IBlobStorageService blobStorageService) : base(kernel, context, userContext)
        {
            FeedService = feedService;
            BlobStorageService = blobStorageService;
        }

        public IBlobStorageService BlobStorageService { get; set; }
        
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            //var listComponents = new List<DashboardComponentViewModel>();
           // EnabledModules.Signal<IDashboardComponentProvider>(c=>c.PopulateComponents(listComponents));

            return View("Index3");

            if (CurrentUser == null)
            {
                return RedirectToAction("Login","Account");
            }
            if (startDate == null)
                startDate = CurrentUser.TimeZone.Now().Subtract(new TimeSpan(30, 0, 0, 0));

            if (endDate == null)
                endDate = CurrentUser.TimeZone.Now().AddDays(1);
            
            var todayEnd = CurrentUser.TimeZone.Now().AddDays(1);
            var todayStart = CurrentUser.TimeZone.Now();

            return View("Index2", new DashboardBindingModel {
                StartDate = startDate,
                EndDate = endDate,
                NumberEntered = WorkOrdersByRange(startDate, endDate).Count(p=>p.StatusId == "Submitted"),
                NumberOutstanding = WorkOrdersByRange(startDate, endDate).Count(p=>p.StatusId != "Complete"),
                NumberCompleted = WorkOrdersByRange(startDate, endDate).Count(p=>p.StatusId == "Complete"),
                IncidentReportsNew = IncidentsByRange(startDate, endDate).Count(p=>p.StatusId == "Reported"),
                IncidentReportsOutstanding = IncidentsByRange(startDate, endDate).Count(p=>p.StatusId != "Reported" && p.StatusId != "Complete"),
                IncidentReportsComplete = IncidentsByRange(startDate, endDate).Count(p=>p.StatusId == "Complete"),
                MaintenanceTotalOutstanding = Context.MaitenanceRequests.Count(p=>p.StatusId != "Complete"),
                MaintenanceScheduledToday = Context.MaitenanceRequests.Count(p=> p.StatusId == "Scheduled" && p.ScheduleDate > todayStart && p.ScheduleDate < todayEnd ),
                IncidentReportsTotalOutstanding = Context.IncidentReports.Count(x=>x.StatusId != "Complete"),
                FeedItems = FeedService.GetAll(),
                //Entered = WorkOrdersByRange(startDate, endDate, currentPropertyId).Where(p => p.StatusId == "Submitted"),
                //Outstanding = WorkOrdersByRange(startDate, endDate, currentPropertyId).Where(p => p.StatusId != "Complete"),
                //Completed = WorkOrdersByRange(startDate, endDate, currentPropertyId).Where(p => p.StatusId == "Complete"),
                WorkOrdersPerEmployee = CheckinsByRange(startDate, endDate).Where(p=>p.StatusId == "Complete")
                    .GroupBy(p=>p.Worker)
                    .Select(p=>new { label = p.Key.FirstName + " " + p.Key.LastName, data = p.Count() })
                    .ToArray()
            });
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public ActionResult UserFeed(string id)
        {
            ApplicationUser user;

            if (string.IsNullOrEmpty(id))
            {
                user = CurrentUser;
            }
            else
            {
                user = Context.Users.Find(id);

                if (user == null)
                {
                    return new HttpNotFoundResult("User Not Found");
                }

            }

            //If user is courtesy officer: add info about incident checkins
            //If user is maintenance add info about maintenance checking

            var mt = Context.MaitenanceRequests.Where(r=>r.UserId == user.Id).ToList();
            var ir = Context.IncidentReports.Where(r => r.UserId == user.Id).ToList();
            var coc = Context.CourtesyOfficerCheckins.Where(r=>r.OfficerId == user.Id).ToList();
            var irc = Context.IncidentReportCheckins.Where(r=>r.OfficerId == user.Id).ToList();
            var mrc = Context.MaintenanceRequestCheckins.Where(r=>r.WorkerId == user.Id).ToList();

            return View(new UserFeedBindingModel()
            {
                User = user.ToUserBindingModel(BlobStorageService),
                MaintenanceRequests = mt.Select(FeedService.ToFeedItemBindingModel)
                                        .OrderByDescending(_=>_.CreatedOn)
                                        .ToList(),
                IncidentReports = ir.Select(FeedService.ToFeedItemBindingModel)
                                    .OrderByDescending(_ => _.CreatedOn)
                                    .ToList(),
                CourtesyCheckins = coc.Select(FeedService.ToFeedItemBindingModel)
                                        .OrderByDescending(_ => _.CreatedOn)
                                        .ToList(),
                IncidentCheckings = irc.Select(FeedService.ToFeedItemBindingModel)
                                        .OrderByDescending(_ => _.CreatedOn)
                                        .ToList(),
                MaintenanceCheckins = mrc.Select(FeedService.ToFeedItemBindingModel)
                                        .OrderByDescending(_ => _.CreatedOn)
                                        .ToList()
            });
        }

        private IQueryable<IncidentReport> IncidentsByRange(DateTime? startDate, DateTime? endDate)
        {
            return Context.IncidentReports.Where(p => p.CreatedOn > startDate && p.CreatedOn < endDate);
        }

        private IQueryable<MaitenanceRequest> WorkOrdersByRange(DateTime? startDate, DateTime? endDate)
        {
            return Context.MaitenanceRequests.Where(p=>p.SubmissionDate > startDate && p.SubmissionDate < endDate);
        }

        private IQueryable<MaintenanceRequestCheckin> CheckinsByRange(DateTime? startDate, DateTime? endDate)
        {
            return Context.MaintenanceRequestCheckins.Where(p => p.Date > startDate && p.Date < endDate);
        }

        private IQueryable<IncidentReportCheckin> IncidentCheckinsByRange(DateTime? startDate, DateTime? endDate)
        {
            return Context.IncidentReportCheckins.Where(p => p.CreatedOn > startDate && p.CreatedOn < endDate);
        }
    }
}