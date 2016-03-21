using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    /// <summary>
    /// Handles the syncronization of data between yardi and apartment apps.
    /// </summary>
    public class YardiIntegration : PropertyIntegrationAddon, IMaintenanceRequestCheckinEvent, IMaintenanceSubmissionEvent
    {
        public override bool Filter(ApplicationUser user)
        {

            return user.Property.YardiInfo != null;
        }

        public void MaintenanceRequestSubmited(ApplicationDbContext ctx, MaitenanceRequest maitenanceRequest)
        {
            // Sync with entrata on work order
        }

        public void MaintenanceRequestCheckin(ApplicationDbContext ctx, MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request)
        {
            
        }
    }
}