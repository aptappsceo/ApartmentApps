using System.Collections.Generic;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IFeedSerivce
    {
        IEnumerable<FeedItemBindingModel> GetAll();
        FeedItemBindingModel ToFeedItemBindingModel(IFeedItem item);
    }
}