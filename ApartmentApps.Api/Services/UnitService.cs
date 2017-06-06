using System.Linq.Expressions;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Korzh.EasyQuery.Db;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class UnitService : StandardCrudService<Unit>
    {
        public UnitService(IKernel kernel, IRepository<Unit> repository) : base(kernel, repository)
        {
        }

        public override string DefaultOrderBy => "Name";
       
        //public override TViewModel CreateNew<TViewModel>()
        //{
        //    return new TViewModel() { };
        //}
        public DbQuery All()
        {
            return CreateQuery("All");
        }
    }
}