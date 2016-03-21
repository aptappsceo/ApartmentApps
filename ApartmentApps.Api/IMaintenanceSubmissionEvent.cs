using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceSubmissionEvent
    {
        void MaintenanceRequestSubmited(ApplicationDbContext ctx, MaitenanceRequest maitenanceRequest);
    }
    public interface IIncidentReportSubmissionEvent
    {
        void IncidentReportSubmited(ApplicationDbContext ctx, IncidentReport incidentReport);
    }
}