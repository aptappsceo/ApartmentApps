using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceRequestStartedEvent
    {
        void MaintenanceRequestStarted(MaitenanceRequest maitenanceRequest);
    }
}