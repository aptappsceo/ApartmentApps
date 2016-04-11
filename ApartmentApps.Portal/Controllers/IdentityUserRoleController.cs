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
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.Portal.Controllers
{
    public class IdentityUserRoleController : AAController
    {
        //    // GET: /IdentityUserRole/
        //    public ActionResult Index()
        //    {
        //        return View(db.IdentityUserRoles.ToList());
        //    }

        //    // GET: /IdentityUserRole/Details/5
        //    public ActionResult Details(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        IdentityUserRole2 identityUserRole2 = db.IdentityUserRoles.Find(id);
        //        if (identityUserRole2 == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(identityUserRole2);
        //    }

        //    // GET: /IdentityUserRole/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        // POST: /IdentityUserRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        public IdentityUserRoleController(PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,UserId")] IdentityUserRole identityUserRole2)
        {
            if (ModelState.IsValid)
            {
                var user = Context.Users.Find(identityUserRole2.UserId);
                user.Roles.Add(identityUserRole2);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(identityUserRole2);
        }

        //    // GET: /IdentityUserRole/Edit/5
        //    public ActionResult Edit(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        IdentityUserRole2 identityUserRole2 = db.IdentityUserRoles.Find(id);
        //        if (identityUserRole2 == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(identityUserRole2);
        //    }

        //    // POST: /IdentityUserRole/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include="RoleId,UserId")] IdentityUserRole2 identityUserRole2)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(identityUserRole2).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(identityUserRole2);
        //    }

        //    // GET: /IdentityUserRole/Delete/5
        //    public ActionResult Delete(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        IdentityUserRole2 identityUserRole2 = db.IdentityUserRoles.Find(id);
        //        if (identityUserRole2 == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(identityUserRole2);
        //    }

        //    // POST: /IdentityUserRole/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(string id)
        //    {
        //        IdentityUserRole2 identityUserRole2 = db.IdentityUserRoles.Find(id);
        //        db.IdentityUserRoles.Remove(identityUserRole2);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}
