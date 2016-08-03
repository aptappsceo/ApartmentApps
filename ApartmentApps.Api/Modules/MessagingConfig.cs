using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class MessagingConfig : ModuleConfig
    {
        public string SendGridApiToken { get; set; }
    }
}