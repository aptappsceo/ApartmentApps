using System;
using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.API.Service.Controllers;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using MaitenanceRequestModel = ApartmentApps.Portal.Controllers.MaitenanceRequestModel;

namespace ApartmentApps.Tests
{


    [TestClass]
    public class MaitenanceRequestsControllerTests : PropertyControllerTest<MaitenanceRequestsController>
    {
        [TestInitialize]
        public override void Init()
        {
            base.Init();
            Context.Kernel.Bind<ApartmentApps.API.Service.Controllers.MaitenanceController>().ToSelf();
            ApiController = Context.Kernel.Get<API.Service.Controllers.MaitenanceController>();
        }

        public MaitenanceController ApiController { get; set; }

        [TestMethod]
        public void TestApi()
        {

            SubmitMaintenanceRequest();
            var result = Context.Kernel.Get<MaintenanceService>().GetAll<MaintenanceRequestViewModel>().FirstOrDefault();
            var apiResult = ApiController.Get(Convert.ToInt32(result.Id));
            
        }

        [TestMethod]
        public void TestProcess()
        {

            SubmitMaintenanceRequest();

            var result = Context.Kernel.Get<MaintenanceService>().GetAll<MaintenanceRequestViewModel>().FirstOrDefault();
            Assert.IsNotNull(result, "Maintenance Request Create Not Working");

            Controller.StartRequest(new MaintenanceStatusRequestModel()
            {
                Id = Convert.ToInt32(result.Id),
                Comments = "Test Pause"
            });
            result = Context.Kernel.Get<MaintenanceService>().GetAll<MaintenanceRequestViewModel>().FirstOrDefault();
            Assert.IsTrue(result != null && result.StatusId == "Started");

            Controller.PauseRequest(new MaintenanceStatusRequestModel()
            {
                Id = Convert.ToInt32(result.Id),
                Comments = "Test Pause"
            });
            result = Context.Kernel.Get<MaintenanceService>().GetAll<MaintenanceRequestViewModel>().FirstOrDefault();
            Assert.IsTrue(result != null && result.StatusId == "Paused");

            Controller.StartRequest(new MaintenanceStatusRequestModel()
            {
                Id = Convert.ToInt32(result.Id),
                Comments = "Restarting"
            });
            result = Context.Kernel.Get<MaintenanceService>().GetAll<MaintenanceRequestViewModel>().FirstOrDefault();
            Assert.IsTrue(result != null && result.StatusId == "Started");

            Controller.CompleteRequest(new MaintenanceStatusRequestModel()
            {
                Id = Convert.ToInt32(result.Id),
                Comments = "Complete"
            });
            result = Context.Kernel.Get<MaintenanceService>().GetAll<MaintenanceRequestViewModel>().FirstOrDefault();
            Assert.IsTrue(result != null && result.StatusId == "Complete");

            
        }

        [TestMethod]
        public void TestAssign()
        {
            SubmitMaintenanceRequest();
            var result = Context.Kernel.Get<MaintenanceService>().GetAll<MaintenanceRequestViewModel>().FirstOrDefault();
            Assert.IsNotNull(result, "Maintenance Request Create Not Working");
            Controller.AssignRequestSubmit(
                new AssignMaintenanceEditModel()
                {
                    Id = result.Id,
                    AssignedToId = Context.UserContext.UserId
                });
            result = Context.Kernel.Get<MaintenanceService>().GetAll<MaintenanceRequestViewModel>().FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(Context.UserContext.UserId, result.AssignedToId);
            // Submit another request to test the list
            SubmitMaintenanceRequest();

            var config = Context.Kernel.Get<ConfigProvider<MaintenanceConfig>>().Config;
            config.SupervisorMode = true;
            var controllerRequestList = ApiController.ListRequests();
            Assert.AreEqual(2,controllerRequestList.Count());
            config.SupervisorMode = false;
            controllerRequestList = ApiController.ListRequests();
           // Assert.AreEqual(2,controllerRequestList.Count());
        }

        private void SubmitMaintenanceRequest()
        {
            var editModel = Context.Kernel.Get<MaitenanceRequestModel>();// new MaitenanceRequestModel()
            {
                editModel.Comments = "Here is my new maintenance request";
            };
            editModel.MaitenanceRequestTypeId = Convert.ToInt32(editModel.MaitenanceRequestTypeId_Items.First().Id);
            editModel.UnitId = Convert.ToInt32(editModel.UnitId_Items.First().Id);
            editModel.PermissionToEnter = true;

            editModel.PetStatus = PetStatus.YesContained;
            Controller.SubmitRequest(editModel);
        }

        [TestCleanup]
        public override void DeInit()
        {
            RemoveAll<MaintenanceRequestCheckin>();
            RemoveAll<MaitenanceRequest>();
            base.DeInit();
        }
    }
}