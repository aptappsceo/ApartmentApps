using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;

namespace ApartmentApps.Api.Modules
{
    public class UserPaymentsOverviewBindingModel
    {
        public UserBindingModel User { get; set; }
        public List<UserLeaseInfo> LeaseInfos { get;set; }
        public List<Invoice> Invoices { get; set; }
    }
}