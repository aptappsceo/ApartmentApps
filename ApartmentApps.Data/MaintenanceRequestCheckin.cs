using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public class MaintenanceRequestCheckin : PropertyEntity
    {

        [Key]
        public int Id { get; set; }
        public string WorkerId { get; set; }

        [ForeignKey("WorkerId")]
        public virtual ApplicationUser Worker { get; set; }

        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual MaintenanceRequestStatus Status { get; set; }

        public int MaitenanceRequestId { get; set; }
        [ForeignKey("MaitenanceRequestId")]
        public virtual MaitenanceRequest MaitenanceRequest { get; set; }

        public string Comments { get; set; }

        public DateTime Date { get; set; }
        public Guid GroupId { get; set; }
    }
}