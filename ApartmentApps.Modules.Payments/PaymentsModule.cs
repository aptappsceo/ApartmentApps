using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Data.Utils;
using ApartmentApps.Payments.Forte;
using ApartmentApps.Payments.Forte.Forte.Client;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Modules
{


    

    [Persistant]
    public class Invoice
    {
        
        [Key]
        public int Id { get; set; }

        public int UserLeaseInfoId { get; set; }

        [ForeignKey(nameof(UserLeaseInfoId))]
        public virtual UserLeaseInfo UserLeaseInfo { get;set; }

        public decimal Amount { get; set; }

        public DateTime AvailableDate { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsArchived { get; set; }

        [ForeignKey(nameof(PaymentTransactionId))]
        public virtual InvoiceTransaction PaymentTransaction { get; set; }

        public string PaymentTransactionId { get; set; } //Id of operation on Forte/else where

        public InvoiceState State { get; set; }
        public string Title { get; set; }
    }

    [Persistant]
    public class InvoiceTransaction
    {
        [Key]
        public string Id { get; set; }

        public InvoiceTransaction()
        {
            Invoices = new List<Invoice>();
        }

        public ICollection<Invoice> Invoices { get; set; }

        public TransactionState State { get; set; }

        public string Comments { get; set; }
    }

    public enum TransactionState
    {
        Inactive, Pending, Complete, Failure
    }

    public class AutoCompleteItem
    {
        public string UniqueKey { get; set; }
        public string Text { get; set; }
    }

    public enum InvoiceState
    {
        NotPaid, Pending, Paid
    }

    [Persistant]
    public class UserLeaseInfo : PropertyEntity
    {

        public string UserId { get; set; }

        //User that must pay
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }

        //Amount of money to pay
        public decimal Amount { get; set; }

        //Starting point: first invoice will be generated with DueDate equal to InvoiceDate
        public DateTime InvoiceDate { get; set; }

        public int? IntervalDays { get; set; }
        public int? IntervalMonths { get; set; }
        public int? IntervalYears { get; set; }

        //Date, after which (if user commited last payment) LeaseInfo will be Suspended and Archived and not updated any more
        public DateTime? RepetitionCompleteDate { get; set; }

        //The moment when leaseinfo is created
        public DateTime CreateDate { get; set; }

        public LeaseState State { get; set; }
        
        public string Title { get; set; }

    }

    public enum IntervalType
    {
        Days, Months, Years
    }



    public class UserPaymentsOverviewBindingModel
    {
        public UserBindingModel User { get; set; }
        public List<UserLeaseInfo> LeaseInfos { get;set; }
        public List<Invoice> Invoices { get; set; }
    }

    public class EditLeaseBindingModel
    {
        
        public decimal Amount { get; set; }

    }

    public enum LeaseState
    {
        Suspended,
        Archived,
        Active
    }

    public class UserLeaseInfoBindingModel : BaseViewModel
    {
         [DataType("Hidden")]
        public int LeaseInfoId { get; set; }

        //User that must pay
        public virtual UserBindingModel User { get; set; }

        //Amount of money to pay
        public decimal Amount { get; set; }

        public DateTime InvoiceDate { get; set; }


        public TimeSpan? Interval { get; set; }

        public DateTime? CompleteDate { get; set; }

        public DateTime CreateDate { get; set; }

        public LeaseState State { get; set; }
        
        public string Title { get; set; }

        /*
        public InvoiceUrgencyState InvoiceUrgencyState
        {
            get
            {
                if(IsArchived || IsSuspended || !NextDue.HasValue) return LeaseUrgencyState.Suspended;
                var timeSpan = NextDue.Value - Property.TimeZone.Now();

                if(timeSpan.Days > 15) return LeaseUrgencyState.Cold;
                if(timeSpan.Days < 15 && timeSpan.Days > 0) return LeaseUrgencyState.Upcoming;

                return LeaseUrgencyState.Urgent;
            }
        }
        */
    }

    public enum InvoiceUrgencyState
    {
        Suspended, Upcoming, Urgent
    }

   

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

  
        private void CreateNextInvoiceFor(UserLeaseInfo leaseInfo)
        {
            var incoice = new Invoice()
            {
                UserLeaseInfo = leaseInfo,
                Amount = leaseInfo.Amount,
                AvailableDate = leaseInfo.InvoiceDate - TimeSpan.FromDays(14),
                DueDate = leaseInfo.InvoiceDate,
                State = InvoiceState.NotPaid,
                Title = leaseInfo.Title
            };

            _invoiceRepository.Add(incoice);
            _invoiceRepository.Save();
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

    public static class LeaseExtensions
    {
        
        
        public static UserLeaseInfoBindingModel ToUserLeaseInfoBindingModel(this UserLeaseInfo lease, PaymentsConfig config, IBlobStorageService blobStorage)
        {
            return null;
        }

        public static bool IsIntervalSet(this UserLeaseInfo lease)
        {
            return lease.IntervalDays.HasValue || lease.IntervalMonths.HasValue || lease.IntervalYears.HasValue;
        }

        public static bool IsIntervalSet(this CreateUserLeaseInfoBindingModel lease)
        {
            return lease.IntervalDays.HasValue || lease.IntervalMonths.HasValue || lease.IntervalYears.HasValue;
        }

    }


    public static class DateTimeExtensions
    {

        public static DateTime Offset(this DateTime source, int days, int months, int years)
        {
            var date1 = new DateTime(2016,5,21).ToString("g");
            return source.AddDays(days).AddMonths(months).AddYears(years);
        }

        public static DateTime ToCorrectedDateTime(this DateTime source)
        {
            var lastDay = DateTime.DaysInMonth(source.Year, source.Month);
            var dif = source.Day - lastDay;
            if (dif > 0)
            {
                return source.Subtract(TimeSpan.FromDays(dif));
            }

            return source;
        }
    }
}