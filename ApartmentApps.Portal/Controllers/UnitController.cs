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
    public class UnitController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Unit/UnitIndex
        public ActionResult UnitIndex()
        {
            var unit = db.Units.Include(u => u.Building);
            return View(unit.ToList());
        }

        /*
        // GET: Unit/UnitDetails/5
        public ActionResult UnitDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }
        */

        // GET: Unit/UnitCreate
        public ActionResult UnitCreate()
        {
            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Name");
            return View();
        }

        // POST: Unit/UnitCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnitCreate([Bind(Include = "Building,Tenants,Id,BuildingId,Name")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Unit record");
                return RedirectToAction("UnitIndex");
            }

            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Name", unit.BuildingId);
            DisplayErrorMessage();
            return View(unit);
        }

        // GET: Unit/UnitEdit/5
        public ActionResult UnitEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Id", unit.BuildingId);
            return View(unit);
        }

        // POST: UnitUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnitEdit([Bind(Include = "Building,Tenants,Id,BuildingId,Name")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Unit record");
                return RedirectToAction("UnitIndex");
            }
            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Id", unit.BuildingId);
            DisplayErrorMessage();
            return View(unit);
        }

        // GET: Unit/UnitDelete/5
        public ActionResult UnitDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Unit/UnitDelete/5
        [HttpPost, ActionName("UnitDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UnitDeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Unit record");
            return RedirectToAction("UnitIndex");
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
