using System;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Korzh.EasyQuery.Db;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class PropertyService : StandardCrudService<Property>
    {
        public PropertyService(IKernel kernel, IRepository<Property> repository) : base(kernel, repository)
        {
        }

        public override string DefaultOrderBy =>"Name";

        [UserQuery("Engaging")]
        public IQueryable<Property> EngagingProperties()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            return Repository.Include(x=>x.MaitenanceRequests).Where(
                p => p.MaitenanceRequests.Any(x => x.SubmissionDate.Month == month && x.SubmissionDate.Year == year));
        }


        public DbQuery All()
        {
            return CreateQuery("All", new ConditionItem("Property.State","Equal","0"));
        }

        public DbQuery Suspended()
        {
            return CreateQuery("Suspended", new ConditionItem("Property.State", "Equal", "1"));
        }
        public DbQuery Archived()
        {
            return CreateQuery("Archived", new ConditionItem("Property.State", "Equal", "2"));
        }
    }
}