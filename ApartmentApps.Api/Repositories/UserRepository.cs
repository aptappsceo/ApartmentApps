using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class UserRepository : PropertyRepository<ApplicationUser>
    {
        public UserRepository(DbContext context, IUserContext userContext, IModuleHelper moduleHelper) : base(moduleHelper, context, userContext)
        {
        }

        public override IQueryable<ApplicationUser> GetAll()
        {
            return base.GetAll();//.Where(p=>!p.Archived);
        }

        public override IQueryable<ApplicationUser> Includes(IDbSet<ApplicationUser> set)
        {
            return base.Includes(set);
        }
    }
}