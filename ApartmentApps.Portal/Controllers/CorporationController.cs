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
    public class CorporationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Corporation/CorporationIndex
        public ActionResult CorporationIndex()
        {
            return View(db.Corporations.ToList());
        }

        /*
        // GET: Corporation/CorporationDetails/5
        public ActionResult CorporationDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporation corporation = db.Corporations.Find(id);
            if (corporation == null)
            {
                return HttpNotFound();
            }
            return View(corporation);
        }
        */

        // GET: Corporation/CorporationCreate
        public ActionResult CorporationCreate()
        {
            return View();
        }

        // POST: Corporation/CorporationCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CorporationCreate([Bind(Include = "Properties,Id,Name")] Corporation corporation)
        {
            if (ModelState.IsValid)
            {
                db.Corporations.Add(corporation);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Corporation record");
                return RedirectToAction("CorporationIndex");
            }

            DisplayErrorMessage();
            return View(corporation);
        }

        // GET: Corporation/CorporationEdit/5
        public ActionResult CorporationEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporation corporation = db.Corporations.Find(id);
            if (corporation == null)
            {
                return HttpNotFound();
            }
            return View(corporation);
        }

        // POST: CorporationCorporation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CorporationEdit([Bind(Include = "Properties,Id,Name")] Corporation corporation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(corporation).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Corporation record");
                return RedirectToAction("CorporationIndex");
            }
            DisplayErrorMessage();
            return View(corporation);
        }

        // GET: Corporation/CorporationDelete/5
        public ActionResult CorporationDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporation corporation = db.Corporations.Find(id);
            if (corporation == null)
            {
                return HttpNotFound();
            }
            return View(corporation);
        }

        // POST: Corporation/CorporationDelete/5
        [HttpPost, ActionName("CorporationDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CorporationDeleteConfirmed(int id)
        {
            Corporation corporation = db.Corporations.Find(id);
            db.Corporations.Remove(corporation);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Corporation record");
            return RedirectToAction("CorporationIndex");
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
