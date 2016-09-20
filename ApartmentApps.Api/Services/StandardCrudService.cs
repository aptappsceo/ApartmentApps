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
using Ninject;

namespace ApartmentApps.Portal.Controllers
{

    public interface ISearchable<TSearchViewModel>
    {
        IEnumerable<Filter> CreateFilters(TSearchViewModel viewModel);
        IEnumerable<TViewModel> Search<TViewModel>(TSearchViewModel criteria, out int count, string orderBy, bool orderByDesc, int page = 0, int resultsPerPage = 20);
    }

    public class FilterViewModel
    {
        [DisplayName("Operator")]
        public ExpressionOperator ExpressionOperator { get; set; }

        [DisplayName("Value")]
        public string Value { get; set; }
    }
    public abstract class SearchableCrudService<TModel, TSearchViewModel> : StandardCrudService<TModel>, ISearchable<TSearchViewModel> where TModel : IBaseEntity, new()
    {
        //public SearchFieldMutator<TModel, TSearchViewModel> Mutator(Predicate<TSearchViewModel> predicate, QueryMutator<TModel,TSearchViewModel> mutator)
        //{
        //    return new SearchFieldMutator<TModel, TSearchViewModel>(predicate,mutator);
        //} 
        //public abstract IEnumerable<SearchFieldMutator<TModel, TSearchViewModel>> GetMutators();


        public IEnumerable<Filter> CreateFilters(TSearchViewModel viewModel)
        {
            foreach (var property in typeof(TSearchViewModel).GetProperties().Where(p => p.PropertyType == typeof(FilterViewModel)))
            {
                var obj = property.GetValue(viewModel, null) as FilterViewModel;
                if (obj == null) continue;
                var filterPath =
                    property.GetCustomAttributes(typeof (FilterPath), true).Cast<FilterPath>().FirstOrDefault();

                if (!string.IsNullOrEmpty(obj.Value))
                {
                    yield return new Filter()
                    {
                        Value = obj.Value,
                        PropertyName = filterPath == null ? property.Name : filterPath.Path,
                        Operator = obj.ExpressionOperator
                    };
                }
            }
        }
      
        public IEnumerable<TViewModel> Search<TViewModel>(TSearchViewModel criteria, out int count, string orderBy, bool orderByDesc, int page = 0, int resultsPerPage = 20)
        {
            var result = Repository.Where(ExpressionBuilder.GetExpression<TModel>(CreateFilters(criteria).ToList()));
            count = result.Count();
            if (string.IsNullOrEmpty(orderBy))
            {
                if (orderByDesc)
                {
                    result = result.OrderByDescending(DefaultOrderBy);
                }
                else
                {
                    result = result.OrderBy(DefaultOrderBy);
                }
                
                result = result.Skip(resultsPerPage * (page - 1));
                result = result.Take(resultsPerPage);
            }
            else
            {
                result = result.OrderBy(orderBy, orderByDesc);
                result = result.Skip(resultsPerPage * (page - 1));
                result = result.Take(resultsPerPage);
            }
            var res = result.ToArray();
            var mapper = _kernel.Get<IMapper<TModel, TViewModel>>();
            return res.Select(mapper.ToViewModel);
        }

        public virtual Expression<Func<TModel, object>> DefaultOrderBy => p => p.Id;

        protected SearchableCrudService(IKernel kernel, IRepository<TModel> repository) : base(kernel, repository)
        {
        }
    }
    public abstract class StandardCrudService<TModel> : IService where TModel : IBaseEntity, new()
    {
        protected readonly IKernel _kernel;

        public IMapper<TModel, TViewModel> Map<TViewModel>()
        {
            return _kernel.Get<IMapper<TModel, TViewModel>>();
        }
        public IRepository<TModel> Repository { get; set; }

        protected StandardCrudService(IKernel kernel, IRepository<TModel> repository)
        {
            _kernel = kernel;
            Repository = repository;
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>()
        {
            
            return GetAll<TViewModel>(_kernel.Get<IMapper<TModel, TViewModel>>());
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
        public void Add<TViewModel>(TViewModel viewModel)
        {
            Repository.Add(_kernel.Get<IMapper<TModel, TViewModel>>().ToModel(viewModel));
            Repository.Save();

        }

        public void Remove(int id)
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

        public void Save<TViewModel>(TViewModel unit) where TViewModel : BaseViewModel
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