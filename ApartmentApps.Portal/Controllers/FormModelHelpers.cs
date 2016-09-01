using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public static HtmlString RenderGrid(this HtmlHelper helper, Type type, object[] model)
        {
            var formHelper = new DefaultFormProvider();
            var gridModel = formHelper.CreateGridFor(type, model);
            gridModel.Items = model;
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

    public static class AutoCompleteHelper
    {

        public static HtmlString RenderAutoComplete<TModel, TObject, TId>(this HtmlHelper<TModel> html, Expression<Func<TModel, TId>> expression,IEnumerable<TObject> from, Func<TObject, TId> select,Func<TObject, string> title)
        {
            var meta = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            return html.Partial("~/Views/Shared/Autocomplete/AutoCompleteFor",new AutoCompleteForModel()
            {
                ModelPropertyId = meta.PropertyName,
                Entries = from.Select(x=>new AutoCompletePair()
                {
                    Id = select(x),
                    Title = title(x)
                }).ToList(),
                Label = "SomeLabel"
            });
        }
    }

    public class AutoCompleteForModel
    {
        public string Label { get; set; }
        public List<AutoCompletePair> Entries { get;set; }

        public string ModelPropertyId { get; set; }

    }

    public class AutoCompletePair
    {
        public string Title { get; set; }
        public object Id { get;set; }
    }

}