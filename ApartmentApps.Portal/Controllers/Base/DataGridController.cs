using ApartmentApps.Api;
using ApartmentApps.Api.Services;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace ApartmentApps.Portal.Controllers
{
    public class DataGridController<TEntity, TViewModel, TFormViewModel, TService> : AutoFormController<TService,TService,TViewModel,TFormViewModel>
           where TFormViewModel : BaseViewModel, new()
           where TService : IService
           where TViewModel : class, new()
    {
        //public DataGridController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext) { }
        public DataGridController(IKernel kernel, TService formService, TService indexService, PropertyContext context, IUserContext userContext, TService service) : base(kernel, formService, indexService, context, userContext)
        {

        }
        public virtual string IndexTitle => this.GetType().Name.Replace("Controller", "");
        public string SearchTextKey => typeof(TViewModel).Name + "GridOptions";
        public string LastSearchText
        {
            get { if (Session == null) return string.Empty; return Session[SearchTextKey] == null ? string.Empty : (string)Session[SearchTextKey]; }
            set { if (Session != null) Session[SearchTextKey] = value;}
        }

        public override ActionResult Index()
        {   
            GridModel<TViewModel> gridModel = CreateGridModel(string.Empty, 1);
            return View("AutoDataGridView", gridModel);
        }

        public ActionResult Search(string searchText)
        {
            LastSearchText = searchText;
            GridModel<TViewModel> gridModel = CreateGridModel(searchText, 1);
            return View("Forms/DataGridPartial", gridModel);
        }

        public ActionResult RefreshGrid(int pageNumber, string orderColumn, bool orderDesc)
        {
            var searchText = LastSearchText;
            GridModel<TViewModel> gridModel = CreateGridModel(searchText, pageNumber, orderColumn, orderDesc);
            return View("Forms/DataGridPartial", gridModel);
        }


        private GridModel<TViewModel> CreateGridModel(string searchText, int page, string orderColumn = null, bool orderDesc = false)
        {
            int count = 0;
            int resultPerPage = 10;
            var result = FullTextSearch(searchText, out count, page, resultPerPage);
            if(!string.IsNullOrEmpty(orderColumn))
            {
                var propertyInfo = typeof(TViewModel).GetProperty(orderColumn);
                Func<TViewModel, object> orderLambada = o => propertyInfo.GetValue(o, null);
                if (orderDesc)
                    result = result.OrderByDescending(orderLambada);
                else result = result.OrderBy(orderLambada);
            }

            var formHelper = new DefaultFormProvider();
            var gridModel = formHelper.CreateGridFor<TViewModel>();
            var grid = new GridList<TViewModel>(result, 1, resultPerPage, count);
            gridModel.Items = grid;
            gridModel.Title = IndexTitle;
            gridModel.CurrentPage = page;

            var pageCount = count / resultPerPage;
            if (pageCount > 0 && count % resultPerPage > 0)
                pageCount += 1;
            gridModel.PageCount = pageCount;

            return gridModel;
        }

        private IEnumerable<TViewModel> FullTextSearch(string searchText, out int count, int page = 1, int resultsPerPage = 10)
        {
            var repository = Kernel.Get<IRepository<TEntity>>();
            IEnumerable<TEntity> queryResult = new List<TEntity>();
            if (!string.IsNullOrEmpty(searchText))
            {
                var query = CreateFullTextSearchQueryExpression<TEntity>(searchText);
                if (query != null)
                    queryResult = repository.GetAll().Where(query);
                else queryResult = repository.GetAll();
            }
            else
            {
                queryResult = repository.GetAll();
            }
            count = queryResult.Count();
            if (page <= 0)
                page = 1;

            var mapper = Kernel.Get<IMapper<TEntity, TViewModel>>();
            var result = queryResult.Skip((page - 1) * 10).Take(resultsPerPage).Select(mapper.ToViewModel).ToArray();
            return result;
        }


        private Expression<Func<T, bool>> CreateFullTextSearchQueryExpression<T>(string searchedText)
        {
            var param = Expression.Parameter(typeof(T), "e");
            //check all string value
            //create s=>s.string_property.Contains(searchText) EXPRESSION for all string properties
            var expressionForString = CreateExpressionForStringProperties<T>(searchedText, param);
            

            int searchInteger = 0;
            Expression expressionForInteger = null;
            if (int.TryParse(searchedText, out searchInteger))
            {
                //if search text is numeric then create s=>s.int_property == searchText EXPRESSION as well
                expressionForInteger = CreateExpressionForIntProperties<T>(searchInteger, param);
            }

            Expression finalExpression = null;
            if (expressionForString != null && expressionForInteger != null)
                finalExpression = Expression.Or(expressionForString, expressionForInteger);
            else if (expressionForString != null)
                finalExpression = expressionForString;
            else if (expressionForInteger != null)
                finalExpression = expressionForInteger;

            if (finalExpression == null)
                return null;

            var lambadaExpression = Expression.Lambda<Func<T, bool>>(finalExpression, param);
            return lambadaExpression;
        }

        private Expression CreateExpressionForIntProperties<T>(int searchedNumeric, ParameterExpression param)
        {
            var intProperties = typeof(T).GetProperties().Where(s => s.PropertyType == typeof(int)).ToList();
            if(intProperties.Count == 1)
            {
                return CreateEqualExpression(intProperties[0].Name, searchedNumeric, param);
            }
            BinaryExpression expression = null;                        
            for (int i = 0; i < intProperties.Count; i++)
            {
                if (i == 0)
                    continue;
                var currentIndex = i;
                var prevIndex = i - 1;
                var rightExpression = CreateEqualExpression(intProperties[currentIndex].Name, searchedNumeric, param);
                if (expression == null)
                {
                    var leftExpression = CreateEqualExpression(intProperties[prevIndex].Name, searchedNumeric, param);
                    expression = Expression.Or(leftExpression, rightExpression);
                }
                else
                {
                    expression = Expression.Or(expression, rightExpression);
                }                
            }

            return expression;
        }

        private Expression CreateExpressionForStringProperties<T>(string searchedText, ParameterExpression param)
        {
            //create s=>s.string_property.Contains(searchText) EXPRESSION for all string properties
            var stringProperties = typeof(T).GetProperties().Where(s => s.PropertyType == typeof(string)).ToList();
            if (stringProperties.Count == 1)
            {
                return CreateContainsValExpression(stringProperties[0].Name, searchedText, param);
            }
            BinaryExpression expression = null;
            
            for (int i = 0; i < stringProperties.Count; i++)
            {
                if (i == 0)
                    continue;
                var currentIndex = i;
                var prevIndex = i - 1;
                var rightExpression = CreateContainsValExpression(stringProperties[currentIndex].Name, searchedText, param);
                if (expression == null)
                {
                    var leftExpression = CreateContainsValExpression(stringProperties[prevIndex].Name, searchedText, param);
                    expression = Expression.Or(leftExpression, rightExpression);
                }
                else
                {
                    expression = Expression.Or(expression, rightExpression);
                }
            }

            return expression;
        }

        private MethodCallExpression CreateContainsValExpression(string propertyName, string searchText, ParameterExpression parameterExp)
        {
            var propertyExp = Expression.Property(parameterExp, propertyName);
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var someValue = Expression.Constant(searchText, typeof(string));
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);

            return containsMethodExp;
        }

        private BinaryExpression CreateEqualExpression(string propertyName, int searchedNumeric, ParameterExpression parameterExp)
        {
            var equalExpression = Expression.Equal(Expression.Property(parameterExp, propertyName), Expression.Constant(searchedNumeric));
            return equalExpression;
        }
    }


}
