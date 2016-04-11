using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
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
        public IQueryable<IGrouping<ApplicationUser, MaitenanceRequest>> WorkOrdersPerEmployee { get; set; }
        public int IncidentReportsNew { get; set; }
        public int IncidentReportsOutstanding { get; set; }
        public int IncidentReportsComplete { get; set; }
    }

    public class DashboardController : AAController
    {
        // GET: Dashboard
        public DashboardController(PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
          
            if (startDate == null)
                startDate = CurrentUser.TimeZone.Now().Subtract(new TimeSpan(30, 0, 0, 0));

            if (endDate == null)
                endDate = CurrentUser.TimeZone.Now().AddDays(1);

            return View("Index2", new DashboardBindingModel {
                StartDate = startDate,
                EndDate = endDate,
                NumberEntered = WorkOrdersByRange(startDate, endDate).Count(p=>p.StatusId == "Submitted"),
                NumberOutstanding = WorkOrdersByRange(startDate, endDate).Count(p=>p.StatusId != "Complete"),
                NumberCompleted = WorkOrdersByRange(startDate, endDate).Count(p=>p.StatusId == "Complete"),
                IncidentReportsNew = IncidentsByRange(startDate, endDate).Count(p=>p.StatusId == "Reported"),
                IncidentReportsOutstanding = IncidentsByRange(startDate, endDate).Count(p=>p.StatusId != "Reported" && p.StatusId != "Complete"),
                IncidentReportsComplete = IncidentsByRange(startDate, endDate).Count(p=>p.StatusId == "Complete"),

                //Entered = WorkOrdersByRange(startDate, endDate, currentPropertyId).Where(p => p.StatusId == "Submitted"),
                //Outstanding = WorkOrdersByRange(startDate, endDate, currentPropertyId).Where(p => p.StatusId != "Complete"),
                //Completed = WorkOrdersByRange(startDate, endDate, currentPropertyId).Where(p => p.StatusId == "Complete"),
                //WorkOrdersPerEmployee = WorkOrdersByRange(startDate, endDate, currentPropertyId).GroupBy(p=>p.User)
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
    }
}