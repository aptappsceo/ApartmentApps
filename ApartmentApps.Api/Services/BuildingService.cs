using System;
using ApartmentApps.Api;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;

namespace ApartmentApps.Portal.Controllers
{

    public class BuildingMapper : BaseMapper<Building, BuildingViewModel>
    {
        public override void ToModel(BuildingViewModel viewModel, Building model)
        {
            model.Name = viewModel.Name;
            model.Id = Convert.ToInt32(viewModel.Id);

        }

        public override void ToViewModel(Building model, BuildingViewModel viewModel)
        {
            viewModel.Name = model.Name;
            viewModel.Id = model.Id.ToString();
        }
    }
    public class BuildingService : StandardCrudService<Building, BuildingViewModel>
    {
        public BuildingService(IRepository<Building> repository, IMapper<Building, BuildingViewModel> mapper) : base(repository, mapper)
        {
        }
    }
}