using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Ninject;
using Syncfusion.JavaScript;

namespace ApartmentApps.Portal.Controllers
{

    public class MessagingController : CrudController<UserBindingModel, ApplicationUser>
    {
        private readonly MessagingService _messageService;
        private readonly MessagingModule _module;

        public MessagingController(MessagingService messageService, MessagingModule module, IKernel kernel, IRepository<ApplicationUser> repository, StandardCrudService<ApplicationUser, UserBindingModel> service, PropertyContext context, IUserContext userContext, AlertsModule messagingService) : base(kernel,repository, service, context, userContext)
        {
            _messageService = messageService;
            _module = module;
            MessagingService = messagingService;
        }

        public AlertsModule MessagingService { get; set; }



        public override ActionResult Index()
        {

            return View("Index");
        }

        public ActionResult History()
        {
            return View("History", _messageService.GetHistory());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SendMessage(string subject, string message)
        {
            int count;
            var ids = GetData(Dm, out count).Select(p => p.Id).ToArray();
            
            _module.SendMessage(ids, subject, message, HttpContext.Request.Url.Host + Url.Action("EmailMessageRead", "Messaging"));
            ViewBag.SuccessMessage = "Message Sent";
            return RedirectToAction("Index");
        }
        [Route("Messaging/EmailMessageRead/{messageId:int}/{userId}.jpg")]
        public ActionResult EmailMessageRead(int messageId, string userId)
        {
            _module.ReadMessage(messageId, userId);
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetExpires(Cache.NoAbsoluteExpiration);
            Response.Cache.SetLastModified(DateTime.UtcNow);
            return File(Server.MapPath("~/Content/blank.png"), "image/png");
        }
        public ActionResult MessageDetails(int id)
        {
            return View("MessageDetails", _messageService.GetMessageWithDetails(id));
        }
    }

}