using System;
using System.Collections.Generic;
using ApartmentApps.Api.BindingModels;

namespace ApartmentApps.Api.Modules
{
    public class FeedItemsListModel : ComponentViewModel
    {
        public IEnumerable<FeedItemBindingModel> FeedItems { get; set; }
        public Func<FeedItemBindingModel, string> ItemUrlSelector { get; set; }
    }
}