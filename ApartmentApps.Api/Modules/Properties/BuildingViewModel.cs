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


    public class PropertyIndexBindingModel : BaseViewModel
    {
        public int PropertyCount { get; set; }
        public string Corporation { get; set; }
        public int CorporationId { get; set; }
        public PropertyState Status { get; set; }
    }

    

    public class PropertyIndexMapper : BaseMapper<Property, PropertyIndexBindingModel>
    {
        public PropertyIndexMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(PropertyIndexBindingModel viewModel, Property model)
        {
            model.Name = viewModel.Title;
            model.CorporationId = viewModel.CorporationId;
            model.State = viewModel.Status;
        }

        public override void ToViewModel(Property model, PropertyIndexBindingModel viewModel)
        {
            viewModel.Title = model.Name;
            viewModel.Id = model.Id.ToString();
            viewModel.Corporation = model.Corporation?.Name;
            viewModel.CorporationId = model.CorporationId;
            viewModel.Status = model.State;
        }
    }

    //public class PropertyService : StandardCrudService<Property>
    //{
    //    public PropertyService(IKernel kernel, IRepository<Property> repository) : base(kernel, repository)
    //    {
            
    //    }
    //}
}