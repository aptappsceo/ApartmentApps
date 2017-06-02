using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Ninject;
using Ninject.Activation.Caching;

namespace ApartmentApps.Data.DataSheet
{
    public interface ISearchCompiler
    {
        Func<IQueryable<TModel>, IQueryable<TModel>> Compile<TModel>(Search model);
        SearchEngineModel Get(string entityName);
        SearchEngineModel Get(Type entityType);
    }

    public class SearchCompiler : ISearchCompiler
    {
        private Dictionary<string, SearchEngineModel> _searchEngines;
        private readonly IKernel _kernel;

        public Dictionary<string, SearchEngineModel> SearchEngines
        {
            get { return _searchEngines ?? (_searchEngines = new Dictionary<string, SearchEngineModel>()); }
            set { _searchEngines = value; }
        }

        public SearchCompiler(IKernel kernel)
        {
            _kernel = kernel;
            Preload();
        }

        public void Preload()
        {
            if (SearchEngines.Count > 0) return;
            var typeDef = typeof(ISearchEngine<>);

            foreach (var searchAssembly in ApplicationDbContext.SearchAssemblies.Distinct())
            {
                foreach (var type in searchAssembly.GetTypes().Where(t => !t.IsAbstract && !t.IsGenericType))
                {
                    var saIface = type.GetInterfaces().FirstOrDefault(iface => iface.IsGenericType && iface.GetGenericTypeDefinition() == typeDef);
                    if (saIface != null) // this is non abstract search engine
                    {
                        var entityType = saIface.GenericTypeArguments[0]; //for TModel

                        //hack: for some reason, some of search engines are getting here twice (through different assemblies?)
                        if(SearchEngines.ContainsKey(entityType.Name)) continue;

                        var model = ExtractModel(type);
                        model.SearchEngineType = type;
                        if (string.IsNullOrEmpty(model.Id)) model.Id = entityType.Name; //if no engine id provided, cache by model name (becomes kind of DefaultSearchEngine for given Entity)
                        if (SearchEngines.ContainsKey(model.Id)) continue;
                        SearchEngines.Add(model.Id, model);
                        //_kernel.Bind(saIface).To(type);
                       // _kernel.Bind(type).ToSelf();
                    }
                }
            }
           
            //Construct and cache search engine model

        }

        private SearchEngineModel ExtractModel(Type type)
        {
            var model = new SearchEngineModel();

            var engineIdData = type.GetCustomAttributes<EngineIdAttribute>(true).FirstOrDefault();
            if (engineIdData != null)
            {
                model.Id = engineIdData.Id;
            }
            var filtersCache = model.Filters;
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (var methodInfo in methods)
            {
                var attribute = methodInfo.GetCustomAttributes<FilterAttribute>(true).FirstOrDefault();
                if (attribute == null) continue;
                Type argumentType = null;
                var parameters = methodInfo.GetParameters().ToArray();
                if (parameters.Length > 1) argumentType = parameters[1].ParameterType;
                filtersCache.Add(attribute.Id, new SearchEngineFilterModel() //get all methods and cache the data
                {
                    Id = attribute.Id,
                    MethodInfo = methodInfo,
                    DefaultActive = attribute.DefaultActive,
                    Title = attribute.Title,
                    ArgumentType = argumentType,
                    DataSource = attribute.DataSource,
                    DataSourceType = attribute.DataSourceType,
                    Description = attribute.Description,
                    EditorType = attribute.EditorType
                });
            }

            return model;
        }

        public Func<IQueryable<TModel>, IQueryable<TModel>> Compile<TModel>(Search model)
        {

            return ( set ) =>
            {

                if (model?.Filters == null || model?.Filters.Count <= 0) return set;


                SearchEngineModel searchEngineModel = null;

                if (!SearchEngines.TryGetValue(model.EngineId, out searchEngineModel))
                {
                    throw new Exception("Cannot resolve search engine model with id: "+model.EngineId);
                }

                ISearchEngine<TModel> searchEngineInstance = _kernel.Get(searchEngineModel.SearchEngineType) as ISearchEngine<TModel>;

                if (searchEngineInstance == null)
                {
                    throw new Exception("Cannot resolve search engine instance of type: "+searchEngineModel.SearchEngineType.Name);
                }


                
                foreach (var filter in model.Filters)
                {
                    SearchEngineFilterModel filterModel = null;
                    if (!searchEngineModel.Filters.TryGetValue(filter.FilterId, out filterModel))
                    {
                        throw new Exception($"Cannot resolve filter {filter.FilterId} of search model {searchEngineModel.Id}");
                    }

                    set = searchEngineInstance.ApplyFilter(set, filterModel, filter);
                }

                return set;
            };
        }

    

