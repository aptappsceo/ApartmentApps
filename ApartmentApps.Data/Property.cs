using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    [MetadataType(typeof(PropertyMetadata))]
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

        public virtual PropertyEntrataInfo EntrataInfo { get; set; }
        public virtual PropertyYardiInfo YardiInfo { get; set; }
    }

    public class PropertyEntrataInfo
    {
        [Key, ForeignKey("Property")]
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
        public string Endpoint { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string EntrataPropertyId { get; set; }
    }

    public class PropertyYardiInfo
    {
        [Key, ForeignKey("Property")]
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
        public string Endpoint { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string YardiPropertyId { get; set; }
    }
}