using System.Linq;
using ApartmentApps.Api.DataSheets;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using Ninject;

namespace ApartmentApps.Api
{
    public class UserDataSheet : BaseDataSheet<ApplicationUser>
    {
        public UserDataSheet(IUserContext userContext, ApplicationDbContext dbContext, IKernel kernel, ISearchCompiler searchCompiler) : base(userContext, dbContext, kernel, searchCompiler)
        {
        }

        public override object StringToPrimaryKey(string id)
        {
            return id;
        }

        protected override IQueryable<ApplicationUser> DefaultContextFilter(IQueryable<ApplicationUser> set)
        {
            return set.Where(user => user.PropertyId == this._userContext.PropertyId);
        }

        protected override IQueryable<ApplicationUser> DefaultOrderFilter(IQueryable<ApplicationUser> set, Query query = null)
        {
            return set.OrderBy(user => user.LastName).ThenBy(user => user.FirstName);
        }
    }
}