using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class AnalyticsConfig : GlobalModuleConfig
    {
        public int EngagementNumberOfDays { get; set; }
    }
}