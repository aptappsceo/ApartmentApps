using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class Message : PropertyEntity
    {
        public string FromId { get; set; }

        [ForeignKey("FromId"),Searchable]
        public ApplicationUser From
        {
            get;set;
        }
        public int SentToCount { get; set; }
        [Searchable]
        public string Subject { get; set; }
        public string Body { get; set; }
        [Searchable]
        public DateTime? SentOn { get; set; }

        public string Filter { get; set; }

        public virtual ICollection<MessageReceipt> MessageReceipts { get; set; }
        public int TargetsCount { get; set; }
        public string TargetsDescription { get; set; }

        [Searchable]
        public bool Sent { get; set; }
    }
}