using System.ComponentModel;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class PaymentsConfig : ModuleConfig
    {
        public PaymentsConfig()
        {
           
        }
        [DisplayName("Use Url?")]
        public bool UseUrl { get; set; }

        [DisplayName("Url")]
        public string Url { get; set; }

    }
}