using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
        private ApplicationDbContext _context;
        private IBlobStorageService _blobStorageService;
        public MessagingController(MessagingService messageService, MessagingModule module, IKernel kernel, IRepository<ApplicationUser> repository, StandardCrudService<ApplicationUser> service, PropertyContext context, IUserContext userContext, AlertsModule messagingService, ApplicationDbContext context1, IBlobStorageService blobStorageService) : base(kernel,repository, service, context, userContext)
        {
            _messageService = messageService;
            _module = module;
            MessagingService = messagingService;
            _context = context1;
            _blobStorageService = blobStorageService;
        }

        public AlertsModule MessagingService { get; set; }



        public override ActionResult Index()
        {

            return View("Index");
        }

        public ActionResult History()
        {
            return View("History", _messageService.GetHistory<MessageViewModel>());
        }


        public ActionResult FileActionMethods(FileExplorerParams args)
        {

            SyncfusionAzureBlobStorageOperations opeartion = new SyncfusionAzureBlobStorageOperations(_blobStorageService,CurrentUser,_context);
            switch (args.ActionType)
            {
                case "Read":
                    var read = opeartion.Read(args.Path, args.ExtensionsAllow);
                    return Json(read);
                case "CreateFolder":
                    return Json(opeartion.CreateFolder(args.Path, args.Name));
                case "Paste":
                    return Json(opeartion.Paste(args.LocationFrom, args.LocationTo, args.Names, args.Action, args.CommonFiles));
                case "Remove":
                    return Json(opeartion.Remove(args.Names, args.Path));
                case "Rename":
                    return Json(opeartion.Rename(args.Path, args.Name, args.NewName, args.CommonFiles));
                case "GetDetails":
                    return Json(opeartion.GetDetails(args.Path, args.Names));
                case "Download":
                    opeartion.Download(args.Path, args.Names);
                    break;
                case "Upload":

                    opeartion.Upload(args.FileUpload, args.Path);
                    break;
            }
            return Json("");
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult SendMessage(string subject, string message)
        {
            int count;
            var ids = GetData(Dm, out count, true).Select(p => p.Id).ToArray();
            
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
        public ActionResult MessageDetails(string id)
        {
            return View("MessageDetails", _messageService.GetMessageWithDetails(id));
        }
    }

}