using System;
using System.Collections.Generic;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api
{
    public class CourtesyService : StandardCrudService<IncidentReport, IncidentIndexBindingModel> ,ICourtesyService
    {
        public PropertyContext Context { get; set; }
        private readonly IMapper<ApplicationUser, UserBindingModel> _userMapper;
        private IBlobStorageService _blobStorageService;

        public CourtesyService(IMapper<ApplicationUser,UserBindingModel> userMapper, IBlobStorageService blobStorageService, PropertyContext context) : base(context.IncidentReports)
        {
            Context = context;
            _userMapper = userMapper;
            _blobStorageService = blobStorageService;
        }

        public int SubmitIncidentReport(ApplicationUser user, string comments, IncidentType incidentReportTypeId, List<byte[]> images)
        {

            var incidentReport = new IncidentReport()
            {
                UserId = user.Id,
                Comments = comments,
                IncidentType = incidentReportTypeId,
                StatusId = "Reported",
                CreatedOn = user.TimeZone.Now(),
                GroupId = Guid.NewGuid()
            };
           

            Context.IncidentReports.Add(incidentReport);

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

            this.InvokeEvent<IIncidentReportSubmissionEvent>( _ => _.IncidentReportSubmited(incidentReport));

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
            this.InvokeEvent<IIncidentReportCheckinEvent>( _ => _.IncidentReportCheckin(checkin, incidentReport));
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

        public override void ToModel(IncidentIndexBindingModel viewModel, IncidentReport model)
        {
            model.Comments = viewModel.Comments;
            model.StatusId = viewModel.StatusId;
        }

        public override void ToViewModel(IncidentReport x, IncidentIndexBindingModel viewModel)
        {

            viewModel.Title = x.IncidentType.ToString();
            viewModel.Comments = x.Comments;
            viewModel.UnitName = x.Unit?.Name;
            viewModel.BuildingName = x.Unit?.Building?.Name;
            viewModel.RequestDate = x.CreatedOn;
            viewModel.ReportedBy = _userMapper.ToViewModel(x.User);// x.User.ToUserBindingModel(BlobStorageService);
            viewModel.StatusId = x.StatusId;
            viewModel.LatestCheckin = x.LatestCheckin?.ToIncidentCheckinBindingModel(_blobStorageService);
            viewModel.Id = x.Id;

        }
    }
}