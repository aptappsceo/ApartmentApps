using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Forms;
using Korzh.EasyQuery.Services;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public static class LinkHelpers
    {
        public static MvcHtmlString RenderDashboardArea(this HtmlHelper helper, DashboardArea area)
        {
            List<ComponentViewModel> components = new List<ComponentViewModel>();
            ModuleHelper.EnabledModules.Signal<IDashboardComponentProvider>(_=>_.PopulateComponents(area, components));
            return helper.Partial("~/Views/Shared/Dashboard/Components.cshtml", components);
        }

        public static MvcHtmlString RenderComponent<TComponent>(this HtmlHelper helper, DashboardArea area, Action<TComponent> initComponent = null) where TComponent : IPortalComponent
        {
            var componentClass = ModuleHelper.Kernel.Get<TComponent>();
            initComponent?.Invoke(componentClass);
            var component = componentClass.Execute();

            return helper.Partial("~/Views/Shared/Dashboard/" + component.GetType().Name + ".cshtml", component);
        }
        public static IEnumerable<ActionLinkModel> GetActionLinksFor(object viewModel)
        {
            var list = new List<ActionLinkModel>();
            ModuleHelper.EnabledModules.Signal<IFillActions>(_=> _.FillActions(list,viewModel));
            return list.OrderBy(p => p.Index);
        }
        public static MvcHtmlString ActionLink(this HtmlHelper helper, ActionLinkModel model, object htmlAttributes = null)
        {
            if (model.Allowed)
                return helper.ActionLink(model.Label, model.Action, model.Controller, model.Parameters, htmlAttributes);

            return MvcHtmlString.Empty;
        }
        public static string Action(this UrlHelper urlHelper, ActionLinkModel model)
        {
            return urlHelper.Action(model.Action, model.Controller, model.Parameters);
        }
    }
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

        public static HtmlString RenderGrid(this HtmlHelper helper, Type type, IEnumerable<object> model, int count, int recordsPerPage, int currentPage, int pageCount, string orderBy, bool descending)
        {
            var formHelper = new DefaultFormProvider();
            var gridModel = formHelper.CreateGridFor(type);
            gridModel.ObjectItems = model;
            gridModel.Count = count;

            return helper.Partial("~/Views/Shared/Forms/Grid.cshtml", gridModel);
        }
        public static HtmlString RenderForm(this HtmlHelper helper, object model)
        {
            var formHelper = new DefaultFormProvider()
            {
                ModelState = helper.ViewData.ModelState
            };
            var formModel = formHelper.CreateFormFor(model);
            return helper.Partial("~/Views/Shared/Forms/Form.cshtml", formModel);
        }
        public static HtmlString RenderForm<TModel>(this HtmlHelper<TModel> helper, TModel model)
        {
            var formHelper = new DefaultFormProvider()
            {
                ModelState = helper.ViewData.ModelState
            };
            var formModel = formHelper.CreateFormFor(model);
            return helper.Partial("~/Views/Shared/Forms/Form.cshtml", formModel);
        }
    }



    public static class FeedItemsHelper
    {
        public static HtmlString RenderQueryList(this HtmlHelper helper)
        {
            var queries =  helper.ViewBag.Queries as IEnumerable<ServiceQuery>;
            return helper.Partial("~/Views/Shared/_QueryList.cshtml", queries);
        }
        public static HtmlString RenderQueryActions(this HtmlHelper helper)
        {
            var queries = helper.ViewBag.Queries as IEnumerable<ServiceQuery>;
            return helper.Partial("~/Views/Shared/_QueryToolbar.cshtml", queries);
        }
        public static HtmlString RenderFeedItems(this HtmlHelper helper, IEnumerable<FeedItemBindingModel> feedItem)
        {
            return helper.Partial("~/Views/Shared/FeedItems/FeedItem1.cshtml", new FeedItemsListModel()
            {
                FeedItems = feedItem
            });
        }

        public static HtmlString RenderFeedItems(this HtmlHelper helper, IEnumerable<FeedItemBindingModel> feedItem, Func<FeedItemBindingModel, string> itemUrlSelector)
        {
            return helper.Partial("~/Views/Shared/FeedItems/FeedItem1.cshtml", new FeedItemsListModel()
            {
                FeedItems = feedItem,
                ItemUrlSelector = itemUrlSelector
            });
        }
    }

    public static class PageHeaderHelper
    {
        public static HtmlString RenderPageHeader(this HtmlHelper helper, string title = null, string subtitle = null,
            string imageUrl = null)
        {
                return helper.Partial("~/Views/Shared/StandardPageHeader.cshtml", new PageHeaderModel()
            {
                    Title = title,
                   Subtitle = subtitle,
                   ImageUrl = imageUrl
            });
        }
    }

    public static class PaymentsHelper
    {
        public static HtmlString RenderPaymentListSummary(this HtmlHelper helper, PaymentListBindingModel model)
        {
            return helper.Partial("~/Views/Shared/Payments/PaymentListSummary.cshtml", model);
        }
    }

    public class FeedItemsListModel
    {
        public IEnumerable<FeedItemBindingModel> FeedItems { get; set; }
        public Func<FeedItemBindingModel, string> ItemUrlSelector { get; set; }
    }

    public class PageHeaderModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}