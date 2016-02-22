using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    /// <summary>
    /// This service is used to handle when push notifications should be sent out.
    /// </summary>
    public class PushNotificationsService : IService, IMaintenanceRequestCompletedEvent, IMaintenanceSubmissionEvent, IMaintenanceRequestCheckinEvent
    {
        public void MaintenanceRequestCompleted(MaitenanceRequest maitenanceRequest)
        {

        }

        public void MaintenanceRequestPaused(MaitenanceRequest maitenanceRequest)
        {

        }

        public void MaintenanceRequestSubmited(MaitenanceRequest maitenanceRequest)
        {

        }

        public void MaintenanceRequestCheckin(MaintenanceRequestCheckin maitenanceRequest)
        {
            
        }
    }
}