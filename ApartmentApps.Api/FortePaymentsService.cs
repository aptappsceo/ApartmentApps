using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Payments.Forte;
using ApartmentApps.Payments.Forte.Forte.Client;
using ApartmentApps.Payments.Forte.PaymentGateway;

namespace ApartmentApps.API.Service.Controllers
{
    public interface IPaymentsService
    {
        Task<MakePaymentResult> MakePayment( MakePaymentBindingModel makePaymentBindingModel);
    }
    public class MakePaymentResult
    {
        public string ErrorMessage { get; set; }
    }

    public class PaymentBindingModel
    {
       
    }

    public class PaymentSummaryBindingModel
    {
        
    }
    public class PaymentOptionBindingModel
    {
        
    }
    public class PaymentHistoryBindingModel
    {
        
    }
    public class MakePaymentBindingModel
    {
        public string PaymentOptionId { get; set; }
    }

    public class AddCreditCardBindingModel
    {
        
    }

    public class AddCreditCardResult
    {
        
    }

    public class AddBankAccountBindingModel
    {
        
    }
    public class AddBankAccountResult
    {
        
    }
    public class FortePaymentsService : IPaymentsService
    {
        public PropertyContext Context { get; set; }
        public IUserContext UserContext{ get; set; }

        public FortePaymentsService(PropertyContext context,IUserContext userContext)
        {
            Context = context;
            UserContext = userContext;
            MerchantId = userContext.CurrentUser.Property.MerchantId ?? 0;
            MerchantPassword= userContext
        } //IRepository<Property> propertyRepo,

        public int MerchantId { get; set; }
        
        public string ApiLoginId { get; set; } = "5KwrM3b7T7";

        public string Key { get; set; } = "18RcFs5F";


        public async Task<AddCreditCardResult> AddCreditCard(AddCreditCardBindingModel addCreditCard)
        {
            var auth = Authenticate.GetClientAuthTicket(ApiLoginId, Key);
            int clientId = await EnsureClientId(auth);



            return new AddCreditCardResult();
        }
        public async Task<AddBankAccountResult> AddBankAccount(AddBankAccountBindingModel addCreditCard)
        {
            var auth = Authenticate.GetClientAuthTicket(ApiLoginId, Key);
            int clientId = await EnsureClientId(auth);


            return new AddBankAccountResult();
        }

        public IEnumerable<PaymentOptionBindingModel> GetPaymentOptions()
        {
            yield break;
        } 

        public IEnumerable<PaymentHistoryBindingModel> GetPaymentHistory()
        {
            yield break;
        }
        public async Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel)
        {
            var auth = Authenticate.GetClientAuthTicket(ApiLoginId, Key);
            int clientId = await EnsureClientId(auth);

            var paymentOptionId = Convert.ToInt32(makePaymentBindingModel.PaymentOptionId);

            var paymentOption = Context.PaymentOptions.FirstOrDefault(p=>p.UserId == UserContext.UserId && p.Id == paymentOptionId);
            if (paymentOption == null)
            {
                return new MakePaymentResult() {ErrorMessage = "Payment Option Not Found."};
            }
            var transactionClient = new Payments.Forte.PaymentGateway.PaymentGatewaySoapClient();
            transactionClient.ExecuteSocketQuery(new ExecuteSocketQueryParams()
            {
                PgMerchantId = MerchantId.ToString(),
                PgClientId = clientId.ToString(),
                PgPaymentMethodId =  paymentOption.TokenId,
                PgPassword = "LEpLqvx7Y5L200"
            });

            return new MakePaymentResult()
            {
                
            };
        }

        private async Task<int> EnsureClientId(Authentication auth)
        {
            var user = UserContext.CurrentUser;
            var clientId = user.ForteClientId ?? 0;
         
            var client = new ClientServiceClient();
            // If the user doesnt have a client account with forte
            if (clientId == 0)
            {
                var result = await client.createClientAsync(auth, new ClientRecord()
                {
                    MerchantID = MerchantId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Status = ClientStatus.Active
                });
                UserContext.CurrentUser.ForteClientId = clientId = result.Body.createClientResult;
                Context.SaveChanges();
            }
            return clientId;
        }
    }
}