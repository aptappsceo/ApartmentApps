using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Linq.Expressions;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Db;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{

    //public interface ISearchable<TSearchViewModel>
    //{
    //    IEnumerable<Filter> CreateFilters(TSearchViewModel viewModel);
    //    IEnumerable<TViewModel> Search<TViewModel>(TSearchViewModel criteria, out int count, string orderBy, bool orderByDesc, int page = 0, int resultsPerPage = 20);
    //}

    public class FilterViewModel
    {
        [DisplayName("Operator")]
        public ExpressionOperator ExpressionOperator { get; set; }

        [DisplayName("Value")]
        public string Value { get; set; }
    }
    
    public abstract class StandardCrudService<TModel> : IService where TModel : IBaseEntity, new()
    {
        protected readonly IKernel _kernel;
        public virtual string DefaultOrderBy => "Id";
        public IMapper<TModel, TViewModel> Map<TViewModel>()
        {
            return _kernel.Get<IMapper<TModel, TViewModel>>();
        }
        public IRepository<TModel> Repository { get; set; }
        public IRepository<ServiceQuery> ServiceQueries { get; set; }

        protected StandardCrudService(IKernel kernel, IRepository<TModel> repository)
        {   
            _kernel = kernel;
            Repository = repository;
         
        }

        public Type ModelType => typeof (TModel);

       

        public IEnumerable<TViewModel> GetAll<TViewModel>()
        {
            
            return GetAll<TViewModel>(_kernel.Get<IMapper<TModel, TViewModel>>());
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>(DbQuery query, out int count, string orderBy, bool orderByDesc, int page = 1, int resultsPerPage = 20)
        {
            var result = Repository.GetAll().DynamicQuery<TModel>(query, !string.IsNullOrEmpty(orderBy) ? orderBy : DefaultOrderBy, orderByDesc);
            count = result.Count();
            //if (string.IsNullOrEmpty(orderBy))
            //{
            //    if (orderByDesc)
            //    {
            //        result = result.OrderByDescending(DefaultOrderBy);
            //    }
            //    else
            //    {
            //        result = result.OrderBy(DefaultOrderBy);
            //    }

            //    result = result.Skip(resultsPerPage * (page - 1));
            //    result = result.Take(resultsPerPage);
            //}
            //else
            //{
              //  result = result.OrderBy(orderBy, orderByDesc);
                result = result.Skip(resultsPerPage * (page - 1));
                result = result.Take(resultsPerPage);
            //}
            var res = result.ToArray();
            var mapper = _kernel.Get<IMapper<TModel, TViewModel>>();
            return res.Select(mapper.ToViewModel);
           
        }
        public IEnumerable<TViewModel> GetAll<TViewModel>(IMapper<TModel, TViewModel> mapper)
        {
            return Repository.GetAll().ToArray().Select(mapper.ToViewModel);
        }


        public IEnumerable<TViewModel> GetRange<TViewModel>(int skip, int take)
        {
            return GetRange(_kernel.Get<IMapper<TModel,TViewModel>>(), skip, take);
        }

        public IEnumerable<TViewModel> GetRange<TViewModel>(IMapper<TModel, TViewModel> mapper, int skip, int take)
        {
            return Repository.GetAll().Skip(skip).Take(take).Select(mapper.ToViewModel);
        }
        public virtual void Add<TViewModel>(TViewModel viewModel)
        {
            var model = _kernel.Get<IMapper<TModel, TViewModel>>().ToModel(viewModel);

            Repository.Add(model);
            Repository.Save();

        }

        public virtual void Remove(string id)
        {
            Repository.Remove(Repository.Find(id));
            Repository.Save();
        }

        public TViewModel Find<TViewModel>(string id) where TViewModel : class,new()
        {
            return Find(id, _kernel.Get<IMapper<TModel, TViewModel>>());
        }
        public IRepository<TModel> Repo<TModel>()
        {
            return _kernel.Get<IRepository<TModel>>();
        }
        public TViewModel Find<TViewModel>(string id, IMapper<TModel, TViewModel> mapper) where TViewModel : class,new()
        {
            var vm = CreateNew<TViewModel>();
            var item = Repository.Find(id);
            if (item == null) return null;
            mapper.ToViewModel(item, vm);
            return vm;
        }

        //public abstract void ToModel(TViewModel viewModel, TModel model);
        //public TModel ToModel(TViewModel viewModel)
        //{
        //    var model = new TModel();
        //    ToModel(viewModel, model);
        //    return model;
        //}

        //public abstract void ToViewModel(TModel model, TViewModel viewModel);
        //public TViewModel ToViewModel(TModel model)
        //{
        //    var viewModel = new TViewModel();
        //    ToViewModel(model, viewModel);
        //    return viewModel;
        //}

        public virtual TViewModel CreateNew<TViewModel>() where TViewModel : new()
        {
            return new TViewModel();
        }

        public virtual void Save<TViewModel>(TViewModel unit) where TViewModel : BaseViewModel
        {
            var result = Repository.Find(unit.Id);
            if (result != null)
            {
                _kernel.Get<IMapper<TModel,TViewModel>>().ToModel(unit, result);
            }
            else
            {
                Repository.Add(_kernel.Get<IMapper<TModel, TViewModel>>().ToModel(unit));

            }
            Repository.Save();
        }
    }
}