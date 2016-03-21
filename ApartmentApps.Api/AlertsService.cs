using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ApartmentApps.Data;
using Microsoft.Azure.NotificationHubs;

namespace ApartmentApps.Api
{
    public interface IPushNotifiationHandler
    {
        Task<bool> SendToUser(string username, string message);
        Task<bool> SendToRole(int propertyId, string role, string message);


        Task<bool> Send( string message, string pns, string expression);
    }

    public class AzurePushNotificationHandler : IPushNotifiationHandler
    {
        public async Task<bool> SendToUser(string username, string message)
        {
            var pns = "apns";
            return await Send(message, pns, "userid:" + username);
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

    
        public async Task<bool> SendToRole(int propertyId, string role, string message)
        {
            var pns = "apns";
         
            return await Send(message, pns, $"propertyid:{propertyId} && role:{role}");

        }
    }

    /// <summary>
    /// This service is used to handle when push notifications should be sent out.
    /// </summary>
    public class AlertsService : IService, IMaintenanceSubmissionEvent, IMaintenanceRequestCheckinEvent
    {
        private IPushNotifiationHandler _pushHandler;

        public AlertsService(IPushNotifiationHandler pushHandler)
        {
            _pushHandler = pushHandler;
        }

        public void MaintenanceRequestSubmited(ApplicationDbContext ctx, MaitenanceRequest maitenanceRequest)
        {
            if (maitenanceRequest.User.PropertyId != null)
                SendAlert(ctx, maitenanceRequest.User.PropertyId.Value, "Maintenance", "New maintenance request has been created", maitenanceRequest.Message, "Maintenance", maitenanceRequest.Id);
            
        }

        public void MaintenanceRequestCheckin(ApplicationDbContext ctx, MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request)
        {
            if (request.User?.PropertyId != null)
            {
                SendAlert(ctx, request.User, $"Maintenance {maitenanceRequest.StatusId}", maitenanceRequest.Comments,"Maintenance", request.Id);
            }
        }

        public void SendAlert(ApplicationDbContext ctx,ApplicationUser user, string title, string message, string type, int relatedId = 0)
        {
            ctx.UserAlerts.Add(new UserAlert()
            {
                Title = title,
                Message = message,
                CreatedOn = user.Property.TimeZone.Now(),
                RelatedId = relatedId,
                Type = type,
                UserId = user.Id
            });
            ctx.SaveChanges();
            _pushHandler.SendToUser(user.Id, message);

        }
        public void SendAlert(ApplicationDbContext ctx, int propertyId, string role, string title, string message, string type, int relatedId = 0)
        {
            foreach (var item in ctx.Users.Include(p=>p.Property).Where(x => x.PropertyId == propertyId && x.Roles.Any(p => p.RoleId == role)))
            {
                ctx.UserAlerts.Add(new UserAlert()
                {
                    Title = title,
                    Message = message,
                    CreatedOn = item.TimeZone.Now(),
                    RelatedId = relatedId,
                    Type = type,
                    UserId = item.Id
                });
            }
            
            ctx.SaveChanges();
            _pushHandler.SendToRole(propertyId, role, title);

        }
    }




}