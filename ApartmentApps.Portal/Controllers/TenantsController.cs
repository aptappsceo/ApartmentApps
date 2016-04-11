using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;

namespace ApartmentApps.Portal.Controllers
{

    public class WebUserContext : IUserContext
    {
        private readonly ApplicationDbContext _db;
        private ApplicationUser _user;

        public WebUserContext(ApplicationDbContext context)
        {
            _db = context;
        }

        public ApplicationUser CurrentUser
        {
            get
            {
               
                return _user ?? (_user =  _db.Users.FirstOrDefault(p => p.Email == Email));
            }
        }

        public IIdentity User => System.Web.HttpContext.Current.User.Identity;

        public string UserId => CurrentUser.Id;
        public string Email => User.GetUserName();
        public string Name => CurrentUser.FirstName + " " + CurrentUser.LastName;
        public int PropertyId
        {
            get {
                if (CurrentUser.PropertyId != null) return CurrentUser.PropertyId.Value;
                return 1;
            }
        }
    }
    public class AAController : Controller
    {
        public IUserContext UserContext { get; }

        public AAController(PropertyContext context, IUserContext userContext)
        {
            Context = context;
            UserContext = userContext;
        }

        protected PropertyContext Context { get; }

        public ApplicationUser CurrentUser => UserContext.CurrentUser;
        public int PropertyId => UserContext.PropertyId;

        public Property Property => CurrentUser?.Property;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Property != null)
            {
                ViewBag.Property = Property;
                if (User.IsInRole("Admin"))
                {
                    ViewBag.Properties = Context.Properties.GetAll().ToArray();

                }
            }
           
        }
    }
    [Authorize(Roles = "PropertyAdmin")]
    public class TenantsController : AAController
    {
        public TenantsController(PropertyContext context, IUserContext userContext, ApplicationUserManager userManager) : base(context, userContext)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager { get; set; }
       
 

        // GET: /Tenants/
        public ActionResult Index()
        {
            var tenants = Context.Tenants;
            return View(tenants.ToList());
        }

        // GET: /Tenants/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = Context.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // GET: /Tenants/Create
        public ActionResult Create()
        {
            ViewBag.UnitId = new SelectList(Context.Units, "Id", "Name");
            ViewBag.UserId = new SelectList(Context.Users, "Id", "Email");
            return View();
        }

        // POST: /Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="UserId,UnitId,ThirdPartyId,FirstName,LastName,UnitNumber,BuildingName,Address,City,State,PostalCode,Email,Gender,MiddleName")] Tenant tenant)
        {
            if (tenant.UserId == null)
            {

                var user = await UserManager.CreateUser(tenant.Email, tenant.FirstName[0].ToString().ToLower() + tenant.LastName.ToLower(), tenant.FirstName, tenant.LastName);
                user.PropertyId = Property.Id;
                tenant.UserId = user.Id;
            }
            if (ModelState.IsValid)
            {
                Context.Tenants.Add(tenant);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnitId = new SelectList(Context.Units.OrderBy(p=>p.Name), "Id", "Name", tenant.UnitId);
            ViewBag.UserId = new SelectList(Context.Users, "Id", "Email", tenant.UserId);
            return View(tenant);
        }

        // GET: /Tenants/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = Property.Users.FirstOrDefault(p => p.Id == id).Tenant;
            if (tenant == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnitId = new SelectList(Context.Units.OrderBy(p => p.Name), "Id", "Name", tenant.UnitId);
            ViewBag.UserId = new SelectList(Context.Users, "Id", "Email", tenant.UserId);
            return View(tenant);
        }

        // POST: /Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UserId,UnitId,ThirdPartyId,FirstName,LastName,UnitNumber,BuildingName,Address,City,State,PostalCode,Email,Gender,MiddleName")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(tenant);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitId = new SelectList(Context.Units.OrderBy(p => p.Name), "Id", "Name", tenant.UnitId);
            ViewBag.UserId = new SelectList(Context.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", tenant.UserId);
            return View(tenant);
        }

        // GET: /Tenants/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = Context.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // POST: /Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tenant tenant = Context.Tenants.Find(id);
            Context.Tenants.Remove(tenant);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
