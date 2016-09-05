using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Forms;

namespace ApartmentApps.Portal.Controllers
{
    public static class FormModelHelpers
    {
 
        public static string Controller(this HtmlHelper htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("controller"))
                return (string)routeValues["controller"];

            return string.Empty;
        }

        public static string Action(this HtmlHelper htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("action"))
                return (string)routeValues["action"];

            return string.Empty;
        }
    
    public static HtmlString RenderGrid(this HtmlHelper helper, Type type, object[] model, int count, int recordsPerPage, int currentPage, int pageCount)
        {
            var formHelper = new DefaultFormProvider();
            var gridModel = formHelper.CreateGridFor(type, model);
            gridModel.Items = model;
            gridModel.Count = count;
            gridModel.RecordsPerPage = recordsPerPage;
            gridModel.CurrentPage = currentPage;
            gridModel.PageCount = pageCount;
            return helper.Partial("~/Views/Shared/Forms/Grid.cshtml", gridModel);
        }
        public static HtmlString RenderForm(this HtmlHelper helper, object model)
        {
            var formHelper = new DefaultFormProvider();
            var formModel = formHelper.CreateFormFor(model);
            return helper.Partial("~/Views/Shared/Forms/Form.cshtml", formModel);
        }
        public static HtmlString RenderForm<TModel>(this HtmlHelper<TModel> helper, TModel model)
        {
            var formHelper = new DefaultFormProvider();
            var formModel = formHelper.CreateFormFor(model);
            return helper.Partial("~/Views/Shared/Forms/Form.cshtml", formModel);
        }
    }

    public static class FeedItemsHelper
    {
        public static HtmlString RenderFeedItems(this HtmlHelper helper, List<FeedItemBindingModel> feedItem)
        {
            return helper.Partial("~/Views/Shared/FeedItems/FeedItem1.cshtml", new FeedItemsListModel()
            {
                FeedItems = feedItem
            });
        }

        public static HtmlString RenderFeedItems(this HtmlHelper helper, List<FeedItemBindingModel> feedItem, Func<FeedItemBindingModel,string> itemUrlSelector)
        {
            return helper.Partial("~/Views/Shared/FeedItems/FeedItem1.cshtml", new FeedItemsListModel()
            {
                FeedItems = feedItem,
                ItemUrlSelector  = itemUrlSelector
            });
        }
    }


    public class FeedItemsListModel
    {
        public List<FeedItemBindingModel> FeedItems { get; set; }
        public Func<FeedItemBindingModel, string> ItemUrlSelector { get; set; }
    }
}