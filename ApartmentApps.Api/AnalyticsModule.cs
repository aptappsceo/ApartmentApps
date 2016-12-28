using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class AnalyticsConfig : GlobalModuleConfig
    {
        public int EngagementNumberOfDays { get; set; }
    }

    [Persistant]
    public class AnalyticsItem : PropertyEntity
    {
        public int Year { get; set; }
        public int DayOfYear { get; set; }

        public int NumberMaintenanceRequests { get; set; }
        public int NumberIncidentReports { get; set; }
        public int NumberCheckins { get; set; }
        public int EngagementScore { get; set; }
        public int NumberMobileMaintenanceRequests { get; set; }
        public int NumberPortalMaintenanceRequests { get; set; }
        public int NumberSignedIntoApp { get; set; }
        public int NumberSignedIntoPortal { get; set; }
        public int NumberOfUnits { get; set; }
        public int NumberOfUnitsEngaging { get; set; }
        public int NumberMessagesSent { get; set; }
        public int UserCount { get; set; }
        public int UserEngagingCount { get; set; }
        public int NumberMaintenanceRequestsCompleted { get; set; }
        public int NumberMaintenanceRequestsPaused { get; set; }
        public int NumberMaintenanceRequestsSubmitted { get; set; }
        public int NumberMaintenanceRequestsStarted { get; set; }
    }
    public class AnalyticsModule : Module<AnalyticsConfig>, IWebJob
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRepository<AnalyticsItem> _analyticsItemRepo;

        public AnalyticsModule(ApplicationDbContext dbContext, IRepository<AnalyticsItem> analyticsItemRepo, IKernel kernel, IRepository<AnalyticsConfig> configRepo, IUserContext userContext) : base(kernel, configRepo, userContext)
        {
            _dbContext = dbContext;
            _analyticsItemRepo = analyticsItemRepo;
        }

        //public IEnumerable<Tuple<Property, int>> GetAllScores()
        //{
        //    foreach (var item in (new BaseRepository<Property>(_dbContext)).Include(x => x.Corporation).ToArray())
        //    {
        //        if (item.State != PropertyState.Active) continue;

        //        var propertyId = item.Id;
        //        yield return new Tuple<Property, int>(item, GetEngagementScore(propertyId));
        //    }
        //}
        //public int GetEngagementScore(int propertyId)
        //{
        //    var activeBefore = DateTime.UtcNow.Subtract(new TimeSpan(90, 0, 0, 0));
        //    var mr = (new BaseRepository<MaitenanceRequest>(_dbContext)).Count(p => p.PropertyId == propertyId && p.SubmissionDate > activeBefore);
        //    return mr;
        //}

        public IRepository<TItem> Repo<TItem>(DashboardContext context = DashboardContext.Property) where TItem : class, IBaseEntity
        {
            if (context == DashboardContext.All || !typeof(IPropertyEntity).IsAssignableFrom(typeof(TItem)))
            {
                return new BaseRepository<TItem>(_dbContext);
            }
            else if (context == DashboardContext.Coorperation)
            {
                var corpId = UserContext.CurrentUser.Property.Corporation.Id;
                var newType = typeof(PropertyRepository<>).MakeGenericType(typeof(TItem));
                return ((IRepository<TItem>)Activator.CreateInstance(newType, Kernel.Get<IModuleHelper>(), _dbContext, UserContext));
                //return new PropertyRepository<TItem>(_dbContext, UserContext);
                //var corpId = UserContext.CurrentUser.Property.Corporation.Id;
                //return new PropertyRepository<TItem>(Context, UserContext).Include(p=>p.Property).Include(p=>p.Property.Corporation).Where(p=>p.Property.CorporationId == corpId);
            }
            else
            {
                var newType = typeof(PropertyRepository<>).MakeGenericType(typeof(TItem));
                return (IRepository<TItem>)Activator.CreateInstance(newType, Kernel.Get<IModuleHelper>(), _dbContext, UserContext);
            }
        }
        public TimeSpan Frequency { get; }
        public int JobStartHour { get; }
        public int JobStartMinute { get; }
        public void Execute(ILogger logger)
        {
            //var userRepo = Repo<ApplicationUser>();
            //foreach (var user in userRepo.ToArray())
            //{
            //    if (user.LastMobileLoginTime == null)
            //    {
            //        var mr = Repo<MaitenanceRequest>().FirstOrDefault(p => p.UserId == user.Id);
            //        if (mr != null)
            //        {
            //            user.LastMobileLoginTime = mr.SubmissionDate;
            //            userRepo.Save();
            //        }
            //        var ir = Repo<IncidentReport>().FirstOrDefault(p => p.UserId == user.Id);
            //        if (ir != null)
            //        {
            //            user.LastMobileLoginTime = ir.CreatedOn;
            //            userRepo.Save();
            //        }

            //    }
            //}

            var startDate = DateTime.UtcNow.Subtract(new TimeSpan(Config.EngagementNumberOfDays, 0, 0, 0));
            var year = DateTime.UtcNow.Year;
            var day = DateTime.UtcNow.DayOfYear;

            var analyticsItem = _analyticsItemRepo.FirstOrDefault(p=>p.Year == year && p.DayOfYear == day) ?? new AnalyticsItem()
            {
                CreateDate = DateTime.UtcNow,
                Year = DateTime.UtcNow.Year,
                DayOfYear = DateTime.UtcNow.DayOfYear
            };

            var mrRepo = Kernel.Get<IRepository<MaitenanceRequest>>();
            analyticsItem.NumberOfUnits = Repo<Unit>().Count();
            analyticsItem.UserCount = Repo<ApplicationUser>().Count(x=>!x.Archived);
            analyticsItem.UserEngagingCount = Repo<ApplicationUser>().Count(x =>!x.Archived && (x.LastMobileLoginTime != null || x.LastPortalLoginTime != null));

            analyticsItem.NumberMaintenanceRequestsCompleted = mrRepo.Count(p => p.SubmissionDate > startDate && p.CompletionDate != null);
            analyticsItem.NumberMaintenanceRequestsPaused = mrRepo.Count(p => p.SubmissionDate > startDate && p.StatusId == "Paused");
            analyticsItem.NumberMaintenanceRequestsSubmitted = mrRepo.Count(p => p.SubmissionDate > startDate && p.StatusId == "Submitted");
            analyticsItem.NumberMaintenanceRequestsStarted = mrRepo.Count(p => p.SubmissionDate > startDate && p.StatusId == "Started");


            analyticsItem.NumberOfUnitsEngaging = mrRepo.Where(p=>p.SubmissionDate > startDate && p.User.Roles.Any(x=>x.RoleId == "Resident")).GroupBy(x => x.UnitId).Count();
            analyticsItem.NumberMaintenanceRequests = mrRepo.Count(p => p.SubmissionDate > startDate);
            analyticsItem.NumberIncidentReports = Repo<IncidentReport>().Count(x => x.CreatedOn > startDate);
            analyticsItem.NumberMobileMaintenanceRequests =
                mrRepo.Count(x => (x.SubmittedVia == SubmittedVia.Mobile || x.SubmittedVia == SubmittedVia.MobileAndroid || x.SubmittedVia == SubmittedVia.MobileIPhone) && x.SubmissionDate > startDate);
            analyticsItem.NumberPortalMaintenanceRequests =
                mrRepo.Count(x => (x.SubmittedVia == SubmittedVia.Portal) && x.SubmissionDate > startDate);

            analyticsItem.NumberSignedIntoApp =
                Repo<ApplicationUser>().Count(p => p.LastMobileLoginTime != null && p.LastMobileLoginTime > startDate);

            analyticsItem.NumberSignedIntoPortal =
                Repo<ApplicationUser>().Count(p => p.LastPortalLoginTime != null && p.LastPortalLoginTime > startDate);
            //analyticsItem.NumberMessagesSent =
            //    Repo<Message>().Count(p => p.LastPortalLoginTime != null && p.LastPortalLoginTime > startDate);

            // The engagement score calculation
            analyticsItem.EngagementScore = analyticsItem.NumberMaintenanceRequests + analyticsItem.NumberIncidentReports;
            

            ModuleHelper.SignalToEnabled<IApplyAnalytics>(x=>x.ApplyAnalytics(this,analyticsItem,startDate));
            if (analyticsItem.Id < 1)
            _analyticsItemRepo.Add(analyticsItem);
            _analyticsItemRepo.Save();
        }



        public int AnalyticForContext(DashboardContext context, Func<AnalyticsItem, int> selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            if (context == DashboardContext.All)
            {
                var items = AllPropertiesAnalytics(context).ToArray();
                return items.Sum(selector);
            }
            else
            {
                var analyticsForProperty = AnalyticsForProperty(UserContext.PropertyId);
                if (analyticsForProperty != null)
                return selector(analyticsForProperty);
                return 0;
            }
        }

        public AnalyticsItem AnalyticsForProperty(int propertyId)
        {
            var year = DateTime.UtcNow.Year;
            var repo = Repo<AnalyticsItem>(DashboardContext.All)
                .Include(p=>p.Property)
                .Include(p=>p.Property.Corporation)
                .Where(p=>p.PropertyId == propertyId && p.Year == year)
                .OrderByDescending(x=>x.DayOfYear)
                .FirstOrDefault()
                ;
            return repo;
        }

        protected override AnalyticsConfig CreateDefaultConfig()
        {
            return new AnalyticsConfig()
            {
                EngagementNumberOfDays = 30,
                Enabled = true
            };
        }
        public IEnumerable<AnalyticsItem> AllPropertiesAnalytics(DashboardContext context)
        {
            foreach (var item in Repo<Property>(context).ToArray())
            {
                if (item.State != PropertyState.Active) continue;
                var a = AnalyticsForProperty(item.Id);
                if (a != null)
                    yield return a;

            }
        }
    }

    public interface IApplyAnalytics
    {
        void ApplyAnalytics(AnalyticsModule module, AnalyticsItem analyticsItem, DateTime startDate);
    }
}