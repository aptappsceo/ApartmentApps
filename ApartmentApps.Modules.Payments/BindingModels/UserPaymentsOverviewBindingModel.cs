using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Modules.Payments.Services;

namespace ApartmentApps.Api.Modules
{
    public class UserPaymentsOverviewBindingModel
    {
        public UserBindingModel User { get; set; }
        public List<UserLeaseInfoBindingModel> LeaseInfos { get;set; }
        public List<InvoiceBindingModel> Invoices { get; set; }
        public List<TransactionHistoryItemBindingModel> Transactions { get; set; }
        public List<PaymentOptionBindingModel> PaymentOptions { get; set; }
    }
}