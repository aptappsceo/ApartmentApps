using System;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class MaintenanceRepository : PropertyRepository<MaitenanceRequest>
    {
        public MaintenanceRepository(IModuleHelper moduleHelper, Func<IQueryable<MaitenanceRequest>, IDbSet<MaitenanceRequest>> includes, DbContext context, IUserContext userContext) : base(moduleHelper, includes, context, userContext)
        {
        }

        public MaintenanceRepository(IModuleHelper moduleHelper, DbContext context, IUserContext userContext) : base(moduleHelper, context, userContext)
        {
        }

        public override IQueryable<MaitenanceRequest> Includes(IDbSet<MaitenanceRequest> set)
        {
            return set.Include(p => p.User).Include(p=>p.MaitenanceRequestType).Include(p=>p.Unit);
        }
    }

}