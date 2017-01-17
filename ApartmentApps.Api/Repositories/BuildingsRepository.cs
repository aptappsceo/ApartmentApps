using System.Data.Entity;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class BuildingsRepository : PropertyRepository<Building>
    {
        public BuildingsRepository(IModuleHelper moduleHelper, DbContext context, IUserContext userContext) : base(moduleHelper,context, userContext)
        {
        }
    }
}