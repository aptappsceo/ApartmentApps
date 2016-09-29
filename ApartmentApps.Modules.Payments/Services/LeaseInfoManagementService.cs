using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Payments.BindingModels;
using ApartmentApps.Modules.Payments.Data;
using TransactionState = ApartmentApps.Api.Modules.TransactionState;

namespace ApartmentApps.Modules.Payments.Services
{
    public class LeaseInfoManagementService
    {
        private readonly IRepository<ApplicationUser> _users;
        private readonly IRepository<Invoice> _invoices;
        private PropertyContext _context;
        private IUserContext _userContext;
        private IRepository<UserLeaseInfo> _leases;
        private IRepository<TransactionHistoryItem> _transactionHistory;
        private IRepository<InvoiceTransaction> _transactions;

        public LeaseInfoManagementService(IRepository<ApplicationUser> users, IRepository<Invoice> invoices,
            PropertyContext context, IUserContext userContext, IRepository<UserLeaseInfo> leases,
            IRepository<InvoiceTransaction> transactions, IRepository<TransactionHistoryItem> transactionHistory)
        {
            _users = users;
            _invoices = invoices;
            _context = context;
            _userContext = userContext;
            _leases = leases;
            _transactions = transactions;
            _transactionHistory = transactionHistory;
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
            if (user == null) throw new KeyNotFoundException();

            if (model.Amount <= 0) throw new Exception("Amount must be greater than 0");

            if (model.InvoiceDate < user.Property.TimeZone.Now())
            {
                throw new Exception("Invoice Date cannot be set before Today");
            }

            var leaseInfo = new UserLeaseInfo()
            {
                Title = model.Title,
                User = user,
                Amount = model.Amount,
                CreateDate = user.Property.TimeZone.Now(),
                NextInvoiceDate = model.InvoiceDate.ToCorrectedDateTime(),
                State = LeaseState.Active
            };

            if (model.UseInterval && model.IsIntervalSet())
            {
                leaseInfo.IntervalDays = model.IntervalDays;
                leaseInfo.IntervalMonths = model.IntervalMonths;
                leaseInfo.IntervalYears = model.IntervalYears;

                if (model.UseCompleteDate && model.RepetitionCompleteDate.HasValue)
                {
                    leaseInfo.RepetitionCompleteDate = model.RepetitionCompleteDate.Value;
                }
            }

            _leases.Add(leaseInfo);
            _leases.Save();

            CreateInvoice(leaseInfo);
        }

        private bool UpdateNextInvoiceDate(UserLeaseInfo info)
        {

            if (info.NextInvoiceDate != null && IsContinuable(info))
            {
                info.NextInvoiceDate = ComputeNextDateForInvoice(info, info.NextInvoiceDate.Value);
                return true;
            }
            else
            {
                info.NextInvoiceDate = null;
                return false; // Cannot set next invoice date, since 
            }
        }

        public void CreateInvoice(UserLeaseInfo lease)
        {

            if (!lease.NextInvoiceDate.HasValue) throw new Exception("No Next Invoice Date is set for the Lease Info");

            var anyActiveInvoices =
                    _invoices.GetAll()
                        .Any(v => v.UserLeaseInfoId == lease.Id && //invoice for same lease
                                  !v.IsArchived && //invoice is not archived
                                  (v.State == InvoiceState.NotPaid || v.State == InvoiceState.Pending));
                //invoice is notpaid or pending

            if (anyActiveInvoices) throw new Exception($"Another Invoice is active for lease id:{lease.Id}");

            if (lease.NextInvoiceDate < lease.User.Property.TimeZone.Now())
            {
                throw new Exception("Invoice cannot be created before Today");
            }

            if (lease.RepetitionCompleteDate.HasValue)
            {
                var canContinue = lease.RepetitionCompleteDate > lease.NextInvoiceDate;
                if (!canContinue)
                {
                    throw new Exception("Invoice cannot be created past Repetition Complete Date");
                }
            }

            var invoice = new Invoice()
            {
                UserLeaseInfo = lease,
                Amount = lease.Amount,
                AvailableDate = lease.NextInvoiceDate.Value - TimeSpan.FromDays(14),
                DueDate = lease.NextInvoiceDate.Value,
                State = InvoiceState.NotPaid,
                Title = lease.Title
            };




            _invoices.Add(invoice);
            _invoices.Save();

            UpdateNextInvoiceDate(lease);
            _leases.Save();

        }

        public void CancelInvoice(CancelInvoiceBindingModel model)
        {
            var invoice = _invoices.Find(model.Id);
            if (invoice == null) throw new KeyNotFoundException();

            CancelInvoice(invoice);

            var lease = invoice.UserLeaseInfo;

            if (model.UserLeaseInfoAction == UserLeaseInfoAction.Cancel)
            {
                CancelUserLeaseInfo(new CancelUserLeaseInfoBindingModel()
                {
                    Id = lease.Id
                });
            }
            else
            {
                GenerateNextInvoiceOrArchive(lease);
            }

            //Some actions for user lease info
        }

        public void CancelInvoice(Invoice invoice)
        {
             if (invoice.IsArchived) throw new Exception("Cannot cancel archived invoice");
            if (invoice.State != InvoiceState.NotPaid)
                throw new Exception(
                    "Cannot cancel invoice, because it has already been processed or is being processed at the moment.");


             invoice.State = InvoiceState.Canceled;
            invoice.IsArchived = true;

            _invoices.Save();

        }

