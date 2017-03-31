using System;
using System.Linq.Expressions;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Korzh.EasyQuery.Db;
using Microsoft.AspNet.Identity;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{

    public class BuildingMapper : BaseMapper<Building, BuildingViewModel>
    {
        public BuildingMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

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
    public class BuildingService : StandardCrudService<Building>
    {
        public BuildingService(IKernel kernel, IRepository<Building> repository) : base(kernel, repository)
        {
        }

        public override string DefaultOrderBy => "Name";
        public DbQuery All()
        {
            return CreateQuery("All");
        }
    }
}