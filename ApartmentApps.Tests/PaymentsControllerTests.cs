using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Payments.Data;
using ApartmentApps.Portal.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace ApartmentApps.Tests
{
    [TestClass]
    public class PaymentsControllerTests : PropertyControllerTest<PaymentsController>
    {
        [TestInitialize]
        public override void Init()
        {
            base.Init();
        }

        public API.Service.Controllers.PaymentsController ServiceController { get; set; }

        [TestMethod]
        public void TestOnetimePaymentRequest()
        {

            var userLeaseInfos = Context.Kernel.Get<IRepository<UserLeaseInfo>>();
            var invoices = Context.Kernel.Get<IRepository<Invoice>>();

            //create user lease info
            var userId = Context.UserContext.UserId;
            UserLeaseInfo pRequest;

            var modelData = new CreateUserLeaseInfoBindingModel()
            {
                Amount = 200,
                UserId = Context.UserContext.UserId,
                InvoiceDate = DateTime.Now + TimeSpan.FromDays(10),
                Title = nameof(pRequest),
                UseInterval = false, //one time
                UseCompleteDate = false
            };

            Controller.SubmitCreateUserLeaseInfo(modelData);

            pRequest = userLeaseInfos.GetAll().FirstOrDefault(s=>s.Title == nameof(pRequest));

            //Initial tests for payment request itself
            Assert.IsTrue(pRequest != null);
            Assert.IsTrue(pRequest.Amount == modelData.Amount);
            Assert.IsTrue(pRequest.IntervalMonths == modelData.IntervalMonths);
            Assert.IsTrue(pRequest.NextInvoiceDate == null);
            Assert.IsTrue(pRequest.State == LeaseState.Active);

            var testPaymentRequest1Invoice1 = invoices.GetAll().FirstOrDefault(i=>i.UserLeaseInfoId == pRequest.Id);

            //Initial tests for corresponding invoice
            Assert.IsTrue(testPaymentRequest1Invoice1 != null);
            Assert.IsTrue(testPaymentRequest1Invoice1.Amount == modelData.Amount);
            Assert.IsTrue(testPaymentRequest1Invoice1.Title == modelData.Title);
            Assert.IsTrue(testPaymentRequest1Invoice1.DueDate == modelData.InvoiceDate);
            Assert.IsTrue(testPaymentRequest1Invoice1.State == InvoiceState.NotPaid);
            Assert.IsTrue(testPaymentRequest1Invoice1.IsArchived == false);

            //Test edit payment request


        }

        [TestCleanup]
        public override void DeInit()
        {
            RemoveAll<UserLeaseInfo>();
            RemoveAll<Invoice>();
            RemoveAll<TransactionHistoryItem>();
            base.DeInit();
        }

        public PaymentsController PaymentsController { get; set; }
    }
}
