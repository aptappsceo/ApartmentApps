using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.API.Service.Controllers
{
 

    [Authorize]
    [RoutePrefix("api/Payments")]
    public class PaymentsController : ApartmentAppsApiController
    {
        public PaymentsModule PaymentsService { get; set; }

        public PaymentsController(PaymentsModule paymentsService, PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
            PaymentsService = paymentsService;
        }

        [HttpPost, Route("AddCreditCard")]
        public async Task<AddCreditCardResult> AddCreditCard(AddCreditCardBindingModel addCreditCard)
        {
            return await PaymentsService.AddCreditCard(addCreditCard);
        }
        [HttpPost, Route("AddBankAccount")]
        public async Task<AddBankAccountResult> AddBankAccount(AddBankAccountBindingModel addBankAccount)
        {
            return await PaymentsService.AddBankAccount(addBankAccount);
        }
        [HttpPost, Route("GetPaymentOptions")]
        public IEnumerable<PaymentOptionBindingModel> GetPaymentOptions()
        {
            return  PaymentsService.GetPaymentOptions();
        }

        [HttpPost, Route("GetPaymentHistory")]
        public IEnumerable<PaymentHistoryBindingModel> GetPaymentHistory()
        {
            return PaymentsService.GetPaymentHistory();
        }

        [HttpPost, Route("MakePayment")]
        public async Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel)
        {
            return await PaymentsService.MakePayment(makePaymentBindingModel);
        }
    }

   
}