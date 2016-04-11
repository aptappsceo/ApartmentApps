using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    public class MaintenanceRequestStatus
    {
        [Key]
        public string Name { get; set; }
    }
}