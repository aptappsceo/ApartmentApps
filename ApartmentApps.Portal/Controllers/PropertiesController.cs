using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data;
using Microsoft.AspNet.Identity.Owin;

namespace ApartmentApps.Portal.Controllers
{
    [RoutePrefix("Property")]
    [Authorize(Roles = "Admin")]
    public class PropertiesController : AAController
    {
        
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: /Properties/
        public ActionResult Index()
        {
            
            var properties = db.Properties.Include(p => p.Corporation);
            return View(properties.ToList());
        }

        public async Task<ActionResult> ImportEntrata(int id)
        {
            var result = await EntrataIntegration.ImportData(UserManager,db, db.Properties.Find(id));
            return RedirectToAction("Index");
        }
        // GET: /Properties/Details/5
        public ActionResult Details(int? id)
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

        // GET: /Properties/Create
        public ActionResult Create()
        {
            ViewBag.CorporationId = new SelectList(db.Corporations, "Id", "Name");
            return View();
        }

        // POST: /Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,CorporationId")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CorporationId = new SelectList(db.Corporations, "Id", "Name", property.CorporationId);
            return View(property);
        }

        // GET: /Properties/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: /Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,CorporationId")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CorporationId = new SelectList(db.Corporations, "Id", "Name", property.CorporationId);
            return View(property);
        }

        // GET: /Properties/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: /Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);
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
