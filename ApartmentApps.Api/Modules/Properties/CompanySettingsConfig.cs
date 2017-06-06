using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class CompanySettingsConfig : PropertyModuleConfig
    {
        public string PhoneNumber { get; set; }
    }
}