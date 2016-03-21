using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceRequestCheckinEvent
    {
        void MaintenanceRequestCheckin(ApplicationDbContext ctx, MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request);
    }

    public interface IIncidentReportCheckinEvent
    {
        void IncidentReportCheckin(ApplicationDbContext ctx, IncidentReportCheckin incidentReportCheckin, IncidentReport incidentReport);
    }
 
}