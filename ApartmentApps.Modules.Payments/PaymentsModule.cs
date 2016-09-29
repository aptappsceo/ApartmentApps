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

            
            //TODO: change later to get UserId from parameter
            var invoices = _invoiceRepository.GetAvailableBy(DateTime.Now).Where(s=>s.UserLeaseInfo.UserId == UserContext.UserId).ToArray();
            decimal convFee = 15;
            var total = invoices.Sum(s => s.Amount) + convFee;

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
        if(data.TryGetKey("pg_response_code",out _responseCodeString))
        {
            ResponseCode = ForteTransactionResultCodeMapping.Codes[_responseCodeString];
        }

        data.TryGetKey("pg_trace_number", out _traceNumber);

    }

}