using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [ModuleConfiguration]
    public class PaymentsConfig : ModuleConfig
    {
        public PaymentsConfig()
        {
            Name = "Payments";
        }

        public bool UseUrl { get; set; }
        public string Url { get; set; }

    }
}