using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ApartmentApps.Data
{
    public partial class MaitenanceRequest : PropertyEntity
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int MaitenanceRequestTypeId { get; set; }

        public bool PermissionToEnter { get; set; }

        public Guid GroupId { get; set; }

        // 0 = false, 1= yes, 2 = yes contained
        public int PetStatus { get; set; }

        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("MaitenanceRequestTypeId")]
        public virtual MaitenanceRequestType MaitenanceRequestType { get; set; }

        public virtual ICollection<MaintenanceRequestCheckin> Checkins { get; set; }

        public DateTime? ScheduleDate { get; set; }

        public string Message { get; set; }

        [NotMapped]
        public MaintenanceRequestCheckin LatestCheckin
        {
            get { return Checkins.OrderByDescending(p => p.Date).FirstOrDefault(); }
        }

        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual MaintenanceRequestStatus Status { get; set; }

        public DateTime SubmissionDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        [NotMapped]
        public TimeSpan? TimeToComplete => CompletionDate?.Subtract(SubmissionDate);
    }
}