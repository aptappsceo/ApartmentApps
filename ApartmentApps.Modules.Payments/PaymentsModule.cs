using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Data.Utils;
using ApartmentApps.Modules.Payments.Data;
using ApartmentApps.Modules.Payments.Services;
using ApartmentApps.Payments.Forte;
using ApartmentApps.Payments.Forte.Forte.Client;
using ApartmentApps.Payments.Forte.Forte.Merchant;
using ApartmentApps.Payments.Forte.Forte.Transaction;
using ApartmentApps.Payments.Forte.PaymentGateway;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
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
        private IRepository<TransactionHistoryItem> _transactionHistory;
        public PropertyContext Context { get; set; }

        public PaymentsModule(IRepository<UserLeaseInfo> leaseRepository, IRepository<Invoice> invoiceRepository,
            IRepository<InvoiceTransaction> transactionRepository, PropertyContext context,
            IRepository<PaymentsConfig> configRepo, IUserContext userContext, IKernel kernel,
            LeaseInfoManagementService leaseService, IRepository<TransactionHistoryItem> transactionHistory)
            : base(kernel, configRepo, userContext)
        {
            _leaseRepository = leaseRepository;
            _invoiceRepository = invoiceRepository;
            _transactionRepository = transactionRepository;
            Context = context;
            _leaseService = leaseService;
            _transactionHistory = transactionHistory;
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            if (!UserContext.IsInRole("Admin") && !UserContext.IsInRole("PropertyAdmin") &&
                !UserContext.IsInRole("Resident")) return;


            var paymentsHome = new MenuItemViewModel("Payments", "fa-money", "Index", "Payments");

            if (UserContext.IsInRole("Admin") || UserContext.IsInRole("PropertyAdmin"))
            {
                paymentsHome.Children.Add(new MenuItemViewModel("Create Payment Request", "fa-plus", "CreateUserLeaseInfoFor", "Payments"));
                paymentsHome.Children.Add(new MenuItemViewModel("Users", "fa-shopping-cart", "PaymentsUsers", "Payments"));
            }

            if (UserContext.IsInRole("Resident"))
            {
                paymentsHome.Children.Add(new MenuItemViewModel("Overview", "fa-shopping-cart", "UserPaymentsOverview", "Payments",new {id = UserContext.CurrentUser.Id}));
            }

            menuItems.Add(paymentsHome);

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

        public IEnumerable<TransactionHistoryItemBindingModel> GetOpenTransactions()
        {
            var openedTransactions = _transactionHistory.Where(s => s.State == TransactionState.Open).ToArray();
            //var cl = new TransactionServiceClient("BasicHttpBinding_ITransactionService");
            //var auth = Authenticate.GetTransactionAuthTicket(ApiLoginId, Key);
            foreach (var tr in openedTransactions)
            {
                //  var state = cl.getTransaction(auth, MerchantId, tr.Trace);
                //ForteTransactionStateCode fState;
                //Enum.TryParse(state.Response.Status,out fState);
                yield return tr.ToBindingModel();
            }
        }


        public async Task<AddCreditCardResult> AddCreditCard(AddCreditCardBindingModel addCreditCard)
        {
            var auth = Authenticate.GetClientAuthTicket(ApiLoginId, Key);
            int clientId = await EnsureClientId(auth);
            PaymentMethod payment = new PaymentMethod();
            payment.AcctHolderName = addCreditCard.AccountHolderName;
            payment.CcCardNumber = addCreditCard.CardNumber;
            payment.CcExpirationDate = addCreditCard.ExpirationDate;
            payment.CcCardType = (CcCardType) Enum.Parse(typeof (CcCardType), addCreditCard.CardType.ToString());
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


        public decimal GetConvenienceFeeForPaymentOption(int paymentOptionId)
        {
            var paymentOption =
                Context.PaymentOptions.FirstOrDefault(p => p.UserId == UserContext.UserId && p.Id == paymentOptionId);

            if (paymentOption == null)
            {
                throw new KeyNotFoundException("Payment Option Not Found");
            }

            switch (paymentOption.Type)
            {
                case PaymentOptionType.CreditCard:
                    return Config.CreditCardConvenienceFee;
                case PaymentOptionType.Checking:
                    return Config.BankAccountCheckingConvenienceFee;
                case PaymentOptionType.Savings:
                    return Config.BankAccountSavingsConvenienceFee;
                default:
                    return 0;
            }
        }

        public async Task<bool> ForceRejectTransaction(string transactionId)
        {
            var transaction = _transactionHistory.Find(transactionId);
            return await ForceRejectTransaction(transaction);
        }

        public async Task<bool> ForceCompleteTransaction(string transactionId)
        {
            var transaction = _transactionHistory.Find(transactionId);
            return await ForceCompleteTransaction(transaction);
        }

        public async Task<bool> ForceRejectTransaction(TransactionHistoryItem transaction)
        {
            RejectForteTransaction(transaction, "Force Reject by " + UserContext.Email,
                ForteTransactionStateCode.SystemForceRejected);
            return false;
        }

        public async Task<bool> ForceCompleteTransaction(TransactionHistoryItem transaction)
        {
            CompleteForteTransaction(transaction, "Force Complete by " + UserContext.Email,
                ForteTransactionStateCode.SystemForceComplete);
            return false;
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

            decimal convFee = GetConvenienceFeeForPaymentOption(paymentOptionId);

            //TODO: change later to get UserId from parameter
            var invoices =
                _invoiceRepository.Where(
                    i =>
                        !i.IsArchived && i.AvailableDate < DateTime.Now && i.State == InvoiceState.NotPaid &&
                        i.UserLeaseInfo.UserId == UserContext.UserId).ToArray();
            var total = invoices.Sum(s => s.Amount) + convFee;

            PaymentGatewaySoapClient transactionClient = null;

            try
            {
                transactionClient = new Payments.Forte.PaymentGateway.PaymentGatewaySoapClient("PaymentGatewaySoap");
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
                PgTotalAmount = pgTotalAmount,
                PgTransactionType = "10", //sale
            });


            ForteMakePaymentResponse typedResponse = null;

            try
            {
                typedResponse = ForteMakePaymentResponse.FromIniString(response);
            }
            catch (Exception ex)
            {
                return new MakePaymentResult()
                {
                    ErrorMessage = "Please, contact our support."
                };
            }

            _leaseService.CreateTransaction(typedResponse.TraceNumber, UserContext.UserId, UserContext.UserId, total,
                convFee, invoices, "Transaction Opened.", DateTime.Now);

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

        public void UpdateOpenForteTransactions()
        {
            // get payments module
            var openedTransactions =
                _transactionHistory.Where(s => s.State == TransactionState.Open).Include(s => s.Invoices).ToArray();
            var cl = new TransactionServiceClient("BasicHttpBinding_ITransactionService");
            var auth = Authenticate.GetTransactionAuthTicket(ApiLoginId, Key);
            foreach (var tr in openedTransactions)
            {
                var state = cl.getTransaction(auth, MerchantId, tr.Trace);
                UpdateForteTransaction(tr, state);
            }
        }

        public void UpdateForteTransaction(TransactionHistoryItem transaction, Transaction forteTransaction)
        {
            var forteState = ForteTransactioNStateCodeMapping.FromString(forteTransaction.Response.Status);
            switch (forteState)
            {
                case ForteTransactionStateCode.Complete:
                    // eCheck verification was performed and the results were positive (POS) or unknown (UNK).
                case ForteTransactionStateCode.Authorized:
                    // The customer's payment was authorized. To complete the sale, the item must be captured from the transaction's detail page.
                case ForteTransactionStateCode.Review:
                    // Transaction was unable to be settled due to a merchant configuration issue. Please contact Customer Service to resolve (1-469-675-9920 x1).
                case ForteTransactionStateCode.Ready:
                    // Transaction was received and is awaiting origination (echeck) or settlement (credit card).
                case ForteTransactionStateCode.Settling:
                    // eCheck item has been originated and Forte is awaiting the settlement results.
                    UpdateForteTransaction(transaction, forteTransaction.Response.ResponseDescription, forteState);
                    break;
                case ForteTransactionStateCode.Funded: // eCheck item was funded to or from the merchant's bank account.
                case ForteTransactionStateCode.Settled:
                    // 	Credit Card itme has been funded to the merchant's bank account.
                    CompleteForteTransaction(transaction, forteTransaction.Response.ResponseDescription, forteState);
                    break;
                case ForteTransactionStateCode.Declined:
                    // Transaction was declined for reasons detailed in Response Code and Response Description.
                case ForteTransactionStateCode.Failed:
                    // 	eCheck verification was performed and the results were negative (NEG) or the transaction failed for reasons detailed in the Response Code and Response Description.
                case ForteTransactionStateCode.Rejected:
                    // eCheck item has been rejected or returned by the client's financial institution. Merchant will not be funded for the item
                case ForteTransactionStateCode.Unfunded:
                    // Previously funded eCheck itme has been returned and funding was reversed.
                case ForteTransactionStateCode.Voided:
                    // 	Transaction was voided and item will not be originated or settled.
                    RejectForteTransaction(transaction, forteTransaction.Response.ResponseDescription, forteState);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _transactionHistory.Save();
        }


        public void UpdateForteTransaction(TransactionHistoryItem target, string message,
            ForteTransactionStateCode state)
        {
            target.StateMessage = message;
            target.ForteState = state;
        }

        public void CompleteForteTransaction(TransactionHistoryItem target, string message,
            ForteTransactionStateCode state)
        {
            target.StateMessage = message;
            target.ForteState = state;
            _leaseService.OnTransactionComplete(target, message, target.User.Property.TimeZone.Now());
        }


        public void RejectForteTransaction(TransactionHistoryItem target, string message,
            ForteTransactionStateCode state)
        {
            target.StateMessage = message;
            target.ForteState = state;
            _leaseService.OnTransactionError(target, message, target.User.Property.TimeZone.Now());
        }


        public void MarkAsPaid(int id, string s)
        {
            var invoice = _invoiceRepository.Find(id);
            if (invoice == null) throw new KeyNotFoundException();
            var user = invoice.UserLeaseInfo.User;
            if (user == null) throw new KeyNotFoundException();

            var opId = Guid.NewGuid().ToString();
            //_leaseService.ÙCreateTransaction(opId, user.Id, new[] {invoice}, "", DateTime.Now);
            //var transaction = _transactionRepository.Find(opId);
            //_leaseService.OnTransactionComplete(transaction,s,user.Property.TimeZone.Now());
            //_transactionRepository.Save();
        }
    }
}

public class ForteMakePaymentResponse
{
    /*
        pg_response_type=A
        pg_response_code=A01
        pg_response_description=TEST APPROVAL
        pg_authorization_code=123456
        pg_trace_number=796B02B2-35DB-4987-BD62-15F5DD1EDF25
        pg_avs_code=Y
        pg_cvv_code=M
        pg_merchant_id=187762
        pg_transaction_type=10
        pg_total_amount=1215.0
        pg_client_id=2077254
        pg_payment_method_id=2358399
        endofdata
    */

    public string TraceNumber
    {
        get { return _traceNumber; }
        set { _traceNumber = value; }
    }

    public string ResponseCodeString
    {
        get { return _responseCodeString; }
        set { _responseCodeString = value; }
    }

    public ForteTransactionResultCode ResponseCode { get; set; }

    private static IniDataParser Parser = new IniDataParser(new IniParserConfiguration()
    {
        SkipInvalidLines = true
    });

    private string _traceNumber;
    private string _responseCodeString;

    public static ForteMakePaymentResponse FromIniString(string ini)
    {
        var res = new ForteMakePaymentResponse();
        res.ReadFromIni(Parser.Parse(ini));
        return res;
    }

    public void ReadFromIni(IniData data)
    {
        string respCode = null;
        if (data.TryGetKey("pg_response_code", out _responseCodeString))
        {
            ResponseCode = ForteTransactionResultCodeMapping.Codes[_responseCodeString];
        }

        data.TryGetKey("pg_trace_number", out _traceNumber);
    }
}