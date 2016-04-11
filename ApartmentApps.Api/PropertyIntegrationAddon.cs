using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public abstract class PropertyIntegrationAddon : IService, IApartmentAppsAddon, IAddonFilter
    {
        public IUserContext UserContext { get; set; }

        protected PropertyIntegrationAddon(IUserContext userContext)
        {
            UserContext = userContext;
        }

        public abstract bool Filter();

    }
}