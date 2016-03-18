using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ApartmentApps.Data
{
    [MetadataType(typeof(PropertyMetadata))]
    public class Property
    {
        public TimeZoneInfo TimeZone
        {
            get
            {
                return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneIdentifier ?? TimeZoneInfo.Local.Id);
            }
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CorporationId { get; set; }

        [ForeignKey("CorporationId")]
        public Corporation Corporation { get; set; }

        public virtual ICollection<Tenant> Tenants { get; set; } 

        public virtual ICollection<PropertyAddon> PropertyAddons { get; set; }

        public virtual ICollection<Building> Buildings { get; set; } 
      
        [NotMapped]
        public virtual IEnumerable<MaitenanceRequest> MaitenanceRequests {
            get { return Users.SelectMany(p=>p.MaitenanceRequests); }
        } 

        
        public string TimeZoneIdentifier { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
         
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