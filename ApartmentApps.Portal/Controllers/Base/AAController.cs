using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Entrata.Model.Requests;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Mvc;
using Korzh.EasyQuery.Services;
using Korzh.EasyQuery.Services.Db;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Provider;
using Ninject;
using Syncfusion.JavaScript.DataVisualization.Models;

namespace ApartmentApps.Portal.Controllers
{
    

    public class AAController : Controller
    {
        public void Success(string message)
        {
            ViewBag.SuccessMessage = message;
        }
        public void Error(string message)
        {
            ViewBag.ErrorMessage = message;
        }
        public void Info(string message)
        {
            ViewBag.InfoMessage = message;
        }
        protected ApplicationSignInManager _signInManager;
        private IModuleHelper _moduleHelper;

        public TConfig GetConfig<TConfig>() where TConfig : PropertyModuleConfig, new()
        {
            var config = Kernel.Get<Module<TConfig>>().Config;
            return config;
        }
        public IUserContext UserContext { get; }

        public IRepository<TModel> Repository<TModel>()
        {
            return Kernel.Get<IRepository<TModel>>();
        }
        public AAController(IKernel kernel, PropertyContext context, IUserContext userContext)
        {
            Kernel = kernel;
            Context = context;
            UserContext = userContext;
        }

        public IEnumerable<ActionLinkModel> Tabs
        {
            get
            {
                var list = new List<ActionLinkModel>();
                Kernel.Get<IModuleHelper>().SignalToEnabled<IPageTabsProvider>(_ => _.PopulateMenuItems(list));
                return list;
            }
        }

        public IModuleHelper ModuleHelper
        {
            get { return _moduleHelper ?? (_moduleHelper = Kernel.Get<IModuleHelper>()); }
        }
        public IEnumerable<IModule> Modules
        {
            get { return ModuleHelper.AllModules; }
        }

        public IEnumerable<IModule> EnabledModules
        {
            get { return Modules.Where(p => p.Enabled); }
        }

        public IKernel Kernel { get; set; }
        protected PropertyContext Context { get; }

        public ApplicationUser CurrentUser => UserContext.CurrentUser;
        public int PropertyId => UserContext.PropertyId;

        public Data.Property Property => CurrentUser?.Property;

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

        [NonAction]
        public ViewResult ViewByModel(BaseViewModel viewModel)
        {
            return View(viewModel.GetType().Name, viewModel);
        }

        public ViewResult Page<TViewModel>(string title, string description, TViewModel viewModel)
        {
            var pageVM = new PageViewModel() {};
            pageVM.Title = title;
            pageVM.Description = description;
            
            ModuleHelper.SignalToEnabled<IFillActions>(_=>_.FillActions(pageVM.ActionLinks,pageVM));

            return View(pageVM.View ?? "Page", pageVM);

        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewBag.Kernel = Kernel;
            ViewBag.ModuleHelper = ModuleHelper;
            if (Property != null)
            {

                ViewBag.Property = Property;
                if (User.IsInRole("Admin"))
                {
                    ViewBag.Properties = Context.Properties.GetAll().ToArray();

                }
                var menuItems = new List<MenuItemViewModel>();
                
                ModuleHelper.SignalToEnabled<IMenuItemProvider>(p => p.PopulateMenuItems(menuItems));
                ViewBag.MenuItems = menuItems;
                ViewBag.Tabs = Tabs;

                if (UserContext.CurrentUser.LastPortalLoginTime == null || UserContext.CurrentUser.LastPortalLoginTime.Value.Add(new TimeSpan(1,0,0)) < DateTime.UtcNow)
                {
                    UserContext.CurrentUser.LastPortalLoginTime = DateTime.UtcNow;
                    Kernel.Get<ApplicationDbContext>().SaveChanges();
                }
            }

        }

        public ActionResult AutoIndex<TViewModel>(string title)
        {
            return View("AutoIndex", new AutoGridModel<TViewModel>()
            {
                Title = title,
                
                //Count = count,
                //CurrentPage = currentPage,
                //RecordsPerPage = recordsPerPage,
                //OrderBy = orderBy,
                //Descending = descending,
                Type = typeof(TViewModel)
            });
        }

        public ActionResult AutoForm(object model, string postAction, string postController, string title = null)
        {
            return View("AutoForm", new AutoFormModel(model, postAction, postController)
            {
                Title = title
            });
        }

        public ActionResult AutoForm(object model, string postAction, string title = null)
        {
            return AutoForm(model, postAction, this.GetType().Name.Replace("Controller", ""), title);
        }

        public void AddErrorMessage(string message)
        {
            TempData["GlobalError"] = message;
        }
        public void AddSuccessMessage(string message)
        {
            TempData["GlobalSuccess"] = message;
        }

        
        protected ActionResult JsonUpdate()
        {
            return Json(new { update = true });
        }

        protected ActionResult JsonRedirect(string url)
        {
            return Json(new { redirect = url });
        }
    }
}