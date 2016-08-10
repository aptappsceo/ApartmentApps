using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class Log : PropertyEntity
    {
        public string Message { get; set; }
        public LogSeverity Severity { get; set; }
    }
}