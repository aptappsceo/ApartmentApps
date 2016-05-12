using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.App_Start;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class MaitenanceRequestModel
    {
      
        //[DataType()]
        [DisplayName("Unit")]
        public int UnitId { get; set; }

        public IEnumerable<FormPropertySelectItem> UnitId_Items
        {
            get
            {
                return
                    NinjectWebCommon.Kernel.Get<IRepository<Unit>>()
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(),p.Name, UnitId == p.Id));

             
            }
        }
        public IEnumerable<FormPropertySelectItem> MaitenanceRequestTypeId_Items
        {
            get
            {
                return
                    NinjectWebCommon.Kernel.Get<IRepository<MaitenanceRequestType>>()
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(),p.Name, MaitenanceRequestTypeId == p.Id));

             
            }
        }

        [DisplayName("Type")]
        public int MaitenanceRequestTypeId { get; set; }

        public IEnumerable<SelectListItem> MaitenanceRequestTypeId_choices()
        {
            return Enumerable.Empty<SelectListItem>();
        }
        [DisplayName("Permission To Enter")]
        public bool PermissionToEnter { get; set; }

        [DisplayName("Pet Status")]
        public PetStatus PetStatus { get; set; }
    
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
  
    }

    [DisplayName("Update Maintenance Request")]
    public class MaintenanceStatusRequestModel
    {
        [DataType("Hidden")]
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
    public enum PetStatus
    {
        NoPet,
        YesContained,
        YesFree
    }
    public class MaitenanceRequestsController : CrudController<MaintenanceRequestViewModel, MaitenanceRequest>
    {
        public IMaintenanceService MaintenanceService { get; set; }

        public MaitenanceRequestsController(IMaintenanceService maintenanceService, IRepository<MaitenanceRequest> repository, StandardCrudService<MaitenanceRequest, MaintenanceRequestViewModel> service, PropertyContext context, IUserContext userContext) : base(repository, service, context, userContext)
        {
            MaintenanceService = maintenanceService;
        }
        public ActionResult NewRequest()
        {

            return View(new MaitenanceRequestModel()
            {
                //MaitenanceRequestTypeId_choices =
                //    Context.MaitenanceRequestTypes.ToArray()
                //        .Select(p => new SelectListItem() {Value = p.Id.ToString(), Text = p.Name}),
                //UnitId_items = Context.Units.ToArray().Select(p=>new SelectListItem() {Value = p.Id.ToString(),Text = p.Name})
            });
        }

        public ActionResult Pause(int id)
        {
            return AutoForm(new MaintenanceStatusRequestModel() { Id = id }, "PauseRequest");
        }
        public ActionResult Complete(int id)
        {
            return AutoForm(new MaintenanceStatusRequestModel() {Id = id}, "CompleteRequest");
        }

        [HttpPost]
        public ActionResult SubmitRequest(MaitenanceRequestModel request)
        {
            
            MaintenanceService.SubmitRequest(
                request.Comments, 
                request.MaitenanceRequestTypeId,
                (int)request.PetStatus, 
                request.PermissionToEnter, 
                null, 
                Convert.ToInt32(request.UnitId)
                );
            return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]
        public ActionResult PauseRequest(MaintenanceStatusRequestModel request)
        {

            MaintenanceService.PauseRequest(
                CurrentUser,
                request.Id,
                request.Comments,null
              
                );
            return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]
        public ActionResult CompleteRequest(MaintenanceStatusRequestModel request)
        {

            MaintenanceService.CompleteRequest(
                CurrentUser,
                request.Id,
                request.Comments, null
                );
            return RedirectToAction("Index");
        }
        public ActionResult Print(int id)
        {
            var item = Service.Find(id);
            return View(item);
        }

    }
    public class AutoGridModel
    {
        private string _title;
        public object[] Model { get; set; }

        public string Title
        {
            get { return _title ?? (_title = Model.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? Model.GetType().Name); }
            set { _title = value; }
        }

        public Type Type { get; set; }


        public AutoGridModel(object[] model)
        {
            Model = model;
        }
    }
    public class AutoFormModel
    {
        private string _title;
        public object Model { get; set; }

        public string Title
        {
            get { return _title ?? (_title = Model.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? Model.GetType().Name); }
            set { _title = value; }
        }

        public string PostAction { get; set; }
        public string PostController { get; set; }

        public AutoFormModel(object model, string postAction, string postController)
        {
            PostController = postController;
            Model = model;
      
            PostAction = postAction;
        }
    }

    public class MaitenanceRequests2Controller : AAController
    {
        // GET: /MaitenanceRequests/
        public MaitenanceRequests2Controller(PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public ActionResult Index()
        {
            var maitenancerequests = Context.MaitenanceRequests.GetAll();
            return View(maitenancerequests.ToList());
        }

        // GET: /MaitenanceRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitenanceRequest maitenanceRequest = Context.MaitenanceRequests.Find(id.Value);
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            return View(maitenanceRequest);
        }

        // GET: /MaitenanceRequests/Create
        public ActionResult Create()
        {
            ViewBag.MaitenanceRequestTypeId = new SelectList(Context.MaitenanceRequestTypes.GetAll(), "Id", "Name");
            ViewBag.StatusId = new SelectList(Context.MaintenanceRequestStatuses.GetAll(), "Name", "Name");
            ViewBag.UnitId = new SelectList(Context.Units.GetAll(), "Id", "Name");
            ViewBag.UserId = new SelectList(Context.Users.GetAll(), "Id", "FirstName");
            return View();
        }

        // POST: /MaitenanceRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserId,MaitenanceRequestTypeId,PermissionToEnter,PetStatus,UnitId,ScheduleDate,Message,StatusId,ImageDirectoryId,SubmissionDate,CompletionDate")] MaitenanceRequest maitenanceRequest)
        {
            if (ModelState.IsValid)
            {
                Context.MaitenanceRequests.Add(maitenanceRequest);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaitenanceRequestTypeId = new SelectList(Context.MaitenanceRequestTypes.GetAll(), "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
            ViewBag.StatusId = new SelectList(Context.MaintenanceRequestStatuses.GetAll(), "Name", "Name", maitenanceRequest.StatusId);
            ViewBag.UnitId = new SelectList(Context.Units.GetAll(), "Id", "Name", maitenanceRequest.UnitId);
            ViewBag.UserId = new SelectList(Context.Users.GetAll(), "Id", "FirstName", maitenanceRequest.UserId);
            return View(maitenanceRequest);
        }

        // GET: /MaitenanceRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitenanceRequest maitenanceRequest = Context.MaitenanceRequests.Find(id.Value);
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaitenanceRequestTypeId = new SelectList(Context.MaitenanceRequestTypes.GetAll(), "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
            ViewBag.StatusId = new SelectList(Context.MaintenanceRequestStatuses.GetAll(), "Name", "Name", maitenanceRequest.StatusId);
            ViewBag.UnitId = new SelectList(Context.Units, "Id", "Name", maitenanceRequest.UnitId);
            ViewBag.UserId = new SelectList(Context.Users, "Id", "FirstName", maitenanceRequest.UserId);
            return View(maitenanceRequest);
        }

        // POST: /MaitenanceRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserId,MaitenanceRequestTypeId,PermissionToEnter,PetStatus,UnitId,ScheduleDate,Message,StatusId,ImageDirectoryId,SubmissionDate,CompletionDate")] MaitenanceRequest maitenanceRequest)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(maitenanceRequest);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaitenanceRequestTypeId = new SelectList(Context.MaitenanceRequestTypes.GetAll(), "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
            ViewBag.StatusId = new SelectList(Context.MaintenanceRequestStatuses.GetAll(), "Name", "Name", maitenanceRequest.StatusId);
            ViewBag.UnitId = new SelectList(Context.Units.GetAll(), "Id", "Name", maitenanceRequest.UnitId);
            ViewBag.UserId = new SelectList(Context.Users.GetAll(), "Id", "FirstName", maitenanceRequest.UserId);
            return View(maitenanceRequest);
        }

        // GET: /MaitenanceRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitenanceRequest maitenanceRequest = Context.MaitenanceRequests.Find(id);
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            return View(maitenanceRequest);
        }

        // POST: /MaitenanceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaitenanceRequest maitenanceRequest = Context.MaitenanceRequests.Find(id);
            Context.MaitenanceRequests.Remove(maitenanceRequest);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
