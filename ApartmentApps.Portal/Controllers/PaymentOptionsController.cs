using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Payments;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class PaymentOptionsController :  AutoGridController
        <PaymentOptionsService, PaymentOptionsService, PaymentOptionBindingModel, PaymentOptionBindingModel>
    {
        public ActionResult ShowOwnedByUser(string id)
        {
            this.CustomQuery = Service.OwnedByUser(id);
            this.CurrentQueryId = "CustomQuery";
            return Index();
        }

        public PaymentOptionsController(IKernel kernel, PaymentOptionsService formService, PaymentOptionsService indexService, PropertyContext context, IUserContext userContext, PaymentOptionsService service) : base(kernel, formService, indexService, context, userContext, service)
        {
        }
    }
}