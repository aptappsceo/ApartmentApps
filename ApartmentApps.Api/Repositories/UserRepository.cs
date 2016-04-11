using System.Data.Entity;
using System.Linq;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class UserRepository : PropertyRepository<ApplicationUser>
    {
        public UserRepository(DbContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public override IQueryable<ApplicationUser> Includes(IDbSet<ApplicationUser> set)
        {
            return base.Includes(set);
        }
    }

    public class TenantRepository : PropertyRepository<Tenant>
    {
        public TenantRepository(DbContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public override IQueryable<Tenant> Includes(IDbSet<Tenant> set)
        {
            return base.Includes(set);
        }
    }
}