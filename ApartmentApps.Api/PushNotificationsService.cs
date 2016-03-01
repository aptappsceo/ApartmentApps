using System;
using System.Threading.Tasks;
using ApartmentApps.Data;
using Microsoft.Azure.NotificationHubs;

namespace ApartmentApps.Api
{
    public interface IPushNotifiationHandler
    {
        Task<bool> SendToUser(string username, string message);
        void SendToRole(string role);


    }

    public class AzurePushNotificationHandler : IPushNotifiationHandler
    {
        public async Task<bool> SendToUser(string username, string message)
        {
            var user = username;
            string[] userTag = new string[1];
            userTag[0] = "userid:" + username;
            //userTag[1] = "from:" + user;
            var pns = "apns";
            return await SendToTags(message, pns, userTag);
        }

        private static async Task<bool> SendToTags(string message, string pns, string[] userTag)
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
                    outcome = await Notifications.Instance.Hub.SendWindowsNativeNotificationAsync(toast, userTag);
                    break;
                case "apns":
                    // iOS
                    var alert = "{\"aps\":{\"alert\":\"" +  message + "\"}}";
                    outcome = await Notifications.Instance.Hub.SendAppleNativeNotificationAsync(alert, userTag);
                    break;
                case "gcm":
                    // Android
                    var notif = "{ \"data\" : {\"message\":\""  + message + "\"}}";
                    outcome = await Notifications.Instance.Hub.SendGcmNativeNotificationAsync(notif, userTag);
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

        public void SendToRole(string role)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// This service is used to handle when push notifications should be sent out.
    /// </summary>
    public class PushNotificationsService : IService, IMaintenanceRequestCompletedEvent, IMaintenanceSubmissionEvent, IMaintenanceRequestCheckinEvent
    {
        private IPushNotifiationHandler _pushHandler;

        public PushNotificationsService(IPushNotifiationHandler pushHandler)
        {
            _pushHandler = pushHandler;
        }
        public void MaintenanceRequestCompleted(MaitenanceRequest maitenanceRequest)
        {

        }


        public void MaintenanceRequestSubmited(MaitenanceRequest maitenanceRequest)
        {
            _pushHandler.SendToUser(maitenanceRequest.UserId, "New maintenance request has been created");
        }

        public void MaintenanceRequestCheckin(MaintenanceRequestCheckin maitenanceRequest)
        {
            _pushHandler.SendToUser(maitenanceRequest.MaitenanceRequest.UserId, $"Maintenance {maitenanceRequest.StatusId}");
        }
    }
}