using System;
using System.Collections.Generic;
using System.Linq;
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





    public class AutoGridController<TService, TViewModel> :
        AutoGridController<TService, TService, TViewModel, TViewModel>
        where TService : class,  IService
        where TViewModel : BaseViewModel, new()
    {
        public AutoGridController(IKernel kernel, TService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, formService, context, userContext, formService)
        {
        }
    }

    public class GridState
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public string OrderBy { get; set; }
        public bool Descending { get; set; }
    }
    public class AutoGridController<TService, TFormService, TViewModel, TFormViewModel> : AutoFormController<TService, TFormService, TViewModel, TFormViewModel>
        where TService : class, IService 
        where TFormViewModel : BaseViewModel, new()
        where TFormService : IService
        where TViewModel : new()
    {
        private EqServiceProviderDb eqService;
        public TService Service { get; set; }
      

        public AutoGridController(IKernel kernel, TFormService formService, TService indexService, PropertyContext context, IUserContext userContext, TService service) : base(kernel, formService, indexService, context, userContext)
        {
            Service = service;
            eqService = new EqServiceProviderDb();
            eqService.DataPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");

            eqService.ModelLoader = (model, modelName) =>
            {
                model.LoadFromType(indexService.ModelType, DataModel.ContextLoadingOptions.ScanOnlyQueryable);
                model.SortEntities();
            };

            eqService.QueryLoader = (query, queryId) =>
            {
                eqService.DefaultQueryLoader(query, queryId);
            };

            eqService.QuerySaver = (query, queryId) =>
            {
                eqService.DefaultQuerySaver(query, queryId);
            };
        }
        public ActionResult GetModel(string modelName)
        {
            var model = eqService.GetModel();
            return Json(model.SaveToDictionary());
        }
        public virtual string IndexTitle => this.GetType().Name.Replace("Controller", "");
        public override ActionResult Index()
        {
            return Grid(0);
        }
        [HttpPost]
        public ActionResult SyncQuery(string queryJson, string optionsJson)
        {

            var query = eqService.SyncQueryDict(queryJson.ToDictionary());
            var statement = eqService.BuildQuery(query, optionsJson.ToDictionary());
            Dictionary<string, object> dict = new Dictionary<string, object>();
            //dict.Add("statement", statement);
            return Json(dict);
        }

        public ActionResult ApplyFilter(string queryJson, string optionsJson)
        {

            FilterQuery = queryJson;
            GridOptions = optionsJson;
            return Grid(1);
            //var resultSet = eqService.GetDataSetByQuery(query, db.Customers, typeof(Customer));
            //var resultSetDict = eqService.DataSetToDictionary(resultSet, optionsJson.ToDictionary());
            //Dictionary<string, object> dict = new Dictionary<string, object>();
            //dict.Add("resultSet", resultSetDict);

            //return Json(dict);
        }
        public ActionResult Grid(int page, string orderBy = null, int recordsPerPage = 10, bool descending = false)
        {

            if (page > 0)
            {
                GridState.Page = page;
            }
            GridState.Descending = descending;
            GridState.RecordsPerPage = recordsPerPage;
            if (orderBy != null)
            {
                GridState.OrderBy = orderBy;
            }

            var query = eqService.LoadQueryDict(FilterQuery.ToDictionary());

            var lvo = string.IsNullOrEmpty(GridOptions) ? new ListViewOptions() { PageIndex = 1 } : GridOptions.ToListViewOptions();

            var count = 0;
            var results = Service.GetAll<TViewModel>(query, out count, lvo.SortBy, GridState.Descending, lvo.PageIndex, GridState.RecordsPerPage);
            if (Request.IsAjaxRequest())
            {
                var formHelper = new DefaultFormProvider();
                var gridModel = formHelper.CreateGridFor(typeof(TViewModel), null);

                gridModel.Items = new GridList<object>(results.Cast<object>().ToArray(), lvo.PageIndex,
                    GridState.RecordsPerPage, count);


                return View("Forms/GridPartial", gridModel);
            }
            return AutoIndex<TViewModel>(new GridList<object>(results.Cast<object>().ToArray(), lvo.PageIndex, GridState.RecordsPerPage, count), IndexTitle);
        }
        public GridState GridState
        {
            get { return Session["GridState"] as GridState ?? (GridState = new GridState()); }
            set { Session["GridState"] = value; }
        }

        public string FilterQueryKey => typeof(TViewModel).Name + "FilterQuery";
        public string GridOptionsyKey => typeof(TViewModel).Name + "GridOptions";
        public string FilterQuery
        {
            get { return Session[FilterQueryKey] == null ? string.Empty : (string)Session[FilterQueryKey]; }
            set { Session[FilterQueryKey] = value; }
        }
        public string GridOptions
        {
            get { return Session[GridOptionsyKey] == null ? string.Empty : (string)Session[GridOptionsyKey]; }
            set { Session[GridOptionsyKey] = value; }
        }
        //public ActionResult SearchForm()
        //{
        //    ViewBag.Layout = null;
        //    return View("SearchForm",FilterViewModel);
        //}
        //[HttpPost]
        //public virtual ActionResult SearchFormSubmit(TSearchViewModel vm)
        //{

        //    FilterViewModel = vm;
        //    return Grid(1);
        //    //return AutoForm(new TSearchViewModel(), "SearchFormSubmit", "Search");
        //}
    }
    public class AutoFormController<TService, TViewModel> :
        AutoFormController<TService, TService, TViewModel, TViewModel> where TViewModel : BaseViewModel, new() where TService : IService
    {
        public AutoFormController(IKernel kernel, TService service, PropertyContext context, IUserContext userContext) : base(kernel, service, service, context, userContext)
        {
        }
    }

    public class AutoFormController<TService, TFormService, TIndexViewModel, TFormViewModel> : AAController
        where TIndexViewModel : new()
        where TFormViewModel : BaseViewModel, new()
        where TService : IService
        where TFormService : IService
    {
        private readonly IKernel _kernel;
        protected readonly TFormService _formService;
        protected readonly TService _indexService;


        public AutoFormController(IKernel kernel, TFormService formService, TService indexService, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            _kernel = kernel;
            _formService = formService;
            _indexService = indexService;

        }



        public virtual ActionResult Index()
        {

            var array = _indexService.GetAll<TIndexViewModel>().ToArray();
            return AutoIndex<TIndexViewModel>(new GridList<object>(array.Cast<object>(), 1, 20, array.Length), this.GetType().Name.Replace("Controller", ""));
        }
        public virtual ActionResult Entry(string id = null)
        {
            if (id != null && id != "0")
            {
                return AutoForm(InitFormModel(_formService.Find<TFormViewModel>(id)), "SaveEntry", "Change");
            }
            return AutoForm(InitFormModel(CreateFormModel()), "SaveEntry", "Create New");
        }

        protected virtual TFormViewModel InitFormModel(TFormViewModel createFormModel)
        {
            return createFormModel;
        }

        protected virtual TFormViewModel CreateFormModel()
        {
            return _formService.CreateNew<TFormViewModel>();
        }
        [HttpPost]
        public virtual ActionResult SaveEntry(TFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id is string[])
                {
                    model.Id = null;
                }
                _formService.Save(model);
                ViewBag.SuccessMessage = "Success!";
                return RedirectToAction("Index");
            }
            return AutoForm(model, "SaveEntry");
        }

        public virtual ActionResult Delete(int id)
        {
            _formService.Remove(id);
            ViewBag.SuccessMessage = "Item Deleted!";
            return RedirectToAction("Index");
        }
    }

    public class AAController : Controller
    {
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
            }

        }
        public ActionResult AutoIndex<TViewModel>(GridList<object> model, string title)
        {
            return View("AutoIndex", new AutoGridModel(model)
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