using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    //public class InspectionsController : AutoFormController<InspectionsService, InspectionViewModel>
    //{
    //    public InspectionsController(IKernel kernel, InspectionsService service, PropertyContext context, IUserContext userContext) : base(kernel, service, context, userContext)
    //    {

    //    }

    //    public ActionResult NewInspection()
    //    {
    //        return
    //            AutoForm(
    //                new CreateInspectionViewModel(Kernel.Get<IRepository<Unit>>(),
    //                    Kernel.Get<IRepository<ApplicationUser>>()), "NewInspectionSubmit", "New Inspection");
    //    }

    //    public ActionResult NewInspectionSubmit(CreateInspectionViewModel createInspection)
    //    {
    //        this._formService.CreateInspection(createInspection);
    //        return RedirectToAction("Index");
    //    }
    //}
}