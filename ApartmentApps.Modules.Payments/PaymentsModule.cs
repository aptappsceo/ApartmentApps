using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Data.Utils;
using ApartmentApps.Modules.Payments.Services;
using ApartmentApps.Payments.Forte;
using ApartmentApps.Payments.Forte.Forte.Client;
using ApartmentApps.Payments.Forte.Forte.Merchant;
using ApartmentApps.Payments.Forte.Forte.Transaction;
using ApartmentApps.Payments.Forte.PaymentGateway;
using Ninject;
using Ninject.Planning.Bindings;
using Authentication = ApartmentApps.Payments.Forte.Forte.Client.Authentication;

namespace ApartmentApps.Api.Modules
{
    public class PaymentsModule : Module<PaymentsConfig>, IMenuItemProvider, IAdminConfigurable, IPaymentsService
    {
        private readonly IRepository<UserLeaseInfo> _leaseRepository;
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IRepository<InvoiceTransaction> _transactionRepository;
        private LeaseInfoManagementService _leaseService;
        public PropertyContext Context { get; set; }

        public PaymentsModule(IRepository<UserLeaseInfo> leaseRepository, IRepository<Invoice> invoiceRepository,
            IRepository<InvoiceTransaction> transactionRepository, PropertyContext context,
            IRepository<PaymentsConfig> configRepo, IUserContext userContext, IKernel kernel,
            LeaseInfoManagementService leaseService) : base(kernel, configRepo, userContext)
        {
            _leaseRepository = leaseRepository;
            _invoiceRepository = invoiceRepository;
            _transactionRepository = transactionRepository;
            Context = context;
            _leaseService = leaseService;
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            menuItems.Add(new MenuItemViewModel("Payments", "payments", "Index", "Payments"));
        }

        public string SettingsController => "PaymentsConfig";

        public string MerchantPassword => Config.MerchantPassword;

        //IRepository<Property> propertyRepo,

        public int MerchantId => string.IsNullOrEmpty(Config.MerchantId) ? 0 : Convert.ToInt32(Config.MerchantId);

        public string ApiLoginId { get; set; } = "5KwrM3b7T7";

        public string Key { get; set; } = "18RcFs5F";

        //Includes fee
        public async Task<PaymentSummaryBindingModel> GetPaymentSummary(string userId)
        {
            var user = Context.Users.Find(userId);



            return new PaymentSummaryBindingModel()
            {
                Amount = user.Unit.Building.RentAmount,

            };
        }

        public async Task<PaymentSummaryBindingModel> GetRentSummary(string userId)
        {
            var user = Context.Users.Find(userId);
            var dateTime = user.Property.TimeZone.Now();

            var invoices = _invoiceRepository.Where(
                s => !s.IsArchived && s.UserLeaseInfo.UserId == userId && s.AvailableDate < dateTime).ToArray();

            return new PaymentSummaryBindingModel()
            {
                Amount = user.Unit.Building.RentAmount,
                SummaryOptions = invoices.Select(s => new PaymentSummaryBindingModel()
                {
                    Title = s.Title,
                    Amount = s.Amount,
                }).ToList()
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
            payment.CcCardType = (CcCardType) Enum.Parse(typeof(CcCardType), addCreditCard.CardType.ToString());
            payment.Note = addCreditCard.FriendlyName;
            payment.ClientID = clientId;
            payment.MerchantID = MerchantId;

            using (var client = new ClientServiceClient("WSHttpBinding_IClientService"))
            {
                try
                {
                    var result = await client.createPaymentMethodAsync(auth, payment);
                    var paymentMethodId = result.Body.createPaymentMethodResult;
                    var userPaymentOption = new UserPaymentOption()
                    {
                        UserId = UserContext.UserId,
                        Type = PaymentOptionType.CreditCard,
                        FriendlyName = addCreditCard.FriendlyName,
                        TokenId = paymentMethodId.ToString()
                    };
                    Context.PaymentOptions.Add(userPaymentOption);
                    Context.SaveChanges();
                    return new AddCreditCardResult() {PaymentOptionId = userPaymentOption.Id};
                }
                catch (Exception ex)
                {
                    return new AddCreditCardResult() {ErrorMessage = ex.Message};
                }

            }

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
                    var userPaymentOption = new UserPaymentOption()
                    {
                        UserId = UserContext.UserId,
                        Type = addCreditCard.IsSavings ? PaymentOptionType.Savings : PaymentOptionType.Checking,
                        FriendlyName = addCreditCard.FriendlyName,
                        TokenId = paymentMethodId.ToString()
                    };
                    Context.PaymentOptions.Add(userPaymentOption);
                    Context.SaveChanges();
                    return new AddBankAccountResult() {PaymentOptionId = userPaymentOption.Id};
                }
                catch (Exception ex)
                {
                    return new AddBankAccountResult() {ErrorMessage = ex.Message};
                }

            }

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

        public IEnumerable<PaymentOptionBindingModel> GetPaymentOptionsFor(string userId)
        {
            return Context.PaymentOptions.Where(p => p.UserId == userId).Select(x =>
                new PaymentOptionBindingModel()
                {
                    FriendlyName = x.FriendlyName,
                    Type = x.Type,
                    Id = x.Id,
                });
        }

        public IEnumerable<UserInvoiceHistoryBindingModel> GetPaymentHistory()
        {
            //return Context.UserTransactions.
            yield break;
        }


        public async Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel)
        {
            var auth = Authenticate.GetClientAuthTicket(ApiLoginId, Key);
            int clientId = await EnsureClientId(auth);

            var paymentOptionId = Convert.ToInt32(makePaymentBindingModel.PaymentOptionId);

            var paymentOption =
                Context.PaymentOptions.FirstOrDefault(p => p.UserId == UserContext.UserId && p.Id == paymentOptionId);
            if (paymentOption == null)
            {
                return new MakePaymentResult() {ErrorMessage = "Payment Option Not Found."};
            }

            var invoices = _invoiceRepository.GetAvailableBy(DateTime.Now).ToArray();

            var total = invoices.Sum(s => s.Amount);

            PaymentGatewaySoapClient transactionClient = null;

            try
            {
                transactionClient =
                    new Payments.Forte.PaymentGateway.PaymentGatewaySoapClient("PaymentGatewaySoap");
            }
            catch (Exception ex)
            {
                throw;
            }

            var pgTotalAmount = $"{total.ToString("0.00")}";

            var response = transactionClient.ExecuteSocketQuery(new ExecuteSocketQueryParams()
            {
                PgMerchantId = MerchantId.ToString(),
                PgClientId = clientId.ToString(),
                PgPaymentMethodId = paymentOption.TokenId,
                PgPassword = MerchantPassword, //"LEpLqvx7Y5L200"
                PgTotalAmount  = pgTotalAmount,
                PgTransactionType = "10",
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
            try
            {
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
            }
            catch (Exception ex)
            {
                throw;
            }
    
            return clientId;
        }

        public void MarkAsPaid(int id, string s)
        {
            var invoice = _invoiceRepository.Find(id);
            if (invoice == null) throw new KeyNotFoundException();
            var user = invoice.UserLeaseInfo.User;
            if (user == null) throw new KeyNotFoundException();

            var opId = Guid.NewGuid().ToString();
            _leaseService.CreateTransaction(opId, user.Id, new[] {invoice}, "", DateTime.Now);
            var transaction = _transactionRepository.Find(opId);
            _leaseService.OnTransactionComplete(transaction,s,user.Property.TimeZone.Now());
            _transactionRepository.Save();

        }
    }
}