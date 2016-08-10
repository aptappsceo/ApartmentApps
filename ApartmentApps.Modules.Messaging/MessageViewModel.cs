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

        public IEnumerable<MessageReceiptViewModel>  Receipts { get; set; }

    }
}