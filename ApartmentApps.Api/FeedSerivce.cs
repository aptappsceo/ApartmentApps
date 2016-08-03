using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api
{
    public class FeedSerivce : IFeedSerivce
    {
        public IBlobStorageService BlobStorageService { get; set; }
        private readonly PropertyContext _context;

        public FeedSerivce(PropertyContext context, IBlobStorageService blobStorageService)
        {
            BlobStorageService = blobStorageService;
            _context = context;
        }

        public IEnumerable<FeedItemBindingModel> GetAll()
        {
            foreach (var feedItemBindingModel in FeedItemBindingModels().OrderByDescending(p=>p.CreatedOn)) yield return feedItemBindingModel;
        }

        private IEnumerable<FeedItemBindingModel> FeedItemBindingModels()
        {
            foreach (var item in _context.CourtesyOfficerCheckins.OrderByDescending(p => p.CreatedOn).Take(10).Cast<IFeedItem>()
                )
            {
                yield return ToFeedItemBindingModel(item);
            }
            foreach (var item in _context.IncidentReportCheckins.OrderByDescending(p => p.CreatedOn).Take(10).Cast<IFeedItem>())
            {
                yield return ToFeedItemBindingModel(item);
            }
            foreach (var item in _context.MaintenanceRequestCheckins.OrderByDescending(p => p.Date).Take(10).Cast<IFeedItem>())
            {
                yield return ToFeedItemBindingModel(item);
            }
        }

        private FeedItemBindingModel ToFeedItemBindingModel(IFeedItem item)
        {
            return new FeedItemBindingModel()
            {
                User = item.User.ToUserBindingModel(BlobStorageService),
                CreatedOn = item.CreatedOn,
                Message = item.Message,
                Photos = BlobStorageService.GetImages(item.GroupId).ToArray(),
                Description = item.Description
            };
        }
    }
}