using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ApartmentApps.Data
{
    public class IncidentReport : PropertyEntity, IImageContainer, IFeedItem
    {
        [Key] 
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        IEnumerable<IFeedItem> IFeedItem.ChildFeedItems => Checkins;

        string IFeedItem.Message => Comments;

        public string UserId { get; set; }

        public Guid GroupId { get; set; }
        public string Description => string.Empty;

        public string Comments { get; set; }
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }


        public IncidentType IncidentType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual IncidentReportStatus IncidentReportStatus { get; set; }

        public virtual ICollection<IncidentReportCheckin> Checkins { get; set; }

        public DateTime? CompletionDate { get; set; }
        [NotMapped]
        public IncidentReportCheckin LatestCheckin
        {
            get { return Checkins.OrderByDescending(p => p.CreatedOn).FirstOrDefault(); }
        }

    }
}