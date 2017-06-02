using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class CourtesyCheckinMapper : BaseMapper<CourtesyOfficerCheckin, CourtesyCheckinViewModel>
    {
        public CourtesyCheckinMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(CourtesyCheckinViewModel viewModel, CourtesyOfficerCheckin model)
        {

        }

        public override void ToViewModel(CourtesyOfficerCheckin p, CourtesyCheckinViewModel viewModel)
        {
            
            //viewModel.Latitude = p.Latitude;
            //viewModel.Longitude = p.Longitude;
            //viewModel.Label = p.Label;
            //viewModel.Id = p.Id;
            //viewModel.Date = item?.CreatedOn;
            //viewModel.Complete = item != null;
            //viewModel.AcceptableCheckinCodes = new List<string>()
            //{
            //    $"http://apartmentapps.com?location={p.LocationId}",
            //    $"http://www.apartmentapps.com?coloc={p.LocationId}"
            //};

        }
    }
}