using System.Collections.Generic;
using System.Linq;

namespace ApartmentApps.Api.Modules
{
    public class MakePaymentBindingModel
    {
        public string PaymentOptionId { get; set; }
        public string UserId { get; set; }
    }

    public class PaymentListBindingModel
    {
        private List<PaymentLineBindingModel> _items;

        public List<PaymentLineBindingModel> Items
        {
            get { return _items ?? (_items = new List<PaymentLineBindingModel>()); }
            set { _items = value; }
        }

        public bool IsEmpty
        {
            get { return Items.All(s => s.Format != PaymentSummaryFormat.Default); }
        }

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