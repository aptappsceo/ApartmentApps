using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Data.Utils;
using ApartmentApps.Payments.Forte;
using ApartmentApps.Payments.Forte.Forte.Client;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class PaymentsModule : Module<PaymentsConfig>, IMenuItemProvider, IAdminConfigurable, IPaymentsService
    {
        private readonly IRepository<UserLeaseInfo> _leaseRepository;
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IRepository<InvoiceTransaction> _transactionRepository;
        public PropertyContext Context { get; set; }

        public PaymentsModule(IRepository<UserLeaseInfo> leaseRepository, IRepository<Invoice> invoiceRepository, IRepository<InvoiceTransaction> transactionRepository, PropertyContext context, IRepository<PaymentsConfig> configRepo, IUserContext userContext, IKernel kernel) : base(kernel, configRepo, userContext)
        {
            _leaseRepository = leaseRepository;
            _invoiceRepository = invoiceRepository;
            _transactionRepository = transactionRepository;
            Context = context;
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
           menuItems.Add(new MenuItemViewModel("Payments", "payments","Index", "Payments"));
        }

        public string SettingsController => "PaymentsConfig";

        public string MerchantPassword => Config.MerchantPassword;

        //IRepository<Property> propertyRepo,

        public int MerchantId => string.IsNullOrEmpty(Config.MerchantId) ? 0 : Convert.ToInt32(Config.MerchantId);

        public string ApiLoginId { get; set; } = "5KwrM3b7T7";

        public string Key { get; set; } = "18RcFs5F";

        public async Task<PaymentSummaryBindingModel> GetPaymentSummary(string userId)
        {
            var user = Context.Users.Find(userId);

            return new PaymentSummaryBindingModel()
            {
                BaseRent = user.Unit.Building.RentAmount,

            };
        }

        public async Task<PaymentSummaryBindingModel> GetRentSummary(string userId)
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
                    var userPaymentOption = new UserPaymentOption()
                    {
                        UserId = UserContext.UserId,
                        Type = PaymentOptionType.CreditCard,
                        FriendlyName = addCreditCard.FriendlyName,
                        TokenId = paymentMethodId.ToString()
                    };
                    Context.PaymentOptions.Add(userPaymentOption);
                    Context.SaveChanges();
                    return new AddCreditCardResult() { PaymentOptionId = userPaymentOption.Id };
                }
                catch (Exception ex)
                {
                    return new AddCreditCardResult() { ErrorMessage = ex.Message };
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
                    return new AddBankAccountResult() { PaymentOptionId = userPaymentOption.Id };
                }
                catch (Exception ex)
                {
                    return new AddBankAccountResult() { ErrorMessage = ex.Message };
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

        public void OnTransactionSuccessful(InvoiceTransaction transaction)
        {

            transaction.State = TransactionState.Complete;

            foreach (var invoice in transaction.Invoices)
            {
                var leaseInfo = invoice.UserLeaseInfo;

                invoice.IsArchived = true;
                invoice.State = InvoiceState.Paid;

                if (leaseInfo.IsIntervalSet())
                {
                    var nextInvoiceDate = leaseInfo.InvoiceDate.Offset(
                        leaseInfo.IntervalDays ?? 0,
                        leaseInfo.IntervalMonths ?? 0,
                        leaseInfo.IntervalYears ?? 0);

                    if (leaseInfo.RepetitionCompleteDate.HasValue &&
                        nextInvoiceDate > leaseInfo.RepetitionCompleteDate.Value)
                    {
                        leaseInfo.State = LeaseState.Archived;
                    }
                    else
                    {
                        leaseInfo.InvoiceDate = nextInvoiceDate;
                        CreateNextInvoiceFor(leaseInfo);
                    }
                }
                else
                {
                    leaseInfo.State = LeaseState.Archived;
                }


            }

            _invoiceRepository.Save();
            _transactionRepository.Save();
            _leaseRepository.Save();


        }

        public void CreateUserLeaseInfo(CreateUserLeaseInfoBindingModel data)
        {
            var user = Context.Users.Find(data.UserId);
            if(user == null) throw new KeyNotFoundException();

            var leaseInfo = new UserLeaseInfo()
            {
                Title = data.Title,
                User = user,
                Amount = data.Amount,
                CreateDate = user.Property.TimeZone.Now(),
                InvoiceDate = data.InvoiceDate.ToCorrectedDateTime(),
                State = LeaseState.Active
            };

            if (data.IsIntervalSet())
            {

                leaseInfo.IntervalDays = data.IntervalDays;
                leaseInfo.IntervalMonths = data.IntervalMonths;
                leaseInfo.IntervalYears = data.IntervalYears;

                if (data.RepetitionCompleteDate.HasValue)
                {
                    leaseInfo.RepetitionCompleteDate = data.RepetitionCompleteDate.Value;
                }
            }

            _leaseRepository.Add(leaseInfo);
            _leaseRepository.Save();

            CreateNextInvoiceFor(leaseInfo);

        }

        public void MarkAsPaid(int id, string s)
        {
            var invoice = _invoiceRepository.Find(id);
            if (invoice == null) throw new KeyNotFoundException();
            var user = invoice.UserLeaseInfo.User;
            if (user == null) throw new KeyNotFoundException();
            var surrogateTransaction = new InvoiceTransaction()
            {
                Comments = "Marked as paid by moderator",
                Invoices = new List<Invoice>() { invoice },
            };

            _transactionRepository.Save();
            OnTransactionSuccessful(surrogateTransaction);

        }
    }
}