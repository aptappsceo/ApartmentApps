using Microsoft.Azure.NotificationHubs;

namespace ApartmentApps.Api
{
    public class Notifications
    {
        public static Notifications Instance = new Notifications();

        public NotificationHubClient Hub { get; set; }

        private Notifications()
        {
            Hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://aptappspush.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=lgyPVVBGNiXNhKDFt5rb+1sG1DoVu+Bhydspa4fIYMo=",
                "apartmentapps");
        }
    }
}