using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class AnalyticsItem : PropertyEntity
    {
        public int Year { get; set; }
        public int DayOfYear { get; set; }

        public int NumberMaintenanceRequests { get; set; }
        public int NumberIncidentReports { get; set; }
        public int NumberCheckins { get; set; }
        public int EngagementScore { get; set; }
        public int NumberMobileMaintenanceRequests { get; set; }
        public int NumberPortalMaintenanceRequests { get; set; }
        public int NumberSignedIntoApp { get; set; }
        public int NumberSignedIntoPortal { get; set; }
        public int NumberOfUnits { get; set; }
        public int NumberOfUnitsEngaging { get; set; }
        public int NumberMessagesSent { get; set; }
        public int UserCount { get; set; }
        public int UserEngagingCount { get; set; }
        public int NumberMaintenanceRequestsCompleted { get; set; }
        public int NumberMaintenanceRequestsPaused { get; set; }
        public int NumberMaintenanceRequestsSubmitted { get; set; }
        public int NumberMaintenanceRequestsStarted { get; set; }
    }
}