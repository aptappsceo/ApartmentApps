using System;
using System.Threading.Tasks;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;

namespace ApartmentApps.Api.BindingModels
{
    public class FeedItemBindingModel
    {
        public UserBindingModel User { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Message { get; set; }

        public string[] Photos { get; set; }
        public string Description { get; set; }
        public object RelatedId { get; set; }
        public FeedItemType Type { get; set; }
    }
}
