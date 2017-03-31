using System;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class MaintenanceRepository : PropertyRepository<MaitenanceRequest>
    {
        private MaintenanceConfig _config;

        public MaintenanceRepository(IModuleHelper moduleHelper, Func<IQueryable<MaitenanceRequest>, IDbSet<MaitenanceRequest>> includes, DbContext context, IUserContext userContext) : base(moduleHelper, includes, context, userContext)
        {
        }

        public MaintenanceRepository(IModuleHelper moduleHelper, DbContext context, IUserContext userContext) : base(moduleHelper, context, userContext)
        {
        }

        public MaintenanceConfig Config => _config ?? (_config = UserContext.GetConfig<MaintenanceConfig>());

        public override IQueryable<MaitenanceRequest> GetAll()
        {
            var result = base.GetAll();
            
            if (Config.SupervisorMode)
            {
                if (UserContext.IsInRole("Admin") || UserContext.IsInRole("MaintenanceSupervisor") || UserContext.IsInRole("PropertyAdmin"))
                {
                    return result;
                }
                var id = UserContext.UserId;
                return result.Where(x => x.WorkerAssignedId == id);
            }
            return result;
        }

        public override IQueryable<MaitenanceRequest> Includes(IDbSet<MaitenanceRequest> set)
        {
            return set.Include(p => p.User).Include(p=>p.MaitenanceRequestType).Include(p=>p.Unit);
        }
    }

}