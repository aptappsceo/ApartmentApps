using System.Web;
using System.Web.Optimization;

namespace ApartmentApps.Portal
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Vendor scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery")

                //.Include("~/Scripts/jquery-2.1.1.min.js")
                .Include("~/Scripts/jquery-2.1.1.min.js")
                .Include("~/Scripts/jquery.easing.1.3.min.js")
                .Include("~/Scripts/jsrender.min.js")
               // .Include("~/Scripts/ej/ej.web.all.min.js")
                .Include("~/Scripts/ej/partial/ej.core.min.js")
                .Include("~/Scripts/ej/partial/ej.unobtrusive.min.js")
                .Include("~/Scripts/ej/partial/ej.draggable.min.js")
                .Include("~/Scripts/ej/partial/ej.globalize.min.js")
                .Include("~/Scripts/ej/partial/ej.scroller.min.js")
                .Include("~/Scripts/ej/partial/ej.touch.min.js")
                .Include("~/Scripts/ej/partial/ej.webform.min.js")

                .Include("~/Scripts/ej/partial/ej.data.min.js")
                
                .Include("~/Scripts/ej/partial/ej.autocomplete.min.js")
                .Include("~/Scripts/ej/partial/ej.button.min.js")
                .Include("~/Scripts/ej/partial/ej.checkbox.min.js")
                .Include("~/Scripts/ej/partial/ej.datepicker.min.js")
                .Include("~/Scripts/ej/partial/ej.datetimepicker.min.js")
                .Include("~/Scripts/ej/partial/ej.dialog.min.js")
                .Include("~/Scripts/ej/partial/ej.dropdownlist.min.js")
                .Include("~/Scripts/ej/partial/ej.editor.min.js")
                .Include("~/Scripts/ej/partial/ej.print.min.js")
                .Include("~/Scripts/ej/partial/ej.progressbar.min.js")
                .Include("~/Scripts/ej/partial/ej.recurrenceeditor.min.js")
                .Include("~/Scripts/ej/partial/ej.timepicker.min.js")
                .Include("~/Scripts/ej/partial/ej.uploadbox.min.js")
                .Include("~/Scripts/ej/partial/ej.maskedit.min.js")

                /* Rich Text Editor and it's dependencies */
                .Include("~/Scripts/ej/partial/ej.rte.min.js")
                .Include("~/Scripts/ej/partial/ej.fileexplorer.min.js")
                .Include("~/Scripts/ej/partial/ej.toolbar.min.js")
                .Include("~/Scripts/ej/partial/ej.tooltip.min.js")
                .Include("~/Scripts/ej/partial/ej.splitter.min.js")
                .Include("~/Scripts/ej/partial/ej.waitingpopup.min.js")
                .Include("~/Scripts/ej/partial/ej.treeview.min.js")
                .Include("~/Scripts/ej/partial/ej.tab.min.js")
                .Include("~/Scripts/ej/partial/ej.colorpicker.min.js")
                .Include("~/Scripts/ej/partial/ej.splitbutton.min.js")
                .Include("~/Scripts/ej/partial/ej.togglebutton.min.js")
                .Include("~/Scripts/ej/partial/ej.radiobutton.min.js")
                .Include("~/Scripts/ej/partial/ej.slider.min.js")
                .Include("~/Scripts/ej/partial/ej.menu.min.js")
                .Include("~/Scripts/ej/partial/ej.grid.min.js")



                .Include("~/Scripts/jquery.timeago.js")
                );

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                      "~/Scripts/app/inspinia.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                      "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js"));

            // jQuery plugins
            bundles.Add(new ScriptBundle("~/plugins/metsiMenu").Include(
                      "~/Scripts/plugins/metisMenu/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/plugins/pace").Include(
                      "~/Scripts/plugins/pace/pace.min.js"));

            bundles.Add(new ScriptBundle("~/plugins/flot")
                    .Include("~/Scripts/plugins/flot/jquery.flot.js")
                    .Include("~/Scripts/plugins/flot/jquery.flot.tooltip.min.js")
                    .Include("~/Scripts/plugins/flot/jquery.flot.resize.js")
                    .Include("~/Scripts/plugins/flot/jquery.flot.pie.js")
                    .Include("~/Scripts/plugins/flot/jquery.flot.time.js")
    
                    
                      );

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/style.css",
                      "~/Content/Site.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));
        }
    }
}
