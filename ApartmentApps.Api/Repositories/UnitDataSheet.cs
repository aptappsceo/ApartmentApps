using System.Linq;
using ApartmentApps.Api.DataSheets;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using Ninject;

namespace ApartmentApps.Api
{
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
}