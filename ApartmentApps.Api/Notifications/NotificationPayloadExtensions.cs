using Newtonsoft.Json.Linq;

namespace ApartmentApps.Api
{
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