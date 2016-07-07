using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Payments.Forte;
using ApartmentApps.Payments.Forte.Forte.Client;

namespace ApartmentApps.Api.Modules
{
    public interface IPaymentsService
    {
        Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel);
        Task<AddCreditCardResult> AddCreditCard(AddCreditCardBindingModel addCreditCard);
        Task<AddBankAccountResult> AddBankAccount(AddBankAccountBindingModel addCreditCard);
        IEnumerable<PaymentOptionBindingModel> GetPaymentOptions();
        IEnumerable<PaymentHistoryBindingModel> GetPaymentHistory();
        Task<PaymentSummaryBindingModel> GetPaymentSummary(int userId);
        Task<PaymentSummaryBindingModel> GetRentSummary(int userId);
    }
    public class MakePaymentResult
    {
        public string ErrorMessage { get; set; }
    }

    public class PaymentBindingModel
    {

    }
    public enum CardType : int
    {
        VISA = 0,
        MAST = 1,
        DISC = 2,
        AMER = 3,
        DINE = 4,
        JCB = 5,
    }


    public class PaymentSummaryBindingModel
    {
        public int BaseRent { get; set; }
        public List<PaymentSummaryBindingModel> SummaryOptions { get; set; }
    }

    public class PaymentSummaryItemBindingModel
    {
        public string Description { get; set; }

        public decimal Amount { get; set; }
    }
    public class PaymentOptionBindingModel
    {
        public string FriendlyName { get; set; }
        public PaymentOptionType Type { get; set; }
        public int Id { get; set; }
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
        public string AccountHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public CardType CardType { get; set; }
        public string FriendlyName { get; set; }
    }

    public class AddCreditCardResult
    {
        public string ErrorMessage { get; set; }
    }

    public class AddBankAccountBindingModel
    {
        [DisplayName("Is Savings?")]
        [Description("If unchecked a checking account is used.")]
        public bool IsSavings { get; set; }

        [DisplayName("Account Holder Name")]
        public string AccountHolderName { get; set; }

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        [DisplayName("Routing Number")]
        public string RoutingNumber { get; set; }

        [DisplayName("Friendly Name")]
        [Description("A friendly name that you can use for this account.")]
        public string FriendlyName { get; set; }
    }
    public class AddBankAccountResult
    {
        public string ErrorMessage { get; set; }
    }
    public class PaymentsModule : Module<PaymentsConfig>, IMenuItemProvider, IAdminConfigurable, IPaymentsService
    {
        public PropertyContext Context { get; set; }

        public PaymentsModule(PropertyContext context, IRepository<PaymentsConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
            Context = context;
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
           // menuItems.Add(new MenuItemViewModel("Payments", "payments","Index", "Payments"));
        }

        public string SettingsController => "PaymentsConfig";

        public string MerchantPassword => Config.MerchantPassword;

        //IRepository<Property> propertyRepo,

        public int MerchantId => string.IsNullOrEmpty(Config.MerchantId) ? 0 : Convert.ToInt32(Config.MerchantId);

        public string ApiLoginId { get; set; } = "5KwrM3b7T7";

        public string Key { get; set; } = "18RcFs5F";

        public async Task<PaymentSummaryBindingModel> GetPaymentSummary(int userId)
        {
            var user = Context.Users.Find(userId);

            return new PaymentSummaryBindingModel()
            {
                BaseRent = user.Unit.Building.RentAmount,

            };
        }

        public async Task<PaymentSummaryBindingModel> GetRentSummary(int userId)
        {
            var user = Context.Users.Find(userId);

            return new PaymentSummaryBindingModel()
            {
                BaseRent = user.Unit.Building.RentAmount,

            };
        }
        public async Task<AddCreditCardResult> AddCreditCard(AddCreditCardBindingModel addCreditCard)
        {
            var auth = Authenticate.GetClientAuthTicket(ApiLoginId, Key);
            int clientId = await EnsureClientId(auth);
            PaymentMethod payment = new PaymentMethod();
            payment.AcctHolderName = addCreditCard.AccountHolderName;
            payment.CcCardNumber = addCreditCard.CardNumber;
            payment.CcExpirationDate = addCreditCard.ExpirationDate;
            payment.CcCardType = (CcCardType)Enum.Parse(typeof(CcCardType), addCreditCard.CardType.ToString());
            payment.Note = addCreditCard.FriendlyName;
            payment.ClientID = clientId;
            payment.MerchantID = MerchantId;

            using (var client = new ClientServiceClient("WSHttpBinding_IClientService"))
            {
                try
                {
                    var result = await client.createPaymentMethodAsync(auth, payment);
                    var paymentMethodId = result.Body.createPaymentMethodResult;
                    Context.PaymentOptions.Add(new UserPaymentOption()
                    {
                        UserId = UserContext.UserId,
                        Type = PaymentOptionType.CreditCard,
                        FriendlyName = addCreditCard.FriendlyName,
                        TokenId = paymentMethodId.ToString()
                    });
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return new AddCreditCardResult() { ErrorMessage = ex.Message };
                }

            }
            return new AddCreditCardResult();
        }
        public async Task<AddBankAccountResult> AddBankAccount(AddBankAccountBindingModel addCreditCard)
        {
            var auth = Authenticate.GetClientAuthTicket(ApiLoginId, Key);
            int clientId = await EnsureClientId(auth);
            PaymentMethod payment = new PaymentMethod();
            payment.AcctHolderName = addCreditCard.AccountHolderName;
            payment.EcAccountNumber = addCreditCard.AccountNumber;
            payment.EcAccountTRN = addCreditCard.RoutingNumber;
            payment.EcAccountType = addCreditCard.IsSavings ? EcAccountType.SAVINGS : EcAccountType.CHECKING;
            payment.Note = addCreditCard.FriendlyName;
            payment.ClientID = clientId;
            payment.MerchantID = MerchantId;

            using (var client = new ClientServiceClient("WSHttpBinding_IClientService"))
            {
                try
                {
                    var result = await client.createPaymentMethodAsync(auth, payment);

                    var paymentMethodId = result.Body.createPaymentMethodResult;
                    Context.PaymentOptions.Add(new UserPaymentOption()
                    {
                        UserId = UserContext.UserId,
                        Type = addCreditCard.IsSavings ? PaymentOptionType.Savings : PaymentOptionType.Checking,
                        FriendlyName = addCreditCard.FriendlyName,
                        TokenId = paymentMethodId.ToString()
                    });
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return new AddBankAccountResult() { ErrorMessage = ex.Message };
                }

            }
            return new AddBankAccountResult();
        }

        public IEnumerable<PaymentOptionBindingModel> GetPaymentOptions()
        {
            return Context.PaymentOptions.Where(p => p.UserId == UserContext.UserId).Select(x =>
                new PaymentOptionBindingModel()
                {
                    FriendlyName = x.FriendlyName,
                    Type = x.Type,
                    Id = x.Id,
                });
        }

        public IEnumerable<PaymentHistoryBindingModel> GetPaymentHistory()
        {
            //return Context.UserTransactions.
            yield break;
        }
        public async Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel)
        {
            var auth = Authenticate.GetClientAuthTicket(ApiLoginId, Key);
            int clientId = await EnsureClientId(auth);

            var paymentOptionId = Convert.ToInt32(makePaymentBindingModel.PaymentOptionId);

            var paymentOption = Context.PaymentOptions.FirstOrDefault(p => p.UserId == UserContext.UserId && p.Id == paymentOptionId);
            if (paymentOption == null)
            {
                return new MakePaymentResult() { ErrorMessage = "Payment Option Not Found." };
            }
            var transactionClient = new Payments.Forte.PaymentGateway.PaymentGatewaySoapClient();
            transactionClient.ExecuteSocketQuery(new ExecuteSocketQueryParams()
            {
                PgMerchantId = MerchantId.ToString(),
                PgClientId = clientId.ToString(),
                PgPaymentMethodId = paymentOption.TokenId,
                PgPassword = MerchantPassword//"LEpLqvx7Y5L200"
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