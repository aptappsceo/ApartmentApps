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