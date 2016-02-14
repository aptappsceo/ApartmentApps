using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Data;

namespace ApartmentApps.Portal
{
    [Authorize]
    public class PropertyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly PropertyService _propertyService;

        public PropertyController()
        {
            _propertyService = new PropertyService(this);
        }

        public ApplicationDbContext Db
        {
            set { db = value; }
            get { return db; }
        }

        // GET: Property/PropertyIndex
        public ActionResult PropertyIndex()
        {
            var property = db.Properties.Include(p => p.Corporation);
            return View(property.ToList());
        }

        /*
        // GET: Property/PropertyDetails/5
        public ActionResult PropertyDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }
        */

        // GET: Property/PropertyCreate
        public ActionResult PropertyCreate()
        {
            ViewBag.CorporationId = new SelectList(db.Corporations, "Id", "Name");
            return View();
        }

        // POST: Property/PropertyCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PropertyCreate([Bind(Include = "Corporation,PropertyAddons,Tenants,Id,Name,CorporationId")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                db.SaveChanges();
                
                DisplaySuccessMessage("Has append a Property record");
                return RedirectToAction("PropertyIndex");
            }

            ViewBag.CorporationId = new SelectList(db.Corporations, "Id", "Name", property.CorporationId);
            DisplayErrorMessage();
            return View(property);
        }

        // GET: Property/PropertyEdit/5
        public ActionResult PropertyEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.CorporationId = new SelectList(db.Corporations, "Id", "Name", property.CorporationId);
            return View(property);
        }

        // POST: PropertyProperty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PropertyEdit([Bind(Include = "Corporation,PropertyAddons,Tenants,Id,Name,CorporationId")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Property record");
                return RedirectToAction("PropertyIndex");
            }
            ViewBag.CorporationId = new SelectList(db.Corporations, "Id", "Name", property.CorporationId);
            DisplayErrorMessage();
            return View(property);
        }

        // GET: Property/PropertyDelete/5
        public ActionResult PropertyDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Property/PropertyDelete/5
        [HttpPost, ActionName("PropertyDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PropertyDeleteConfirmed(int id)
        {
            _propertyService.DeleteProperty(id);
            DisplaySuccessMessage("Has delete a Property record");
            return RedirectToAction("PropertyIndex");
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
