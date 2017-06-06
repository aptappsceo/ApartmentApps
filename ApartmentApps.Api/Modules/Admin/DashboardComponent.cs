using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api.Modules
{
    public abstract class DashboardComponent<TResultViewModel> : PortalComponent<TResultViewModel>
        where TResultViewModel : ComponentViewModel
    {
        //public IKernel Kernel { get; }
        public AnalyticsModule Analytics { get; set; }
        public ApplicationDbContext Context { get; }
        public IUserContext UserContext { get; }
        public DashboardContext DashboardContext { get; set; }


        public IRepository<TItem> Repo<TItem>() where TItem : class, IBaseEntity
        {
            return Analytics.Repo<TItem>(DashboardContext);
        }

        protected DashboardComponent(AnalyticsModule analytics, ApplicationDbContext dbContext, IUserContext userContext)
        {
            //Kernel = kernel;
            Analytics = analytics;
            Context = dbContext;
            UserContext = userContext;
        }


    }
}