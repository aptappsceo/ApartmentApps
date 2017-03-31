using System;
using System.ComponentModel;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class MessagingConfig : PropertyModuleConfig
    {
        public string SendGridApiToken { get; set; }
        [DisplayName("Send From Email")]
        public string SendFromEmail { get; set; } = "noreply@apartmentapps.com";

        public bool FullLogging { get; set; }
        
        public string Template { get; set; }

        public string LogoImageUrl { get; set; }


    }


}