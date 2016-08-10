using System.Collections.Generic;

namespace ApartmentApps.Api.Modules
{
    public class PaymentSummaryBindingModel
    {
        public int BaseRent { get; set; }
        public List<PaymentSummaryBindingModel> SummaryOptions { get; set; }
    }
}