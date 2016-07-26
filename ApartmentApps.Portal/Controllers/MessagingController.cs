using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public MessagingController(MessagingService messageService, MessagingModule module, IKernel kernel, IRepository<ApplicationUser> repository, StandardCrudService<ApplicationUser, UserBindingModel> service, PropertyContext context, IUserContext userContext, AlertsService messagingService) : base(kernel,repository, service, context, userContext)
        {
            _messageService = messageService;
            _module = module;
            MessagingService = messagingService;
        }

        public AlertsService MessagingService { get; set; }



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
            _module.SendMessage(ids, subject, message);
            ViewBag.SuccessMessage = "Message Sent";
            return RedirectToAction("Index");
        }
    }
}