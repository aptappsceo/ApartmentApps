using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceRequestPausedEvent
    {
        void MaintenanceRequestPaused(MaitenanceRequest maitenanceRequest);
    }
}