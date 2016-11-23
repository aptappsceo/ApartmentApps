using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.Modules
{
    public class PaymentOptionBindingModel : BaseViewModel
    {
        public UserBindingModel User { get; set; }
        public string FriendlyName { get; set; }
        public PaymentOptionType Type { get; set; }
    }
}