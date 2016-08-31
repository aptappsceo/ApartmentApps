using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{


    public class NotificationsController : AutoFormController<NotificationService, NotificationViewModel>
    {
        public NotificationsController(IKernel kernel, NotificationService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, context, userContext)
        {
        }
    }

    public class AutoFormController<TService, TViewModel> :
        AutoFormController<TService, TService, TViewModel, TViewModel> where TViewModel : BaseViewModel, new() where TService : IServiceFor<TViewModel>
    {
        public AutoFormController(IKernel kernel, TService service, PropertyContext context, IUserContext userContext) : base(kernel, service, service, context, userContext)
        {
        }
    }
    
    public class AutoFormController<TService, TFormService, TIndexViewModel, TFormViewModel> : AAController
        where TIndexViewModel : new()
        where TFormViewModel : BaseViewModel, new()
        where TService : IServiceFor<TIndexViewModel>
        where TFormService : IServiceFor<TFormViewModel>
    {
        private readonly IKernel _kernel;
        protected readonly TFormService _formService;
        protected readonly TService _indexService;

        public AutoFormController(IKernel kernel, TFormService formService, TService indexService, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            _kernel = kernel;
            _formService = formService;
            _indexService = indexService;
        }

 
        
        public virtual ActionResult Index()
        {
            return AutoIndex(_indexService.GetAll().ToArray());
        }
        public virtual ActionResult Entry(int? id = null)
        {
            if (id != null && id != 0)
            {
                return AutoForm(_formService.Find(id.Value), "SaveEntry", "Change");
            }
            return AutoForm(_formService.CreateNew(), "SaveEntry", "Create New");
        }

        public virtual ActionResult SaveEntry(TFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id is string[])
                {
                    model.Id = null;
                }
                _formService.Save(model);
                ViewBag.SuccessMessage = "Success!";
                return RedirectToAction("Index");
            }
            return AutoForm(model, "SaveEntry");
        }

        public virtual ActionResult Delete(int id)
        {
            _formService.Remove(id);
            ViewBag.SuccessMessage = "Item Deleted!";
            return RedirectToAction("Index");
        }
    }

    public class AAController : Controller
    {
        public IUserContext UserContext { get; }

        public AAController(IKernel kernel,PropertyContext context, IUserContext userContext)
        {
            Kernel = kernel;
            Context = context;
            UserContext = userContext;
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
                EnabledModules.Signal<IMenuItemProvider>(p=>p.PopulateMenuItems(menuItems));
                ViewBag.MenuItems = menuItems;
            }

        }
        public ActionResult AutoIndex<TViewModel>(TViewModel[] model, string title = null)
        {
            return View("AutoIndex", new AutoGridModel(model.Cast<object>().ToArray())
            {
                Title = title,
                Type = typeof(TViewModel)
            });
        }
        public ActionResult AutoForm(object model, string postAction, string title = null)
        {
            return View("AutoForm", new AutoFormModel(model, postAction, this.GetType().Name.Replace("Controller", ""))
            {
                Title = title
            });
        }
    }
}