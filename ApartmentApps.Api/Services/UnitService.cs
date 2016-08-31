using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public class UnitMapper : BaseMapper<Unit, UnitViewModel>
    {
        public override void ToModel(UnitViewModel viewModel, Unit model)
        {

            model.Name = viewModel.Name;
            model.Latitude = viewModel.Latitude;
            model.Longitude = viewModel.Longitude;
            model.BuildingId = viewModel.BuildingId;

        }

        public override void ToViewModel(Unit model, UnitViewModel viewModel)
        {
            viewModel.Id = model.Id.ToString();
            viewModel.Name = model.Name;
            viewModel.Latitude = model.Latitude;
            viewModel.Longitude = model.Longitude;
            viewModel.BuildingId = model.BuildingId;
            viewModel.BuildingName = model.Building.Name;
        }

    }
    public class UnitService : StandardCrudService<Unit, UnitViewModel>
    {
        public UnitService(IRepository<Unit> repository, IMapper<Unit, UnitViewModel> mapper) : base(repository, mapper)
        {
        }

   
    }
}