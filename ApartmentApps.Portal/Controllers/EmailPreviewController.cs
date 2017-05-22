using System;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class EmailPreviewController : AAController
    {
        public EmailPreviewController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        public ActionResult SendPreview()
        {
            var cModule = Kernel.Get<CourtesyModule>();
            cModule.SendEmail(UserContext.Now);
            return this.Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}