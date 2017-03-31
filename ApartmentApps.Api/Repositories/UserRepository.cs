using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using ApartmentApps.Api.DataSheets;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using Ninject;

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

    public class UserSearchEngine : SearchEngine<ApplicationUser>
    {

        public IQueryable<ApplicationUser> CommonSearch(IQueryable<ApplicationUser> set, string query)
        {
            var tokenized = Tokenize(query);
            if (tokenized.Length <= 0) return set;
            return
                set.Where(
                    _ =>
                        tokenized.Any(
                            token =>
                                    _.FirstName.Contains(token) || _.LastName.Contains(token) || _.Email.Contains(token)));
        }
    }
}