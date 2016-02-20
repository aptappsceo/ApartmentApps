﻿using System;
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
    [Authorize(Roles = "PropertyAdmin")]
    public class BuildingsController : AAController
    {
       

        // GET: /Buildings/
        public ActionResult Index()
        {
            var buildings = Property.Buildings;
            return View(buildings.ToList());
        }

        // GET: /Buildings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = Property.Buildings.FirstOrDefault(p=>p.Id == id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // GET: /Buildings/Create
        public ActionResult Create()
        {
            //ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name");
            return View();
        }

        // POST: /Buildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,PropertyId")] Building building)
        {
            building.PropertyId = Property.Id;
            if (ModelState.IsValid)
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", building.PropertyId);
            return View(building);
        }

        // GET: /Buildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = Property.Buildings.FirstOrDefault(p=>p.Id == id);
            if (building == null)
            {
                return HttpNotFound();
            }
            //ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", building.PropertyId);
            return View(building);
        }

        // POST: /Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,PropertyId")] Building building)
        {
            building.PropertyId = Property.Id;
            if (ModelState.IsValid)
            {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.PropertyId = new SelectList(db.Properties, "Id", "Name", building.PropertyId);
            return View(building);
        }

        // GET: /Buildings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = Property.Buildings.FirstOrDefault(p=>p.Id == id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: /Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Building building = Property.Buildings.FirstOrDefault(p => p.Id == id);
            
            db.Buildings.Remove(building);
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
