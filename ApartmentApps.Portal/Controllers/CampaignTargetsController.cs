using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Mvc;
using Ninject;

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
}