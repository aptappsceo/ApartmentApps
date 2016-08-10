using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceRequestCompletedEvent
    {
        void MaintenanceRequestCompleted(MaitenanceRequest maitenanceRequest);
    }
}