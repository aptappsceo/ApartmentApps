using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class UserFormModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<string> RolesList { get; set; }
        public List<string> SelectedRoles { get; set; }


        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsTenant { get; set; }

        public int? UnitId { get; set; }


    }

    public class ProfileEditModel
    {
        public string Id { get; set; }



        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ProfileImage { get; set; }

        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    public class UserManagementController : AutoGridController<UserService, UserBindingModel>
    {
        public override string IndexTitle => "User Management";
        private ApplicationUserManager _userManager;

        public UserManagementController(IKernel kernel, UserService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, context, userContext)
        {
        }
        public override ActionResult GridResult(GridList<UserBindingModel> grid)
        {
            if (Request.IsAjaxRequest())
            {
                return View("OverviewListPartial", grid);
            }
            return base.GridResult(grid);
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
        [HttpPost]
        public async Task<ActionResult> SaveUser(UserFormModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Context.Users.Find(model.Id);
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
                user.UnitId = model.UnitId;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Roles.Clear();
                foreach (var item in model.SelectedRoles)
                {
                    user.Roles.Add(new IdentityUserRole() { RoleId = item, UserId = user.Id });
                }
                if (newUser)
                {

                    var result = await UserManager.CreateAsync(user, "Temp1234!");
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
                    Context.SaveChanges();
                }


                //AddErrors(result);
            }


            return RedirectToAction("Index");
        }
        public override ActionResult Entry(string id = null)
        {
            var user = Context.Users.Find(id);

            var userModel = new UserFormModel()
            {
                RolesList = Context.Roles.Select(p => p.Id).ToList(),

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
                userModel.PhoneNumber = user.PhoneNumber;
                userModel.UnitId = user.UnitId;
                userModel.SelectedRoles = user.Roles.Select(p => p.RoleId).ToList();

            }
            ViewBag.UnitId = new SelectList(Context.Units.OrderBy(p => p.Name), "Id", "Name", user?.UnitId);

            return View("EditUser", userModel);
            //return base.Entry(id);
        }
        
    }

    [Authorize(Roles = "PropertyAdmin,Admin")]
    public class UserManagementController2 : CrudController<UserBindingModel,ApplicationUser>
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        //public UserManagementController(PropertyContext context, IUserContext userContext, ApplicationSignInManager signInManager, ApplicationUserManager userManager) : base(context, userContext)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //}

        public UserManagementController2(IKernel kernel, IRepository<ApplicationUser> repository, StandardCrudService<ApplicationUser> service, PropertyContext context, IUserContext userContext, ApplicationSignInManager signInManager, ApplicationUserManager userManager) : base(kernel, repository, service, context, userContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

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

        // GET: UserManagement
        public override ActionResult Index()
        {
            return View(Service.GetAll<UserBindingModel>().Where(u=>!u.Archived));
        }
        public ActionResult DeleteUser(string id)
        {
            var user = Context.Users.Find(id);

            return View("Delete", user);

        }
        // POST: /Units/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserConfirmed(string id)
        {
            //var unit = Service.Find(id);
            var user = Context.Users.Find(id);
            user.Archived = true;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditUser(string id = null)
        {
            var user = Context.Users.Find(id);

            var userModel = new UserFormModel()
            {
                RolesList = Context.Roles.Select(p=>p.Id).ToList(),
                
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
                userModel.PhoneNumber = user.PhoneNumber;
                userModel.UnitId = user.UnitId;
                userModel.SelectedRoles = user.Roles.Select(p => p.RoleId).ToList();

            }
            ViewBag.UnitId = new SelectList(Context.Units.OrderBy(p=>p.Name), "Id", "Name", user?.UnitId);

            return View(userModel);
        }
    

        [HttpPost]
        public async Task<ActionResult> SaveUser(UserFormModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Context.Users.Find(model.Id);
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
                user.UnitId = model.UnitId;
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
                  
                    var result = await UserManager.CreateAsync(user, "Temp1234!");
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
                    Context.SaveChanges();
                }

             
                //AddErrors(result);
            }

          
            return RedirectToAction("Index");
        }
    }
}