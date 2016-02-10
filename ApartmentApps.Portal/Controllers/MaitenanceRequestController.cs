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
    public class MaitenanceRequestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MaitenanceRequest/MaitenanceRequestIndex
        public ActionResult MaitenanceRequestIndex()
        {
            var maitenanceRequest = db.MaitenanceRequests.Include(m => m.MaitenanceRequestType).Include(m => m.User).Include(m => m.Worker);
            return View(maitenanceRequest.ToList());
        }

        /*
        // GET: MaitenanceRequest/MaitenanceRequestDetails/5
        public ActionResult MaitenanceRequestDetails(int? id)
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
        */

        // GET: MaitenanceRequest/MaitenanceRequestCreate
        public ActionResult MaitenanceRequestCreate()
        {
            ViewBag.MaitenanceRequestTypeId = new SelectList(db.MaitenanceRequestTypes, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.WorkerId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: MaitenanceRequest/MaitenanceRequestCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MaitenanceRequestCreate(
            [Bind(Include = "Actions,MaitenanceRequestType,User,Worker,Id,UserId,WorkerId,MaitenanceRequestTypeId,Date,Message")]
        MaitenanceRequest maitenanceRequest)
        {
            if (ModelState.IsValid)
            {
                db.MaitenanceRequests.Add(maitenanceRequest);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a MaitenanceRequest record");
                return RedirectToAction("MaitenanceRequestIndex");
            }

            ViewBag.MaitenanceRequestTypeId = new SelectList(db.MaitenanceRequestTypes, "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", maitenanceRequest.UserId);
            ViewBag.WorkerId = new SelectList(db.Users, "Id", "Email", maitenanceRequest.WorkerId);
            DisplayErrorMessage();
            return View(maitenanceRequest);
        }

        // GET: MaitenanceRequest/MaitenanceRequestEdit/5
        public ActionResult MaitenanceRequestEdit(int? id)
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
            ViewBag.MaitenanceRequestTypeId = new SelectList(db.MaitenanceRequestTypes, "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", maitenanceRequest.UserId);
            ViewBag.WorkerId = new SelectList(db.Users, "Id", "Email", maitenanceRequest.WorkerId);
            return View(maitenanceRequest);
        }

        // POST: MaitenanceRequestMaitenanceRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MaitenanceRequestEdit([Bind(Include = "Actions,MaitenanceRequestType,User,Worker,Id,UserId,WorkerId,MaitenanceRequestTypeId,Date,Message")] MaitenanceRequest maitenanceRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maitenanceRequest).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a MaitenanceRequest record");
                return RedirectToAction("MaitenanceRequestIndex");
            }
            ViewBag.MaitenanceRequestTypeId = new SelectList(db.MaitenanceRequestTypes, "Id", "Name", maitenanceRequest.MaitenanceRequestTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", maitenanceRequest.UserId);
            ViewBag.WorkerId = new SelectList(db.Users, "Id", "Email", maitenanceRequest.WorkerId);
            DisplayErrorMessage();
            return View(maitenanceRequest);
        }

        // GET: MaitenanceRequest/MaitenanceRequestDelete/5
        public ActionResult MaitenanceRequestDelete(int? id)
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

        // POST: MaitenanceRequest/MaitenanceRequestDelete/5
        [HttpPost, ActionName("MaitenanceRequestDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult MaitenanceRequestDeleteConfirmed(int id)
        {
            MaitenanceRequest maitenanceRequest = db.MaitenanceRequests.Find(id);
            db.MaitenanceRequests.Remove(maitenanceRequest);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a MaitenanceRequest record");
            return RedirectToAction("MaitenanceRequestIndex");
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
