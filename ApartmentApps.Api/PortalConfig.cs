using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public class PortalConfig : ModuleConfig
    {
    }

    [Persistant]
    public class CompanySettingsConfig : ModuleConfig
    {
        public string PhoneNumber { get; set; }
    }
}