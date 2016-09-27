using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ApartmentApps.Data
{
    public class IncidentReport : PropertyEntity, IImageContainer, IFeedItem, IBaseEntity
    {
     

        [ForeignKey("UserId"),Searchable(Caption = "Submission By")]
        public virtual ApplicationUser User { get; set; }

        IEnumerable<IFeedItem> IFeedItem.ChildFeedItems => Checkins;

        string IFeedItem.Message => Comments;

        public string UserId { get; set; }

        public Guid GroupId { get; set; }
        public string Description => string.Empty;
        public object RelatedId => Id;
        public FeedItemType Type => FeedItemType.IncidentReport;


        public string Comments { get; set; }
        public int? UnitId { get; set; }

        [ForeignKey("UnitId"), Searchable(Caption = "Unit")]
        public virtual Unit Unit { get; set; }

        [Searchable(Caption = "Incident Type")]
        public IncidentType IncidentType { get; set; }
        [Searchable(Caption = "Submit Date")]
        public DateTime CreatedOn { get; set; }
        [Searchable(Caption = "Status")]
        public string StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual IncidentReportStatus IncidentReportStatus { get; set; }

        public virtual ICollection<IncidentReportCheckin> Checkins { get; set; }
        [Searchable(Caption = "Complete Date")]
        public DateTime? CompletionDate { get; set; }
        [NotMapped]
        public IncidentReportCheckin LatestCheckin
        {
            get { return Checkins.OrderByDescending(p => p.CreatedOn).FirstOrDefault(); }
        }

    }
}