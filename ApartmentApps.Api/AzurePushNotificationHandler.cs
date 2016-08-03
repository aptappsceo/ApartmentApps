using System.Threading.Tasks;

namespace ApartmentApps.Api
{
    public class AzurePushNotificationHandler : IPushNotifiationHandler
    {
        public async Task<bool> SendToUser(string username, string message)
        {
            await Send(message, "gcm", "userid:" + username);
            return await Send(message, "apns", "userid:" + username);
        }

        public async  Task<bool> SendToUser(string username, NotificationPayload payload)
        {
            await Send(payload, "gcm", "userid:" + username);
            return await Send(payload, "apns", "userid:" + username);
        }

        public async Task<bool> Send(string message, string pns, string expression)
        {
            Microsoft.Azure.NotificationHubs.NotificationOutcome outcome = null;
            //HttpStatusCode ret = HttpStatusCode.InternalServerError;
            //Notifications.Instance.Hub.SendNotificationAsync(new TemplateNotification())
            switch (pns.ToLower())
            {
                case "wns":
                    // Windows 8.1 / Windows Phone 8.1
                    var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" +
                                message + "</text></binding></visual></toast>";
                    outcome = await Notifications.Instance.Hub.SendWindowsNativeNotificationAsync(toast, expression);
                    break;
                case "apns":
                    // iOS
                    var alert = "{\"aps\":{\"alert\":\"" +  message + "\"}}";
                    outcome = await Notifications.Instance.Hub.SendAppleNativeNotificationAsync(alert, expression);
                    break;
                case "gcm":
                    // Android
                    var notif = "{ \"data\" : {\"message\":\""  + message + "\"}}";
                    outcome = await Notifications.Instance.Hub.SendGcmNativeNotificationAsync(notif, expression);
                    break;
            }
            if (outcome != null)
            {
                if (!((outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Abandoned) ||
                      (outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Unknown)))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Send(NotificationPayload payload, string pns, string expression)
        {
            Microsoft.Azure.NotificationHubs.NotificationOutcome outcome = null;
            switch (pns.ToLower())
            {
                case "wns":
                    // Windows 8.1 / Windows Phone 8.1
                    var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" +
                                "stub" + "</text></binding></visual></toast>";
                    outcome = await Notifications.Instance.Hub.SendWindowsNativeNotificationAsync(toast, expression);
                    break;
                case "apns":
                    // iOS
                    outcome = await Notifications.Instance.Hub.SendAppleNativeNotificationAsync(payload.ToANPSJson().ToString(), expression);
                    break;
                case "gcm":
                    outcome = await Notifications.Instance.Hub.SendGcmNativeNotificationAsync(payload.ToGCMJson().ToString(), expression);
                    break;
            }
            if (outcome != null)
            {
                if (!((outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Abandoned) ||
                      (outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Unknown)))
                {
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> SendToRole(int propertyId, string role, string message)
        {
            var pns = "apns";
         
            //
            await Send(message, "gcm", $"propertyid:{propertyId} && role:{role}");
            return await Send(message, pns, $"propertyid:{propertyId} && role:{role}");
        }

        public async Task<bool> SendToRole(int propertyId, string role, NotificationPayload payload)
        {
            var pns = "apns";
         
            //
            await Send(payload, "gcm", $"propertyid:{propertyId} && role:{role}");
            return await Send(payload, pns, $"propertyid:{propertyId} && role:{role}");
        }
    }
}