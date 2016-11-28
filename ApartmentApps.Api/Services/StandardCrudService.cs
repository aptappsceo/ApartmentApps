using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;
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

    public class ConditionItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attrId"></param>
        /// <param name="operator">
        /// Equal | is equal to 
        /// NotEqual | is not equal to 
        /// LessThan | is less than 
        /// LessOrEqual | is less than or equal to 
        /// GreaterThan | greater than
        /// GreaterOrEqual | greater than or equal to
        /// IsNull | is null | {expr1} is null
        /// InList | is in list | {expr1} in ({expr2})
        /// StartsWith | starts with | {expr1} like {expr2}
        /// NotStartsWith | does not start with | not({ expr1}
        /// like {expr2})
        /// Contains | contains | {expr1} like {expr2}
        /// NotContains | does not contain | not({ expr1}
        /// like {expr2})
        /// Between | is between | {expr1} between {expr2} and {expr3}
        /// InSubQuery | is in set | {expr1} in ({expr2})
        /// DateEqualSpecial | is | {expr1} = {expr2}
        /// DateEqualPrecise | is | {expr1} = {expr2}
        /// DateBeforeSpecial | is before(special date) 
        /// DateBeforePrecise | is before(precise date) 
        /// DateAfterSpecial | is after(special date) | {expr1} > {expr2}
        /// DateAfterSpecial | is after(precise date) | {expr1} > {expr2}
        /// </param>
        /// <param name="values"></param>
        public ConditionItem(string attrId, string @operator, params string[] values)
        {
            AttrId = attrId;
            Operator = @operator;
            Values = values;
        }

        public ConditionItem()
        {
        }

        public string AttrId { get; set; }
        public string Operator { get; set; }
        public string[] Values { get; set; }
    }

    public class IgnoreQueryAttribute : Attribute
    {
        
    }
    public abstract class StandardCrudService<TModel> : IService where TModel : IBaseEntity, new()
    {
        protected readonly IKernel _kernel;
        private IRepository<ServiceQuery> _queries;
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

        public Type ModelType => typeof(TModel);
        protected DbQuery CreateQuery(string queryId, string queryName, params ConditionItem[] conditions)
        {
            DbQuery query = new DbQuery() { QueryName = queryName, ID = queryId };
            query.Model = new DbModel();
            query.Model.LoadFromType(typeof(PropertyEntity)); //hax
            query.Model.AddDefaultOperators();
            LoadFromType(query.Model.EntityRoot, ModelType, (Entity)null, new List<Type>());

            if (conditions != null)
            {
                foreach (var condition in conditions)
                {
                    query.Root.Conditions.Add(query.CreateSimpleCondition(condition.AttrId, condition.Operator,
                        condition.Values));
                }
            }

            return query;
        }
        [IgnoreQuery]
        public DbQuery CreateQuery(string queryName = null, params ConditionItem[] conditions)
        {
            DbQuery query = new DbQuery() {QueryName = queryName, ID =queryName };
            query.Model = new DbModel();
            query.Model.LoadFromType(typeof(PropertyEntity)); //hax
            query.Model.AddDefaultOperators();
            LoadFromType(query.Model.EntityRoot, ModelType, (Entity)null, new List<Type>());
            
            if (conditions != null)
            {
                foreach (var condition in conditions)
                {
                    query.Root.Conditions.Add(query.CreateSimpleCondition(condition.AttrId, condition.Operator,
                        condition.Values));
                }
            }
            
            return query;
        }

        
        public IEnumerable<TViewModel> GetAll<TViewModel>()
        {

            return GetAll<TViewModel>(_kernel.Get<IMapper<TModel, TViewModel>>());
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>(DbQuery query, out int count, string orderBy, bool orderByDesc, int page = 1, int resultsPerPage = 20)
        {
            return GetAll<TViewModel>(Repository.GetAll(), query, out count, orderBy, orderByDesc, page, resultsPerPage);
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>(IQueryable<TModel> items, DbQuery query, out int count, string orderBy, bool orderByDesc, int page = 1, int resultsPerPage = 20)
        {
            if (query == null)
            {
                var res2 = items.ToArray();
                count = res2.Count();
                var mapper2 = _kernel.Get<IMapper<TModel, TViewModel>>();
                return res2.Select(mapper2.ToViewModel);

            }
            var result = items.DynamicQuery<TModel>(query, null, !string.IsNullOrEmpty(orderBy) ? orderByDesc : DefaultOrderByDesc);

            count = result.Count();
   
            result = result.OrderBy(!string.IsNullOrEmpty(orderBy) ? orderBy : DefaultOrderBy, !string.IsNullOrEmpty(orderBy) ? orderByDesc : DefaultOrderByDesc);
            result = result.Skip(resultsPerPage * (page - 1));
            result = result.Take(resultsPerPage);
     
            var res = result.ToArray();
            var mapper = _kernel.Get<IMapper<TModel, TViewModel>>();
            return res.Select(mapper.ToViewModel);

        }

        public virtual bool DefaultOrderByDesc => true;

        public IEnumerable<TViewModel> GetAll<TViewModel>(IMapper<TModel, TViewModel> mapper)
        {
            return Repository.GetAll().ToArray().Select(mapper.ToViewModel);
        }


        public IEnumerable<TViewModel> GetRange<TViewModel>(int skip, int take)
        {
            return GetRange(_kernel.Get<IMapper<TModel, TViewModel>>(), skip, take);
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

        public TViewModel Find<TViewModel>(string id) where TViewModel : class, new()
        {
            return Find(id, _kernel.Get<IMapper<TModel, TViewModel>>());
        }
        public IRepository<TModel> Repo<TModel>()
        {
            return _kernel.Get<IRepository<TModel>>();
        }
        public TViewModel Find<TViewModel>(string id, IMapper<TModel, TViewModel> mapper) where TViewModel : class, new()
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
            var mapper = _kernel.Get<IMapper<TModel, TViewModel>>();
            TModel item = default(TModel);
            if (result != null)
            {
                _kernel.Get<IMapper<TModel, TViewModel>>().ToModel(unit, result);
                Repository.Save();
                mapper.ToViewModel(result, unit);
            }
            else
            {
                var model = mapper.ToModel(unit);
                Repository.Add(model);
                Repository.Save();
                mapper.ToViewModel(model, unit);
            }
        }

        public IEnumerable<ServiceQuery> GetQueries(IServiceQueryVariableProvider variableProvider)
        {
            var name = this.GetType().Name;
            var method = this.GetType().GetMethods();
            
            foreach (var item in method)
            {
                if (item.IsDefined(typeof (IgnoreQueryAttribute), true)) continue;
                if (item.ReturnType != typeof(DbQuery)) continue;
                var parameters = item.GetParameters().Select(p => variableProvider.GetVariable(p.Name)).ToArray();

                var result = item.Invoke(this, parameters) as DbQuery;
                
                if (result != null)
                {
                    var methodNameAttribute =
                        item.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                            .Cast<DisplayNameAttribute>()
                            .FirstOrDefault();
                    yield return new ServiceQuery()
                    {
                        QueryId = item.Name,
                        Name = methodNameAttribute?.DisplayName ?? item.Name,
                        QueryJson = QueryToXml(result),
                        Service = name,
                    };
                }
                else
                {
                    
                }
            }
            int index = 0;
            foreach (var item in this._kernel.Get<IRepository<ServiceQuery>>().Where(p => p.Service == name).OrderBy(p=>p.Index))
            {
                yield return item;
                index = item.Index;
            }

            var customQuery = variableProvider.GetVariable("CustomQuery") as DbQuery;
            if (customQuery != null)
            {
                yield return new ServiceQuery()
                {
                   QueryId = "CustomQuery",
                   Name = "Custom",
                   QueryJson = QueryToXml((DbQuery)customQuery),
                   Service = name,
                   Index = ++index
                };
            }
        }

        public void RemoveQuery(string queryId)
        {
            var q = Queries.FirstOrDefault(p => p.QueryId == queryId);
            if (q != null)
            {
                Queries.Remove(q);
                Queries.Save();
            }
        }

        public IRepository<ServiceQuery> Queries => _queries ?? (_queries = _kernel.Get<IRepository<ServiceQuery>>());
        public void LoadQuery(IServiceQueryVariableProvider provider, DbQuery query, string queryId)
        {
            var q = GetQueries(provider).FirstOrDefault(p => p.QueryId == queryId);
            if (q != null)
            {
                string queryXml = q.QueryJson;
                query.LoadFromString(queryXml);
            }
        }

        public void SaveQuery(DbQuery query, string queryId)
        {
            string queryXml = query.SaveToString();
            //var queryId = query.ID;
            var q = Queries.FirstOrDefault(p => p.QueryId == queryId);
            if (q != null)
            {
                q.QueryJson = queryXml;
                Queries.Save();
            }
            else
            {
                Queries.Add(new ServiceQuery()
                {
                    Name = query.QueryName,
                    QueryId = queryId,
                    QueryJson = queryXml,
                    Service = this.GetType().Name
                });
                Queries.Save();
            }
        }

        public void LoadModel(DbModel model, string modelName)
        {
            //model.LoadFromType(typeof(object)); // Ensure the hidden bool is set
            //model.Clear();
            //model.EntityRoot.LoadFromType(ModelType,null,null);
            model.AddDefaultOperators();
            //LoadFromType(model.EntityRoot, ModelType);
            LoadFromType(model.EntityRoot, ModelType, (Entity)null, new List<Type>());
            model.SortEntities();
        }

        public string QueryToXml(DbQuery query)
        {
            var stringBuilder = new StringBuilder();
            
            using (var writer = new StringWriter(stringBuilder))
            {
                var xmlWriter = new XmlTextWriter(writer);
                query.SaveToXmlWriter(xmlWriter,Query.RWOptions.All);
            }
            return stringBuilder.ToString();
        }
        public void LoadFromProperty(EntityAttr attr, PropertyInfo property, Entity parent)
        {
            Type propertyType = property.PropertyType;
            attr.ID = Utils.ComposeKey(parent.ObjInfo.ID, property.Name);
            attr.Caption = Utils.GetPropertyDisplayName(property);
            attr.ObjInfo.ObjType = propertyType;
            attr.ObjInfo.BaseType = parent.ObjInfo.BaseType;
            attr.ObjInfo.PropInfo = property;
            attr.ObjInfo.PropertyName = property.Name;
            Searchable entityAttrAttribute = Attribute.GetCustomAttribute((MemberInfo)property, typeof(Searchable)) as Searchable;
            if (entityAttrAttribute != null)
            {
                attr.Caption = entityAttrAttribute.Caption ?? attr.Caption;
                attr.UseInConditions = entityAttrAttribute.UseInConditions;
                attr.UseInResult = entityAttrAttribute.UseInResult;
            }
            if (Utils.IsSimpleType(propertyType))
            {
                if (attr.DataType == DataType.Unknown)
                    attr.DataType = Utils.GetDataTypeBySystemType(propertyType);
                if (propertyType.IsEnum)
                {
                    attr.Operations.Add(attr.Model.Operators.FindByID("Equal"));
                    attr.Operations.Add(attr.Model.Operators.FindByID("InList"));
                    attr.Operations.Add(attr.Model.Operators.FindByID("NotEqual"));
                    attr.Operations.Add(attr.Model.Operators.FindByID("NotInList"));
                    ConstListValueEditor constListValueEditor = new ConstListValueEditor();
                    foreach (FieldInfo fieldInfo in propertyType.GetFields().Where(f => !f.Name.Equals("value__")))
                        constListValueEditor.Values.Add(fieldInfo.GetRawConstantValue().ToString(), fieldInfo.Name);
                    attr.DefaultEditor = constListValueEditor;
                }
                else if (Attribute.IsDefined(property, typeof(EqListValueEditorAttribute)))
                {
                    var eqListValueEditorAttribute = Attribute.GetCustomAttribute((MemberInfo)property, typeof(EqListValueEditorAttribute)) as EqListValueEditorAttribute;
                    eqListValueEditorAttribute?.ProcessEntityAttr(attr);
                }
                else
                    attr.FillOperatorsWithDefaults(attr.Model);
            }
            else
            {
                if (!Utils.IsEnumerableOfSimpleType(propertyType))
                    return;
                attr.Operations.Add(attr.Model.AddUpdateOperator("ListContains", "contains", "{expr1} contains {expr2}", "{expr1} [[contains]] {expr2}", DataKind.Scalar, DataModel.CommonOperatorGroup));
                attr.DataType = Utils.GetDataTypeBySystemType(propertyType.GetGenericArguments()[0]);
            }
        }
        public void LoadFromType(Entity en, Type type, Entity parent, List<Type> ignoredTypes, string propertyName = null)
        {
            string str = Utils.ComposeKey(parent == null ? null : parent.ObjInfo.ID, propertyName ?? type.Name);
            en.ObjInfo.ObjType = type;
            en.ObjInfo.BaseType = parent == null ? null : parent.ObjInfo.BaseType;
            en.ObjInfo.ID = str;
            en.Name = propertyName ?? Utils.GetTypeDisplayName(type);
            EqEntityAttribute eqEntityAttribute = Attribute.GetCustomAttribute(type, typeof(EqEntityAttribute)) as EqEntityAttribute;
            if (eqEntityAttribute != null)
            {
                en.Name = eqEntityAttribute.DisplayName;
                en.UseInConditions = eqEntityAttribute.UseInConditions;
                en.UseInResult = eqEntityAttribute.UseInResult;
            }
            foreach (PropertyInfo property in Utils.GetMappedProperties(type.GetProperties()))
            {
                if (!property.IsDefined(typeof(Searchable)))
                {
                    if (property.Name != "Email")
                        continue;
                }
                Type propertyType = property.PropertyType;
                if (Utils.IsSimpleType(propertyType) || Utils.IsEnumerableOfSimpleType(propertyType))
                {
                    string attrId = Utils.ComposeKey(en.ObjInfo.ID, property.Name);
                    EntityAttr entityAttr = en.Attributes.FirstOrDefault(a => a.ID == attrId);
                    if (entityAttr == null)
                    {
                        entityAttr = en.Model.CreateEntityAttr();
                        en.Attributes.Add(entityAttr);
                    }
                    LoadFromProperty(entityAttr, property, en);
                }
                else if (en.Model.EntityGraph.ContainsVertex(propertyType))
                {
                    en.Model.EntityGraph.AddEdge(type, propertyType);

                    if (en.Model.NavPropNames.ContainsKey(type))
                    {
                        en.Model.NavPropNames[type][propertyType] = property.Name;
                    }
                    else
                    {
                        Dictionary<Type, string> dictionary = new Dictionary<Type, string>();
                        dictionary[propertyType] = property.Name;
                        en.Model.NavPropNames[type] = dictionary;
                    }
                }
                else if (propertyType.GetInterfaces().Any(x =>
                {
                    if (x.IsGenericType)
                        return x.GetGenericTypeDefinition() == typeof(IEnumerable<>);
                    return false;
                }))
                {
                    Type type1 = propertyType.GetInterfaces().First(x =>
                    {
                        if (x.IsGenericType)
                            return x.GetGenericTypeDefinition() == typeof(IEnumerable<>);
                        return false;
                    }).GetGenericArguments()[0];
                    if (!Utils.IsSimpleType(type1) && !Utils.IsComplexType(type1) && !ignoredTypes.Contains(type1))
                    {
                        string subEntityId = property.Name;
                        Entity entity = en.Model.EntityRoot.SubEntities.FirstOrDefault(e => e.ObjInfo.ID == subEntityId);
                        if (entity != null)
                        {
                            List<Type> ignoredTypes1 = ignoredTypes.ToList();
                            ignoredTypes1.Add(type1);
                            LoadFromType(entity, type1, en.Model.EntityRoot, ignoredTypes1, property.Name);
                        }
                    }
                }
                else if (!ignoredTypes.Contains(propertyType) && propertyType.GetInterfaces().All(i => i != typeof(IEnumerable)))
                {
                    string subEntityId = Utils.ComposeKey(en.ObjInfo.ID, property.Name);
                    Entity entity = en.SubEntities.FirstOrDefault(e => e.ObjInfo.ID == subEntityId);
                    if (entity == null)
                    {
                        entity = en.Model.CreateEntity();
                        en.SubEntities.Add(entity);
                    }
                    List<Type> ignoredTypes1 = ignoredTypes.ToList();
                    ignoredTypes1.Add(propertyType);
                    LoadFromType(entity, propertyType, en, ignoredTypes1, property.Name);
                }
            }
        }
    }

    public interface IServiceQueryVariableProvider
    {
        object GetVariable(string name);
    }
}