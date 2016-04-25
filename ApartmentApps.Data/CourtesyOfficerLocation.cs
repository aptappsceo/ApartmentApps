using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public partial class CourtesyOfficerLocation : PropertyEntity
    {
      
        public string Label { get; set; }

        ////[Index("IX_LocationAndProperty",1)]
        public string LocationId { get; set; }

        //[Index("IX_LocationAndProperty", 2)]

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<CourtesyOfficerCheckin> CourtesyOfficerCheckins { get; set; } 
    }
}