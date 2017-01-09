using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{


    public class UserFormModel : BaseViewModel
    {
        private readonly UnitService _unitService;

        public UserFormModel()
        {
        }
        [Inject]
        public UserFormModel(UnitService unitService)
        {
            _unitService = unitService;
        }


        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [SelectFrom(nameof(RolesList))]
        public List<string> SelectedRoles { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Email Adress")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Is Tenant ?")]
        public bool IsTenant { get; set; }

        [SelectFrom(nameof(UnitItems))]
        [DisplayName("Assigned Unit")]
        public int? UnitId { get; set; }

        [AutoformIgnore]
        public List<UnitViewModel> UnitItems => _unitService.GetAll<UnitViewModel>().ToList();

        [AutoformIgnore]
        public List<RoleBindingModel> RolesList { get; set; }

        [AutoformIgnore]
        public string Password { get; set; }
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

    [Authorize(Roles = "Admin,PropertyAdmin")]
    public class UserManagementController : AutoGridController<UserService, UserBindingModel>
    {
        public override string IndexTitle => "User Management";
        private ApplicationUserManager _userManager;

        public UserManagementController(IKernel kernel, UserService formService, PropertyContext context,
            IUserContext userContext) : base(kernel, formService, context, userContext)
        {
        }
        
        public override ActionResult GridResult(GridList<UserBindingModel> grid)
        {
            if (Request != null && Request.IsAjaxRequest())
            {
                return View("OverviewListPartial", grid);
            }
            return base.GridResult(grid);
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public void Unarchive(string id)
        {
            Service.Unarchive(id);
        }
        public void SendEngagementLetter(string id)
        {
            var alertsModule = Modules.OfType<AlertsModule>().FirstOrDefault();
            alertsModule?.SendUserEngagementLetter(Repository<ApplicationUser>().Find(id));
        }
        [Authorize(Roles = "PropertyAdmin, Admin")]
        public ActionResult HardResetPassword(string userId)
        {
            //        UserManager<IdentityUser> userManager =
            //new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            var newPassword = Guid.NewGuid().ToString().Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];

            UserManager.RemovePassword(userId);
            UserManager.AddPassword(userId, newPassword);

            var userRepo = Kernel.Get<IRepository<ApplicationUser>>();
            var user = userRepo.Find(userId);
            var userMapper = Kernel.Get<IMapper<ApplicationUser, UserBindingModel>>();
            var alertsModule = Kernel.Get<AlertsModule>();

            alertsModule.SendEmail(new ActionEmailData()
            {
                FromEmail = "auto@apartmentapps.com",
                ToEmail = user.Email,
                Message = $"Username: {user.UserName} {Environment.NewLine}Password: {newPassword}{Environment.NewLine}It is highly recommended that you change your password once you log-in!",
                User = userMapper.ToViewModel(user),
                Subject = "Here is your account information.",
                Links = new Dictionary<string, string>()
                {
                    { "Login Now", "http://portal.apartmentapps.com/Account/Login" }
                }
            });
            return RedirectToAction("Index");
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

                if (Request != null && Request.IsAjaxRequest())
                {
                    return JsonUpdate();
                }
                else
                {
                    return RedirectToAction("Index");
                }


                //AddErrors(result);
            }
            else
            {
                return AutoForm(model, nameof(SaveUser), "Create/Update User Information");
            }


        }

        public override ActionResult Entry(string id = null)
        {
            var user = Context.Users.Find(id);

            var userModel = Kernel.Get<UserFormModel>();
            userModel.RolesList = Context.Roles.Select(p => new RoleBindingModel()
            {
                Id = p.Id,
                Title = p.Name
            }).ToList();
            // If we aren't an admin we shouldn't be able to create admin accounts
            if (!User.IsInRole("Admin"))
            {
                userModel.RolesList.RemoveAll(s => s.Title == "Admin");
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
                userModel.IsTenant = user.Roles.Any(p => p.RoleId == "Resident");
            }
            ViewBag.UnitId = new SelectList(Context.Units.OrderBy(p => p.Name), "Id", "Name", user?.UnitId);

            return AutoForm(userModel, nameof(SaveUser), user == null ? "Create User" : "Edit User Information");

            //return View("EditUser", userModel);
            //return base.Entry(id);
        }

    }

    public class RoleBindingModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}

