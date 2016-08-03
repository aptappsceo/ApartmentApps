using System.Collections.Generic;
using ApartmentApps.Api.BindingModels;

namespace ApartmentApps.Api
{
    public interface IFeedSerivce
    {
        IEnumerable<FeedItemBindingModel> GetAll();
    }
}