using System;
using ApartmentApps.Api.BindingModels;

namespace ApartmentApps.Api.Modules
{
    public class FeedComponent : PortalComponent<FeedItemsListModel>
    {
        private readonly IFeedSerivce _feedService;
        public Func<FeedItemBindingModel, string> ItemUrlSelector { get; }

        public FeedComponent(IFeedSerivce feedService)
        {
            _feedService = feedService;
        }

        public override FeedItemsListModel ExecuteResult()
        {
            return new FeedItemsListModel()
            {
                FeedItems = _feedService.GetAll(),
                ItemUrlSelector = ItemUrlSelector
            };
        }


    }
}