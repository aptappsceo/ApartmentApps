using System.Linq;
using ApartmentApps.Api.DataSheets;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using Ninject;

namespace ApartmentApps.Api
{
    public class IncidentsDataSheet : BasePropertyDataSheet<IncidentReport>
    {
        public IncidentsDataSheet(IUserContext userContext, ApplicationDbContext dbContext, IKernel kernel, ISearchCompiler searchCompiler) : base(userContext, dbContext, kernel, searchCompiler)
        {
        }

        protected override IQueryable<IncidentReport> DefaultOrderFilter(IQueryable<IncidentReport> set, Query query = null)
        {

            return set.OrderBy(p => p.CreatedOn);
            //return base.DefaultOrderFilter(set, query);
        }
    }
}