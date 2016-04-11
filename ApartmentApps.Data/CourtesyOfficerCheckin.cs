using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public class CourtesyOfficerCheckin : PropertyEntity
    {
        [Key]
        public int Id { get; set; }
        public string OfficerId { get; set; }
        public int CourtesyOfficerLocationId { get; set; }

        [ForeignKey("OfficerId")]
        public virtual ApplicationUser Officer { get; set; }

        [ForeignKey("CourtesyOfficerLocationId")]
        public virtual CourtesyOfficerLocation CourtesyOfficerLocation { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Comments { get; set; }

        public Guid GroupId { get; set; }
    }
}