using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Entrata.Model.Requests;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Mvc;
using Korzh.EasyQuery.Services;
using Korzh.EasyQuery.Services.Db;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Provider;
using Ninject;
using Syncfusion.JavaScript.DataVisualization.Models;

namespace ApartmentApps.Portal.Controllers
{
    

    public class AAController : Controller
    {
        public TConfig GetConfig<TConfig>() where TConfig : ModuleConfig, new()
        {
            var config = Kernel.Get<Module<TConfig>>().Config;
            return config;
        }
        public IUserContext UserContext { get; }

        public IRepository<TModel> Repository<TModel>()
        {
            return Kernel.Get<IRepository<TModel>>();
        }
        public AAController(IKernel kernel, PropertyContext context, IUserContext userContext)
        {
            Kernel = kernel;
            Context = context;
            UserContext = userContext;
        }

        public IEnumerable<ActionLinkModel> Tabs
        {
            get
            {
                var list = new List<ActionLinkModel>();
                ModuleHelper.EnabledModules.Signal<IPageTabsProvider>(_ => _.PopulateMenuItems(list));
                return list;
            }
        }
        public IEnumerable<IModule> Modules
        {
            get { return Kernel.GetAll<IModule>(); }
        }

        public IEnumerable<IModule> EnabledModules
        {
            get { return Modules.Where(p => p.Enabled); }
        }

        public IKernel Kernel { get; set; }
        protected PropertyContext Context { get; }

        public ApplicationUser CurrentUser => UserContext.CurrentUser;
        public int PropertyId => UserContext.PropertyId;

        public Data.Property Property => CurrentUser?.Property;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Property != null)
            {
                ViewBag.Property = Property;
                if (User.IsInRole("Admin"))
                {
                    ViewBag.Properties = Context.Properties.GetAll().ToArray();

                }
                var menuItems = new List<MenuItemViewModel>();
                EnabledModules.Signal<IMenuItemProvider>(p => p.PopulateMenuItems(menuItems));
                ViewBag.MenuItems = menuItems;
                ViewBag.Tabs = Tabs;

                
            }

        }
        public void LoadFromProperty(EntityAttr attr,PropertyInfo property, Entity parent)
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
        public void LoadFromType(Entity en,Type type, Entity parent, List<Type> ignoredTypes)
        {
            string str = Utils.ComposeKey(parent == null ? null : parent.ObjInfo.ID, type.Name);
            en.ObjInfo.ObjType = type;
            en.ObjInfo.BaseType = parent == null ? null : parent.ObjInfo.BaseType;
            en.ObjInfo.ID = str;
            en.Name = Utils.GetTypeDisplayName(type);
            EqEntityAttribute eqEntityAttribute = Attribute.GetCustomAttribute(type, typeof(EqEntityAttribute)) as EqEntityAttribute;
            if (eqEntityAttribute != null)
            {
                en.Name = eqEntityAttribute.DisplayName;
                en.UseInConditions = eqEntityAttribute.UseInConditions;
                en.UseInResult = eqEntityAttribute.UseInResult;
            }
            foreach (PropertyInfo property in Utils.GetMappedProperties(type.GetProperties()))
            {
                if (!property.IsDefined(typeof (Searchable)))
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
                    LoadFromProperty(entityAttr,property, en);
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
                        string subEntityId = type1.Name;
                        Entity entity = en.Model.EntityRoot.SubEntities.FirstOrDefault(e => e.ObjInfo.ID == subEntityId);
                        if (entity != null)
                        {
                            List<Type> ignoredTypes1 = ignoredTypes.ToList();
                            ignoredTypes1.Add(type1);
                            LoadFromType(entity, type1, en.Model.EntityRoot, ignoredTypes1);
                        }
                    }
                }
                else if (!ignoredTypes.Contains(propertyType) && propertyType.GetInterfaces().All(i => i != typeof (IEnumerable)))
                {
                    string subEntityId = Utils.ComposeKey(en.ObjInfo.ID, propertyType.Name);
                    Entity entity = en.SubEntities.FirstOrDefault(e => e.ObjInfo.ID == subEntityId);
                    if (entity == null)
                    {
                        entity = en.Model.CreateEntity();
                        en.SubEntities.Add(entity);
                    }
                    List<Type> ignoredTypes1 = ignoredTypes.ToList();
                    ignoredTypes1.Add(propertyType);
                    LoadFromType(entity,propertyType, en, ignoredTypes1);
                }
            }
        }
        public ActionResult AutoIndex<TViewModel>(string title)
        {
            return View("AutoIndex", new AutoGridModel<TViewModel>()
            {
                Title = title,
                
                //Count = count,
                //CurrentPage = currentPage,
                //RecordsPerPage = recordsPerPage,
                //OrderBy = orderBy,
                //Descending = descending,
                Type = typeof(TViewModel)
            });
        }
        public ActionResult AutoForm(object model, string postAction, string title = null)
        {
            return View("AutoForm", new AutoFormModel(model, postAction, this.GetType().Name.Replace("Controller", ""))
            {
                Title = title
            });
        }
    }
}