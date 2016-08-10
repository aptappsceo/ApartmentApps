using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceSubmissionEvent
    {
        void MaintenanceRequestSubmited( MaitenanceRequest maitenanceRequest);
    }
}