        public SearchEngineModel Get(string entityName)
        {
            SearchEngineModel template = null;
            if (!SearchEngines.TryGetValue(entityName, out template))
            {
                throw new Exception("Not search engine for given entity name " + entityName);
            }
            return template;
        }

        public SearchEngineModel Get(Type entityType)
        {
            return Get(entityType.Name);
        }
    }


    public interface ISearchEngine
    {
        string Id { get; set; }
    }
    public interface ISearchEngine<TModel>
    {
        IQueryable<TModel> ApplyFilter(IQueryable<TModel> set, SearchEngineFilterModel model, FilterData data);
    }


    public abstract class SearchEngine<TModel> : ISearchEngine<TModel>
    {
     

        public virtual IQueryable<TModel> ApplyFilter(IQueryable<TModel> set, SearchEngineFilterModel model, FilterData data)
        {
            if (model.ArgumentType == null)
            {
                set = (IQueryable<TModel>)model.MethodInfo.Invoke(this, new object[] { set });
            }
            else
            {
                var argument = GetObject(data, model.ArgumentType);
                if (argument != null)
                    set = (IQueryable<TModel>)model.MethodInfo.Invoke(this, new object[] { set, argument });
            }

            return set;
        }

        protected virtual T GetObject<T>(FilterData cnd)
        {
            return (T)GetObject(cnd, typeof(T));
        }

        protected virtual object GetObject(FilterData data, Type type)
        {
            var obj = JObject.Parse(data.JsonValue);
            var realValue = obj["value"];
            return realValue.ToObject(type);
        }

        protected virtual string[] TokenSeparators { get; set; } = { " ", ",", ".", ":", "\t" };

        public virtual string[] Tokenize(string argument)
        {
            if (string.IsNullOrEmpty(argument))
            {
                return new string[0];
            }
            return argument.Split(TokenSeparators, StringSplitOptions.RemoveEmptyEntries);
        }

    }

    public class EngineIdAttribute : Attribute
    {
        public EngineIdAttribute(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }

    public class SearchEngineModel
    {
        private Dictionary<string, SearchEngineFilterModel> _filters;
        public string Id { get; set; }

        public Dictionary<string, SearchEngineFilterModel> Filters
        {
            get { return _filters ?? (_filters = new Dictionary<string, SearchEngineFilterModel>()); }
            set { _filters = value; }
        }

        public Type SearchEngineType { get; set; }

    }

    public class SearchEngineFilterModel
    {
        public string Id { get; set; }
        public MethodInfo MethodInfo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DataSource { get; set; }
        public Type DataSourceType { get; set; }
        public string EditorType { get; set; }
        public bool DefaultActive { get; set; }
        public Type ArgumentType { get; set; }
    }

    public class FilterAttribute : Attribute
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DataSource { get; set; }
        public Type DataSourceType { get; set; }
        public string EditorType { get; set; }
        public bool DefaultActive { get; set; }

        public FilterAttribute(string id, string title, string editorType = EditorTypes.TextField, bool defaultActive = false)
        {
            Id = id;
            Title = title;
            EditorType = editorType;
            DefaultActive = defaultActive;
        }
    }

    public static class EditorTypes
    {
        public const string TextArea = nameof(TextArea);
        public const string TextField = nameof(TextField);
        public const string Select = nameof(Select);
        public const string SelectMultiple= nameof(SelectMultiple);
        public const string Typeahead = nameof(Typeahead);
        public const string TypeaheadMultiple = nameof(TypeaheadMultiple);
        public const string Date = nameof(Date);
        public const string Time = nameof(Time);
        public const string DateTime = nameof(DateTime);
        public const string DateInterval = nameof(DateInterval);
        public const string TimeInterval = nameof(TimeInterval);
        public const string DateTimeInterval = nameof(DateTimeInterval);
    }

}
