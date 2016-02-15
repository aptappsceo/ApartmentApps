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

        public virtual ICollection<Tenant> Tenants { get; set; }

        public string Name { get; set; }
    }
}