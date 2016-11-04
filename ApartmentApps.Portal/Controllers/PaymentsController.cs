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
using ApartmentApps.Api.ViewModels;
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
        private readonly UserService _users;
        private LeaseInfoManagementService _leaseService;

        // GET: Payments
        public ActionResult Index()
        {
            if (User.IsInRole("Resident") && CurrentUser.UnitId != null)
            {
                return RedirectToAction("RentSummaryFor");
            }
            return View("RentSummary"); // TODO Redirect to other pages for property manager
        }

        public PaymentsController(IBlobStorageService blobStorageService, PaymentsModule paymentsModule, IRepository<UserLeaseInfo> leaseInfos, IRepository<Invoice> invoices, IKernel kernel, PropertyContext context, IUserContext userContext, IRepository<InvoiceTransaction> transactions, LeaseInfoManagementService leaseService, IRepository<TransactionHistoryItem> invoiceHistory, UserService users) : base(kernel, context, userContext)
        {
            _blobStorageService = blobStorageService;
            _paymentsModule = paymentsModule;
            _leaseInfos = leaseInfos;
            _invoices = invoices;
            _transactions = transactions;
            _leaseService = leaseService;
            _invoiceHistory = invoiceHistory;
            _users = users;
        }

        public async Task<ActionResult> RentSummaryFor(string userId)
        {
            IsUserMakingPayment = true;
            ViewBag.NextAction = Url.Action("PaymentOptionsFor",new {userId});
            var rent = await _paymentsModule.GetRentSummaryFor(userId);
            return View("RentSummary", rent);
        }

        public ActionResult PaymentOptionsFor(string userId)
        {
            ViewBag.UserId = userId;
            return View("PaymentOptions", _paymentsModule.GetPaymentOptionsFor(userId));
        }

        public ActionResult PaymentSummaryFor(string userId, string paymentOptionId)
        {
            SelectedPaymentOption = paymentOptionId;
            ViewBag.UserId = userId;
            ViewBag.NextAction = Url.Action("SubmitPayment",new MakePaymentBindingModel()
            {
                UserId = userId
            });
            return View("RentSummary", _paymentsModule.GetPaymentSummaryFor(userId,paymentOptionId).Result);
        }

        public ActionResult SubmitPayment(MakePaymentBindingModel model)
        {
            model.PaymentOptionId = SelectedPaymentOption;
            var makePaymentResult = _paymentsModule.MakePayment(model).Result;
            if (makePaymentResult.ErrorMessage != null)
            {
                this.AddErrorMessage(makePaymentResult.ErrorMessage);
            }
            else
            {
                this.AddSuccessMessage("Payment will be processed soon.");
            }
            return RedirectToAction("UserPaymentsOverview", new {id = model.UserId});
        }

        public ActionResult AddCreditCardFor(string userId)
        {
            return AutoForm(new AddCreditCardBindingModel()
            {
                Users = _users.GetAll<UserLookupBindingModel>().ToList(),
                UserId = userId
            }, "AddCreditCardForSubmit", "Add Credit Card");
        }

        public ActionResult AddCreditCard()
        {
            return AutoForm(new AddCreditCardBindingModel()
            {
                Users = _users.GetAll<UserLookupBindingModel>().ToList()
            }, "AddCreditCardForSubmit", "Add Credit Card");
        }

        public bool IsUserMakingPayment
        {
            get { return Session[nameof(IsUserMakingPayment)] != null && bool.Parse(Session[nameof(IsUserMakingPayment)].ToString()); }
            set { Session[nameof(IsUserMakingPayment)] = value.ToString(); }
        }

        public string SelectedPaymentOption
        {
            get { return (string)Session[nameof(SelectedPaymentOption)]; }
            set { Session[nameof(SelectedPaymentOption)] = value; }
        }

        public async Task<ActionResult> AddCreditCardForSubmit(AddCreditCardBindingModel cardModel)
        {
            var res = await _paymentsModule.AddCreditCard(cardModel);
            if (res.ErrorMessage != null)
            {
                AddErrorMessage(res.ErrorMessage);
                return AutoForm(cardModel, "AddCreditCardForSubmit", "Add Credit Card");
            }

            if (IsUserMakingPayment)
            {
                return RedirectToAction("PaymentSummaryFor", new {userId = cardModel.UserId, paymentOptionId = res.PaymentOptionId.ToString()});
            }

            return RedirectToAction("UserPaymentsOverview", new {id = cardModel.UserId});

        }

        public ActionResult AddBankAccountFor(string userId)
        {
            return AutoForm(new AddBankAccountBindingModel()
            {
                Users = _users.GetAll<UserLookupBindingModel>().ToList(),
                UserId = userId
            }, "AddBankAccountSubmit", "Add Bank Account");
        }

        public ActionResult AddBankAccount(string userId)
        {
            return AutoForm(new AddBankAccountBindingModel()
            {
                Users = _users.GetAll<UserLookupBindingModel>().ToList(),
            }, "AddBankAccountSubmit", "Add Bank Account");
        }

        public async Task<ActionResult> AddBankAccountSubmit(AddBankAccountBindingModel cardModel)
        {
            var res = await _paymentsModule.AddBankAccount(cardModel);
            if (res.ErrorMessage != null)
            {
                AddErrorMessage(res.ErrorMessage);
                return AutoForm(cardModel, "AddBankAccountSubmit", "Add Bank Account");
            }

            if (IsUserMakingPayment)
            {
                return RedirectToAction("PaymentSummaryFor", new {userId = cardModel.UserId, paymentOptionId = res.PaymentOptionId.ToString()});
            }

            return RedirectToAction("UserPaymentsOverview", new {id = cardModel.UserId});
        }

        public ActionResult CreateUserLeaseInfoFor(string id = null)
        {
            return View("CreateUserLeaseInfo", new CreateUserLeaseInfoBindingModel()
            {
                UserId = id,
            });
        }

        [HttpPost]
        public ActionResult SubmitCreateUserLeaseInfo(CreateUserLeaseInfoBindingModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateUserLeaseInfo", data);
            }

            _leaseService.CreateUserLeaseInfo(data);

            return RedirectToAction("UserPaymentsOverview", new {id = data.UserId});
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

        public async Task<ActionResult> ForceRejectTransaction(int id)
        {

            var transaction = _invoiceHistory.Find(id);
            if (transaction == null) return HttpNotFound();
            var user = transaction.User;
            if (user == null) return HttpNotFound();
            var s = await _paymentsModule.ForceRejectTransaction(id);
            return RedirectToAction("UserPaymentsOverview", new {id = user.Id});
        }

        public async Task<ActionResult> ForceCompleteTransaction(int id)
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
                Id = id.ToString(),
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
                if (userLeaseInfo== null) return HttpNotFound("Payment request not found");

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

        public ActionResult UpdateOpenForteTransactions(string id = null)
        {
            _paymentsModule.UpdateOpenForteTransactions();
            this.AddSuccessMessage("System was synchronized with Forte!");
            if (!string.IsNullOrEmpty(id))
            {
                return RedirectToAction("UserPaymentsOverview", new {id = id});
            }
            else
            {
                return RedirectToAction("Index", "PaymentRequests");
            }
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

    }
}