using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    [Persistant]
    public class ServiceQuery : PropertyEntity
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string QueryId { get; set; }
        public string QueryJson { get; set; }
        public string Service { get; set; }
    }
}