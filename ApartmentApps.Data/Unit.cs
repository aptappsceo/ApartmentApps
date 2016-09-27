using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public interface IBaseEntity
    {
        int Id { get; }
    }
    public partial class Unit : PropertyEntity, IBaseEntity
    {

        public int BuildingId { get; set; }

        [ForeignKey("BuildingId"),Searchable]
        public virtual Building Building { get; set; }

        public virtual ICollection<MaitenanceRequest> MaitenanceRequests { get; set; } 

        public virtual ICollection<ApplicationUser> Users { get; set; }
        [Searchable]
        public string Name { get; set; }

        public double Latitude { get; set; }
        
        public double Longitude { get; set; }

    }
}