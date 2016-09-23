using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class BuildingsController :
          AutoGridController<BuildingService, BuildingViewModel>
    {
        public BuildingsController(IKernel kernel, BuildingService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, context, userContext)
        {
        }
        
    }
    //public class Buildings3Controller : CrudController<BuildingViewModel,Building>
    //{
    //    public Buildings3Controller(IRepository<Building> repository, StandardCrudService<Building, BuildingViewModel> service, PropertyContext context, IUserContext userContext) : base(repository, service, context, userContext)
    //    {
    //    }
    //}
    [Authorize(Roles = "PropertyAdmin")]
    public class Buildings2Controller : AAController
    {
       

        // GET: /Buildings/
        public Buildings2Controller(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

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
                Context.Buildings.Add(building);
                Context.SaveChanges();
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
                Context.Entry(building);
                Context.SaveChanges();
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
            
            Context.Buildings.Remove(building);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
