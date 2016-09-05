using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
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

        public PaymentsController(IBlobStorageService blobStorageService, PaymentsModule paymentsModule, IRepository<UserLeaseInfo> leaseInfos, IRepository<Invoice> invoices  ,IKernel kernel, PropertyContext context, IUserContext userContext, IRepository<InvoiceTransaction> transactions, LeaseInfoManagementService leaseService) : base(kernel, context, userContext)
        {
            _blobStorageService = blobStorageService;
            _paymentsModule = paymentsModule;
            _leaseInfos = leaseInfos;
            _invoices = invoices;
            _transactions = transactions;
            _leaseService = leaseService;
        }

        public ActionResult RentSummary()
        {
            ViewBag.NextAction = Url.Action("PaymentOptions");
            return View("RentSummary", _paymentsModule.GetRentSummary(CurrentUser.Id).Result);
        }

        public ActionResult PaymentOptions()
        {
            return View("PaymentOptions", _paymentsModule.GetPaymentOptions());
        }

        public ActionResult MakePayment()
        {
            return AutoForm(new MakePaymentBindingModel(), "MakePaymentSubmit", "Make Payment");
        }

        [HttpPost]
        public ActionResult MakePaymentSubmit(MakePaymentBindingModel model)
        {
           
            return View("PaymentSuccess", _paymentsModule.MakePayment(model).Result);
        }


       
        public string PaymentOptionId
        {
            get
            {

                return Session["PaymentOptionId"] as string;
            }
            set
            {
                Session["PaymentOptionId"] = value;
            }
        }
        public ActionResult PaymentSummary(string paymentOptionId)
        {
            PaymentOptionId = paymentOptionId;
            ViewBag.NextAction = Url.Action("MakePayment");
            return View("RentSummary", _paymentsModule.GetPaymentSummary(CurrentUser.Id).Result);
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
            return View("CreateUserLeaseInfo",new CreateUserLeaseInfoBindingModel()
            {
                UserIdItems = Context.Users.GetAll().Where(u=>!u.Archived).ToList().Select(u=>u.ToUserBindingModel(_blobStorageService)).Where(u=>!string.IsNullOrWhiteSpace(u.FullName)).ToList(),
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
                 return View("CreateUserLeaseInfo",data);
            }

            _leaseService.CreateUserLeaseInfo(data);

            return RedirectToAction("UserPaymentsOverview", new { id = data.UserId });
        }

        public ActionResult UserPaymentsOverview(string id)
        {
            var user = Context.Users.Find(id);
            if (user == null) return HttpNotFound();

            var userLeaseInfos = _leaseInfos.GetAll().Where(s => s.UserId == id).ToList();
            var transactions = _transactions.GetAll().Where(s => s.UserId == id).ToList();
            var userLeaseInfosIds = userLeaseInfos.Select(s => s.Id).ToArray();
            
            return View("UserPaymentsOverview",new UserPaymentsOverviewBindingModel()
            {
                User = user.ToUserBindingModel(_blobStorageService),
                Invoices = _invoices.GetAll().Where(s=> userLeaseInfosIds.Contains(s.UserLeaseInfoId)).ToList().Select(s=>s.ToBindingModel(_blobStorageService)).ToList(),
                LeaseInfos = userLeaseInfos.Select(s=>s.ToBindingModel(_blobStorageService)).ToList(),
                Transactions = transactions.Select(s=>s.ToBindingModel(_blobStorageService)).ToList() 
            });
        }

        public ActionResult MarkAsPaid(int id)
        {
            var invoice = _invoices.Find(id);
            if (invoice == null) return HttpNotFound();
            var user = invoice.UserLeaseInfo.User;
            if (user == null) return HttpNotFound();
            _paymentsModule.MarkAsPaid(id, "Marked as paid by " + CurrentUser.Email);
            

            return RedirectToAction("UserPaymentsOverview", new { id = user.Id });
        }

        public async Task<ActionResult> AddBankAccountSubmit(AddBankAccountBindingModel cardModel)
        {
            await _paymentsModule.AddBankAccount(cardModel);
            return RedirectToAction("MakePayment");
        }

        public ActionResult CreateUserLeaseInfoFor(string id)
        {
            return View("CreateUserLeaseInfo",new CreateUserLeaseInfoBindingModel()
            {
                UserId = id,
                UserIdItems = Context.Users.GetAll().Where(u=>!u.Archived).ToList().Select(u=>u.ToUserBindingModel(_blobStorageService)).Where(u=>!string.IsNullOrWhiteSpace(u.FullName)).ToList(),
            });
        }
    }
}