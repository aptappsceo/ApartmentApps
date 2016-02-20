using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Data;
using Microsoft.AspNet.Identity;

namespace ApartmentApps.Portal.Controllers
{
    public class AAController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationUser CurrentUser
        {
            get
            {
                var uName = User.Identity.GetUserName();
                return db.Users.FirstOrDefault(p => p.Email == uName);
            }
        }

        public Property Property
        {
            get { return CurrentUser.Property; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewBag.Property = Property;
            if (User.IsInRole("Admin"))
            {
                ViewBag.Properties = db.Properties.ToArray();
                
            }
        }
    }
    [Authorize(Roles = "PropertyAdmin")]
    public class TenantsController : AAController
    {
        public ApplicationUserManager UserManager { get; set; }
       
        public TenantsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        // GET: /Tenants/
        public ActionResult Index()
        {
            var tenants = db.Tenants.Include(t => t.Unit).Include(t => t.User).Where(p=>p.User.PropertyId == Property.Id);
            return View(tenants.ToList());
        }

        // GET: /Tenants/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = Property.Tenants.FirstOrDefault(p=>p.User.PropertyId == Property.Id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // GET: /Tenants/Create
        public ActionResult Create()
        {
            ViewBag.UnitId = new SelectList(db.Units.Where(p=>p.Building.PropertyId == Property.Id), "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email");
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

                var user = await UserManager.CreateUser(tenant.Email, tenant.FirstName[0].ToString().ToLower() + tenant.LastName.ToLower());
                user.PropertyId = Property.Id;
                tenant.UserId = user.Id;
            }
            if (ModelState.IsValid)
            {
                db.Tenants.Add(tenant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnitId = new SelectList(db.Units.Where(p=>p.Building.PropertyId == Property.Id).Where(p=>p.Building.PropertyId == Property.Id), "Id", "Name", tenant.UnitId);
            ViewBag.UserId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", tenant.UserId);
            return View(tenant);
        }

        // GET: /Tenants/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = Property.Tenants.FirstOrDefault(p => p.User.PropertyId == Property.Id && p.UserId == id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnitId = new SelectList(db.Units.Where(p=>p.Building.PropertyId == Property.Id), "Id", "Name", tenant.UnitId);
            ViewBag.UserId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", tenant.UserId);
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
                db.Entry(tenant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitId = new SelectList(db.Units.Where(p=>p.Building.PropertyId == Property.Id), "Id", "Name", tenant.UnitId);
            ViewBag.UserId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", tenant.UserId);
            return View(tenant);
        }

        // GET: /Tenants/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
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
            Tenant tenant = Property.Tenants.FirstOrDefault(p => p.User.PropertyId == Property.Id && p.UserId == id);
            db.Tenants.Remove(tenant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
