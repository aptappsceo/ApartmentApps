using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceRequestCompletedEvent
    {
        void MaintenanceRequestCompleted(MaitenanceRequest maitenanceRequest);
    }
    public interface IMaintenanceRequestStartedEvent
    {
        void MaintenanceRequestStarted(MaitenanceRequest maitenanceRequest);
    }
}