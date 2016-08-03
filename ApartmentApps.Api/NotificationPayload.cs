namespace ApartmentApps.Api
{
    public class NotificationPayload
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Semantic { get; set; } = "Default"; //App decides about icon based on semantic
        public string Action { get; set; }
        public int DataId { get; set; }
        public string DataType { get; set; }
    }
}