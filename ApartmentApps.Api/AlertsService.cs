using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Api
{
    public interface IFeedSerivce
    {
        IEnumerable<FeedItemBindingModel> GetAll();
    }

    public class FeedSerivce : IFeedSerivce
    {
        public IBlobStorageService BlobStorageService { get; set; }
        private readonly PropertyContext _context;

        public FeedSerivce(PropertyContext context, IBlobStorageService blobStorageService)
        {
            BlobStorageService = blobStorageService;
            _context = context;
        }

        public IEnumerable<FeedItemBindingModel> GetAll()
        {
            foreach (var feedItemBindingModel in FeedItemBindingModels().OrderByDescending(p=>p.CreatedOn)) yield return feedItemBindingModel;
        }

        private IEnumerable<FeedItemBindingModel> FeedItemBindingModels()
        {
            foreach (var item in _context.CourtesyOfficerCheckins.OrderByDescending(p => p.CreatedOn).Take(10).Cast<IFeedItem>()
                )
            {
                yield return ToFeedItemBindingModel(item);
            }
            foreach (var item in _context.IncidentReportCheckins.OrderByDescending(p => p.CreatedOn).Take(10).Cast<IFeedItem>())
            {
                yield return ToFeedItemBindingModel(item);
            }
            foreach (var item in _context.MaintenanceRequestCheckins.OrderByDescending(p => p.Date).Take(10).Cast<IFeedItem>())
            {
                yield return ToFeedItemBindingModel(item);
            }
        }

        private FeedItemBindingModel ToFeedItemBindingModel(IFeedItem item)
        {
            return new FeedItemBindingModel()
            {
                User = item.User.ToUserBindingModel(BlobStorageService),
                CreatedOn = item.CreatedOn,
                Message = item.Message,
                Photos = BlobStorageService.GetImages(item.GroupId).ToArray(),
                Description = item.Description
            };
        }
    }


    public interface IPushNotifiationHandler
    {
        Task<bool> SendToUser(string username, string message);
        Task<bool> SendToUser(string username, NotificationPayload payload);
        Task<bool> SendToRole(int propertyId, string role, string message);
        Task<bool> SendToRole(int propertyId, string role, NotificationPayload payload);
        Task<bool> Send( string message, string pns, string expression);
        Task<bool> Send( NotificationPayload payload, string pns, string expression);
    }

    public class NotificationPayload
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Semantic { get; set; } = "Default"; //App decides about icon based on semantic
        public string Action { get; set; }
        public int DataId { get; set; }
        public string DataType { get; set; }
    }

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

    /// <summary>
    /// This service is used to handle when push notifications should be sent out.
    /// </summary>
    public class AlertsService : IService, IMaintenanceSubmissionEvent, IMaintenanceRequestCheckinEvent, IIncidentReportSubmissionEvent, IIncidentReportCheckinEvent
    {
        public PropertyContext Context { get; set; }
        private readonly IIdentityMessageService _emailService;
        private IPushNotifiationHandler _pushHandler;

        public AlertsService(IIdentityMessageService emailService, IPushNotifiationHandler pushHandler, PropertyContext context)
        {
            Context = context;
            _emailService = emailService;
            _pushHandler = pushHandler;
        }

        public void MaintenanceRequestSubmited( MaitenanceRequest maitenanceRequest)
        {
            if (maitenanceRequest.User.PropertyId != null)
                SendAlert(maitenanceRequest.User.PropertyId.Value, "Maintenance", "New maintenance request has been created", maitenanceRequest.Message, "Maintenance", maitenanceRequest.Id);
            
        }

        public void MaintenanceRequestCheckin( MaintenanceRequestCheckin maitenanceRequest, MaitenanceRequest request)
        {
            if (request.User?.PropertyId != null)
            {
                SendAlert( request.User, $"Maintenance {maitenanceRequest.StatusId}", maitenanceRequest.Comments,"Maintenance", request.Id);
            }
        }

        public void SendAlert(ApplicationUser user, string title, string message, string type, int relatedId = 0)
        {
            var alert = new UserAlert()
            {
                Title = title,
                Message = message,
                CreatedOn = user.Property.TimeZone.Now(),
                RelatedId = relatedId,
                Type = type,
                UserId = user.Id
            };
            Context.UserAlerts.Add(alert);
            Context.SaveChanges();

            _emailService.SendAsync(new IdentityMessage() { Body = message, Destination = user.Email, Subject = title });

            _pushHandler.SendToUser(user.Id, new NotificationPayload()
            {
                Action = "View",
                DataId = relatedId,
                DataType = type,
                Message = message,
                Title = title
            });

        }
        public void SendAlert( int propertyId, string role, string title, string message, string type, int relatedId = 0)
        {
            foreach (var item in Context.Users.Where(x => x.Roles.Any(p => p.RoleId == role)))
            {

                Context.UserAlerts.Add(new UserAlert()
                {
                    Title = title,
                    Message = message,
                    CreatedOn = item.TimeZone.Now(),
                    RelatedId = relatedId,
                    Type = type,
                    UserId = item.Id
                });
                _emailService.SendAsync(new IdentityMessage() {Body = message, Destination = item.Email, Subject = title});
            }

            Context.SaveChanges();
       
            //_pushHandler.SendToRole(propertyId, role, title);

            _pushHandler.SendToRole(propertyId, role, new NotificationPayload()
            {
                Action = "View",
                DataId = relatedId,
                DataType = type,
                Message = message,
                Title = title
            });

        }

        public void IncidentReportSubmited( IncidentReport incidentReport)
        {
            if (incidentReport.User.PropertyId != null)
                SendAlert(incidentReport.User.PropertyId.Value, "Officer", "An incident report has been submitted", incidentReport.Comments, "Incident", incidentReport.Id);
        }

        public void IncidentReportCheckin( IncidentReportCheckin incidentReportCheckin,
            IncidentReport incidentReport)
        {
            if (incidentReport.User?.PropertyId != null)
            {
                SendAlert(incidentReport.User, $"Incident Report {incidentReport.StatusId}", incidentReport.Comments, "Incident", incidentReport.Id);
            }
        }

        public void SendAlert(object[] ids,string title, string message, string type, int relatedId)
        {
            foreach (var id in ids)
            {
                var user = Context.Users.Find(id);
                SendAlert(user, title, message, type, relatedId);
            }

        }
    }
    public class EmailService : IIdentityMessageService
    {

        public Task SendAsync(IdentityMessage message)
        {
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("noreply@apartmentapps.com", "AptApps2016!");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            MailAddress
                maFrom = new MailAddress("noreply@apartmentapps.com", "Apartment Apps", Encoding.UTF8),
                maTo = new MailAddress(message.Destination, string.Empty, Encoding.UTF8);
            MailMessage mmsg = new MailMessage(maFrom.Address, maTo.Address);
            mmsg.Body = message.Body;
            mmsg.BodyEncoding = Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.Subject = message.Subject;
            mmsg.SubjectEncoding = Encoding.UTF8;

            client.Send(mmsg);

            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    public static class NotificationPayloadExtensions
    {
        public static JObject ToGCMJson(this NotificationPayload payload)
        {
            return new JObject(new JProperty("data", JObject.FromObject(payload)));
        }
        public static JObject ToANPSJson(this NotificationPayload payload)
        {
            var jpayload = JObject.FromObject(payload);
            var jmessage = new JObject(
                new JProperty("title",payload.Title),
                new JProperty("body",payload.Message));

            return new JObject(
                new JProperty("aps", new JObject(
                    new JProperty("alert",jmessage),
                    new JProperty("content-available", 1)
                )), 
                new JProperty("payload", jpayload));
        }
    }

}