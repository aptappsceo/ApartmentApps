using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public class IncidentReportCheckin : PropertyEntity
    {
        [Key]
        public int Id { get; set; }
        public string OfficerId { get; set; }

        [ForeignKey("OfficerId")]
        public virtual ApplicationUser Officer { get; set; }
        public string Comments { get; set; }
        public Guid GroupId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int IncidentReportId { get; set; }

        [ForeignKey("IncidentReportId")]
        public virtual IncidentReport IncidentReport { get; set; }

        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual IncidentReportStatus IncidentReportStatus { get; set; }
    }
}