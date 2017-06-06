using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules.Corporations
{
    public class CorporationBindingModel : BaseViewModel
    {
        public int PropertyCount { get; set; }
    }
    public class CorporationMapper : BaseMapper<Corporation, CorporationBindingModel> {
        public CorporationMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(CorporationBindingModel viewModel, Corporation model)
        {
            //model.Id = Convert.ToInt32(viewModel.Id);
            model.Name = viewModel.Title;
        }

        public override void ToViewModel(Corporation model, CorporationBindingModel viewModel)
        {
            viewModel.Title = model.Name;
            viewModel.Id = model.Id.ToString();
            viewModel.PropertyCount = model.Properties.Count();

        }
    }

    public class CorporationService : StandardCrudService<Corporation>
    {
        public CorporationService(IKernel kernel, IRepository<Corporation> repository) : base(kernel, repository)
        {
        }
    }
}
