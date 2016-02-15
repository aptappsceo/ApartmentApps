using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public partial class MaitenanceRequest
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string WorkerId { get; set; }
        public int MaitenanceRequestTypeId { get; set; }

        public int UnitId { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        [ForeignKey("WorkerId")]
        public ApplicationUser Worker { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [ForeignKey("MaitenanceRequestTypeId")]
        public MaitenanceRequestType MaitenanceRequestType { get; set; }

        public ICollection<MaitenanceAction> Actions { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public MaintenanceRequestStatus Status { get; set; }

        public string Message { get; set; }
    }

    public class MaintenanceRequestStatus
    {
        [Key]
        public string Name { get; set; }
    }
}