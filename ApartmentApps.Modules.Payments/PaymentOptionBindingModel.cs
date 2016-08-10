using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public class PaymentOptionBindingModel
    {
        public string FriendlyName { get; set; }
        public PaymentOptionType Type { get; set; }
        public int Id { get; set; }
    }
}