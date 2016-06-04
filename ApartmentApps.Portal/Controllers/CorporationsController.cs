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
    public class CorporationsController : AAController
    {
    

        // GET: /Corporations/
        public CorporationsController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        public ActionResult Index()
        {
            return View(Context.Corporations.ToList());
        }

        // GET: /Corporations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporation corporation = Context.Corporations.Find(id);
            if (corporation == null)
            {
                return HttpNotFound();
            }
            return View(corporation);
        }

        // GET: /Corporations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Corporations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] Corporation corporation)
        {
            if (ModelState.IsValid)
            {
                Context.Corporations.Add(corporation);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(corporation);
        }

        // GET: /Corporations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporation corporation = Context.Corporations.Find(id);
            if (corporation == null)
            {
                return HttpNotFound();
            }
            return View(corporation);
        }

        // POST: /Corporations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] Corporation corporation)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(corporation);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(corporation);
        }

        // GET: /Corporations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporation corporation = Context.Corporations.Find(id);
            if (corporation == null)
            {
                return HttpNotFound();
            }
            return View(corporation);
        }

        // POST: /Corporations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Corporation corporation = Context.Corporations.Find(id);
            Context.Corporations.Remove(corporation);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
