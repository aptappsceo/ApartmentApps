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
        [ForeignKey("FromId")]
        public ApplicationUser From
        {
            get;set;
        }
        public int SentToCount { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentOn { get; set; }

        public virtual ICollection<MessageReceipt> MessageReceipts { get; set; }

    }
}