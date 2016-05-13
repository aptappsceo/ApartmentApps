using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Payments.Forte;
using ApartmentApps.Payments.Forte.Forte.Client;

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
    public class MakePaymentBindingModel
    {

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
        public ApplicationDbContext Context { get; set; }
        public IUserContext UserContext{ get; set; }

        public FortePaymentsService(ApplicationDbContext context,IUserContext userContext)
        {
            Context = context;
            UserContext = userContext;
            MerchantId = userContext.CurrentUser.Property.MerchantId ?? 0;
        } //IRepository<Property> propertyRepo,

        public int MerchantId { get; set; }

        public string ApiClientId { get; set; }

        public string Key { get; set; }
        public async Task<AddCreditCardResult> AddCreditCard(AddCreditCardBindingModel addCreditCard)
        {

            return new AddCreditCardResult();
        }
        public async Task<AddBankAccountResult> AddBankAccount(AddBankAccountBindingModel addCreditCard)
        {
            return new AddBankAccountResult();
        }
        public async Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel)
        {
            var auth = Authenticate.GetClientAuthTicket(ApiClientId, Key);
            int clientId = await EnsureClientId(auth);

            //var transactionClient = new Payments.Forte.PaymentGateway.PaymentGatewaySoapClient();
            //transactionClient.ExecuteSocketQuery(Mer)

            return new MakePaymentResult();
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
                await Context.SaveChangesAsync();
            }
            return clientId;
        }
    }
}