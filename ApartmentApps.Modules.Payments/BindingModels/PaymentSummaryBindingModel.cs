using System.Collections.Generic;

namespace ApartmentApps.Api.Modules
{
    public class PaymentSummaryBindingModel
    {
        public decimal Amount { get; set; }
        public string Title { get; set; }
        public List<PaymentSummaryBindingModel> SummaryOptions { get; set; }
    }
}