using System;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using Ninject;

namespace ApartmentApps.Api.Services
{
    public class LookupService
    {
        private readonly IKernel _kernel;

        public LookupService(IKernel kernel)
        {
            _kernel = kernel;
        }

        public QueryResult<LookupBindingModel> GetLookups(Type type, string search)
        {
            var datasheetType = typeof(IDataSheet<>).MakeGenericType(type);
            var datasheet = this._kernel.Get(datasheetType);
            var queryMethod = datasheetType.GetMethod("Query");
            var obj = queryMethod.Invoke(datasheet, new[] {search});
            var get = obj.GetType().GetMethods().First(p=>p.ContainsGenericParameters && p.Name == "Get").MakeGenericMethod(typeof(LookupBindingModel));
            return ((QueryResult<LookupBindingModel>) get.Invoke (obj, null));
        }
    }
}