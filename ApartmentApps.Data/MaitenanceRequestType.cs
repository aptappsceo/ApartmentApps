using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.API.Service.Models
{
    public class MaitenanceRequestType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}