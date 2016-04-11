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
    [Authorize(Roles = "Admin")]
    public class PropertyEntrataInfoController : AAController
    {
        

        // GET: /PropertyEntrataInfo/
        public PropertyEntrataInfoController(PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public ActionResult Index()
        {
            var propertyentratainfoes = Context.PropertyEntrataInfos.GetAll();
            return View(propertyentratainfoes.ToList());
        }

        // GET: /PropertyEntrataInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyEntrataInfo propertyEntrataInfo = Context.PropertyEntrataInfos.Find(id);
            if (propertyEntrataInfo == null)
            {
                return HttpNotFound();
            }
            return View(propertyEntrataInfo);
        }

        // GET: /PropertyEntrataInfo/Create
        public ActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name");
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
                Context.PropertyEntrataInfos.Add(propertyEntrataInfo);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", propertyEntrataInfo.PropertyId);
            return View(propertyEntrataInfo);
        }

        // GET: /PropertyEntrataInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyEntrataInfo propertyEntrataInfo = Context.PropertyEntrataInfos.Find(id);
            if (propertyEntrataInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", propertyEntrataInfo.PropertyId);
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
                Context.Entry(propertyEntrataInfo);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", propertyEntrataInfo.PropertyId);
            return View(propertyEntrataInfo);
        }

        // GET: /PropertyEntrataInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyEntrataInfo propertyEntrataInfo = Context.PropertyEntrataInfos.Find(id);
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
            PropertyEntrataInfo propertyEntrataInfo = Context.PropertyEntrataInfos.Find(id);
            Context.PropertyEntrataInfos.Remove(propertyEntrataInfo);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
