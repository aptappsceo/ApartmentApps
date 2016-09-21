using System.Collections.Generic;

namespace ApartmentApps.Api.Modules
{
    public class MakePaymentBindingModel
    {
        public string PaymentOptionId { get; set; }
    }

    public class PaymentListBindingModel
    {
        public List<PaymentLineBindingModel> Items { get; set; } 
    }

    public class PaymentLineBindingModel
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public PaymentSummaryFormat Format { get; set; }
    }

    public enum PaymentSummaryFormat
    {
        Default,
        Discount,
        Total
    }
}