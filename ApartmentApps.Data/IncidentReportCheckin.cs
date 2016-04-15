using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public class IncidentReportCheckin : PropertyEntity, IImageContainer, IFeedItem
    {
        [Key]
        public int Id { get; set; }
        public string OfficerId { get; set; }

        [ForeignKey("OfficerId")]
        public virtual ApplicationUser Officer { get; set; }
        public string Comments { get; set; }
        public Guid GroupId { get; set; }
        public DateTime CreatedOn { get; set; }

        ApplicationUser IFeedItem.User => Officer;
        string IFeedItem.Message => Comments;
        public string Description
        {
            get
            {
                switch (StatusId)
                {
                    case "Reported":
                        return $"{IncidentReport.User.FirstName} {IncidentReport.User.LastName} reported an incident";
                }
                return $"{StatusId.TrimEnd('e')}ed an incident report";
            }

        }
        IEnumerable<IFeedItem> IFeedItem.ChildFeedItems
        {
            get { yield break; }
        }

      

        public int IncidentReportId { get; set; }

        [ForeignKey("IncidentReportId")]
        public virtual IncidentReport IncidentReport { get; set; }

        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual IncidentReportStatus IncidentReportStatus { get; set; }
    }
}