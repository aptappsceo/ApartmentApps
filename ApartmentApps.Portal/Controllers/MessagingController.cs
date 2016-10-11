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
using Korzh.EasyQuery;
using Korzh.EasyQuery.Db;
using Microsoft.AspNet.Identity;
using Ninject;
using Syncfusion.JavaScript;
using Korzh.EasyQuery.Mvc;
namespace ApartmentApps.Portal.Controllers
{
    public class CampaignTargetsController : AutoGridController<UserService, UserListModel>
    {
        private readonly MessagingService _messagingService;
        private int _messageId; // UNIT TESTING ONLY

        public CampaignTargetsController(MessagingService messagingService, IKernel kernel, UserService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, context, userContext)
        {
            _messagingService = messagingService;
            EqService.QueryLoader = (query, s) =>
            {
                var q = _messagingService.Find<MessageTargetsViewModel>(s);
                if (q != null)
                {
                    string queryXml = q.TargetsXml;
                    if (!string.IsNullOrEmpty(queryXml))
                    {
                        query.LoadFromString(queryXml);
                    }
                    
                }
            };
            EqService.QuerySaver = (query, s) =>
            {
                var q = _messagingService.Find<MessageTargetsViewModel>(s);
                q.TargetsXml = query.SaveToString();
                q.TargetsDescription = query.GetConditionsText(QueryTextFormats.Default);
                var count = 0;
                Service.GetAll<UserBindingModel>(query, out count, "Id", false, 1, 3);
                q.TargetsCount = count;
                _messagingService.Save(q);

            };
        }

        public override ActionResult ApplyFilter(string queryJson, string optionsJson)
        {
            var query = EqService.LoadQueryDict(queryJson.ToDictionary());
            var q = _messagingService.Find<MessageTargetsViewModel>(MessageId.ToString());
            q.TargetsXml = query.SaveToString();
            q.TargetsDescription = query.GetConditionsText(QueryTextFormats.Default);
            var count = 0;
            Service.GetAll<UserBindingModel>(query, out count, null, false, 1, 3);
            q.TargetsCount = count;
            _messagingService.Save(q);
            return base.ApplyFilter(queryJson, optionsJson);
        }

        public override ActionResult GridResult(GridList<UserListModel> grid)
        {
            ViewBag.MessageId = MessageId;
            if (Request != null && Request.IsAjaxRequest())
            {
                var formHelper = new DefaultFormProvider();
                var gridModel = formHelper.CreateGridFor<UserListModel>();

                gridModel.Items = grid;
                return View("Forms/GridPartial", gridModel);
            }
            return View("List", _messagingService.Find<MessageTargetsViewModel>(MessageId.ToString()));
        }

        public int MessageId
        {
            get
            {
                if (Session == null)
                {
                    return _messageId;
                }
                return (int)Session["MessageId"];
            }
            set
            {
                if (Session == null)
                {
                    _messageId = value;
                }
                else
                {
                    Session["MessageId"] = value;
                }
                
            }
        }
        public ActionResult SelectTargets(int messageId)
        {
            MessageId = messageId;
            ViewBag.MessageId = messageId;
            return RedirectToAction("Index");
        }
    }

    


    public class MessagingController : AutoGridController<MessagingService,MessagingService,MessageViewModel, MessageFormViewModel>
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
            if (Request.IsAjaxRequest())
            {
                return View("OverviewListPartial", grid);
            }
            return View("Overview",grid);
        }

        public ActionResult SelectTargets(int messageId)
        {
            return RedirectToAction("SelectTargets", "CampaignTargets", new {messageId = messageId});
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
            var q = Service.Find<MessageViewModel>(messageId.ToString());
            if (q != null)
            {
                string queryXml = q.TargetsXml;
                var query = new DbQuery();
                if (!string.IsNullOrEmpty(queryXml))
                {
                    if (query.Model != null)
                    {
                        query.LoadFromString(queryXml);
                    }
                    else
                    {
                        query = null;
                    }
                    
                }
                else
                {
                    query = null;
                }
                var count = 0;
                var items = _userService.GetAll<UserBindingModel>(query, out count, null, false, 1, Int32.MaxValue).ToArray().Select(p=>p.Id).Cast<object>().ToArray();

                _module.SendMessage(items, q, string.Empty);
                Service.MarkSent(messageId);
                return RedirectToAction("Details",new {id = messageId});

            }
            return RedirectToAction("Index");
        }
        [ValidateInput(false)]
        public override ActionResult SaveEntry(MessageFormViewModel model)
        {
            bool isNew = model.Id == "0" || string.IsNullOrEmpty(model.Id);
            base.SaveEntry(model);
            if (isNew)
            {
                return RedirectToAction("SelectTargets", "CampaignTargets", new {messageId = model.Id});
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
    }
    public class Messaging2Controller : CrudController<UserBindingModel, ApplicationUser>
    {
        private readonly MessagingService _messageService;
        private readonly MessagingModule _module;
        private ApplicationDbContext _context;
        private IBlobStorageService _blobStorageService;
        public Messaging2Controller(MessagingService messageService, MessagingModule module, IKernel kernel, IRepository<ApplicationUser> repository, StandardCrudService<ApplicationUser> service, PropertyContext context, IUserContext userContext, AlertsModule messagingService, ApplicationDbContext context1, IBlobStorageService blobStorageService) : base(kernel,repository, service, context, userContext)
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


        //[HttpPost, ValidateInput(false)]
        //public ActionResult SendMessage(string subject, string message)
        //{
        //    int count;
        //    var ids = GetData(Dm, out count, true).Select(p => p.Id).ToArray();
            
        //    _module.SendMessage(ids, subject, message, HttpContext.Request.Url.Host + Url.Action("EmailMessageRead", "Messaging"));
        //    ViewBag.SuccessMessage = "Message Sent";
        //    return RedirectToAction("Index");
        //}
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