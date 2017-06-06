using System.Text;
using Entrata.Model.Requests;
using Microsoft.AspNet.Identity;
using Microsoft.Data.OData.Query.SemanticAst;

//using Yardi.Client.ResidentData;
//using Yardi.Client.ResidentTransactions;

namespace ApartmentApps.Api
{
    public static class Extensions
    {
        public static string NumbersOnly(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            var strBuilder = new StringBuilder();
            foreach (var c in str)
            {
                if (char.IsDigit(c))
                {
                    strBuilder.Append(c);
                }
            }
            return strBuilder.ToString();
        }
    }

    ///// <summary>
    ///// Handles the synchronization of entrata and apartment apps.
    ///// </summary>
    //public class EntrataIntegration : 
    //    PropertyIntegrationAddon, 
    //    IMaintenanceSubmissionEvent, 
    //    IMaintenanceRequestCheckinEvent,
    //    IDataImporter
    //{

    //    public ApplicationDbContext Context { get; set; }
    //    public PropertyContext PropertyContext { get; set; }

    //    public EntrataIntegration(Property property, ApplicationDbContext context,PropertyContext propertyContext, IUserContext userContext) : base(property, userContext)
    //    {
    //        Context = context;
    //        PropertyContext = propertyContext;
    //    }

    //    public override bool Filter()
    //    {
    //        return PropertyContext.PropertyEntrataInfos.Any();
    //    }

     

    //    public void MaintenanceRequestSubmited( MaitenanceRequest maitenanceRequest)
    //    {
    //        // Sync with entrata on work order
    //    }

    //    public void MaintenanceRequestCheckin(MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request)
    //    {
            
    //    }

    //}
}