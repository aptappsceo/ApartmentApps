using System.ComponentModel;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.ViewModels
{
    [DisplayName("Buildings")]
    public class BuildingViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }


    public class PropertyBindingModel : BaseViewModel
    {
        public int PropertyCount { get; set; }
        public string Corporation { get; set; }
        public int CorporationId { get; set; }
    }
    public class PropertyMapper : BaseMapper<Property, PropertyBindingModel>
    {
        public PropertyMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(PropertyBindingModel viewModel, Property model)
        {
            
            model.Name = viewModel.Name;
            model.CorporationId = viewModel.CorporationId;
        }

        public override void ToViewModel(Property model, PropertyBindingModel viewModel)
        {
            viewModel.Title = model.Name;
            viewModel.Id = model.Id.ToString();
            viewModel.Corporation = model.Corporation.Name;
            viewModel.CorporationId = model.CorporationId;
        }
    }

    //public class PropertyService : StandardCrudService<Property>
    //{
    //    public PropertyService(IKernel kernel, IRepository<Property> repository) : base(kernel, repository)
    //    {
            
    //    }
    //}
}