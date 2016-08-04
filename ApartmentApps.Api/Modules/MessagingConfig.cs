using System.ComponentModel;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class MessagingConfig : ModuleConfig
    {
        public string SendGridApiToken { get; set; }
        [DisplayName("Send From Email")]
        public string SendFromEmail { get; set; } = "noreply@apartmentapps.com";

        public bool FullLogging { get; set; }
    }
}