using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class MaintenanceConfig : ModuleConfig
    {
        public bool SupervisorMode { get; set; }
    }
}