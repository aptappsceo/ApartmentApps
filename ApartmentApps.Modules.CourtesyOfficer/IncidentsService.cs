using System;
using System.Collections.Generic;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Korzh.EasyQuery.Db;
using Ninject;

namespace ApartmentApps.Api
{
    public class IncidentsService : StandardCrudService<IncidentReport>, IIncidentsService
    {
        public IncidentsService(IModuleHelper moduleHelper, IRepository<IncidentReport> repository, IBlobStorageService blobStorageService, PropertyContext context, IMapper<ApplicationUser, UserBindingModel> userMapper, IKernel kernel) : base(kernel, repository)
        {
            _moduleHelper = moduleHelper;
            _blobStorageService = blobStorageService;
            Context = context;
            UserMapper = userMapper;
        }

        public PropertyContext Context { get; set; }
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; }
        private readonly IModuleHelper _moduleHelper;
        private IBlobStorageService _blobStorageService;

        public DbQuery Reported()
        {
            return CreateQuery("Reported", new ConditionItem("IncidentReport.StatusId", "Equal", "Reported"));
        }
        public DbQuery Open()
        {
            return CreateQuery("Open", new ConditionItem("IncidentReport.StatusId", "Equal", "Open"));
        }
        public DbQuery Paused()
        {
            return CreateQuery("Paused", new ConditionItem("IncidentReport.StatusId", "Equal", "Paused"));
        }
        public DbQuery Complete()
        {
            return CreateQuery("Complete", new ConditionItem("IncidentReport.StatusId", "Equal", "Complete"), new ConditionItem("IncidentReport.CompletionDate", "DateWithinThisMonth"));
        }
        public int SubmitIncidentReport(ApplicationUser user, string comments, IncidentType incidentReportTypeId, List<byte[]> images, int? unitId = null)
        {

            var incidentReport = new IncidentReport()
            {
                UserId = user.Id,
                Comments = comments,
                IncidentType = incidentReportTypeId,
                StatusId = "Reported",
                CreatedOn = user.TimeZone.Now(),
                GroupId = Guid.NewGuid(),
                UnitId = unitId ?? user.UnitId
            };


            Context.IncidentReports.Add(incidentReport);
            if (images != null)
                foreach (var image in images)
                {
                    var imageKey = $"{Guid.NewGuid()}.{user.UserName.Replace('@', '_').Replace('.', '_')}".ToLowerInvariant();
                    var filename = _blobStorageService.UploadPhoto(image, imageKey);
                    Context.ImageReferences.Add(new ImageReference()
                    {
                        GroupId = incidentReport.GroupId,
                        Url = filename,
                        ThumbnailUrl = filename
                    });
                }

            Context.SaveChanges();

            Checkin(user, incidentReport.Id, incidentReport.Comments, incidentReport.StatusId, null,
              incidentReport.GroupId);
            _moduleHelper.SignalToEnabled<IIncidentReportSubmissionEvent>(_ => _.IncidentReportSubmited(incidentReport));


            return incidentReport.Id;

        }

        private bool Checkin(ApplicationUser officer, int reportId, string comments, string status, List<byte[]> photos, Guid? groupId = null)
        {

            var checkin = new IncidentReportCheckin()
            {
                IncidentReportId = reportId,
                Comments = comments,
                StatusId = status,
                OfficerId = officer.Id,
                CreatedOn = officer.TimeZone.Now(),
                GroupId = groupId ?? Guid.NewGuid(),

            };

            Context.IncidentReportCheckins.Add(checkin);
            if (photos != null && groupId == null)
                foreach (var image in photos)
                {
                    var imageKey = $"{Guid.NewGuid()}.{officer.UserName.Replace('@', '_').Replace('.', '_')}".ToLowerInvariant();
                    var filename = _blobStorageService.UploadPhoto(image, imageKey);
                    Context.ImageReferences.Add(new ImageReference()
                    {
                        GroupId = checkin.GroupId,
                        Url = filename,
                        ThumbnailUrl = filename
                    });
                }
            Context.SaveChanges();
            var incidentReport =
                Context.IncidentReports.Find(reportId);
            incidentReport.StatusId = status;
            if (status == "Complete")
            {
                incidentReport.CompletionDate = officer.TimeZone.Now();
            }
            Context.SaveChanges();
            _moduleHelper.SignalToEnabled<IIncidentReportCheckinEvent>(_ => _.IncidentReportCheckin(checkin, incidentReport));
            return true;

        }
        public bool OpenIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos)
        {
            return Checkin(user, incidentReportId, comments, "Open", photos);
        }

        public bool PauseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos)
        {
            return Checkin(user, incidentReportId, comments, "Paused", photos);
        }

        public bool CloseIncidentReport(ApplicationUser user, int incidentReportId, string comments, List<byte[]> photos)
        {
            return Checkin(user, incidentReportId, comments, "Complete", photos);
        }


    }
}