using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.Modules
{
    public class DashboardLastLoginByRole : DashboardComponent<DashboardStatViewModel>
    {
        public DashboardLastLoginByRole(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
        }

        public override DashboardStatViewModel ExecuteResult()
        {
            var users = Repo<ApplicationUser>().Include(x=>x.Roles).FirstOrDefault(p => p.Roles.Any(x => x.RoleId == RoleId) && p.Roles.All(x => x.RoleId != "Admin"));
            if (users != null && users.ActiveOnMobile && users.LastMobileLoginTime != null)
            {
                return new DashboardStatViewModel()
                {
                    Title = $"{RoleId}",
                    Value = users.FirstName + " " + users.LastName,
                    Subtitle = $"Activity on mobile {users.LastMobileLoginTime.Value.ToShortDateString()}"
                };
            } else if (users != null && users.LastPortalLoginTime != null)
            {
                return new DashboardStatViewModel()
                {
                    Title = $"{RoleId}",
                    Value = users.FirstName + " " + users.LastName,
                    Subtitle = $"Activity on portal {users.LastPortalLoginTime.Value.ToShortDateString()}"
                };
            }
            return new DashboardStatViewModel()
            {
                Title = $"Last Login By {RoleId}",
                Value = (users == null ? "Not Setup" : users.FirstName + " " + users.LastName),
                Subtitle = $"No Activity Yet"
            };

        }

        public class UserViewModel
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string PhoneNumber { get; set; }
        }
        public string RoleId { get; set; }
    }
    public class DashboardNumberWorkOrders : DashboardComponent<DashboardStatViewModel>
    {


        public override DashboardStatViewModel ExecuteResult()
        {
            return new DashboardStatViewModel()
            {
                Title = "Work Orders",
                Subtitle = $"In the past {Analytics.Config.EngagementNumberOfDays} days.",
                Value = Analytics.AnalyticForContext(DashboardContext, x => x.NumberMaintenanceRequests).ToString()
            };
        }

        public DashboardNumberWorkOrders(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
        }
    }
    public class DashboardNumberMessages : DashboardComponent<DashboardStatViewModel>
    {


        public override DashboardStatViewModel ExecuteResult()
        {
            return new DashboardStatViewModel()
            {
                Title = "Messages Sent",
                Subtitle = $"In the past {Analytics.Config.EngagementNumberOfDays} days.",
                Value = Analytics.AnalyticForContext(DashboardContext, x => x.NumberMessagesSent).ToString()
            };
        }

        public DashboardNumberMessages(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
        }
    }
    public class DashboardNumberIncidentReports : DashboardComponent<DashboardStatViewModel>
    {


        public override DashboardStatViewModel ExecuteResult()
        {
            return new DashboardStatViewModel()
            {
                Title = "Number of Incident Reports",
                Subtitle = $"In the past {Analytics.Config.EngagementNumberOfDays} days.",
                Value = Analytics.AnalyticForContext(DashboardContext, x => x.NumberIncidentReports).ToString()
            };
        }

        public DashboardNumberIncidentReports(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
        }
    }
    public class DashboardNumberCheckins : DashboardComponent<DashboardStatViewModel>
    {


        public override DashboardStatViewModel ExecuteResult()
        {
            return new DashboardStatViewModel()
            {
                Title = "Number of Work Orders",
                Subtitle = $"In the past {Analytics.Config.EngagementNumberOfDays}",
                Value = Analytics.AnalyticForContext(DashboardContext, x => x.NumberIncidentReports).ToString()
            };
        }

        public DashboardNumberCheckins(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
        }
    }
   
    public class DashboardPropertyEngagementScoreList : DashboardComponent<DashboardGridViewModel>
    {
        public override DashboardGridViewModel ExecuteResult()
        {
            var activeProperties = Analytics.AllPropertiesAnalytics(DashboardContext).OrderByDescending(p => p.EngagementScore).Select(x => new EngagementScore() { Corporation = x.Property.Corporation.Name, Name = x.Property.Name, Value = x.EngagementScore.ToString() });
            return new DashboardGridViewModel(typeof(EngagementScore), activeProperties)
            {
                Title = "Property Engagement Scoring",
            };
        }


        public class EngagementScore
        {
            public string Corporation { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public DashboardPropertyEngagementScoreList(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
        }
    }
    //public class DashboardEngagingPropertiesList : DashboardComponent<DashboardGridViewModel>
    //{

    //    public override DashboardGridViewModel ExecuteResult()
    //    {

    //       // var activeBefore = DateTime.UtcNow.Subtract(new TimeSpan(7, 0, 0, 0));
    //        var activeProperties = Analytics.GetAllScores().Where(p => p.Item2 > 0).Select(x=>new EngagementScore() {Name = x.Item1.Name});
    //        return new DashboardGridViewModel(typeof(EngagementScore), activeProperties)
    //        {
    //            Title = "Engaging Properties (Last 7 Days)"
    //        };
    //    }
    //    public class EngagementScore
    //    {
    //        public string Name { get; set; }
    //    }

    //    public DashboardEngagingPropertiesList(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
    //    {
    //    }
    //}



    public class DashboardEngagingProperties : DashboardComponent<DashboardPieViewModel>
    {
        private readonly IRepository<Property> _propertyRepo;

        public DashboardEngagingProperties(AnalyticsModule analytics, IRepository<Property> propertyRepo, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
            _propertyRepo = propertyRepo;
        }

        public override DashboardPieViewModel ExecuteResult()
        {
            //var activeBefore = DateTime.UtcNow.Subtract(new TimeSpan(7, 0, 0, 0));
            var activeProperties = Analytics.AllPropertiesAnalytics(DashboardContext).ToArray();
            var active = activeProperties.Count(x => x.EngagementScore > 0);
            var inActive = activeProperties.Count() - active;

            return new DashboardPieViewModel("Engaging Properties", "Properties actively using", 1,
                    new DashboardPieViewModel.ChartData() { label = "Active", data = active },
                    new DashboardPieViewModel.ChartData() { label = "In-Active", data = inActive })
            {
                Stretch = "col-md-6",
                //ListData = activeProperties.Select(p=> new EngagementScore() { Name = p.Item1.Name, Score = p.Item2})
            };
        }


    }
    public class DashboardEngagingUnits : DashboardComponent<DashboardPieViewModel>
    {
        private readonly IRepository<Property> _propertyRepo;

        public DashboardEngagingUnits(AnalyticsModule analytics, IRepository<Property> propertyRepo, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
            _propertyRepo = propertyRepo;
        }

        public override DashboardPieViewModel ExecuteResult()
        {
            //var activeBefore = DateTime.UtcNow.Subtract(new TimeSpan(7, 0, 0, 0));
            var activeProperties = Analytics.AllPropertiesAnalytics(DashboardContext).ToArray();
            var active = activeProperties.Count(x => x.EngagementScore > 0);
            var inActive = activeProperties.Count() - active;

            return new DashboardPieViewModel("Engaging Properties", "Properties actively using", 1,
                    new DashboardPieViewModel.ChartData() { label = "Active", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberOfUnits) },
                    new DashboardPieViewModel.ChartData() { label = "In-Active", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberOfUnitsEngaging) })
            {
                Stretch = "col-md-6",
                //ListData = activeProperties.Select(p=> new EngagementScore() { Name = p.Item1.Name, Score = p.Item2})
            };
        }


    }
    public class DashboardAppVsPortal : DashboardComponent<DashboardPieViewModel>
    {
        private readonly IRepository<Property> _propertyRepo;

        public DashboardAppVsPortal(AnalyticsModule analytics, IRepository<Property> propertyRepo, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
            _propertyRepo = propertyRepo;
        }

        public override DashboardPieViewModel ExecuteResult()
        {
            //var activeBefore = DateTime.UtcNow.Subtract(new TimeSpan(7, 0, 0, 0));


            return new DashboardPieViewModel(
                "Mobile Vs Portal Activity", "", 1,
                    new DashboardPieViewModel.ChartData()
                    { label = "Portal", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberSignedIntoPortal) },
                    new DashboardPieViewModel.ChartData()
                    { label = "Mobile", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberSignedIntoApp) })
            {
                Stretch = "col-md-6",
                //ListData = activeProperties.Select(p=> new EngagementScore() { Name = p.Item1.Name, Score = p.Item2})
            };
        }


    }
    public class DashboardMaitenanceByUser : DashboardComponent<DashboardPieViewModel>
    {
        private readonly IRepository<Property> _propertyRepo;

        public DashboardMaitenanceByUser(AnalyticsModule analytics, IRepository<Property> propertyRepo, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
            _propertyRepo = propertyRepo;
        }

        public override DashboardPieViewModel ExecuteResult()
        {
            var start = DateTime.UtcNow.Subtract(new TimeSpan(Analytics.Config.EngagementNumberOfDays, 0, 0, 0));

            return new DashboardPieViewModel("Maintenance By User", $"Last {Analytics.Config.EngagementNumberOfDays} Days", 3,
                CheckinsByRange(start, DateTime.UtcNow).Where(p => p.StatusId == "Complete")
                    .GroupBy(p => p.Worker)
                    .Select(
                        p =>
                            new DashboardPieViewModel.ChartData()
                            {
                                label = p.Key.FirstName + " " + p.Key.LastName,
                                data = p.Count()
                            })
                    .ToArray())
            {
                Row = 1,
                Stretch = "col-md-12",
                Title = "Complete",

                Subtitle = "Last 30 Days"
            };
            //return new DashboardPieViewModel(
            //    "Mobile Vs Portal Users", "Units Engaging", 1,
            //        new DashboardPieViewModel.ChartData()
            //        { label = "Portal", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberSignedIntoPortal) },
            //        new DashboardPieViewModel.ChartData()
            //        { label = "Mobile", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberSignedIntoApp) })
            //{
            //    Stretch = "col-md-6",
            //    //ListData = activeProperties.Select(p=> new EngagementScore() { Name = p.Item1.Name, Score = p.Item2})
            //};
        }
        private IQueryable<MaintenanceRequestCheckin> CheckinsByRange(DateTime? startDate, DateTime? endDate)
        {
            var mrc = Repo<MaintenanceRequestCheckin>();
            return mrc.Where(p => p.Date > startDate && p.Date < endDate);
        }

        private IQueryable<MaitenanceRequest> WorkOrdersByRange(DateTime? startDate, DateTime? endDate)
        {
            return Repo<MaitenanceRequest>().Where(p => p.SubmissionDate > startDate && p.SubmissionDate < endDate);
        }

    }
    public class DashboardUsersEngaging : DashboardComponent<DashboardPieViewModel>
    {
        private readonly IRepository<Property> _propertyRepo;

        public DashboardUsersEngaging(AnalyticsModule analytics, IRepository<Property> propertyRepo, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
            _propertyRepo = propertyRepo;
        }

        public override DashboardPieViewModel ExecuteResult()
        {
            //var activeBefore = DateTime.UtcNow.Subtract(new TimeSpan(7, 0, 0, 0));


            var model =  new DashboardPieViewModel(
                "Users Engaging", $"All Time", 1,
                    new DashboardPieViewModel.ChartData()
                    { label = "Not Engaging", data = Analytics.AnalyticForContext(DashboardContext, x => x.UserCount -x.UserEngagingCount) },
                    new DashboardPieViewModel.ChartData()
                    { label = "Engaging", data = Analytics.AnalyticForContext(DashboardContext, x => x.UserEngagingCount) })
            {
                Stretch = "col-md-6",
                //ListData = activeProperties.Select(p=> new EngagementScore() { Name = p.Item1.Name, Score = p.Item2})
            };
            return model;
        }


    }
    public class DashboardUnitsEngaging : DashboardComponent<DashboardPieViewModel>
    {
        private readonly IRepository<Property> _propertyRepo;

        public DashboardUnitsEngaging(AnalyticsModule analytics, IRepository<Property> propertyRepo, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
            _propertyRepo = propertyRepo;
        }

        public override DashboardPieViewModel ExecuteResult()
        {
            //var activeBefore = DateTime.UtcNow.Subtract(new TimeSpan(7, 0, 0, 0));


            return new DashboardPieViewModel(
                "Users Engaging", $"Last {Analytics.Config.EngagementNumberOfDays} Days", 1,
                    new DashboardPieViewModel.ChartData()
                    { label = "Active", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberOfUnits) },
                    new DashboardPieViewModel.ChartData()
                    { label = "In-Active", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberOfUnitsEngaging) })
            {
                Stretch = "col-md-6",
                //ListData = activeProperties.Select(p=> new EngagementScore() { Name = p.Item1.Name, Score = p.Item2})
            };
        }


    }
    public class DashboardMaintenancePortalVsApp : DashboardComponent<DashboardPieViewModel>
    {
        private readonly IRepository<Property> _propertyRepo;

        public DashboardMaintenancePortalVsApp(AnalyticsModule analytics, IRepository<Property> propertyRepo, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
            _propertyRepo = propertyRepo;
        }

        public override DashboardPieViewModel ExecuteResult()
        {
            //var activeBefore = DateTime.UtcNow.Subtract(new TimeSpan(7, 0, 0, 0));


            return new DashboardPieViewModel(
                "Work Orders App Vs Portal", $"Last {Analytics.Config.EngagementNumberOfDays} Days", 1,
                    new DashboardPieViewModel.ChartData()
                    { label = "Mobile", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberMobileMaintenanceRequests) },
                    new DashboardPieViewModel.ChartData()
                    { label = "Portal", data = Analytics.AnalyticForContext(DashboardContext, x => x.NumberPortalMaintenanceRequests) })
            {
                Stretch = "col-md-6",
                //ListData = activeProperties.Select(p=> new EngagementScore() { Name = p.Item1.Name, Score = p.Item2})
            };
        }


    }

    public class DashboardEngagementOverTime : DashboardComponent<LineChartViewModel>
    {
        public DashboardEngagementOverTime(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
        }

        public override LineChartViewModel ExecuteResult()
        {
            return new LineChartViewModel()
            {

                datasets = new List<LineChartViewModel.LineChartDataSet>()
                {

                    new LineChartViewModel.LineChartDataSet()
                    {
                        label="User Engage Count",
                        data = Analytics.AllAnalytics(this.DashboardContext,7).Select(x=>new int[] { x.DayOfYear, x.UserEngagingCount}).ToList()
                    },   new LineChartViewModel.LineChartDataSet()
                    {
                        label="User Engage Count",
                        data = Analytics.AllAnalytics(this.DashboardContext,7).Select(x=>new int[] { x.DayOfYear, x.UserCount}).ToList()
                    }
                }
            };
        }
    }
    public class DashboardTotalIncome : DashboardComponent<DashboardStatViewModel>
    {


        public override DashboardStatViewModel ExecuteResult()
        {
            return new DashboardStatViewModel()
            {
                Title = "Income Per Month",
                Value = "$" + Repo<Unit>().Count(p => p.Property.State == PropertyState.Active),
                Subtitle = "Based on $1 per unit."
            };
        }

        public DashboardTotalIncome(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext) : base(analytics, dbContext, userContext)
        {
        }
    }

}