using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using ApartmentApps.Api.ViewModels;
using Korzh.EasyQuery;

namespace ApartmentApps.Data
{
    public class MaitenanceRequestConfig : EntityTypeConfiguration<MaitenanceRequest>
    {
        public MaitenanceRequestConfig()
        {
            this.HasOptional(p => p.WorkerAssigned).WithMany().Map(m=>m.MapKey("WorkerAssignedId"));
        }
    }

    public partial class MaitenanceRequest : PropertyEntity, IImageContainer, IFeedItem
    {
        [ForeignKey("WorkerAssigned")]
        public string WorkerAssignedId { get; set; }

        [ForeignKey("WorkerAssignedId"), Searchable(Caption="Worker Assigned"), EqListValueEditor("Workers")]
        public virtual ApplicationUser WorkerAssigned { get; set; }

        public string UserId { get; set; }

        public int MaitenanceRequestTypeId { get; set; }

        public bool PermissionToEnter { get; set; }

        public Guid GroupId { get; set; }
        public string Description { get { return string.Empty; } }
        public object RelatedId => Id;
        public FeedItemType Type => FeedItemType.MaintenanceRequest;


        // 0 = false, 1= yes, 2 = yes contained
        public int PetStatus { get; set; }

        public int? UnitId { get; set; }

        [ForeignKey("UnitId"),Searchable]
        public virtual Unit Unit { get; set; }

        DateTime IFeedItem.CreatedOn => SubmissionDate;

        [ForeignKey("UserId"),Searchable(Caption="Requested By")]
        public virtual ApplicationUser User { get; set; }

        IEnumerable<IFeedItem> IFeedItem.ChildFeedItems => Checkins;

        [ForeignKey("MaitenanceRequestTypeId")]
        public virtual MaitenanceRequestType MaitenanceRequestType { get; set; }

        public virtual ICollection<MaintenanceRequestCheckin> Checkins { get; set; }

        [Searchable(Caption="Scheduled For")]
        public DateTime? ScheduleDate { get; set; }

        public string Message { get; set; }

        [NotMapped, EqEntityAttr(UseInConditions = false)]
        public MaintenanceRequestCheckin LatestCheckin
        {
            get { return Checkins.OrderByDescending(p => p.Date).FirstOrDefault(); }
        }
        [Searchable(Caption = "Status")]
        public string StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual MaintenanceRequestStatus Status { get; set; }
        [Searchable(Caption="Create Date")]
        public DateTime SubmissionDate { get; set; }
        [Searchable(Caption="Completed On")]
        public DateTime? CompletionDate { get; set; }

        [NotMapped, EqEntityAttr(UseInConditions = false)]
        public TimeSpan? TimeToComplete => CompletionDate?.Subtract(SubmissionDate);

    }
}