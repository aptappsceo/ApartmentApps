using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public abstract class PropertyIntegrationAddon : IService, IApartmentAppsAddon, IAddonFilter
    {
        public abstract bool Filter(ApplicationUser user);

    }
}