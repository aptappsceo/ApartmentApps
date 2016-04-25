using System.Data.Entity;
using System.Linq;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class IncidentReportRepository : PropertyRepository<IncidentReport>
    {
        public IncidentReportRepository(DbContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public override IQueryable<IncidentReport> Includes(IDbSet<IncidentReport> set)
        {
            return set.Include(p => p.IncidentReportStatus)
                .Include(p => p.Unit)
                .Include(p=> p.User)
                .Include(p => p.User.Unit)
                .Include(p => p.User.Unit.Building)
                .Include(p => p.Checkins);
        }
    }
}