using System.Data.Entity;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class BuildingsRepository : PropertyRepository<Building>
    {
        public BuildingsRepository(DbContext context, IUserContext userContext) : base(context, userContext)
        {
        }
    }
}