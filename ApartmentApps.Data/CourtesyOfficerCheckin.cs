using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public interface IImageContainer
    {
        Guid GroupId { get; set; }
    }
    public class CourtesyOfficerCheckin : PropertyEntity, IImageContainer , IFeedItem
    {
     
        public string OfficerId { get; set; }
        public int CourtesyOfficerLocationId { get; set; }

        [ForeignKey("OfficerId")]
        public virtual ApplicationUser Officer { get; set; }

        [ForeignKey("CourtesyOfficerLocationId")]
        public virtual CourtesyOfficerLocation CourtesyOfficerLocation { get; set; }

        public DateTime CreatedOn { get; set; }

        ApplicationUser IFeedItem.User => Officer;

        IEnumerable<IFeedItem> IFeedItem.ChildFeedItems
        {
            get { yield break; }
        }

        string IFeedItem.Message => this.Comments;

        public string Comments { get; set; }

        public Guid GroupId { get; set; }

        public string Description => $"checked in at location {CourtesyOfficerLocation.Label}";

        public object RelatedId => null;
        public FeedItemType Type => FeedItemType.CourtesyCheckin;

    }
}