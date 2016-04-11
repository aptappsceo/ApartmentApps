using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.API.Service.Controllers.Api
{
    public class NotifiationsController : ApartmentAppsApiController
    {
        public NotifiationsController(PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public async Task<HttpResponseMessage> Post(string pns, [FromBody]string message, string to_tag)
        {
            var user = HttpContext.Current.User.Identity.Name;
            string[] userTag = new string[2];
            userTag[0] = "username:" + to_tag;
            userTag[1] = "from:" + user;

            Microsoft.Azure.NotificationHubs.NotificationOutcome outcome = null;
            HttpStatusCode ret = HttpStatusCode.InternalServerError;

            switch (pns.ToLower())
            {
                case "wns":
                    // Windows 8.1 / Windows Phone 8.1
                    var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" +
                                "From " + user + ": " + message + "</text></binding></visual></toast>";
                    outcome = await Notifications.Instance.Hub.SendWindowsNativeNotificationAsync(toast, userTag);
                    break;
                case "apns":
                    // iOS
                    var alert = "{\"aps\":{\"alert\":\"" + "From " + user + ": " + message + "\"}}";
                    outcome = await Notifications.Instance.Hub.SendAppleNativeNotificationAsync(alert, userTag);
                    break;
                case "gcm":
                    // Android
                    var notif = "{ \"data\" : {\"message\":\"" + "From " + user + ": " + message + "\"}}";
                    outcome = await Notifications.Instance.Hub.SendGcmNativeNotificationAsync(notif, userTag);
                    break;
            }

            if (outcome != null)
            {
                if (!((outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Abandoned) ||
                    (outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Unknown)))
                {
                    ret = HttpStatusCode.OK;
                }
            }

            return Request.CreateResponse(ret);
        }
    }
    [RoutePrefix("api/Alerts")]
    public class AlertsController : ApartmentAppsApiController
    {
        public AlertsController(PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        [HttpPost]
        public void Post(int alertId)
        {
            Context.UserAlerts.Find(alertId).HasRead = true;
            Context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<AlertBindingModel> Get()
        {
            return Context.UserAlerts.Where(p => p.UserId == CurrentUser.Id).OrderByDescending(p=>p.CreatedOn).Select(p =>
                 new AlertBindingModel
                 {
                     Id = p.Id,
                     CreatedOn = p.CreatedOn,
                     Message = p.Message,
                     Title = p.Title,
                     Type = p.Type,
                     RelatedId = p.RelatedId,
                     HasRead = p.HasRead
                 });
        }


    }

    public class AlertBindingModel
    {
        public DateTime CreatedOn { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int RelatedId { get; set; }
        public bool HasRead { get; set; }
        public int Id { get; set; }
    }
}