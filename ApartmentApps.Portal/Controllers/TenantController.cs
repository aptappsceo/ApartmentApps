using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Data;

namespace ApartmentApps.Portal.Controllers
{
    [Authorize]
    public class TenantController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tenant/TenantIndex
        public ActionResult TenantIndex()
        {
            var tenant = db.Tenants.Include(t => t.Unit).Include(t => t.User);
            return View(tenant.ToList());
        }

        /*
        // GET: Tenant/TenantDetails/5
        public ActionResult TenantDetails(string id)
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
        */

        // GET: Tenant/TenantCreate
        public ActionResult TenantCreate()
        {
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Tenant/TenantCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TenantCreate([Bind(Include = "Unit,User,UserId,UnitId,ThirdPartyId,FirstName,LastName,UnitNumber,BuildingName,Address,City,State,PostalCode,Email,Gender,MiddleName")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Tenants.Add(tenant);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Tenant record");
                return RedirectToAction("TenantIndex");
            }

            ViewBag.UnitId = new SelectList(db.Units, "Id", "Name", tenant.UnitId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", tenant.UserId);
            DisplayErrorMessage();
            return View(tenant);
        }

        // GET: Tenant/TenantEdit/5
        public ActionResult TenantEdit(string id)
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
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Name", tenant.UnitId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", tenant.UserId);
            return View(tenant);
        }

        // POST: TenantTenant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TenantEdit([Bind(Include = "Unit,User,UserId,UnitId,ThirdPartyId,FirstName,LastName,UnitNumber,BuildingName,Address,City,State,PostalCode,Email,Gender,MiddleName")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenant).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Tenant record");
                return RedirectToAction("TenantIndex");
            }
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Name", tenant.UnitId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", tenant.UserId);
            DisplayErrorMessage();
            return View(tenant);
        }

        // GET: Tenant/TenantDelete/5
        public ActionResult TenantDelete(string id)
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

        // POST: Tenant/TenantDelete/5
        [HttpPost, ActionName("TenantDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TenantDeleteConfirmed(string id)
        {
            Tenant tenant = db.Tenants.Find(id);
            db.Tenants.Remove(tenant);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Tenant record");
            return RedirectToAction("TenantIndex");
        }

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
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
