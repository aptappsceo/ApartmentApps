using System;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using ApartmentApps.Portal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace ApartmentApps.Tests
{
    [TestClass]
    public class MessagingControllerTests : PropertyControllerTest<MessagingController>
    {
        [TestInitialize]
        public override void Init()
        {
            base.Init();
            CampaignTargetsController = Context.Kernel.Get<CampaignTargetsController>();
        }

        public CampaignTargetsController CampaignTargetsController { get; set; }

        [TestMethod]
        public void TestProcess()
        {
            //Context.Kernel.Bind<AccountController>().ToSelf();
            //var accountController = Context.Kernel.Get<AccountController>();
            //Context.Kernel.Bind<UserManagementController>().ToSelf();
            //var userController = Context.Kernel.Get<UserManagementController>();
            //userController.SaveUser(new UserFormModel()
            //{
            //    Email = new 
            //});
        
          
            CreateCampaign();

            var result = Context.Kernel.Get<MessagingService>().GetAll<MessageViewModel>().FirstOrDefault();
            Assert.IsNotNull(result, "Message not created");

            CampaignTargetsController.SelectTargets(Convert.ToInt32(result.Id));
            CampaignTargetsController.ApplyFilter(string.Empty, string.Empty);
            result = Context.Kernel.Get<MessagingService>().GetAll<MessageViewModel>().FirstOrDefault();
            Assert.IsNotNull(result, "Message not found");
            Assert.IsTrue(!string.IsNullOrEmpty(result.TargetsXml));
            Console.Write(result.TargetsDescription);
            Controller.SendMessage(Convert.ToInt32(result.Id));
            result = Context.Kernel.Get<MessagingService>().GetAll<MessageViewModel>().FirstOrDefault();
            Assert.IsNotNull(result, "Message not found");
            Assert.IsTrue(result.DeliverCount > 0,"Delivery Failed");
        }


        private void CreateCampaign()
        {
            var editModel = new MaitenanceRequestModel()
            {
                Comments = "Here is my new maintenance request",
            };
            editModel.MaitenanceRequestTypeId = Convert.ToInt32(editModel.MaitenanceRequestTypeId_Items.First().Id);
            editModel.UnitId = Convert.ToInt32(editModel.UnitId_Items.First().Id);
            editModel.PermissionToEnter = true;

            editModel.PetStatus = PetStatus.YesContained;
            Controller.SaveEntry(new MessageFormViewModel()
            {
                Body = "Unit Test Email Message Please Disregaurd",
                Subject = "Unit Test Email Message Please Disregaurd",
            });

        }

        [TestCleanup]
        public override void DeInit()
        {
            RemoveAll<MessageReceipt>();
            RemoveAll<Message>();
            base.DeInit();
        }
    }
}