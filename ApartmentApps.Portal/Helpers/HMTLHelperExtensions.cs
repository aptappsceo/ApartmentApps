using System;
using System.Web.Mvc;

namespace ApartmentApps.Portal.Helpers
{
    public static class HMTLHelperExtensions
    {
        public static MvcHtmlString Timeago(this HtmlHelper helper, DateTime dateTime)
        {
            var tag = new TagBuilder("abbr");
            tag.AddCssClass("timeago");
            tag.Attributes.Add("title", dateTime.ToString("s") + "Z");
            tag.SetInnerText(dateTime.ToString());

            return MvcHtmlString.Create(tag.ToString());
        }
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }
    }
}
