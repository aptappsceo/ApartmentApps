using System;
using System.Collections.Generic;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public class CourtesyService : ICourtesyService
    {
        private IBlobStorageService _blobStorageService;

        public CourtesyService(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }
        public int SubmitIncidentReport(ApplicationUser user, string comments, IncidentType incidentReportTypeId, List<byte[]> images)
        {
            using (var ctx = new ApplicationDbContext())
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
                var localCtxUser = ctx.Users.Find(user.Id);

                ctx.IncidentReports.Add(incidentReport);

                foreach (var image in images)
                {
                    var imageKey = $"{Guid.NewGuid()}.{user.UserName.Replace('@', '_').Replace('.', '_')}".ToLowerInvariant();
                    var filename = _blobStorageService.UploadPhoto(image, imageKey);
                    ctx.ImageReferences.Add(new ImageReference()
                    {
                        GroupId = incidentReport.GroupId,
                        Url = filename,
                        ThumbnailUrl = filename
                    });
                }

                ctx.SaveChanges();
                this.InvokeEvent<IIncidentReportSubmissionEvent>(ctx, localCtxUser, _ => _.IncidentReportSubmited(incidentReport));
                return incidentReport.Id;
            }
        }
        private bool Checkin(ApplicationUser officer, int reportId, string comments, string status, List<byte[]> photos)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var checkin = new IncidentReportCheckin()
                {
                    IncidentReportId = reportId,
                    Comments = comments,
                    StatusId = status,
                    OfficerId = officer.Id,
                    CreatedOn = officer.TimeZone.Now(),
                    GroupId = Guid.NewGuid(),
                    
                };

                ctx.IncidentReportCheckins.Add(checkin);
                if (photos != null)
                foreach (var image in photos)
                {
                    var imageKey = $"{Guid.NewGuid()}.{officer.UserName.Replace('@', '_').Replace('.', '_')}".ToLowerInvariant();
                    var filename = _blobStorageService.UploadPhoto(image, imageKey);
                    ctx.ImageReferences.Add(new ImageReference()
                    {
                        GroupId = checkin.GroupId,
                        Url = filename,
                        ThumbnailUrl = filename
                    });
                }
                ctx.SaveChanges();
                var incidentReport =
                    ctx.IncidentReports.Find(reportId);
                incidentReport.StatusId = status;
                if (status == "Complete")
                {
                    incidentReport.CompletionDate = officer.TimeZone.Now();
                }
                ctx.SaveChanges();
                this.InvokeEvent<IIncidentReportCheckinEvent>(ctx, officer, _ => _.IncidentReportCheckin(checkin, incidentReport));
                return true;
            }
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