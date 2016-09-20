using System;
using System.Linq.Expressions;
using ApartmentApps.Api;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Ninject;

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

    public class BuildingSearchViewModel
    {
        public FilterViewModel Name { get; set; }
    }
    public class BuildingService : SearchableCrudService<Building, BuildingSearchViewModel>
    {
        public BuildingService(IKernel kernel, IRepository<Building> repository) : base(kernel, repository)
        {
        }

        public override Expression<Func<Building, object>> DefaultOrderBy => p => p.Name;
    }
}