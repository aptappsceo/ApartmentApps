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
    [Authorize(Roles = "Admin")]
    public class PropertyYardiInfoController : AAController
    {

        // GET: /PropertyYardiInfo/
        public PropertyYardiInfoController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        public ActionResult Index()
        {
            var propertyyardiinfoes = Context.PropertyYardiInfos.GetAll();
            return View(propertyyardiinfoes.ToList());
        }
       
        // GET: /PropertyYardiInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyYardiInfo propertyYardiInfo = Context.PropertyYardiInfos.Find(id);
            if (propertyYardiInfo == null)
            {
                return HttpNotFound();
            }
            return View(propertyYardiInfo);
        }

        // GET: /PropertyYardiInfo/Create
        public ActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name");
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
                Context.PropertyYardiInfos.Add(propertyYardiInfo);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", propertyYardiInfo.PropertyId);
            return View(propertyYardiInfo);
        }

        // GET: /PropertyYardiInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyYardiInfo propertyYardiInfo = Context.PropertyYardiInfos.Find(id);
            if (propertyYardiInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", propertyYardiInfo.PropertyId);
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
                Context.Entry(propertyYardiInfo);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", propertyYardiInfo.PropertyId);
            return View(propertyYardiInfo);
        }

        // GET: /PropertyYardiInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyYardiInfo propertyYardiInfo = Context.PropertyYardiInfos.Find(id);
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
            PropertyYardiInfo propertyYardiInfo = Context.PropertyYardiInfos.Find(id);
            Context.PropertyYardiInfos.Remove(propertyYardiInfo);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
