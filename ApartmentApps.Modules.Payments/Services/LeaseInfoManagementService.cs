using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Payments.BindingModels;

namespace ApartmentApps.Modules.Payments.Services
{
    public class LeaseInfoManagementService
    {
        private readonly IRepository<Invoice> _invoices;
        private PropertyContext _context;
        private IUserContext _userContext;
        private IRepository<UserLeaseInfo> _leases;
        private IRepository<InvoiceTransaction> _transactions;

        public LeaseInfoManagementService(IRepository<Invoice> invoices, PropertyContext context, IUserContext userContext, IRepository<UserLeaseInfo> leases, IRepository<InvoiceTransaction> transactions)
        {
            _invoices = invoices;
            _context = context;
            _userContext = userContext;
            _leases = leases;
            _transactions = transactions;
        }

        public void ResumeUserLeaseInfo(ResumeUserLeaseInfoBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void SuspendUserLeaseInfo(SuspendUserLeaseInfoBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void CreateUserLeaseInfo(CreateUserLeaseInfoBindingModel model)
        {
            var user = _context.Users.Find(model.UserId);
            if(user == null) throw new KeyNotFoundException();

            if (model.Amount <= 0) throw new Exception("Amount must be greater than 0");

            if (model.InvoiceDate > user.Property.TimeZone.Now())
            {
                throw new Exception("Invoice Date cannot be set before Today");
            }

            var leaseInfo = new UserLeaseInfo()
            {
                Title = model.Title,
                User = user,
                Amount = model.Amount,
                CreateDate = user.Property.TimeZone.Now(),
                InvoiceDate = model.InvoiceDate.ToCorrectedDateTime(),
                State = LeaseState.Active
            };

            if (model.IsIntervalSet())
            {

                leaseInfo.IntervalDays = model.IntervalDays;
                leaseInfo.IntervalMonths = model.IntervalMonths;
                leaseInfo.IntervalYears = model.IntervalYears;

                if (model.RepetitionCompleteDate.HasValue)
                {
                    leaseInfo.RepetitionCompleteDate = model.RepetitionCompleteDate.Value;
                }
            }

            _leases.Add(leaseInfo);
            _leases.Save();

            CreateInvoice(leaseInfo);
        }

        public void CreateInvoice(UserLeaseInfo lease)
        {

            var anyActiveInvoices =
                _invoices.GetAll()
                    .Any(v => v.UserLeaseInfoId == lease.Id && //invoice for same lease
                    !v.IsArchived &&  //invoice is not archived
                    (v.State == InvoiceState.NotPaid || v.State == InvoiceState.Pending)); //invoice is notpaid or pending

            if (anyActiveInvoices) throw new Exception($"Another Invoice is active for lease id:{lease.Id}");

            if (lease.InvoiceDate > lease.User.Property.TimeZone.Now())
            {
                throw new Exception("Invoice cannot be created before Today");
            }

            if (lease.RepetitionCompleteDate.HasValue)
            {
                var canContinue = lease.RepetitionCompleteDate > lease.InvoiceDate;
                if (!canContinue)
                {
                    throw new Exception("Invoice cannot be created past Repetition Complete Date");
                }
            }

            var invoice = new Invoice()
            {
                UserLeaseInfo = lease,
                Amount = lease.Amount,
                AvailableDate = lease.InvoiceDate - TimeSpan.FromDays(14),
                DueDate = lease.InvoiceDate,
                State = InvoiceState.NotPaid,
                Title = lease.Title
            };

            _invoices.Add(invoice);
            _invoices.Save();
        }

        public void CancelInvoice(CancelInvoiceBindingModel model)
        {
            var invoice = _invoices.Find(model.InvoiceId);
            if(invoice == null) throw new KeyNotFoundException();

            if (invoice.IsArchived) throw new Exception("Cannot cancel archived invoice");
            if(invoice.State != InvoiceState.NotPaid) throw new Exception("Cannot cancel invoice, because it has already been processed or is being processed at the moment.");

            invoice.State = InvoiceState.Canceled;
            invoice.IsArchived = true;
          
            _invoices.Save();
        }

        public void CreateTransaction(string id, Invoice[] invoices, string comments)
        {

            foreach (var invoice in invoices)
            {
                if (invoice.State != InvoiceState.NotPaid || invoice.IsArchived)
                {
                   throw new Exception($"One of invoices has illegal state: {invoice.Id} is {invoice.State} (Must be NotPaid)");
                }
            }

            var transaction = new InvoiceTransaction()
            {
                State = TransactionState.Pending,
                Invoices = invoices,
                Comments = comments
            };
            
            _transactions.Add(transaction);
            _transactions.Save();

            foreach (var invoice in invoices)
            {
                invoice.State = InvoiceState.Pending;
                invoice.PaymentTransactionId = transaction.Id;
            }

            _invoices.Save();
            

        }

        public void OnTransactionComplete(InvoiceTransaction transaction, string comment, DateTime completeDate)
        {
            transaction.State = TransactionState.Complete;
            transaction.Comments = comment;
            var invoices = transaction.Invoices;
            foreach (var invoice in invoices)
            {
                invoice.State = InvoiceState.Paid;
                invoice.IsArchived = true;
            }

            _transactions.Save();
            _invoices.Save();

            foreach (var invoice in invoices)
            {
                var lease = invoice.UserLeaseInfo;
                if(lease.State != LeaseState.Active) throw new Exception("Fatal Error: Transaction complete for invoice of NonActive lease. This should not happen.");

                if (IsContinuable(lease))
                {
                    lease.InvoiceDate = ComputeNextDateForInvoice(lease);
                    CreateInvoice(lease);
                }
                else
                {
                    lease.State = LeaseState.Archived;
                }
            }

            _leases.Save();
            _invoices.Save();

        }

        public bool IsContinuable(UserLeaseInfo lease)
        {

            if (lease.State != LeaseState.Active) return false; //because lease is suspended 

            var anyActiveInvoices =
                _invoices.GetAll()
                    .Any(v => v.UserLeaseInfoId == lease.Id && //invoice for same lease
                    !v.IsArchived &&  //invoice is not archived
                    (v.State == InvoiceState.NotPaid || v.State == InvoiceState.Pending)); //invoice is notpaid or pending

            if (anyActiveInvoices) return false; //because active invoice exists for this lease

            if (lease.IsIntervalSet()) return false; //because lease is not repetative

            var newDate = ComputeNextDateForInvoice(lease);

            if (lease.RepetitionCompleteDate.HasValue && newDate > lease.RepetitionCompleteDate.Value) return false; //because lease is complete

            return true;

        }

        public void OnTransactionError(InvoiceTransaction transaction, string comment, DateTime completeDate)
        {
            //invoices set back to NotPaid state
            throw new NotImplementedException();
        }

        public void CancelTransaction(CancelTransactionBindingModel model)
        {
            throw new NotImplementedException();
        }

        public UserPaymentsOverviewBindingModel GetUserPaymentsOverview(string userId)
        {
            throw new NotImplementedException();
        }

        public DateTime ComputeNextDateForInvoice(UserLeaseInfo lease)
        {
            return lease.InvoiceDate.Offset(lease.IntervalDays ?? 0, lease.IntervalMonths ?? 0,
                lease.IntervalYears ?? 0);
        }


    }
}
