using System.Linq.Expressions;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Korzh.EasyQuery.Db;
using Microsoft.AspNet.Identity;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class BuildingService : StandardCrudService<Building>
    {
        public BuildingService(IKernel kernel, IRepository<Building> repository) : base(kernel, repository)
        {
        }

        public override string DefaultOrderBy => "Name";
        public DbQuery All()
        {
            return CreateQuery("All");
        }
    }
}