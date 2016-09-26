using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
using Microsoft.Rest;
using Microsoft.Rest.TransientFaultHandling;

namespace ApartmentApps.API.Service.Controllers
{
 

    [Authorize]
    [RoutePrefix("api/Payments")]
    public class PaymentsController : ApartmentAppsApiController
    {
        private readonly IRepository<Invoice> _invoices;
        public PaymentsModule PaymentsService { get; set; }

        public PaymentsController(IRepository<Invoice> invoices, PaymentsModule paymentsService, PropertyContext context, IUserContext userContext) : base(context, userContext)
        {
            _invoices = invoices;
            PaymentsService = paymentsService;
        }

        [HttpPost, Route("AddCreditCard"),ApiExceptionFilter]
        public async Task<AddCreditCardResult> AddCreditCard(AddCreditCardBindingModel addCreditCard)
        {
            var result = await PaymentsService.AddCreditCard(addCreditCard);
            if (result.ErrorMessage != null)
            {
                throw new ApiException(result.ErrorMessage,HttpStatusCode.BadRequest);
            }
            return result;
        }
        [HttpPost, Route("AddBankAccount"),ApiExceptionFilter]
        public async Task<AddBankAccountResult> AddBankAccount(AddBankAccountBindingModel addBankAccount)
        {
            var result =  await PaymentsService.AddBankAccount(addBankAccount);
            if (result.ErrorMessage != null)
            {
                throw new ApiException(result.ErrorMessage,HttpStatusCode.BadRequest);
            }
            return result;
        }
        [HttpPost, Route("GetPaymentOptions")]
        public IEnumerable<PaymentOptionBindingModel> GetPaymentOptions()
        {
            return  PaymentsService.GetPaymentOptions();
        }

        [HttpPost, Route("GetPaymentHistory")]
        public IEnumerable<UserInvoiceHistoryBindingModel> GetPaymentHistory()
        {
            return PaymentsService.GetPaymentHistory();
        }

        [Route("RentSummary")]
        public async Task<PaymentListBindingModel> GetRentSummary()
        {
            var now = this.CurrentUser.Property.TimeZone.Now();
            var items = _invoices.GetAvailableBy(now).ToList();
            return new PaymentListBindingModel()
            {
                Items = LinesFromInvoices(items)
            };
        }

        [Route("PaymentSummary")]
        public async Task<PaymentListBindingModel> GetPaymentSummary(int paymentOptionId)
        {
            var now = this.CurrentUser.Property.TimeZone.Now();
            var items = _invoices.GetAvailableBy(now).ToList();
            var lines = LinesFromInvoices(items);
            lines.Add(new PaymentLineBindingModel()
            {
                Title = "Payment Option Fee (MOCK)",
                Format = PaymentSummaryFormat.Default,
                Price = "$mock"
            });

            return new PaymentListBindingModel()
            {
                Items = lines
            };
        }

        [HttpPost, Route("MakePayment")]
        public async Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel)
        {
            return await PaymentsService.MakePayment(makePaymentBindingModel);
        }

        private List<PaymentLineBindingModel> LinesFromInvoices(IEnumerable<Invoice> invoices)
        {
            var list = new List<PaymentLineBindingModel>();
            decimal total = 0;

            foreach (var inv in invoices)
            {
                var line = new PaymentLineBindingModel()
                {
                    Format = PaymentSummaryFormat.Default,
                    Price = $"{inv.Amount:$#,##0.00;($#,##0.00);Zero}",
                    Title = inv.Title
                };
                total += inv.Amount;
                list.Add(line);
            }

            list.Add(new PaymentLineBindingModel()
            {
                Format = PaymentSummaryFormat.Total,
                Price = $"{total:$#,##0.00;($#,##0.00);Zero}",
                Title = "Total"
            });

            return list;
        }

    }

   
}