using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public partial class Unit : PropertyEntity
    {
        [Key]
        public int Id { get; set; }

        public int BuildingId { get; set; }

        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }

        public virtual ICollection<MaitenanceRequest> MaitenanceRequests { get; set; } 

        public virtual ICollection<Tenant> Tenants { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }
        
        public double Longitude { get; set; }

    }
}