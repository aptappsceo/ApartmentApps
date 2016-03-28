﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ApartmentApps.Portal.Controllers
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<string> RolesList { get; set; }
        public List<string> SelectedRoles { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
    [Authorize(Roles = "PropertyAdmin,Admin")]
    public class UserManagementController : AAController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public UserManagementController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        // GET: UserManagement
        public ActionResult Index()
        {
            var applicationusers = db.Users.Include(a => a.Property).Include(a => a.Tenant).Where(p => p.PropertyId == PropertyId);
            return View(applicationusers.ToList());
        }

        public ActionResult EditUser(string id = null)
        {
            var user = db.Users.Include(p=>p.Roles).FirstOrDefault(p => p.PropertyId == PropertyId && p.Id == id);

            var userModel = new UserModel()
            {
                RolesList = db.Roles.Select(p=>p.Id).ToList(),
                
            };
            // If we aren't an admin we shouldn't be able to create admin accounts
            if (!User.IsInRole("Admin"))
            {
                userModel.RolesList.Remove("Admin");
            }
            if (user != null)
            {
                userModel.FirstName = user.FirstName;
                userModel.LastName = user.LastName;
                userModel.Email = user.Email;
                userModel.Id = user.Id;
                userModel.SelectedRoles = user.Roles.Select(p => p.RoleId).ToList();

            }
            return View(userModel);
        }
    

        [HttpPost]
        public async Task<ActionResult> SaveUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(p=>p.PropertyId == PropertyId && p.Id == model.Id );
                var newUser = false;
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        
                    };
                    newUser = true;
                }
                else
                {
                    
                }
                if (!User.IsInRole("Admin"))
                {
                    model.SelectedRoles.Remove("Admin"); // Just to make sure
                }
                user.Email = model.Email;
                user.PropertyId = PropertyId;
                user.UserName = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Roles.Clear();
                foreach (var item in model.SelectedRoles)
                {
                    user.Roles.Add(new IdentityUserRole() { RoleId = item, UserId = user.Id});
                }
                if (newUser)
                {
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {


                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    }
                }
                else
                {
                    await db.SaveChangesAsync();
                }

             
                //AddErrors(result);
            }

          
            return RedirectToAction("Index");
        }
    }
}