//[Authorize(Roles = "PropertyAdmin,Admin")]
//public class UserManagementController2 : CrudController<UserBindingModel,ApplicationUser>
//{
//    private ApplicationSignInManager _signInManager;
//    private ApplicationUserManager _userManager;
//    private readonly IMapper<Unit, UnitViewModel> _mapper;

//    //public UserManagementController(PropertyContext context, IUserContext userContext, ApplicationSignInManager signInManager, ApplicationUserManager userManager) : base(context, userContext)
//    //{
//    //    _signInManager = signInManager;
//    //    _userManager = userManager;
//    //}

//    public UserManagementController(IKernel kernel, IRepository<ApplicationUser> repository, StandardCrudService<ApplicationUser, UserBindingModel> service, PropertyContext context, IUserContext userContext, ApplicationSignInManager signInManager, ApplicationUserManager userManager, IMapper<Unit,UnitViewModel> mapper ) : base(kernel, repository, service, context, userContext)
//    {
//        _signInManager = signInManager;
//        _userManager = userManager;
//        _mapper = mapper;
//    }

//    public ApplicationSignInManager SignInManager
//    {
//        get
//        {
//            return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
//        }
//        private set
//        {
//            _signInManager = value;
//        }
//    }

//    public ApplicationUserManager UserManager
//    {
//        get
//        {
//            return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//        }
//        private set
//        {
//            _userManager = value;
//        }
//    }

//    // GET: UserManagement
//    public override ActionResult Index()
//    {
//        return View(Service.GetAll<UserBindingModel>().Where(u=>!u.Archived));
//    }
//    public ActionResult DeleteUser(string id)
//    {
//        var user = Context.Users.Find(id);

//        return View("Delete", user);

//    }
//    // POST: /Units/Delete/5
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public ActionResult DeleteUserConfirmed(string id)
//    {
//        //var unit = Service.Find(id);
//        var user = Context.Users.Find(id);
//        user.Archived = true;
//        Context.SaveChanges();
//        return RedirectToAction("Index");
//    }
//    public ActionResult EditUser(string id = null)
//    {
//        var user = Context.Users.Find(id);

//        var userModel = new UserFormModel()
//        {
//            RolesList = Context.Roles.Select(p=>p.Id).ToList(),

//        };
//        // If we aren't an admin we shouldn't be able to create admin accounts
//        if (!User.IsInRole("Admin"))
//        {
//            userModel.RolesList.Remove("Admin");
//        }
//        if (user != null)
//        {
//            userModel.FirstName = user.FirstName;
//            userModel.LastName = user.LastName;
//            userModel.Email = user.Email;
//            userModel.Id = user.Id;
//            userModel.PhoneNumber = user.PhoneNumber;
//            userModel.UnitId = user.UnitId;
//            userModel.SelectedRoles = user.Roles.Select(p => p.RoleId).ToList();

//        }
//        userModel.UnitItems = Context.Units.OrderBy(p => p.Name).Select(u => _mapper.ToViewModel(u)).ToList();
//        ViewBag.UnitId = new SelectList(Context.Units.OrderBy(p=>p.Name), "Id", "Name", user?.UnitId);

//        return View(userModel);
//    }


//    [HttpPost]
//    public async Task<ActionResult> SaveUser(UserFormModel model)
//    {
//        if (ModelState.IsValid)
//        {
//            var user = Context.Users.Find(model.Id);
//            var newUser = false;
//            if (user == null)
//            {

//                user = new ApplicationUser
//                {

//                };

//                newUser = true;
//            }
//            else
//            {

//            }
//            if (!User.IsInRole("Admin"))
//            {
//                model.SelectedRoles.Remove("Admin"); // Just to make sure
//            }
//            user.Email = model.Email;
//            user.PropertyId = PropertyId;
//            user.UserName = model.Email;
//            user.UnitId = model.UnitId;
//            user.FirstName = model.FirstName;
//            user.LastName = model.LastName;
//            user.PhoneNumber = model.PhoneNumber;
//            user.Roles.Clear();
//            foreach (var item in model.SelectedRoles)
//            {
//                user.Roles.Add(new IdentityUserRole() { RoleId = item, UserId = user.Id});
//            }
//            if (newUser)
//            {

//                var result = await UserManager.CreateAsync(user, "Temp1234!");
//                if (result.Succeeded)
//                {


//                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
//                    // Send an email with this link
//                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
//                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
//                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

//                }
//            }
//            else
//            {
//                Context.SaveChanges();
//            }


//            //AddErrors(result);
//        }


//        return RedirectToAction("Index");
//    }
//}
