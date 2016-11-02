using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Korzh.EasyQuery.Db;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class UnitFormModel : BaseViewModel
    {

        public string Name { get; set; }

        public int BuildingId { get; set; }

        public UnitFormModel()
        {
        }


        public IEnumerable<FormPropertySelectItem> BuildingId_Items
        {
            get
            {
                return
                    ModuleHelper.Kernel.Get<IRepository<Building>>()
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, BuildingId == p.Id));


            }
        }

    }
    public class UnitFormMapper : BaseMapper<Unit, UnitFormModel>
    {
        public UnitFormMapper(IUserContext userContext) : base(userContext)
        {
        }

        public override void ToModel(UnitFormModel viewModel, Unit model)
        {
            model.Name = viewModel.Name;
            model.BuildingId = viewModel.BuildingId;
        }

        public override void ToViewModel(Unit model, UnitFormModel viewModel)
        {
            viewModel.Id = model.Id.ToString();
            viewModel.Name = model.Name;
          
            viewModel.BuildingId = model.BuildingId;
    
        }
    }
    public class UnitMapper : BaseMapper<Unit, UnitViewModel>
    {
        public UnitMapper(IUserContext userContext) : base(userContext)
        {
        }

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
            viewModel.Title = $"{model.Building.Name} - {model.Name}";
            viewModel.Latitude = model.Latitude;
            viewModel.Longitude = model.Longitude;
            viewModel.BuildingId = model.BuildingId;
            viewModel.BuildingName = model.Building.Name;
            viewModel.SearchAlias = $"{model.Building.Name}-{model.Name}";
        }

    }

    public class UnitSearchViewModel
    {
        public FilterViewModel Name { get; set; }

        [FilterPath("Building.Name")]
        public FilterViewModel BuildingName { get; set; }

    }

    public class UnitService : StandardCrudService<Unit>
    {
        public UnitService(IKernel kernel, IRepository<Unit> repository) : base(kernel, repository)
        {
        }

        public override string DefaultOrderBy => "Name";
        public override TViewModel CreateNew<TViewModel>()
        {
            return new TViewModel() {};
        }
        public DbQuery All()
        {
            return CreateQuery("All");
        }
    }
}