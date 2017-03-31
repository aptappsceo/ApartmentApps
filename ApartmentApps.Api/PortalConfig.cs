using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public class PortalConfig : PropertyModuleConfig
    {
    }

    [Persistant]
    public class CompanySettingsConfig : PropertyModuleConfig
    {
        public string PhoneNumber { get; set; }
    }
}