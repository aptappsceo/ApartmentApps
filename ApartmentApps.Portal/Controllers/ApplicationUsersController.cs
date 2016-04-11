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
    public class ApplicationUsersController : AAController
    {
    

        // GET: /ApplicationUsers/
        public ApplicationUsersController(PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        public ActionResult Index()
        {
            var applicationusers = Context.Users.GetAll();
            return View(applicationusers.ToList());
        }
        
        // GET: /ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = Context.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: /ApplicationUsers/Create
        public ActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name");
            ViewBag.Id = new SelectList(Context.Tenants, "UserId", "ThirdPartyId");
            ViewBag.Roles = new SelectList(Context.Roles, "Id", "Name");
            return View();
        }

        // POST: /ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,PropertyId,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")]
        ApplicationUser applicationUser, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                Context.Users.Add(applicationUser);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", applicationUser.PropertyId);
            ViewBag.Id = new SelectList(Context.Tenants, "UserId", "ThirdPartyId", applicationUser.Id);
           
            return View(applicationUser);
        }

        // GET: /ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = Context.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", applicationUser.PropertyId);
            ViewBag.Id = new SelectList(Context.Tenants, "UserId", "ThirdPartyId", applicationUser.Id);
            return View(applicationUser);
        }

        // POST: /ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,PropertyId,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(applicationUser);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(Context.Properties, "Id", "Name", applicationUser.PropertyId);
            ViewBag.Id = new SelectList(Context.Tenants, "UserId", "ThirdPartyId", applicationUser.Id);
            return View(applicationUser);
        }

        // GET: /ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = Context.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: /ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = Context.Users.Find(id);
            Context.Users.Remove(applicationUser);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

    
    }
}
