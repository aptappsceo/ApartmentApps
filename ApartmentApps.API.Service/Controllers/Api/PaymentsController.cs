using System.Threading.Tasks;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.API.Service.Controllers
{
 

    [Authorize]
    [RoutePrefix("api/Payments")]
    public class PaymentsController : ApartmentAppsApiController

    {
        public IPaymentsService PaymentsService { get; set; }

        public PaymentsController(IPaymentsService paymentsService, PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
            PaymentsService = paymentsService;
        }

        [HttpPost]
        public async Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel)
        {
            return await PaymentsService.MakePayment(makePaymentBindingModel);
        }
    }

   
}