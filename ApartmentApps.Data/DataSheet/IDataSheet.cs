using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Korzh.EasyQuery;
using Ninject;

namespace ApartmentApps.Data.DataSheet
{


    public interface IDataSheet
    {
    }

    

    public interface IDataSheet<TModel> where TModel : class
    {
        IQueryState<TModel> Query(Query query = null);
        IDbSet<TModel> DbSet { get; }
        TViewModel Get<TViewModel>(string id) where TViewModel : class;
        TModel Get(string id);
        object StringToPrimaryKey(string id);
        void SaveChanges();
    }

    public interface IFetcher<TModel> where TModel : class
    {
        IKernel Kernel { get; }
        IQueryable<TModel> FetchRaw(QueryState<TModel> queryState);
        IEnumerable<TViewModel> FetchRaw<TViewModel>(QueryState<TModel> queryState);
        QueryResult<TViewModel> Fetch<TViewModel>(QueryState<TModel> queryState) where TViewModel : class;
        QueryResult<TModel> Fetch(QueryState<TModel> queryState);
    }


    public interface IQueryState<TEntityModel>
    {
        IQueryState<TEntityModel> Search<TSearchEngine>(Func<TSearchEngine, IQueryable<TEntityModel>, IQueryable<TEntityModel>> mapper);
        IQueryState<TEntityModel> Order(Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> mapper);
        IQueryState<TEntityModel> Navigate(Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> mapper);
        IQueryState<TEntityModel> Filter(Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> mapper);

        IQueryable<TEntityModel> Raw();
        IEnumerable<TViewModel> Raw<TViewModel>();
        QueryResult<TEntityModel> Get();
        QueryResult<TViewModel> Get<TViewModel>() where TViewModel : class;
    }

    public class QueryState<TEntityModel> : IQueryState<TEntityModel> where TEntityModel : class
    {

        public IFetcher<TEntityModel> Fetcher { get; set; }
        public IQueryable<TEntityModel> InitialSet { get; set; }
        public Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> NavigationFilter { get; set; }
        public Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> CustomFilter { get; set; }
        public Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> SearchFilter { get; set; }
        public Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> OrderFilter { get; set; }
        public Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> ContextFilter { get; set; }

        public IQueryState<TEntityModel> Navigate(Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> mapper)
        {
            NavigationFilter = mapper;
            return this;
        }

        public IQueryState<TEntityModel> Filter(Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> mapper)
        {
            CustomFilter = mapper;
            return this;
        }

        public IQueryState<TEntityModel> Order(Func<IQueryable<TEntityModel>, IQueryable<TEntityModel>> mapper)
        {

            this.OrderFilter = mapper;
            return this;
        }

        public IQueryState<TEntityModel> Search<TSearchEngine>(Func<TSearchEngine, IQueryable<TEntityModel>, IQueryable<TEntityModel>> mapper)
        {

            SearchFilter = x =>
            {
                if (!Fetcher.Kernel.CanResolve<TSearchEngine>())
                    throw new Exception("Search engine not found: " + typeof(TSearchEngine).Name);
                return mapper(Fetcher.Kernel.Get<TSearchEngine>(), x);
            };
            return this;

        }

        public IQueryable<TEntityModel> Raw()
        {
            return this.Fetcher.FetchRaw(this);
        }

        public IEnumerable<TViewModel> Raw<TViewModel>()
        {
            return Fetcher.FetchRaw<TViewModel>(this);
        }

        public QueryResult<TEntityModel> Get()
        {
            return this.Fetcher.Fetch(this);
        }

        public QueryResult<TViewModel> Get<TViewModel>() where TViewModel : class
        {
            return this.Fetcher.Fetch<TViewModel>(this);
        }
    }

    public class QueryResult<T>
    {
        public int Total { get; set; } //total of all entities before navigation is applied
        public List<T> Result { get; set; }
    }

    public class Query
    {
        public Navigation Navigation { get; set; }
        public Order Order { get; set; }
        public Search Search { get; set; }
    }

    public class Navigation
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class Order
    {
        //Not yet implemented
    }

    public class Search
    {
        public string EngineId { get; set; }
        public List<FilterData> Filters { get; set; }
    }

    public class FilterData
    {
        public string FilterId { get; set; }
        public string JsonValue { get; set; }
    }

    public static class QuerystateExtensions
    {
        public static IQueryState<TModel> SkipTake<TModel>(this IQueryState<TModel> state, int skip, int take)
        {
            return state.Navigate(set => set.Skip(skip).Take(take));
        }
    }


}
