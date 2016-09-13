using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;

namespace ApartmentApps.Api.Modules
{
    public class UserPaymentsOverviewBindingModel
    {
        public UserBindingModel User { get; set; }
        public List<UserLeaseInfoBindingModel> LeaseInfos { get;set; }
        public List<InvoiceBindingModel> Invoices { get; set; }
        public List<TransactionBindingModel> Transactions { get; set; }
        public List<PaymentOptionBindingModel> PaymentOptions { get; set; }
    }
}