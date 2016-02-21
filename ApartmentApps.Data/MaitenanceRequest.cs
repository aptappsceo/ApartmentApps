using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ApartmentApps.Data
{
    public partial class MaitenanceRequest
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int MaitenanceRequestTypeId { get; set; }

        public int UnitId { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [ForeignKey("MaitenanceRequestTypeId")]
        public MaitenanceRequestType MaitenanceRequestType { get; set; }

        public ICollection<MaintenanceRequestCheckin> Checkins { get; set; }

        public string Message { get; set; }

        [NotMapped]
        public MaintenanceRequestCheckin LatestCheckin
        {
            get { return Checkins.OrderByDescending(p => p.Date).FirstOrDefault(); }
        }

        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual MaintenanceRequestStatus Status { get; set; }
        public string ImageDirectoryId { get; set; }
    }

    public class MaintenanceRequestCheckin
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
        public string ImageDirectoryId { get; set; }
    }

    public class MaintenanceRequestStatus
    {
        [Key]
        public string Name { get; set; }
    }
}