using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Korzh.EasyQuery;

namespace ApartmentApps.Data
{
    //[EqEntity(UseInConditions = false, UseInResult = false)]
    public class Property : IBaseEntity
    {
        [EqEntityAttr(UseInConditions = false)]
        public TimeZoneInfo TimeZone
        {
            get
            {
                return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneIdentifier ?? TimeZoneInfo.Local.Id);
            }
        }

        [Key]
        [EqEntityAttr(UseInConditions = false)]
        public int Id { get; set; }

        public string Name { get; set; }
        [EqEntityAttr(UseInConditions = false)]
        public int CorporationId { get; set; }

        [ForeignKey("CorporationId")]
        public Corporation Corporation { get; set; }

        public virtual ICollection<PropertyAddon> PropertyAddons { get; set; }

        public virtual ICollection<Building> Buildings { get; set; } 
      
        [NotMapped]
        public virtual IEnumerable<MaitenanceRequest> MaitenanceRequests {
            get { return Users.SelectMany(p=>p.MaitenanceRequests); }
        } 

        
        public string TimeZoneIdentifier { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public string PaymentsUrl { get; set; }

        //public virtual PropertyEntrataInfo EntrataInfo { get; set; }
        //public virtual PropertyYardiInfo YardiInfo { get; set; }
    }
}