        public void CancelUserLeaseInfo(UserLeaseInfo lease)
        {
            if(lease.State == LeaseState.Archived) throw new Exception("Cannot cancel archived Payment Request");

            var activeInvoices = _invoices.Where(s=>s.UserLeaseInfoId == lease.Id && !s.IsArchived);

            foreach (var invoice in activeInvoices)
            {
                if(invoice.State != InvoiceState.NotPaid)  throw new Exception("Cannot cancel Payment Request, since one of the related invoices is being processed");
            }

            foreach (var invoice in activeInvoices)
            {
                CancelInvoice(invoice);
            }

            lease.State = LeaseState.Archived;
            _leases.Save();
        }

        public string CreateTransaction(string trace, string userId, string commiterId, decimal totalIncludingConvenienceFee, decimal convenienceFee, Invoice[] invoices, string comments, DateTime estimatedCompleteDate)
        {
            foreach (var invoice in invoices)
            {
                if (invoice.State != InvoiceState.NotPaid || invoice.IsArchived)
                {
                    throw new Exception(
                        $"One of invoices has illegal state: {invoice.Id} is {invoice.State} (Must be Not Paid)");
                }
            }

            var user = _users.Find(userId);
            if (user == null) throw new Exception("Not Found User With Id: " + userId);
            
            var commiter = _users.Find(commiterId);
            if (commiter == null) throw new Exception("Not Found Commiter (User)  With Id: " + userId);

            var transaction = new TransactionHistoryItem()
            {
                Trace= trace,
                State = TransactionState.Open,
                Invoices = invoices,
                OpenDate = user.Property.TimeZone.Now(),
                Amount= totalIncludingConvenienceFee ,
                ConvenienceFee = convenienceFee,
                CommiterId = commiterId,
                UserId = userId,
                StateMessage = comments,
                Service = PaymentVendor.Forte,
            };

            _transactionHistory.Add(transaction);

             _transactions.Save();

            foreach (var invoice in invoices)
            {
                invoice.State = InvoiceState.Pending;
            }

            _invoices.Save();

            return transaction.Id;
        }

        public void OnTransactionComplete(InvoiceTransaction transaction, string comment, DateTime completeDate)
        {
            transaction.State = TransactionState.Approved; 
            transaction.Comments = comment; 
            transaction.CompleteDate = completeDate;
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
                if (lease.State != LeaseState.Active)
                    throw new Exception(
                        "Fatal Error: Transaction complete for invoice of NonActive lease. This should not happen.");

                GenerateNextInvoiceOrArchive(lease);
            }

            _leases.Save();
            _invoices.Save();
        }

        public void GenerateNextInvoiceOrArchive(UserLeaseInfo lease)
        {
            if (lease.NextInvoiceDate.HasValue)
            {
                CreateInvoice(lease);
            }
            else
            {
                lease.State = LeaseState.Archived;
            }
            _leases.Save();
        }

        public bool IsContinuable(UserLeaseInfo lease)
        {

            if (lease.State != LeaseState.Active) return false; //because lease is suspended 

            if (!lease.IsIntervalSet()) return false; //because lease is not repetative

            if (!lease.NextInvoiceDate.HasValue) return false;

            var newDate = ComputeNextDateForInvoice(lease, lease.NextInvoiceDate.Value);

            if (lease.RepetitionCompleteDate.HasValue && newDate > lease.RepetitionCompleteDate.Value)
                return false; //because lease is complete

            return true;
        }

        public void OnTransactionError(InvoiceTransaction transaction, string comment, DateTime completeDate)
        {
            //invoices set back to NotPaid state
            throw new NotImplementedException();
        }

        public UserPaymentsOverviewBindingModel GetUserPaymentsOverview(string userId)
        {
            throw new NotImplementedException();
        }

        public DateTime ComputeNextDateForInvoice(UserLeaseInfo lease, DateTime latestInvoiceDate)
        {
            return latestInvoiceDate.Offset(lease.IntervalDays ?? 0, lease.IntervalMonths ?? 0,
                lease.IntervalYears ?? 0);
        }


        public void EditInvoice(EditInvoiceBindingModel data)
        {
            var invoice = _invoices.Find(data.Id);
            invoice.Title = data.Title;
            invoice.DueDate = data.DueDate;
            invoice.AvailableDate = data.AvailableDate;
            invoice.Amount = data.Amount;
            _invoices.Save();
        }

        public void EditUserLeaseInfo(EditUserLeaseInfoBindingModel data)
        {

            var lease = _leases.Find(data.Id);

            if (data.UseInterval)
            {
                lease.IntervalMonths = data.IntervalMonths;
            }
            else
            {
                lease.IntervalMonths = null;
                lease.IntervalDays = null;
                lease.IntervalYears = null;
            }

            if (data.UseCompleteDate)
            {
                lease.RepetitionCompleteDate = data.CompleteDate;
            }
            else
            {
                lease.RepetitionCompleteDate = null;
            }

            lease.NextInvoiceDate = data.NextInvoiceDate;

            lease.Title = data.Title;
            lease.Amount = data.Amount;

            _leases.Save();

        }

        public void CancelUserLeaseInfo(CancelUserLeaseInfoBindingModel data)
        {
            var lease = _leases.Find(data.Id);
            CancelUserLeaseInfo(lease);
            _leases.Save();
        }
    }
}