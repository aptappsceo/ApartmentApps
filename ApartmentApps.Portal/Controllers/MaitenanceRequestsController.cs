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
    [Authorize(Roles = "PropertyAdmin")]
    public class MaitenanceRequestsController : AAController
    {
        

        // GET: /MaitenanceRequests/
        public ActionResult Index()
        {
            var maitenancerequests = db
                .MaitenanceRequests.Where(p => p.User.PropertyId == Property.Id)
                .Include(m => m.MaitenanceRequestType)
                .Include(m => m.Unit)
                .Include(m => m.User);
            

            return View(maitenancerequests.ToList());
        }

        // GET: /MaitenanceRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitenanceRequest maitenanceRequest = Property.MaitenanceRequests.FirstOrDefault(p=>p.Id == id);
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            return View(maitenanceRequest);
        }

        // GET: /MaitenanceRequests/Create
        public ActionResult Create()
        {
            ViewBag.MaitenanceRequestTypeId = new SelectList(db.MaitenanceRequestTypes, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.MaintenanceRequestStatuses, "Name", "Name");
            ViewBag.UnitId = new SelectList(db.Units.Where(p=>p.Building.PropertyId == Property.Id), "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email");
            ViewBag.WorkerId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email");
            return View();
        }

        // POST: /MaitenanceRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserId,WorkerId,MaitenanceRequestTypeId,UnitId,SubmissionDate,ScheduleDate,CloseDate,StatusId,Message")] MaitenanceRequest maitenanceRequest)
        {
            if (ModelState.IsValid)
            {
                db.MaitenanceRequests.Add(maitenanceRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaitenanceRequestTypeId = new SelectList(db.MaitenanceRequestTypes, "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
            //ViewBag.StatusId = new SelectList(db.MaintenanceRequestStatuses, "Name", "Name", maitenanceRequest.StatusId);
            ViewBag.UnitId = new SelectList(db.Units.Where(p=>p.Building.PropertyId == Property.Id), "Id", "Name", maitenanceRequest.UnitId);
            ViewBag.UserId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", maitenanceRequest.UserId);
            //ViewBag.WorkerId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", maitenanceRequest.WorkerId);
            return View(maitenanceRequest);
        }

        // GET: /MaitenanceRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitenanceRequest maitenanceRequest = Property.MaitenanceRequests.FirstOrDefault(p => p.Id == id);
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaitenanceRequestTypeId = new SelectList(db.MaitenanceRequestTypes, "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
          //  ViewBag.StatusId = new SelectList(db.MaintenanceRequestStatuses, "Name", "Name", maitenanceRequest.StatusId);
            ViewBag.UnitId = new SelectList(db.Units.Where(p=>p.Building.PropertyId == Property.Id), "Id", "Name", maitenanceRequest.UnitId);
            ViewBag.UserId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", maitenanceRequest.UserId);
            //ViewBag.WorkerId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", maitenanceRequest.WorkerId);
            return View(maitenanceRequest);
        }

        // POST: /MaitenanceRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserId,WorkerId,MaitenanceRequestTypeId,UnitId,SubmissionDate,ScheduleDate,CloseDate,StatusId,Message")] MaitenanceRequest maitenanceRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maitenanceRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaitenanceRequestTypeId = new SelectList(db.MaitenanceRequestTypes, "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
            //ViewBag.StatusId = new SelectList(db.MaintenanceRequestStatuses, "Name", "Name", maitenanceRequest.StatusId);
            ViewBag.UnitId = new SelectList(db.Units.Where(p=>p.Building.PropertyId == Property.Id), "Id", "Name", maitenanceRequest.UnitId);
            ViewBag.UserId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", maitenanceRequest.UserId);
            //ViewBag.WorkerId = new SelectList(db.Users.Where(p=>p.PropertyId == Property.Id), "Id", "Email", maitenanceRequest.WorkerId);
            return View(maitenanceRequest);
        }

        // GET: /MaitenanceRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitenanceRequest maitenanceRequest = db.MaitenanceRequests.Find(id);
            if (maitenanceRequest == null)
            {
                return HttpNotFound();
            }
            return View(maitenanceRequest);
        }

        // POST: /MaitenanceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaitenanceRequest maitenanceRequest = Property.MaitenanceRequests.FirstOrDefault(p => p.Id == id);
            db.MaitenanceRequests.Remove(maitenanceRequest);
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
