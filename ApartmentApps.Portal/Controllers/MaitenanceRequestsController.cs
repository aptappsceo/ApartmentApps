using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
    public static class SortExtensions
    {
        public static IEnumerable<T> OrderByAlphaNumeric<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            int max = source
                .SelectMany(i => Regex.Matches(selector(i), @"\d+").Cast<Match>().Select(m => (int?)m.Value.Length))
                .Max() ?? 0;

            return source.OrderBy(i => Regex.Replace(selector(i), @"\d+", m => m.Value.PadLeft(max, '0')));
        }
    }
    public class AlphanumComparatorFast : IComparer
    {
        List<string> GetList(string s1)
        {
            List<string> SB1 = new List<string>();
            string st1, st2, st3;
            st1 = "";
            bool flag = char.IsDigit(s1[0]);
            foreach (char c in s1)
            {
                if (flag != char.IsDigit(c) || c == '\'')
                {
                    if (st1 != "")
                        SB1.Add(st1);
                    st1 = "";
                    flag = char.IsDigit(c);
                }
                if (char.IsDigit(c))
                {
                    st1 += c;
                }
                if (char.IsLetter(c))
                {
                    st1 += c;
                }


            }
            SB1.Add(st1);
            return SB1;
        }

        public int Compare(object x, object y)
        {
            string s1 = x as string;
            if (s1 == null)
            {
                return 0;
            }
            string s2 = y as string;
            if (s2 == null)
            {
                return 0;
            }
            if (s1 == s2)
            {
                return 0;
            }
            int len1 = s1.Length;
            int len2 = s2.Length;
            int marker1 = 0;
            int marker2 = 0;

            // Walk through two the strings with two markers.
            List<string> str1 = GetList(s1);
            List<string> str2 = GetList(s2);
            while (str1.Count != str2.Count)
            {
                if (str1.Count < str2.Count)
                {
                    str1.Add("");
                }
                else
                {
                    str2.Add("");
                }
            }
            int x1 = 0; int res = 0; int x2 = 0; string y2 = "";
            bool status = false;
            string y1 = ""; bool s1Status = false; bool s2Status = false;
            //s1status ==false then string ele int;
            //s2status ==false then string ele int;
            int result = 0;
            for (int i = 0; i < str1.Count && i < str2.Count; i++)
            {
                status = int.TryParse(str1[i].ToString(), out res);
                if (res == 0)
                {
                    y1 = str1[i].ToString();
                    s1Status = false;
                }
                else
                {
                    x1 = Convert.ToInt32(str1[i].ToString());
                    s1Status = true;
                }

                status = int.TryParse(str2[i].ToString(), out res);
                if (res == 0)
                {
                    y2 = str2[i].ToString();
                    s2Status = false;
                }
                else
                {
                    x2 = Convert.ToInt32(str2[i].ToString());
                    s2Status = true;
                }
                //checking --the data comparision
                if (!s2Status && !s1Status)    //both are strings
                {
                    result = str1[i].CompareTo(str2[i]);
                }
                else if (s2Status && s1Status) //both are intergers
                {
                    if (x1 == x2)
                    {
                        if (str1[i].ToString().Length < str2[i].ToString().Length)
                        {
                            result = 1;
                        }
                        else if (str1[i].ToString().Length > str2[i].ToString().Length)
                            result = -1;
                        else
                            result = 0;
                    }
                    else
                    {
                        int st1ZeroCount = str1[i].ToString().Trim().Length - str1[i].ToString().TrimStart(new char[] { '0' }).Length;
                        int st2ZeroCount = str2[i].ToString().Trim().Length - str2[i].ToString().TrimStart(new char[] { '0' }).Length;
                        if (st1ZeroCount > st2ZeroCount)
                            result = -1;
                        else if (st1ZeroCount < st2ZeroCount)
                            result = 1;
                        else
                            result = x1.CompareTo(x2);

                    }
                }
                else
                {
                    result = str1[i].CompareTo(str2[i]);
                }
                if (result == 0)
                {
                    continue;
                }
                else
                    break;

            }
            return result;
        }
    }
    public class MaitenanceRequestModel
    {
      
        //[DataType()]
        [DisplayName("Unit")]
        public int UnitId { get; set; }

        public IEnumerable<FormPropertySelectItem> UnitId_Items
        {
            get
            {
                var items =
                    NinjectWebCommon.Kernel.Get<IRepository<Unit>>()
                        .ToArray().OrderByAlphaNumeric(p=>p.Name);
                

                return items.Select(p => new FormPropertySelectItem(p.Id.ToString(),p.Name, UnitId == p.Id));

             
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
        public override ActionResult Index()
        {
            return View(Service.GetAll().OrderByDescending(p=>p.RequestDate));
        }

        public MaitenanceRequestsController(IKernel kernel, IMaintenanceService maintenanceService, IRepository<MaitenanceRequest> repository, StandardCrudService<MaitenanceRequest, MaintenanceRequestViewModel> service, PropertyContext context, IUserContext userContext) : base(kernel,repository, service, context, userContext)
        {
            MaintenanceService = maintenanceService;
        }

        public ActionResult MySchedule()
        {
            return View();
        }

        public JsonResult MyScheduleData()
        {
            return Json(MaintenanceService.GetAppointments(), JsonRequestBehavior.AllowGet);
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
        public MaitenanceRequests2Controller(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
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
