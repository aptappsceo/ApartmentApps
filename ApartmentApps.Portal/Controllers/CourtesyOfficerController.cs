using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Syncfusion.Pdf;
using System.Threading;
using ApartmentApps.Modules.CourtesyOfficer.Report;
using System.Web;
using RazorEngine.Templating;
using Syncfusion.HtmlConverter;

namespace ApartmentApps.Portal.Controllers
{
    public class CourtesyOfficerController : AAController
    {
        private PdfDocument _document;
        public CourtesyOfficerService Service { get; set; }

        public CourtesyOfficerController(IKernel kernel, CourtesyOfficerService service, PropertyContext context, IUserContext userContext) : base(kernel,context,userContext)
        {
            Service = service;
        }

        public ActionResult Index()
        {
            return View("Index",Service.ForDay(UserContext.CurrentUser.TimeZone.Today()));
        }
        public ActionResult Yesterday()
        {
            return View("Index", Service.ForDay(UserContext.CurrentUser.TimeZone.Today().Subtract(new TimeSpan(1,0,0,0))));
        }
        public ActionResult ThisWeek()
        {
            return View("Index", Service.ForWeek(UserContext.CurrentUser.TimeZone.Now()));
        }

        public ActionResult CheckinMonthlyReport()
        {
            return AutoForm(new CheckinsFilterModel(), "CreateMonthlyReport", "Checkins");
        }

        [HttpPost]
        public ActionResult CreateMonthlyReport(CheckinsFilterModel model)
        {
#if DEBUG
            model.StartDate = DateTime.Now.AddYears(-5);
            model.EndDate = DateTime.Now;
#endif
            if (UserContext.CurrentUser == null) // hack for caching the current user httpcontext.current is not available in thread
            {
                return RedirectToAction("CheckinMonthlyReport");
            }

            var httpContext = System.Web.HttpContext.Current;
            OfficerReportHelper reportHelper = Kernel.Get(typeof(OfficerReportHelper)) as OfficerReportHelper;
            var result = reportHelper.CreateMonthlyCheckinsReport(model);
            Thread thread = new Thread(() => 
            {                
                CreateDocument(result, httpContext);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            var stream = new MemoryStream();
            _document.Save(stream);
            _document.Close(true);
            return File(stream.ToArray(), "application/pdf", $"Checkin_Monthly_Report{model.StartDate.Value.Month}{model.StartDate.Value.Day}-{model.EndDate.Value.Month}{model.EndDate.Value.Day}.pdf");
        }

        private void CreateDocument(CheckinReportViewModel model, HttpContext httpContext)
         {
            var razorService = Kernel.Get<IRazorEngineService>();
            var templateType = model.GetType();
            var templateName = "CheckinMonthlyReport";

            if (!razorService.IsTemplateCached(templateName, templateType))
            {
                razorService.AddTemplate(templateName,
                    LoadHtmlFile($"ApartmentApps.Portal.Views.CourtesyOfficer.{templateName}.cshtml"));
            }

            var reportHtml = razorService.RunCompile(templateName, templateType, model);
            if (!string.IsNullOrEmpty(reportHtml))
            {
                //inject css
                var baseUrl = string.Empty;
#if DEBUG
                baseUrl = $"{Request.Url.Scheme}://{Request.Url.Host}:{Request.Url.Port}";
#else
                baseUrl = $"{Request.Url.Scheme}://{Request.Url.Host}";
#endif
                reportHtml = reportHtml.Replace("/Content/bootstrap.min.css", baseUrl + "/Content/bootstrap.min.css");
                reportHtml = reportHtml.Replace("/Content/style.css", baseUrl + "/Content/style.css");

                HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
                var reportMargins = new Syncfusion.Pdf.Graphics.PdfMargins();
                reportMargins.Top = 60;
                reportMargins.Left = 50;
                reportMargins.Right = 50;
                reportMargins.Bottom = 40;
                htmlConverter.ConverterSettings.Margin = reportMargins;
                _document = htmlConverter.Convert(reportHtml, string.Empty);
            }
        }
    }

    

    
}