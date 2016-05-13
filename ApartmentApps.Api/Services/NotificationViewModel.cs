using System;

namespace ApartmentApps.Portal.Controllers
{
    public class NotificationViewModel : BaseViewModel
    {
        public string Type { get; set; }
        public int RelatedId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool HasRead { get; set; }
        public DateTime Date { get; set; }
    }
}