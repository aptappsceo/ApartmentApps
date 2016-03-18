using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceRequestCheckinEvent
    {
        void MaintenanceRequestCheckin(MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request);
    }

    public interface IIncidentReportCheckinEvent
    {
        void IncidentReportCheckin(IncidentReportCheckin incidentReportCheckin, IncidentReport incidentReport);
    }
 
}