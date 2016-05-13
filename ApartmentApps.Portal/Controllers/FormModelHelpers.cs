using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
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
}