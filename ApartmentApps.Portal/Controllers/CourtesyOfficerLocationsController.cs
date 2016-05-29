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
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class CourtesyOfficerLocationsController : AAController
    {


        // GET: /CourtesyOfficerLocations/
        public CourtesyOfficerLocationsController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        public ActionResult Index()
        {
            var courtesyofficerlocations = Context.CourtesyOfficerLocations.GetAll();
            return View(courtesyofficerlocations.ToList());
        }

        // GET: /CourtesyOfficerLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtesyOfficerLocation courtesyOfficerLocation = Context.CourtesyOfficerLocations.Find(id);
            if (courtesyOfficerLocation == null)
            {
                return HttpNotFound();
            }
            return View(courtesyOfficerLocation);
        }

        // GET: /CourtesyOfficerLocations/Create
        public ActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name");
            return View();
        }
	
        // POST: /CourtesyOfficerLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Label,LocationId,PropertyId,Latitude,Longitude")] CourtesyOfficerLocation courtesyOfficerLocation)
        {
            if (ModelState.IsValid)
            {
                courtesyOfficerLocation.PropertyId = PropertyId;
                Context.CourtesyOfficerLocations.Add(courtesyOfficerLocation);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", courtesyOfficerLocation.PropertyId);
            return View(courtesyOfficerLocation);
        }

        // GET: /CourtesyOfficerLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtesyOfficerLocation courtesyOfficerLocation = Context.CourtesyOfficerLocations.Find(id);
            
            if (courtesyOfficerLocation == null)
            {
                return HttpNotFound();
            }
            courtesyOfficerLocation.PropertyId = PropertyId;
            return View(courtesyOfficerLocation);
        }

        // POST: /CourtesyOfficerLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Label,LocationId,PropertyId,Latitude,Longitude")] CourtesyOfficerLocation courtesyOfficerLocation)
        {
            if (ModelState.IsValid)
            {
                courtesyOfficerLocation.PropertyId = PropertyId;
                Context.Entry(courtesyOfficerLocation);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", courtesyOfficerLocation.PropertyId);
            return View(courtesyOfficerLocation);
        }

        // GET: /CourtesyOfficerLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtesyOfficerLocation courtesyOfficerLocation = Context.CourtesyOfficerLocations.Find(id);
            if (courtesyOfficerLocation == null)
            {
                return HttpNotFound();
            }
            return View(courtesyOfficerLocation);
        }

        // POST: /CourtesyOfficerLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtesyOfficerLocation courtesyOfficerLocation = Context.CourtesyOfficerLocations.Find(id);
            Context.CourtesyOfficerLocations.Remove(courtesyOfficerLocation);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
