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
using ApartmentApps.Forms;
using Korzh.EasyQuery.Db;
using Microsoft.AspNet.Identity;
using Ninject;
using Syncfusion.JavaScript;

namespace ApartmentApps.Portal.Controllers
{
    public class MessagingController : AutoGridController<MessagingService, MessagingService, MessageViewModel, MessageFormViewModel>
    {
        private readonly UserService _userService;
        private readonly MessagingService _messageService;
        private readonly MessagingModule _module;
        private ApplicationDbContext _context;
        private IBlobStorageService _blobStorageService;

        public MessagingController(UserService userService, IKernel kernel, MessagingService formService, MessagingService indexService, PropertyContext context, IUserContext userContext, MessagingService service, MessagingService messageService, MessagingModule module, ApplicationDbContext context2, IBlobStorageService blobStorageService, AlertsModule messagingService) : base(kernel, formService, indexService, context, userContext, service)
        {
            _userService = userService;
            _messageService = messageService;
            _module = module;
            _context = context2;
            _blobStorageService = blobStorageService;
            MessagingService = messagingService;
        }

        public AlertsModule MessagingService { get; set; }

        public override ActionResult Entry(string id = null)
        {
            if (id != null && id != "0")
            {
                return View("EditMessage", InitFormModel(_formService.Find<MessageFormViewModel>(id)));
            }
            return View("EditMessage", InitFormModel(CreateFormModel()));
        }
        public override ActionResult GridResult(GridList<MessageViewModel> grid)
        {
            if (Request != null && Request.IsAjaxRequest())
            {
                return View("OverviewListPartial", grid);
            }
            return View("Overview", grid);
        }

        public ActionResult SelectTargets(int messageId)
        {
            return RedirectToAction("SelectTargets", "CampaignTargets", new { messageId = messageId });
        }
        public ActionResult History()
        {
            return View("History", _messageService.GetHistory<MessageViewModel>());
        }


        public ActionResult FileActionMethods(FileExplorerParams args)
        {

            SyncfusionAzureBlobStorageOperations opeartion = new SyncfusionAzureBlobStorageOperations(_blobStorageService, CurrentUser, _context);
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

        public ActionResult SendMessage(int messageId)
        {
            Service.QueueSend(messageId);
            return RedirectToAction("MessageDetails", new {id=messageId.ToString()});
        }
        [ValidateInput(false)]
        public override ActionResult SaveEntry(MessageFormViewModel model)
        {
            bool isNew = model.Id == "0" || string.IsNullOrEmpty(model.Id);
            base.SaveEntry(model);
            if (isNew)
            {
                return RedirectToAction("SelectTargets", "CampaignTargets", new { messageId = model.Id });
            }
            else
            {
                return RedirectToAction("MessageDetails", new { id = model.Id });
            }
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

        public ActionResult ShowByUser(string id)
        {
            this.CustomQuery = Service.SentByUser(id);
            this.CurrentQueryId = "CustomQuery";
            return Index();
        }
    }

}