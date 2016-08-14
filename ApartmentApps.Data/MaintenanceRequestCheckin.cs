using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace ApartmentApps.Data
{
    public interface IFeedItem
    {
        DateTime CreatedOn { get; }
        ApplicationUser User { get; }
        IEnumerable<IFeedItem> ChildFeedItems { get; } 
        string Message { get; }
        Guid GroupId { get; }
        string Description { get; }
        object RelatedId { get; }
        FeedItemType Type { get; }
    }

    public enum FeedItemType
    {
        CourtesyCheckin,
        IncidentReport,
        MaintenanceRequest
    }

    public class MaintenanceRequestCheckin : PropertyEntity, IImageContainer, IFeedItem
    {

       
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

        public string Description
        {
            get
            {
                string unitInfoSuffix = "";
                if(!string.IsNullOrEmpty(MaitenanceRequest?.Unit?.Name))
                unitInfoSuffix = $" at Unit #{MaitenanceRequest.Unit.Name}";

                switch (StatusId)
                {
                    case "Complete":
                        return "completed a work order"+unitInfoSuffix;
                    case "Scheduled":
                        return "scheduled a work order" + unitInfoSuffix;
                    case "Started":
                        return "started a work order" + unitInfoSuffix;
                    case "Paused":
                        return "paused a work order" + unitInfoSuffix;
                    case "Submitted":
                        return "submitted a work order" + unitInfoSuffix;
                }
                return string.Empty;
            }
            
        }

        public object RelatedId => MaitenanceRequest.Id;
        public FeedItemType Type => FeedItemType.MaintenanceRequest;

        DateTime IFeedItem.CreatedOn => Date;

        ApplicationUser IFeedItem.User => Worker;

        IEnumerable<IFeedItem> IFeedItem.ChildFeedItems
        {
            get { yield break; }
        }

        string IFeedItem.Message => Comments;
    }
}