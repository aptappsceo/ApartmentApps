using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.DataSheets;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules.Corporations
{
    public class CorporationIndexBindingModel : BaseViewModel
    {
        public int PropertyCount { get; set; }
    }
    public class CorporationIndexMapper : BaseMapper<Corporation, CorporationIndexBindingModel> {
        public CorporationIndexMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(CorporationIndexBindingModel viewModel, Corporation model)
        {
            //model.Id = Convert.ToInt32(viewModel.Id);
            model.Name = viewModel.Title;
        }

        public override void ToViewModel(Corporation model, CorporationIndexBindingModel viewModel)
        {
            viewModel.Title = model.Name;
            viewModel.Id = model.Id.ToString();
            viewModel.PropertyCount = model.Properties.Count();

        }
    }

    public class CorporationDataSheet : BaseDataSheet<Corporation>
    {
        public CorporationDataSheet(IUserContext userContext, ApplicationDbContext dbContext, IKernel kernel, ISearchCompiler searchCompiler) : base(userContext, dbContext, kernel, searchCompiler)
        {
        }
        protected override IQueryable<Corporation> DefaultOrderFilter(IQueryable<Corporation> set, Query query = null)
        {

            return set.OrderBy(p => p.Name);
            //return base.DefaultOrderFilter(set, query);
        }
    }
    public class CorporationSearchEngine : SearchEngine<Corporation>
    {

        //[Filter(nameof(SearchByType), "Search By Type", EditorTypes.CheckboxList, false, DataSource = nameof(Pro), DataSourceType = typeof(IncidentReportStatus))]
        //public IQueryable<IncidentReport> SearchByType(IQueryable<Corporation> set, List<string> key)
        //{
        //    return set.Where(item => key.Contains(item.StatusId));
        //}

        //[Filter(nameof(SearchByUser), "Search By User", EditorTypes.SelectMultiple, false, DataSource = nameof(ApplicationUser), DataSourceType = typeof(ApplicationUser))]
        //public IQueryable<IncidentReport> SearchByUser(IQueryable<Corporation> set, List<string> key)
        //{
        //    return set.Where(item => key.Contains(item.UserId));
        //}
    }
    public class CorporationService : StandardCrudService<Corporation>
    {
        public CorporationService(IKernel kernel, IRepository<Corporation> repository) : base(kernel, repository)
        {
        }
   
    }
}
