using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.API.Service.Models
{
    public class Property
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CorporationId { get; set; }

        [ForeignKey("CorporationId")]
        public Corporation Corporation { get; set; }

        public ICollection<Tenant> Tenants { get; set; } 

        public virtual ICollection<PropertyAddon> PropertyAddons { get; set; } 
    }
}