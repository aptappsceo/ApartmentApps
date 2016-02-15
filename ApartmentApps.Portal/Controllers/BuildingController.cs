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
    public class BuildingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Building/BuildingIndex
        public ActionResult BuildingIndex()
        {
            var building = db.Buildings.Include(b => b.Property);
            return View(building.ToList());
        }

        /*
        // GET: Building/BuildingDetails/5
        public ActionResult BuildingDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }
        */

        // GET: Building/BuildingCreate
        public ActionResult BuildingCreate()
        {
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name");
            return View();
        }

        // POST: Building/BuildingCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuildingCreate([Bind(Include = "Property,Units,Id,Name,PropertyId")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Building record");
                return RedirectToAction("BuildingIndex");
            }

            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", building.PropertyId);
            DisplayErrorMessage();
            return View(building);
        }

        // GET: Building/BuildingEdit/5
        public ActionResult BuildingEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", building.PropertyId);
            return View(building);
        }

        // POST: BuildingBuilding/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuildingEdit([Bind(Include = "Property,Units,Id,Name,PropertyId")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Building record");
                return RedirectToAction("BuildingIndex");
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", building.PropertyId);
            DisplayErrorMessage();
            return View(building);
        }

        // GET: Building/BuildingDelete/5
        public ActionResult BuildingDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: Building/BuildingDelete/5
        [HttpPost, ActionName("BuildingDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BuildingDeleteConfirmed(int id)
        {
            Building building = db.Buildings.Find(id);
            db.Buildings.Remove(building);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Building record");
            return RedirectToAction("BuildingIndex");
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
