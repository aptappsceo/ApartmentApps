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
                switch (StatusId)
                {
                    case "Complete":
                        return "completed a maintenance request";
                    case "Scheduled":
                        return "scheduled a maintenance request";
                    case "Started":
                        return "started a maintenance request";
                    case "Paused":
                        return "paused a maintenance request";
                    case "Submitted":
                        return $"{MaitenanceRequest.User.FirstName} {MaitenanceRequest.User.LastName} submitted a maintenance request";
                }
                return string.Empty;
            }
            
        }

        DateTime IFeedItem.CreatedOn => Date;

        ApplicationUser IFeedItem.User => Worker;

        IEnumerable<IFeedItem> IFeedItem.ChildFeedItems
        {
            get { yield break; }
        }

        string IFeedItem.Message => Comments;
    }
}