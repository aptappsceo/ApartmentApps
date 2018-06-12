using System;
using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{

    public class AutoFormController<TService, TFormService, TIndexViewModel, TFormViewModel> : AAController
        where TIndexViewModel : new()
        where TFormViewModel : BaseViewModel, new()
        where TService : IService
        where TFormService : IService
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
            var array = _indexService.GetAll<TIndexViewModel>().ToArray();
            return AutoIndex<TIndexViewModel>(this.GetType().Name.Replace("Controller", ""));
        }
        public virtual ActionResult Entry(string id = null)
        {
            if (id != null && id != "0")
            {
                var entry = _formService.Find<TFormViewModel>(id);
                return AutoForm(InitFormModel(entry), "SaveEntry", "Change");
            }
            return AutoForm(InitFormModel(CreateFormModel()), "SaveEntry", "Create New");
        }

        protected virtual TFormViewModel InitFormModel(TFormViewModel createFormModel)
        {
            return createFormModel;
        }

        protected virtual TFormViewModel CreateFormModel()
        {
            return _formService.CreateNew<TFormViewModel>();
        }
        [HttpPost]
        public virtual ActionResult SaveEntry(TFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id is string[])
                {
                    model.Id = null;
                }
                _formService.Save(model);
                Success("Success!");
                //ViewBag.SuccessMessage = "Success!";


                if (Request != null && Request.IsAjaxRequest())
                {
                    return JsonUpdate();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Success("Whoopsie! Fix the errors and try again.");
            }
            return AutoForm(model, "SaveEntry");
        }




        public virtual ActionResult Delete(string id)
        {
            try
            {
                _formService.Remove(id);
                Success("Item Deleted!");

            }
            catch (Exception ex)
            {
                Error("Couldn't delete item. There is most likely other things that are dependent on this item.");
            }
            return RedirectToAction("Index");
        }
    }

    public class AutoFormController<TService, TViewModel> :
        AutoFormController<TService, TService, TViewModel, TViewModel> where TViewModel : BaseViewModel, new() where TService : IService
    {
        public AutoFormController(IKernel kernel, TService service, PropertyContext context, IUserContext userContext) : base(kernel, service, service, context, userContext)
        {
        }
    }
}