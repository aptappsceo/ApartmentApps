using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.DataSheets
{
    public class BasePropertyDataSheet<TModel> : BaseDataSheet<TModel> where TModel : class, IPropertyEntity
    {

        protected override IQueryable<TModel> DefaultOrderFilter(IQueryable<TModel> set, Query query = null)
        {
            return set.OrderBy(s => s.CreateDate);
        }

        protected override IQueryable<TModel> DefaultContextFilter(IQueryable<TModel> set)
        {
            return set.Where(_ => _.PropertyId == _userContext.PropertyId);
        }

        public BasePropertyDataSheet(IUserContext userContext, ApplicationDbContext dbContext, IKernel kernel, ISearchCompiler searchCompiler) : base(userContext, dbContext, kernel, searchCompiler)
        {
        }
    }
}
