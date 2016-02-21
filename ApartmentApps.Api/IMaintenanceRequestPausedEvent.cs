using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceRequestCheckinEvent
    {
        void MaintenanceRequestCheckin(MaintenanceRequestCheckin maitenanceRequest);
    }
 
}