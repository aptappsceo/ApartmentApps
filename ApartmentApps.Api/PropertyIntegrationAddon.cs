using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api
{
    public abstract class PropertyIntegrationAddon : IService, IApartmentAppsAddon, IAddonFilter
    {
        private readonly Property _property;
        public IUserContext UserContext { get; set; }

        protected PropertyIntegrationAddon(Property property, IUserContext userContext)
        {
            _property = property;
            UserContext = userContext;
        }

        public abstract bool Filter();

        //public abstract object GetSettingsModel();

        //public abstract void SaveSettingsModel(object obj);
    }
}