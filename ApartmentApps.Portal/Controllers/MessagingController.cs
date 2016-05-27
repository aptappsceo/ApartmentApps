using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Syncfusion.JavaScript;

namespace ApartmentApps.Portal.Controllers
{

    public class MessagingController : CrudController<UserBindingModel, ApplicationUser>
    {
        public MessagingController(IRepository<ApplicationUser> repository, StandardCrudService<ApplicationUser, UserBindingModel> service, PropertyContext context, IUserContext userContext, AlertsService messagingService) : base(repository, service, context, userContext)
        {
            MessagingService = messagingService;
        }

        public AlertsService MessagingService { get; set; }



        public override ActionResult Index()
        {

            return View("Index");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SendMessage(string subject, string message)
        {
            int count;
            MessagingService.SendAlert(GetData(Dm, out count).Select(p => p.Id).ToArray(), subject, message,"Message",0);
            ViewBag.SuccessMessage = "Message Sent";
            return RedirectToAction("Index");
        }
    }
}