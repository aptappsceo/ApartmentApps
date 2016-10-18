using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Ninject;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Db;
using DbQuery = Korzh.EasyQuery.Db.DbQuery;

namespace ApartmentApps.Modules.Payments
{
    public class PaymentsRequestsService : StandardCrudService<UserLeaseInfo>
    {

        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
        public PropertyContext Context { get; set; }

        public PaymentsRequestsService(PropertyContext propertyContext, IRepository<UserLeaseInfo> repository, IBlobStorageService blobStorageService, IUserContext userContext, IKernel kernel) : base(kernel, repository)
        {
            Context = propertyContext;
        }


#region Queries

        public DbQuery Active()
        {
            return this.CreateQuery("Submitted", new ConditionItem("UserLeaseInfo.State", "Equal", "Active"));
        }

        public DbQuery Archived()
        {
            return this.CreateQuery("Archived", new ConditionItem("UserLeaseInfo.State", "Equal", "Paused"));
        }

#endregion


    }
}
