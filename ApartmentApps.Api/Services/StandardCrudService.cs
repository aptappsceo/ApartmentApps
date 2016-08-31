using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public delegate IQueryable<TItem> QueryMutator<TItem, TSearch>(IQueryable<TItem> items, TSearch search);
    public class SearchFieldMutator<TItem, TSearch>
    {
        public Predicate<TSearch> Condition { get; set; }
        public QueryMutator<TItem, TSearch> Mutator { get; set; }

        public SearchFieldMutator(Predicate<TSearch> condition, QueryMutator<TItem, TSearch> mutator)
        {
            Condition = condition;
            Mutator = mutator;
        }

        public IQueryable<TItem> Apply(TSearch search, IQueryable<TItem> query)
        {
            return Condition(search) ? Mutator(query, search) : query;
        }
    }

    public class GridFilterViewModel
    {
        

    }
    public interface ISearchable<TModel, TSearchViewModel>
    {
        IEnumerable<SearchFieldMutator<TModel, TSearchViewModel>> GetMutators();

    }

    public abstract class SearchableCrudService<TModel, TViewModel, TSearchViewModel> : StandardCrudService<TModel,TViewModel>, ISearchable<TModel, TSearchViewModel> where TModel : IBaseEntity, new() where TViewModel : BaseViewModel, new()
    {
        public SearchFieldMutator<TModel, TSearchViewModel> Mutator(Predicate<TSearchViewModel> predicate, QueryMutator<TModel,TSearchViewModel> mutator)
        {
            return new SearchFieldMutator<TModel, TSearchViewModel>(predicate,mutator);
        } 
        public abstract IEnumerable<SearchFieldMutator<TModel, TSearchViewModel>> GetMutators();

        protected IEnumerable<TViewModel> Search(IMapper<TModel,TViewModel> mapper, TSearchViewModel criteria,out int count, int? skip = null, int? take = null)
        {
            var result = Repository.GetAll();
            foreach (var mutator in GetMutators())
            {
                result = mutator.Apply(criteria, result);
            }

            if (skip != null)
                result = result.Skip(skip.Value);
            if (take != null)
                result = result.Take(take.Value);


            var res = result.Select(Mapper.ToViewModel).ToArray();
            count = res.Length;
            return res;
        }

        protected SearchableCrudService(IRepository<TModel> repository, IMapper<TModel, TViewModel> mapper) : base(repository, mapper)
        {
        }
    }
    public abstract class StandardCrudService<TModel, TViewModel> : IService, IServiceFor<TViewModel> where TViewModel : BaseViewModel, new() where TModel : IBaseEntity, new()
    {
        public IRepository<TModel> Repository { get; set; }
        public IMapper<TModel, TViewModel> Mapper { get; set; }

        protected StandardCrudService(IRepository<TModel> repository, IMapper<TModel, TViewModel> mapper)
        {
            Repository = repository;
            Mapper = mapper;
           
        }

        public IEnumerable<TViewModel> GetAll()
        {
            return GetAll(Mapper);
        }

        public IEnumerable<TViewModel> GetAll(IMapper<TModel,TViewModel> mapper)
        {
            return Repository.GetAll().ToArray().Select(mapper.ToViewModel);
        }


        public IEnumerable<TViewModel> GetRange(int skip, int take)
        {
            return GetRange(Mapper, skip, take);
        }

        public IEnumerable<TViewModel> GetRange(IMapper<TModel, TViewModel> mapper, int skip, int take)
        {
            return Repository.GetAll().Skip(skip).Take(take).Select(mapper.ToViewModel);
        }
        public void Add(TViewModel viewModel)
        {
            Repository.Add(Mapper.ToModel(viewModel));
            Repository.Save();

        }

        public void Remove(int id)
        {
            Repository.Remove(Repository.Find(id));
            Repository.Save();
        }

        public TViewModel Find(int id)
        {
            return Find(id, Mapper);
        }

        public TViewModel Find(int id, IMapper<TModel,TViewModel> mapper)
        {
            var vm = new TViewModel();
            mapper.ToViewModel(Repository.Find(id), vm);
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

        public TViewModel CreateNew()
        {
            return new TViewModel();
        }

        public void Save(TViewModel unit)
        {
            var result = Repository.Find(unit.Id);
            if (result != null)
            {
                Mapper.ToModel(unit, result);
            }
            else
            {
                Repository.Add(Mapper.ToModel(unit));

            }
            Repository.Save();
        }
    }
}