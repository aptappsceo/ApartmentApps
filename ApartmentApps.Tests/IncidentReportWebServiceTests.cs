using System;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.API.Service.Controllers.Api;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace ApartmentApps.Tests
{
    [TestClass]
    public class IncidentReportWebServiceTests : PropertyControllerTest<ApartmentApps.API.Service.Controllers.Api.InspectionsController>
    {
        [TestInitialize]
        public override void Init()
        {
            base.Init();
            Context.Kernel.Bind<ApartmentApps.API.Service.Controllers.Api.CourtesyController>().ToSelf();
            CourtesyController = Context.Kernel.Get<ApartmentApps.API.Service.Controllers.Api.CourtesyController>();
        }

        public CourtesyController CourtesyController { get; set; }

        [TestMethod]
        public void TestProcess()
        {

            SubmitIncidentReport();
            
            var result = Context.Kernel.Get<IncidentsService>().GetAll<IncidentReportViewModel>().FirstOrDefault();
            Assert.IsNotNull(result, "Incident Create Not Working");
            Assert.IsTrue(result != null && result.StatusId == "Reported");
            //           context.IncidentReportStatuses.AddOrUpdate(
            //    new IncidentReportStatus { Name = "Reported" },
            //    new IncidentReportStatus { Name = "Open" },
            //    new IncidentReportStatus { Name = "Paused" },
            //    new IncidentReportStatus { Name = "Complete" }
            //);
            CourtesyController.OpenIncidentReport(Convert.ToInt32(result.Id),"Opening test incident.", null);
            result = Context.Kernel.Get<IncidentsService>().GetAll<IncidentReportViewModel>().FirstOrDefault();
            Assert.IsTrue(result != null && result.StatusId == "Open");
            CourtesyController.PauseIncidentReport(Convert.ToInt32(result.Id), "Pausing test incident.", null);
            result = Context.Kernel.Get<IncidentsService>().GetAll<IncidentReportViewModel>().FirstOrDefault();
            Assert.IsTrue(result != null && result.StatusId == "Paused");
            CourtesyController.CloseIncidentReport(Convert.ToInt32(result.Id), "Closing test incident.", null);
            result = Context.Kernel.Get<IncidentsService>().GetAll<IncidentReportViewModel>().FirstOrDefault();
            Assert.IsTrue(result != null && result.StatusId == "Complete");
        }

        private void SubmitIncidentReport()
        {
            var editModel = new IncidentReportModel
            {
                Comments = "Here is my new incident report",
                IncidentReportTypeId = IncidentType.Parking,
            };
            CourtesyController.SubmitIncidentReport(editModel);
        }

        [TestCleanup]
        public override void DeInit()
        {
            RemoveAll<IncidentReportCheckin>();
            RemoveAll<IncidentReport>();

            base.DeInit();
        }
    }
}