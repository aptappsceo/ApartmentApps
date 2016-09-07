using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Helpers;

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

    public static class StepFormExtensions
    {
        public static StepFormBuilder<TModel> StepFormFor<TModel>(this HtmlHelper<TModel> html, string id, string action, string controller, object routeValues = null)
        {
            return new StepFormBuilder<TModel>(new StepFormModel()
            {
                Id = id,
                Action = action,
                Controller = controller,
                RouteValues = routeValues
            },html);
        }
    }

    public class StepFormBuilder<TModel>
    {
        private StepFormModel _model;
        private HtmlHelper _helper;
        public StepFormBuilder(StepFormModel model, HtmlHelper<TModel> helper)
        {
            _model = model;
            _helper = helper;
        }

        public StepFormBuilder<TModel> AddPage(string title, Func<object, HelperResult> template)
        {
            _model.Items.Add(new StepFormItem()
            {
                Title = title,
                Template = template
            });
            return this;
        }

        public HtmlString Render()
        {
            return _helper.Partial("~/Views/Shared/Forms/StepForm.cshtml",_model);
        }

    }

    public class StepFormModel
    {
        private List<StepFormItem> _items;

        public List<StepFormItem> Items
        {
            get { return _items ?? (_items = new List<StepFormItem>()); }
            set { _items = value; }
        }

        public string Id { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public object RouteValues { get; set; }
    }

    public class StepFormItem
    {
        public string Title { get;set; }
        public Func<object, HelperResult> Template { get; set; }
    }

}