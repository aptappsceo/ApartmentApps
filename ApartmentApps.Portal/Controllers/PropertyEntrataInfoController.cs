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
    public class PropertyEntrataInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PropertyEntrataInfo/
        public ActionResult Index()
        {
            var propertyentratainfoes = db.PropertyEntrataInfos.Include(p => p.Property);
            return View(propertyentratainfoes.ToList());
        }

        // GET: /PropertyEntrataInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyEntrataInfo propertyEntrataInfo = db.PropertyEntrataInfos.Find(id);
            if (propertyEntrataInfo == null)
            {
                return HttpNotFound();
            }
            return View(propertyEntrataInfo);
        }

        // GET: /PropertyEntrataInfo/Create
        public ActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name");
            return View();
        }

        // POST: /PropertyEntrataInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PropertyId,Endpoint,Username,Password,EntrataPropertyId")] PropertyEntrataInfo propertyEntrataInfo)
        {
            if (ModelState.IsValid)
            {
                db.PropertyEntrataInfos.Add(propertyEntrataInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", propertyEntrataInfo.PropertyId);
            return View(propertyEntrataInfo);
        }

        // GET: /PropertyEntrataInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyEntrataInfo propertyEntrataInfo = db.PropertyEntrataInfos.Find(id);
            if (propertyEntrataInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", propertyEntrataInfo.PropertyId);
            return View(propertyEntrataInfo);
        }

        // POST: /PropertyEntrataInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PropertyId,Endpoint,Username,Password,EntrataPropertyId")] PropertyEntrataInfo propertyEntrataInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyEntrataInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", propertyEntrataInfo.PropertyId);
            return View(propertyEntrataInfo);
        }

        // GET: /PropertyEntrataInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyEntrataInfo propertyEntrataInfo = db.PropertyEntrataInfos.Find(id);
            if (propertyEntrataInfo == null)
            {
                return HttpNotFound();
            }
            return View(propertyEntrataInfo);
        }

        // POST: /PropertyEntrataInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyEntrataInfo propertyEntrataInfo = db.PropertyEntrataInfos.Find(id);
            db.PropertyEntrataInfos.Remove(propertyEntrataInfo);
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
