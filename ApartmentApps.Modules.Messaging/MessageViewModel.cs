using System;
using System.Collections.Generic;
using System.ComponentModel;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{
    [DisplayName("Messages")]
    public class MessageViewModel : BaseViewModel
    {
        public string Body { get; set; }
        public string Title { get; set; }
        public int SentToCount { get; set; }
        public DateTime? SentOn { get; set; }
        public int OpenCount { get; set; }

        public int DeliverCount { get; set; }
        public string TargetsXml { get; set; }

        public IEnumerable<MessageReceiptViewModel>  Receipts { get; set; }
        public UserBindingModel From { get; set; }
        public int TargetsCount { get; set; }
        public string TargetsDescription { get; set; }
        public bool Sent { get; set; }
    }
}