using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;
using Syncfusion.JavaScript.DataVisualization.Models;

namespace ApartmentApps.Portal.Controllers
{


    public class NotificationsController : AutoFormController<NotificationService, NotificationViewModel>
    {
        public NotificationsController(IKernel kernel, NotificationService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, context, userContext)
        {
        }
    }


    public class AutoUserController : AutoGridController<UserService,UserBindingModel, UserSearchViewModel>
    {
        public AutoUserController(IKernel kernel, UserService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, context, userContext)
        {
        }
        [HttpPost]
        public override ActionResult SearchFormSubmit(UserSearchViewModel vm)
        {
            return base.SearchFormSubmit(vm);
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

    public class AutoGridController<TService, TViewModel, TSearchViewModel> :
        AutoGridController<TService, TService, TViewModel, TViewModel, TSearchViewModel>
               where TService : class, ISearchable<TViewModel, TSearchViewModel>, IServiceFor<TViewModel> 
        where TSearchViewModel : class, new()
        
        
        where TViewModel : BaseViewModel, new()
    {
        public AutoGridController(IKernel kernel, TService formService,  PropertyContext context, IUserContext userContext) : base(kernel, formService, formService, context, userContext, formService)
        {
        }
    }

    public class GridState
    {
        public int Page { get; set; }
        public int RecordsPerPage { get; set; } = 10;

        public string OrderBy { get; set; }
        public bool Descending { get; set; }
    }
    public class AutoGridController<TService, TFormService, TViewModel, TFormViewModel,TSearchViewModel> : AutoFormController<TService,TFormService,TViewModel, TFormViewModel> 
        where TService : class,ISearchable<TViewModel, TSearchViewModel>, IServiceFor<TViewModel> where TSearchViewModel : class, new()
        where TFormViewModel : BaseViewModel, new()
        where TFormService : IServiceFor<TFormViewModel> 
        where TViewModel : new()
    {
        public TService Service { get; set; }
        public ISearchable<TViewModel, TSearchViewModel> Searchable => Service as ISearchable<TViewModel, TSearchViewModel>;

        public AutoGridController(IKernel kernel, TFormService formService, TService indexService, PropertyContext context, IUserContext userContext, TService service) : base(kernel, formService, indexService, context, userContext)
        {
            Service = service;
        }

        public virtual string IndexTitle => this.GetType().Name.Replace("Controller", "");
        public override ActionResult Index()
        {
            return Grid(0);
        }

        public ActionResult Grid(int page, string orderBy = null)
        {
            if (page > 0)
            {
                GridState.Page = page;
            }
           
            if (orderBy != null)
            {
                GridState.OrderBy = orderBy;
            }
            var count = 0;
            var results = Searchable.Search(FilterViewModel, out count, GridState.OrderBy, GridState.Descending,GridState.Page,GridState.RecordsPerPage);
            return AutoIndex(results.ToArray(), count, page, IndexTitle);
        }
        public GridState GridState
        {
            get { return Session["GridState"] as GridState ?? (GridState = new GridState()); }
            set { Session["GridState"] = value; }
        }
        public TSearchViewModel FilterViewModel
        {
            get { return  Session["FilterViewModel"] as TSearchViewModel ?? (FilterViewModel = new TSearchViewModel()); }
            set { Session["FilterViewModel"] = value; }
        }

        public ActionResult SearchForm()
        {
            ViewBag.Layout = null;
            return View("SearchForm",FilterViewModel);
        }
        [HttpPost]
        public virtual ActionResult SearchFormSubmit(TSearchViewModel vm)
        {
            FilterViewModel = vm;
            return Grid(0);
            //return AutoForm(new TSearchViewModel(), "SearchFormSubmit", "Search");
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
            
            var array = _indexService.GetAll().ToArray();
            return AutoIndex(array, array.Length,0);
        }
        public virtual ActionResult Entry(string id = null)
        {
            if (id != null && id != "0")
            {
                return AutoForm(_formService.Find(id), "SaveEntry", "Change");
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
        public ActionResult AutoIndex<TViewModel>(TViewModel[] model, int count,int currentPage, string title = null )
        {
            return View("AutoIndex", new AutoGridModel(model.Cast<object>().ToArray())
            {
                Title = title,
                Count = count,
                CurrentPage = currentPage,
                RecordsPerPage = 20,
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