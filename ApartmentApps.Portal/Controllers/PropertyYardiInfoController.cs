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
    [Authorize(Roles = "Admin")]
    public class PropertyYardiInfoController : AAController
    {

        // GET: /PropertyYardiInfo/
        public ActionResult Index()
        {
            var propertyyardiinfoes = db.PropertyYardiInfos.Include(p => p.Property);
            return View(propertyyardiinfoes.ToList());
        }

        // GET: /PropertyYardiInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyYardiInfo propertyYardiInfo = db.PropertyYardiInfos.Find(id);
            if (propertyYardiInfo == null)
            {
                return HttpNotFound();
            }
            return View(propertyYardiInfo);
        }

        // GET: /PropertyYardiInfo/Create
        public ActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name");
            return View();
        }

        // POST: /PropertyYardiInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PropertyId,Endpoint,Username,Password,YardiPropertyId")] PropertyYardiInfo propertyYardiInfo)
        {
            if (ModelState.IsValid)
            {
                db.PropertyYardiInfos.Add(propertyYardiInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", propertyYardiInfo.PropertyId);
            return View(propertyYardiInfo);
        }

        // GET: /PropertyYardiInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyYardiInfo propertyYardiInfo = db.PropertyYardiInfos.Find(id);
            if (propertyYardiInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", propertyYardiInfo.PropertyId);
            return View(propertyYardiInfo);
        }

        // POST: /PropertyYardiInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PropertyId,Endpoint,Username,Password,YardiPropertyId")] PropertyYardiInfo propertyYardiInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyYardiInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", propertyYardiInfo.PropertyId);
            return View(propertyYardiInfo);
        }

        // GET: /PropertyYardiInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyYardiInfo propertyYardiInfo = db.PropertyYardiInfos.Find(id);
            if (propertyYardiInfo == null)
            {
                return HttpNotFound();
            }
            return View(propertyYardiInfo);
        }

        // POST: /PropertyYardiInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyYardiInfo propertyYardiInfo = db.PropertyYardiInfos.Find(id);
            db.PropertyYardiInfos.Remove(propertyYardiInfo);
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
