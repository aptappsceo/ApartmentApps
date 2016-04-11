using System.Data.Entity;
using System.Linq;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class MaintenanceRepository : PropertyRepository<MaitenanceRequest>
    {
        public MaintenanceRepository(DbContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public override IQueryable<MaitenanceRequest> Includes(IDbSet<MaitenanceRequest> set)
        {
            return set.Include(p => p.User).Include(p=>p.MaitenanceRequestType);
        }
    }
}