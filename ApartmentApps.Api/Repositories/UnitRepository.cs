using System.Data.Entity;
using System.Linq;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class UnitRepository : PropertyRepository<Unit>
    {
        public UnitRepository(DbContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public override IQueryable<Unit> Includes(IDbSet<Unit> set)
        {
            return set.Include(p => p.Building);
        }
    }
}