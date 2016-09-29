using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceRequestCheckinEvent
    {
        void MaintenanceRequestCheckin( MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request);
    }

    public interface IMaintenanceRequestAssignedEvent
    {
        void MaintenanceRequestAssigned(MaitenanceRequest request);
    }
}