using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    [Authorize]
    public class PaymentsController : AAController
    {
        private readonly PaymentsModule _paymentsModule;
        // GET: Payments
        public ActionResult Index()
        {
            if (User.IsInRole("Resident") && CurrentUser.UnitId != null)
            {
                return RedirectToAction("RentSummary");
            }
            return View("RentSummary"); // TODO Redirect to other pages for property manager
        }

        public PaymentsController(PaymentsModule paymentsModule, IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            _paymentsModule = paymentsModule;
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
        public async Task<ActionResult> AddBankAccountSubmit(AddBankAccountBindingModel cardModel)
        {
            await _paymentsModule.AddBankAccount(cardModel);
            return RedirectToAction("MakePayment");
        }
    }
}