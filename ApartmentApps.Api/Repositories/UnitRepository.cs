using System.Data.Entity;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class UnitRepository : PropertyRepository<Unit>
    {
        public UnitRepository(DbContext context, IUserContext userContext, IModuleHelper moduleHelper) : base(moduleHelper,context, userContext)
        {
        }

        public override IQueryable<Unit> Includes(IDbSet<Unit> set)
        {
            return set.Include(p => p.Building).Include(p=>p.Users);
        }
    }
}