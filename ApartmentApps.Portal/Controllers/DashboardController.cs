using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Data;

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
    }

    public class DashboardController : AAController
    {
        // GET: Dashboard
       
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var currentPropertyId = CurrentUser.PropertyId;
            if (startDate == null)
                startDate = DateTime.UtcNow.Subtract(new TimeSpan(30, 0, 0, 0));
            if (endDate == null)
                endDate = DateTime.UtcNow;

            return View(new DashboardBindingModel {
                StartDate = startDate,
                EndDate = endDate,
                NumberEntered = WorkOrdersByRange(startDate, endDate, currentPropertyId).Count(p=>p.StatusId == "Submitted"),
                NumberOutstanding = WorkOrdersByRange(startDate, endDate, currentPropertyId).Count(p=>p.StatusId != "Complete"),
                NumberCompleted = WorkOrdersByRange(startDate, endDate, currentPropertyId).Count(p=>p.StatusId == "Complete"),
                Entered = WorkOrdersByRange(startDate, endDate, currentPropertyId).Where(p => p.StatusId == "Submitted"),
                Outstanding = WorkOrdersByRange(startDate, endDate, currentPropertyId).Where(p => p.StatusId != "Complete"),
                Completed = WorkOrdersByRange(startDate, endDate, currentPropertyId).Where(p => p.StatusId == "Complete"),
                WorkOrdersPerEmployee = WorkOrdersByRange(startDate, endDate, currentPropertyId).GroupBy(p=>p.User)
            });
        }

        private IQueryable<MaitenanceRequest> WorkOrdersByRange(DateTime? startDate, DateTime? endDate, int? currentPropertyId)
        {
            return db.MaitenanceRequests.Where(p=>p.SubmissionDate > startDate && p.SubmissionDate < endDate && p.User.PropertyId == currentPropertyId);
        }
    }
}