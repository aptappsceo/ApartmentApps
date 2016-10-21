using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class AutoGridController<TService, TFormService, TViewModel, TFormViewModel> : AutoFormController<TService, TFormService, TViewModel, TFormViewModel>, IServiceQueryVariableProvider where TService : class, IService
           where TFormViewModel : BaseViewModel, new()
           where TFormService : IService
           where TViewModel : class, new()
    {

        private string _filterQuery;
        private string _gridOptions;
        private GridState _gridState;
        public EqServiceProviderDb EqService { get; }
        public TService Service { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
     
          
            base.OnActionExecuting(filterContext);


        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maitenanceRequest = Service.Find<TViewModel>(id.Value.ToString());
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            return View(maitenanceRequest);
        }



        public IEnumerable<ServiceQuery> GetQueries()
        {
            return Service.GetQueries(this);
        }

        public IEnumerable<ServiceQuery> AllQueries()
        {
            return Service.GetQueries(this);
        }
        public AutoGridController(IKernel kernel, TFormService formService, TService indexService, PropertyContext context, IUserContext userContext, TService service) : base(kernel, formService, indexService, context, userContext)
        {

            Service = service;
            EqService = new EqServiceProviderDb();

            EqService.ModelLoader = (model, modelName) =>
            {
                Service.LoadModel(model, modelName);

            };

            EqService.QueryRemover = (queryId) => Service.RemoveQuery(queryId);

            EqService.QueryLoader = (query, queryId) => Service.LoadQuery(this, query, queryId);

            EqService.QuerySaver = (query, queryId) => Service.SaveQuery(query, queryId);

        }
        public ActionResult GetModel(string modelName)
        {
            var model = EqService.GetModel();
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

            var query = EqService.SyncQueryDict(queryJson.ToDictionary());
            var statement = EqService.BuildQuery(query, optionsJson.ToDictionary());
            Dictionary<string, object> dict = new Dictionary<string, object>();
            //dict.Add("statement", statement);
            return Json(dict);
        }

        public virtual ActionResult ApplyFilter(string queryJson, string optionsJson)
        {

            FilterQuery = queryJson;
            GridOptions = optionsJson;
            return Grid(1);
        }

        public IEnumerable<TViewModel> GetData(out int count)
        {
            var query = EqService.LoadQueryDict(FilterQuery.ToDictionary());
            var results = Service.GetAll<TViewModel>(query, out count, "Id", false, 0, int.MaxValue);
            return results;
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

            var query = EqService.LoadQueryDict(FilterQuery.ToDictionary());
            CurrentQueryId = query.QueryName;
            var lvo = string.IsNullOrEmpty(GridOptions) ? new ListViewOptions() { PageIndex = 1 } : GridOptions.ToListViewOptions();

            var count = 0;
            var results = Service.GetAll<TViewModel>(query, out count, lvo.SortBy?.Replace("DESC", "") ?? lvo.SortBy, lvo.SortBy?.EndsWith("DESC") ?? false, lvo.PageIndex, GridState.RecordsPerPage);
            var queries = GetQueries().OrderBy(p => p.Index).ToArray();
            ViewBag.Queries = queries;
            ViewBag.CurrentQuery = string.IsNullOrEmpty(CurrentQueryId) ? (CurrentQueryId = queries.FirstOrDefault()?.QueryId) : CurrentQueryId;
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
            get { if (Session == null) return _gridState ?? (_gridState = new GridState()); return Session["GridState"] as GridState ?? (GridState = new GridState()); }
            set { if (Session != null) Session["GridState"] = value; _gridState = value; }
        }

        public string FilterQueryKey => typeof(TViewModel).Name + "FilterQuery";
        public string GridOptionsyKey => typeof(TViewModel).Name + "GridOptions";
        public string FilterQuery
        {
            get
            {
                if (Session == null) return _filterQuery;
                return Session[FilterQueryKey] == null ? string.Empty : (string)Session[FilterQueryKey];
            }
            set
            {
                if (Session != null) Session[FilterQueryKey] = value;
                _filterQuery = value;
            }
        }
        public string GridOptions
        {
            get { if (Session == null) return _gridOptions; return Session[GridOptionsyKey] == null ? string.Empty : (string)Session[GridOptionsyKey]; }
            set { if (Session != null) Session[GridOptionsyKey] = value; _gridOptions = value; }
        }

        /// <summary>
        /// Gets the query by its name
        /// </summary>
        /// <param name="queryName">The name.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetQuery(string queryName)
        {
            var query = EqService.GetQuery(queryName);
            return Json(query.SaveToDictionary());
        }

        [HttpPost]
        public ActionResult NewQuery(string queryName)
        {
            var query = EqService.GetQuery();
            query.Clear();
            query.QueryName = queryName;
            query.ID = EqService.GenerateQueryId(queryName);
            EqService.SaveQuery(query);

            return Json(query.SaveToDictionary());
        }


        /// <summary>
        /// Saves the query.
        /// </summary>
        /// <param name="queryJson">The JSON representation of the query .</param>
        /// <param name="queryName">Query name.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveQuery(string queryJson, string queryName)
        {
            var query = EqService.SaveQueryDict(queryJson.ToDictionary(), queryName);

            //we return a JSON object with one property "query" that contains the definition of saved query
            var dict = new Dictionary<string, object>();
            dict.Add("query", query.SaveToDictionary());
            return Json(dict);
        }

        [HttpPost]
        public ActionResult RemoveQuery(string queryId)
        {
            EqService.RemoveQuery(queryId);
            var dict = new Dictionary<string, object>();
            dict.Add("result", "ok");
            return Json(dict);
        }
        public string CurrentQueryId
        {
            get { return Session?[this.GetType().Name + "CurrentQueryId"]?.ToString(); }
            set
            {
                if (Session != null)
                    Session[this.GetType().Name + "CurrentQueryId"] = value;
            }
        }

        public DbQuery CustomQuery
        {
            get { return Session?[this.GetType().Name + "CustomQuery"] as DbQuery; }
            set
            {
                if (Session != null)
                    Session[this.GetType().Name + "CustomQuery"] = value;
            }
        }

        public object GetVariable(string name)
        {
            return Session?[this.GetType().Name + name];
        }
    }
    public class AutoGridController<TService, TViewModel> :
        AutoGridController<TService, TService, TViewModel, TViewModel>
        where TService : class, IService
        where TViewModel : BaseViewModel, new()
    {
        public AutoGridController(IKernel kernel, TService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, formService, context, userContext, formService)
        {
        }
    }
}