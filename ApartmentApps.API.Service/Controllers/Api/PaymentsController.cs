using System.Threading.Tasks;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.API.Service.Controllers
{
    public interface IPaymentsService
    {
        Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel);
    }

    public class FortePaymentsService : IPaymentsService
    {
        public FortePaymentsService(IUserContext context)
        {
            MerchantId = context.CurrentUser.Property.Name;
        }

        public string MerchantId { get; set; }

        public async Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel)
        {
            //var merchantId = "1234";
            //var apiClientId = "2000";
            //var key = "";
            //var client = new ApartmentApps.Payments.Forte.Forte.Client.ClientServiceClient();
            //var auth = Authenticate.GetClientAuthTicket(apiClientId, key);
            //var result = await client.createClientAsync(auth, new ClientRecord()
            //{
            //     FirstName = "",
            //     LastName = "",
            //});
            return new MakePaymentResult();
        }
    }


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

    public class MakePaymentResult
    {
        
    }
    public class MakePaymentBindingModel
    {
        
    }
}