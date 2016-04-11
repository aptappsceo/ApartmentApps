using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    public class IncidentReportStatus
    {
        [Key]
        public string Name { get; set; }
    }
}