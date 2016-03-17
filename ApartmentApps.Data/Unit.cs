using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public partial class Unit
    {
        [Key]
        public int Id { get; set; }

        public int BuildingId { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        public virtual ICollection<MaitenanceRequest> MaitenanceRequests { get; set; } 

        public virtual ICollection<Tenant> Tenants { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }
        
        public decimal Longitude { get; set; }
    }

    public partial class CourtesyOfficerLocation
    {
        [Key]
        public int Id { get; set; }

        [Index("IX_LocationAndProperty",1)]
        public string LocationId { get; set; }

        public int PropertyId { get; set; }

        [ForeignKey("PropertyId"), Index("IX_LocationAndProperty", 2)]
        public Property Property { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}