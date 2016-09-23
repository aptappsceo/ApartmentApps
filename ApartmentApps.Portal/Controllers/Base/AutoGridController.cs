using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Db;
using Korzh.EasyQuery.Mvc;
using Korzh.EasyQuery.Services.Db;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
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
                model.LoadFromType(typeof(PropertyEntity)); // Ensure the hidden bool is set
                model.Clear();
                model.AddDefaultOperators();
                LoadFromType(model.EntityRoot, indexService.ModelType, (Entity)null, new List<Type>());
                //model.LoadFromType(indexService.ModelType, DataModel.ContextLoadingOptions.ScanOnlyQueryable);
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
   
            return GridResult(new GridList<TViewModel>(results.ToArray(), lvo.PageIndex, GridState.RecordsPerPage, count));
        }

        public virtual ActionResult GridResult(GridList<TViewModel> grid)
        {
            if (Request.IsAjaxRequest())
            {
                var formHelper = new DefaultFormProvider();
                var gridModel = formHelper.CreateGridFor<TViewModel>();

                gridModel.Items = grid;
                return View("Forms/GridPartial", gridModel);
            }
            return AutoIndex<TViewModel>(IndexTitle);
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
    public class AutoGridController<TService, TViewModel> :
        AutoGridController<TService, TService, TViewModel, TViewModel>
        where TService : class,  IService
        where TViewModel : BaseViewModel, new()
    {
        public AutoGridController(IKernel kernel, TService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, formService, context, userContext, formService)
        {
        }
    }
}