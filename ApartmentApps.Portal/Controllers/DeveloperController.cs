using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    [Authorize(Roles="Tester")]
    public class TesterController : AAController
    {
        private readonly IRepository<ApplicationUser> _userManager;

        public TesterController( IRepository<ApplicationUser> userManager,IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            _userManager = userManager;
        }
        public ActionResult ViewAsAdmin()
        {
            AssignToRoles("Admin", "Maintenance", "PropertyAdmin");
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult ViewAsOfficer()
        {
            AssignToRoles("Officer");
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult ViewAsPropertyAdmin()
        {
            AssignToRoles("PropertyAdmin");
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult ViewAsTech()
        {
            AssignToRoles( "Maintenance");
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult ViewAsTechSupervisor()
        {
            AssignToRoles("Maintenance", "MaintenanceSupervisor");
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult ViewAsResident()
        {
            AssignToRoles("Resident");
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult ViewAsRoles(string roles)
        {
            AssignToRoles(roles.Split(','));
            return RedirectToAction("Index", "Dashboard");
        }


        private void AssignToRoles(params string[] rolesArray)
        {
            var id = UserContext.UserId;
            var user = _userManager.FirstOrDefault(p => p.Id == id);
            var roles = user.Roles.ToArray();
            foreach (var role in roles)
            {
                user.Roles.Remove(role);
                _userManager.Save();
            }
            foreach (var role in rolesArray)
            {
                user.Roles.Add(new IdentityUserRole()
                {
                    RoleId = role,
                    UserId = user.Id
                });
            }
            user.Roles.Add(new IdentityUserRole()
            {
                RoleId = "Tester",
                UserId = user.Id
            });
            _userManager.Save();
            SignInManager.SignIn(user,false,false);

        }

      
    }
}