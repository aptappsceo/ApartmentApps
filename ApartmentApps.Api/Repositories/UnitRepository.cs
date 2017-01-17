using System.Data.Entity;
using System.Linq;
using ApartmentApps.Api.DataSheets;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using Ninject;

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

    public class UnitDataSheet : BasePropertyDataSheet<Unit>
    {
        public UnitDataSheet(IUserContext userContext, ApplicationDbContext dbContext, IKernel kernel, ISearchCompiler searchCompiler) : base(userContext, dbContext, kernel, searchCompiler)
        {

        }

        protected override IQueryable<Unit> DefaultOrderFilter(IQueryable<Unit> set, Query query = null)
        {
            return set.OrderByDescending(req => req.Id);
        }
    }

    public class UnitSearchEngine : SearchEngine<Unit>
    {

        [Filter(nameof(CommonSearch),"Search",EditorTypes.TextField)]
        public IQueryable<Unit> CommonSearch(IQueryable<Unit> set, string query)
        {
            var tokenized = Tokenize(query);
            if (tokenized.Length <= 0) return set;
            return set.Where(unit => tokenized.Any(token => unit.Name.Contains(token) || unit.Users.Any(user=>user.FirstName.Contains(token) || user.LastName.Contains(token))));
        }

    }
}