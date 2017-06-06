using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using LinqKit;
using Ninject;

namespace ApartmentApps.Api.DataSheets
{
    public class BaseDataSheet<TModel> : IFetcher<TModel>, IDataSheet<TModel> where TModel : class
    {

        protected readonly IUserContext _userContext;
        protected IKernel _kernel;
        protected readonly ApplicationDbContext _dbContext;
        protected IDbSet<TModel> _dbSet;
        protected ISearchCompiler _searchCompiler;
        public BaseDataSheet(IUserContext userContext, ApplicationDbContext dbContext, IKernel kernel, ISearchCompiler searchCompiler)
        {
            _userContext = userContext;
            _dbContext = dbContext;
            _kernel = kernel;
            _searchCompiler = searchCompiler;
        }

        public IQueryState<TModel> Query(Query query = null)
        {
            var queryState = new QueryState<TModel>()
            {
                Fetcher = this,
                ContextFilter = (set) => DefaultContextFilter(set),
                OrderFilter = (set) => DefaultOrderFilter(set, query),
                NavigationFilter = (set) => DefaultNavigationFilter(set, query),
                InitialSet = DbSet.AsExpandable()
            };

            if (query?.Search != null)
            {
                queryState.SearchFilter = _searchCompiler.Compile<TModel>(query.Search);
            }
            else
            {
                queryState.SearchFilter = set => DefaultSearchFilter(set);
            }

            return queryState;
        }

        public IDbSet<TModel> DbSet
        {
            get { return _dbSet ?? (_dbSet = _dbContext.Set<TModel>()); }
        }
        public IKernel Kernel => _kernel;

        public virtual TViewModel Get<TViewModel>(string id) where TViewModel : class
        {
            var model = Get(id);
            if (model != null)
            {
                if (!_kernel.CanResolve<IMapper<TModel, TViewModel>>()) throw new Exception(
                    $"Cannot find mapper from {typeof(TModel).Name} to {typeof(TViewModel).Name}");
                var mapper = _kernel.Get<IMapper<TModel, TViewModel>>();

                return mapper.ToViewModel(model);
            }
            return null;

        }

        public virtual TModel Get(string id)
        {
            return _dbSet.Find(id);
        }

        public virtual object StringToPrimaryKey(string id)
        {
            int key = 0;
            if (!int.TryParse(id, out key))
            {
                throw new Exception("Cannot parse primary key: " + id);
            }
            return key;
        }

        public virtual void SaveChanges()
        {
            this._dbContext.SaveChanges();
        }

        protected virtual IQueryable<TModel> DefaultSearchFilter(IQueryable<TModel> set, Query query = null)
        {
            return set;
        }

        protected virtual IQueryable<TModel> DefaultNavigationFilter(IQueryable<TModel> set, Query query = null)
        {
            if (query?.Navigation != null)
            {
                set = set.Skip(query.Navigation.Skip);
                set = set.Take(query.Navigation.Take);
            }
            return set;
        }

        protected virtual IQueryable<TModel> DefaultOrderFilter(IQueryable<TModel> set, Query query = null)
        {
            return set;
        }

        protected virtual IQueryable<TModel> DefaultContextFilter(IQueryable<TModel> set)
        {
            return set;
        }

        private IQueryable<TModel> FetchNotNavigated(QueryState<TModel> queryState)
        {
            if (queryState == null) return null;
            var contextFiltered = queryState?.ContextFilter?.Invoke(queryState.InitialSet) ?? queryState.InitialSet;
            var filtered = queryState?.CustomFilter?.Invoke(contextFiltered) ?? contextFiltered;
            var searched = queryState?.SearchFilter?.Invoke(filtered) ?? filtered;
            var ordered = queryState?.OrderFilter?.Invoke(searched) ?? searched;
            return ordered;
        }
        public IQueryable<TModel> FetchRaw(QueryState<TModel> queryState)
        {
            return queryState.NavigationFilter(FetchNotNavigated(queryState));
        }

        public IEnumerable<TViewModel> FetchRaw<TViewModel>(QueryState<TModel> queryState)
        {
            if (!_kernel.CanResolve<IMapper<TModel, TViewModel>>()) throw new Exception(
                $"Cannot find mapper from {typeof(TModel).Name} to {typeof(TViewModel).Name}");
            var mapper = _kernel.Get<IMapper<TModel, TViewModel>>();
            var result = Fetch(queryState);

            return result.Result.Select(s => mapper.ToViewModel(s)).ToList();
        }

        public QueryResult<TViewModel> Fetch<TViewModel>(QueryState<TModel> queryState) where TViewModel : class
        {
            if (!_kernel.CanResolve<IMapper<TModel, TViewModel>>()) throw new Exception(
                $"Cannot find mapper from {typeof(TModel).Name} to {typeof(TViewModel).Name}");
            var mapper = _kernel.Get<IMapper<TModel, TViewModel>>();
            var result = Fetch(queryState);

            return new QueryResult<TViewModel>()
            {
                Total = result.Total,
                Result = result.Result.Select(s => mapper.ToViewModel(s)).ToList()
            };

        }

        public QueryResult<TModel> Fetch(QueryState<TModel> queryState)
        {
            var notNavigated = FetchNotNavigated(queryState);
            var count = notNavigated.Count();
            var navigated = queryState.NavigationFilter(notNavigated);
            var navigatedList = navigated.ToList();
            return new QueryResult<TModel>()
            {
                Result = navigatedList,
                Total = count,
            };
        }
    }
}