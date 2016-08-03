﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

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
        public IFeedSerivce FeedService { get; set; }
        // GET: Dashboard
        public DashboardController(IKernel kernel, PropertyContext context, IUserContext userContext, IFeedSerivce feedService) : base(kernel, context, userContext)
        {
            FeedService = feedService;
        }

        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
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
    }
}