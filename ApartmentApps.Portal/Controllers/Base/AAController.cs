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
        public TConfig GetConfig<TConfig>() where TConfig : ModuleConfig, new()
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
                ModuleHelper.EnabledModules.Signal<IPageTabsProvider>(_ => _.PopulateMenuItems(list));
                return list;
            }
        }
        public IEnumerable<IModule> Modules
        {
            get { return Kernel.GetAll<IModule>(); }
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
            
            ModuleHelper.EnabledModules.Signal<IFillActions>(_=>_.FillActions(pageVM.ActionLinks,pageVM));

            return View(pageVM.View ?? "Page", pageVM);

        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Property != null)
            {
                ViewBag.Property = Property;
                if (User.IsInRole("Admin"))
                {
                    ViewBag.Properties = Context.Properties.GetAll().ToArray();

                }
                var menuItems = new List<MenuItemViewModel>();
                EnabledModules.Signal<IMenuItemProvider>(p => p.PopulateMenuItems(menuItems));
                ViewBag.MenuItems = menuItems;
                ViewBag.Tabs = Tabs;

                
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