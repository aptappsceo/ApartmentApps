using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    /// <summary>
    /// Handles the syncronization of data between yardi and apartment apps.
    /// </summary>
    public class YardiIntegration : PropertyIntegrationAddon, IMaintenanceRequestCompletedEvent, IMaintenanceRequestPausedEvent, IMaintenanceSubmissionEvent
    {
        public override bool Filter(ApplicationUser user)
        {

            return user.Property.YardiInfo != null;
        }

        public void MaintenanceRequestCompleted(MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }

        public void MaintenanceRequestPaused(MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }

        public void MaintenanceRequestSubmited(MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }
    }
}