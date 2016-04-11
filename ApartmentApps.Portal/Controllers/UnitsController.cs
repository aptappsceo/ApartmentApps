using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    [Authorize(Roles = "PropertyAdmin")]
    public class UnitsController : AAController
    {
      

        // GET: /Units/
        public UnitsController(PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public ActionResult Index()
        {
            var units = Context.Units.ToArray();
            return View(units.ToList());
        }

        // GET: /Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = Context.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: /Units/Create
        public ActionResult Create()
        {
            ViewBag.BuildingId = new SelectList(Context.Buildings, "Id", "Name");
            return View();
        }

        // POST: /Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,BuildingId,Name")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                Context.Units.Add(unit);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuildingId = new SelectList(Context.Buildings, "Id", "Name", unit.BuildingId);
            return View(unit);
        }

        // GET: /Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = Context.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingId = new SelectList(Context.Buildings, "Id", "Name", unit.BuildingId);
            return View(unit);
        }

        // POST: /Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,BuildingId,Name")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(unit);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuildingId = new SelectList(Context.Buildings, "Id", "Name", unit.BuildingId);
            return View(unit);
        }

        // GET: /Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = Context.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: /Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = Context.Units.Find(id);
            Context.Units.Remove(unit);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
