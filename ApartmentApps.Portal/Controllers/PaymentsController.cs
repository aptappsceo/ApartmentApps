using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Payments.BindingModels;
using ApartmentApps.Modules.Payments.Data;
using ApartmentApps.Modules.Payments.Services;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    [Authorize]
    public class PaymentsController : AAController
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly PaymentsModule _paymentsModule;
        private readonly IRepository<UserLeaseInfo> _leaseInfos;
        private readonly IRepository<Invoice> _invoices;
        private readonly IRepository<TransactionHistoryItem> _invoiceHistory;
        private readonly IRepository<InvoiceTransaction> _transactions;
        private LeaseInfoManagementService _leaseService;
        // GET: Payments
        public ActionResult Index()
        {
            if (User.IsInRole("Resident") && CurrentUser.UnitId != null)
            {
                return RedirectToAction("RentSummary");
            }
            return View("RentSummary"); // TODO Redirect to other pages for property manager
        }

        public PaymentsController(IBlobStorageService blobStorageService, PaymentsModule paymentsModule, IRepository<UserLeaseInfo> leaseInfos, IRepository<Invoice> invoices, IKernel kernel, PropertyContext context, IUserContext userContext, IRepository<InvoiceTransaction> transactions, LeaseInfoManagementService leaseService, IRepository<TransactionHistoryItem> invoiceHistory) : base(kernel, context, userContext)
        {
            _blobStorageService = blobStorageService;
            _paymentsModule = paymentsModule;
            _leaseInfos = leaseInfos;
            _invoices = invoices;
            _transactions = transactions;
            _leaseService = leaseService;
            _invoiceHistory = invoiceHistory;
        }

        public ActionResult RentSummary()
        {
            ViewBag.NextAction = Url.Action("PaymentOptions");
            return View("RentSummary", _paymentsModule.GetRentSummary(CurrentUser.Id).Result);
        }

        public async Task<ActionResult> RentSummaryFor(string userId)
        {
            ViewBag.NextAction = Url.Action("PaymentOptionsFor",new {userId = userId});
            var rent = await _paymentsModule.GetRentSummary(userId);
            return View("RentSummary", rent);
        }

        public ActionResult PaymentOptions()
        {
            return View("PaymentOptions", _paymentsModule.GetPaymentOptions());
        }

        public ActionResult PaymentOptionsFor(string userId)
        {
            return View("PaymentOptions", _paymentsModule.GetPaymentOptionsFor(userId));
        }

        public ActionResult MakePayment()
        {
            return AutoForm(new MakePaymentBindingModel(), "MakePaymentSubmit", "Make Payment");
        }

            public ActionResult PaymentSummary(string paymentOptionId)
        {
            PaymentOptionId = paymentOptionId;
            ViewBag.NextAction = Url.Action("MakePayment");
            return View("RentSummary", _paymentsModule.GetPaymentSummary(CurrentUser.Id).Result);
        }

        [HttpPost]
        public ActionResult MakePaymentSubmit(MakePaymentBindingModel model)
        {
            return View("PaymentSuccess", _paymentsModule.MakePayment(model).Result);
        }


        public string PaymentOptionId
        {
            get { return Session["PaymentOptionId"] as string; }
            set { Session["PaymentOptionId"] = value; }
        }



        public ActionResult AddCreditCard()
        {
            return AutoForm(new AddCreditCardBindingModel(), "AddCreditCardSubmit", "Add Credit Card");
        }

        public async Task<ActionResult> AddCreditCardSubmit(AddCreditCardBindingModel cardModel)
        {
            var result = await _paymentsModule.AddCreditCard(cardModel);
            PaymentOptionId = result.PaymentOptionId.ToString();
            return RedirectToAction("MakePayment");
        }

        public ActionResult AddBankAccount()
        {
            return AutoForm(new AddBankAccountBindingModel(), "AddBankAccountSubmit", "Add Credit Card");
        }

        public ActionResult CreateUserLeaseInfo()
        {
            return View("CreateUserLeaseInfo", new CreateUserLeaseInfoBindingModel()
            {
                UserIdItems =
                    Context.Users.GetAll()
                        .Where(u => !u.Archived)
                        .ToList()
                        .Select(u => u.ToUserBindingModel(_blobStorageService))
                        .Where(u => !string.IsNullOrWhiteSpace(u.FullName))
                        .ToList(),
            });
        }

        [HttpPost]
        public ActionResult SubmitCreateUserLeaseInfo(CreateUserLeaseInfoBindingModel data)
        {
            if (!ModelState.IsValid)
            {
                data.UserIdItems =
                    Context.Users.GetAll()
                        .Where(u => !u.Archived)
                        .ToList()
                        .Select(u => u.ToUserBindingModel(_blobStorageService))
                        .Where(u => !string.IsNullOrWhiteSpace(u.FullName))
                        .ToList();
                return View("CreateUserLeaseInfo", data);
            }

            _leaseService.CreateUserLeaseInfo(data);

            return RedirectToAction("UserPaymentsOverview", new {id = data.UserId});
        }


        public async Task<ActionResult> GetPaymentSummary(string userId)
        {
            return View("RentSummary", await _paymentsModule.GetRentSummary(userId));
        }

        public ActionResult UserPaymentsOverview(string id)
        {
            var user = Context.Users.Find(id);
            if (user == null) return HttpNotFound();

            var userLeaseInfos = _leaseInfos.GetAll().Where(s => s.UserId == id).ToList();
            var transactions = _invoiceHistory.GetAll().Include(s=>s.Invoices).Where(s => s.UserId == id).ToList();
            var userLeaseInfosIds = userLeaseInfos.Select(s => s.Id).ToArray();

            return View("UserPaymentsOverview", new UserPaymentsOverviewBindingModel()
            {
                User = user.ToUserBindingModel(_blobStorageService),
                Invoices =
                    _invoices.GetAll()
                        .Where(s => userLeaseInfosIds.Contains(s.UserLeaseInfoId))
                        .ToList()
                        .Select(s => s.ToBindingModel(_blobStorageService))
                        .ToList(),
                LeaseInfos = userLeaseInfos.Select(s => s.ToBindingModel(_blobStorageService)).ToList(),
                Transactions = transactions.Select(s => s.ToBindingModel()).ToList(),
                PaymentOptions = _paymentsModule.GetPaymentOptionsFor(user.Id).ToList()
            });
        }

        public ActionResult MarkAsPaid(int id)
        {
            var invoice = _invoices.Find(id);
            if (invoice == null) return HttpNotFound();
            var user = invoice.UserLeaseInfo.User;
            if (user == null) return HttpNotFound();
            _paymentsModule.MarkAsPaid(id, "Marked as paid by " + CurrentUser.Email);


            return RedirectToAction("UserPaymentsOverview", new {id = user.Id});
        }

        public async Task<ActionResult> AddBankAccountSubmit(AddBankAccountBindingModel cardModel)
        {
            await _paymentsModule.AddBankAccount(cardModel);
            return RedirectToAction("MakePayment");
        }

        public ActionResult CreateUserLeaseInfoFor(string id)
        {
            return View("CreateUserLeaseInfo", new CreateUserLeaseInfoBindingModel()
            {
                UserId = id,
                UserIdItems =
                    Context.Users.GetAll()
                        .Where(u => !u.Archived)
                        .ToList()
                        .Select(u => u.ToUserBindingModel(_blobStorageService))
                        .Where(u => !string.IsNullOrWhiteSpace(u.FullName))
                        .ToList(),
            });
        }


        public ActionResult CancelInvoice(int id)
        {
            var invoice = _invoices.Find(id);
            if (invoice == null) return HttpNotFound();

            return View("CancelInvoice", new CancelInvoiceBindingModel()
            {
                Id = id
            });
        }

        [HttpPost]
        public ActionResult CancelInvoice(CancelInvoiceBindingModel data)
        {
            if (ModelState.IsValid)
            {
                var invoice = _invoices.Find(data.Id);
                if (invoice == null) return HttpNotFound();

                var user = invoice.UserLeaseInfo.User;

                _leaseService.CancelInvoice(data);

                return RedirectToAction("UserPaymentsOverview", new {id = user.Id});
            }
            else
            {
                return View("CancelInvoice", data);
            }
        }

        public async Task<ActionResult> ForceRejectTransaction(string id)
        {

            var transaction = _invoiceHistory.Find(id);
            if (transaction == null) return HttpNotFound();
            var user = transaction.User;
            if (user == null) return HttpNotFound();
            var s = await _paymentsModule.ForceRejectTransaction(id);
            return RedirectToAction("UserPaymentsOverview", new {id = user.Id});
        }

        public async Task<ActionResult> ForceCompleteTransaction(string id)
        {

            var transaction = _invoiceHistory.Find(id);
            if (transaction == null) return HttpNotFound();
            var user = transaction.User;
            if (user == null) return HttpNotFound();
            var s = await _paymentsModule.ForceCompleteTransaction(id);
            return RedirectToAction("UserPaymentsOverview", new {id = user.Id});
        }


        public ActionResult EditInvoice(int id)
        {
                  var invoice = _invoices.Find(id);
            if (invoice == null) return HttpNotFound();

            return View("EditInvoice", new EditInvoiceBindingModel()
            {
                Id = id,
                Title = invoice.Title,
                AvailableDate = invoice.AvailableDate,
                DueDate = invoice.DueDate,
                Amount = invoice.Amount
            });
        }

        [HttpPost]
        public ActionResult EditInvoice(EditInvoiceBindingModel data)
        {
            if (ModelState.IsValid)
            {
                var invoice = _invoices.Find(data.Id);
                if (invoice == null) return HttpNotFound();

                var user = invoice.UserLeaseInfo.User;

                _leaseService.EditInvoice(data);

                return RedirectToAction("UserPaymentsOverview", new {id = user.Id});
            }
            else
            {
                return View("EditInvoice", data);
            }
        }

        public ActionResult EditUserLeaseInfo(int id)
        {
            var lease = _leaseInfos.Find(id);
            if (lease== null) return HttpNotFound();

            var editUserLeaseInfoBindingModel = new EditUserLeaseInfoBindingModel()
            {
                Id = id,
                Amount = lease.Amount,
                NextInvoiceDate = lease.NextInvoiceDate,
                CompleteDate = lease.RepetitionCompleteDate,
                Title = lease.Title,
                IntervalMonths = lease.IntervalMonths,
                UseInterval = lease.IsIntervalSet(),
                UseCompleteDate = lease.RepetitionCompleteDate.HasValue
            };
            return View("EditUserLeaseInfo", editUserLeaseInfoBindingModel);
        }

        [HttpPost]
        public ActionResult EditUserLeaseInfo(EditUserLeaseInfoBindingModel data)
        {
            if (ModelState.IsValid)
            {
                var userLeaseInfo = _leaseInfos.Find(data.Id);
                if (userLeaseInfo== null) return HttpNotFound();

                var user = userLeaseInfo.User;

                _leaseService.EditUserLeaseInfo(data);

                return RedirectToAction("UserPaymentsOverview", new {id = user.Id});
            }
            else
            {
                return View("EditUserLeaseInfo", data);
            }
        }


        public ActionResult CancelUserLeaseInfo(int id)
        {
            var userLeaseInfo = _leaseInfos.Find(id);
            if (userLeaseInfo== null) return HttpNotFound();

            return View("CancelUserLeaseInfo", new CancelUserLeaseInfoBindingModel()
            {
                Id = id
            });
        }

        [HttpPost]
        public ActionResult CancelUserLeaseInfo(CancelUserLeaseInfoBindingModel data)
        {
              if (ModelState.IsValid)
            {
                var userLeaseInfo = _leaseInfos.Find(data.Id);
                if (userLeaseInfo== null) return HttpNotFound();

                var user = userLeaseInfo.User;

                _leaseService.CancelUserLeaseInfo(data);

                return RedirectToAction("UserPaymentsOverview", new {id = user.Id});
            }
            else
            {
                return View("CancelUserLeaseInfo", data);
            }
        }


        public ActionResult InvoiceDetails(int id)
        {
            var invoice = _invoices.Find(id);
            if (invoice == null) return HttpNotFound();
            return View("InvoiceDetails", invoice.ToBindingModel(_blobStorageService));
        }


        public ActionResult UserLeaseInfoDetails(int id)
        {
            var userLeaseInfo = _leaseInfos.Find(id);
            if (userLeaseInfo== null) return HttpNotFound();
            return View("UserLeaseInfoDetails", userLeaseInfo.ToBindingModel(_blobStorageService));
        }


        public ActionResult TransactionDetails(string id)
        {
            var transaction = _transactions.Find(id);
            if (transaction == null) return HttpNotFound();
            return View("TransactionDetails", transaction.ToBindingModel(_blobStorageService));
        }
    }
}