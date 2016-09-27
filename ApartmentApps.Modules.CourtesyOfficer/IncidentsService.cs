using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Modules.CourtesyOfficer;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api
{
    public class IncidentReportFormModel : BaseViewModel
    {

        //[DataType()]
        [DisplayName("Unit")]
        public int UnitId { get; set; }

        public IEnumerable<FormPropertySelectItem> UnitId_Items
        {
            get
            {
                return
                    ModuleHelper.Kernel.Get<IRepository<Unit>>()
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, UnitId == p.Id));


            }
        }


        [DisplayName("Type")]
        [Required]
        public IncidentType ReportType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

    }
    public class IncidentReportFormMapper : BaseMapper<IncidentReport, IncidentReportFormModel>
    {
        private readonly IBlobStorageService _blobStorageService;
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }

        public IncidentReportFormMapper(IMapper<ApplicationUser, UserBindingModel> userMapper,
            IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
            UserMapper = userMapper;
        }

        public override void ToModel(IncidentReportFormModel viewModel, IncidentReport model)
        {
            model.Comments = viewModel.Comments;
            model.IncidentType = viewModel.ReportType;
            model.UnitId = viewModel.UnitId;
        }

        public override void ToViewModel(IncidentReport model, IncidentReportFormModel viewModel)
        {
            viewModel.Comments = model.Comments;
            viewModel.ReportType = model.IncidentType;
            viewModel.UnitId = model.UnitId ?? 0;
            viewModel.Id = model.Id.ToString();

        }
    }
    public class IncidentReportMapper : BaseMapper<IncidentReport, IncidentReportViewModel>
    {
        private readonly IBlobStorageService _blobStorageService;
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }

        public IncidentReportMapper(IMapper<ApplicationUser, UserBindingModel> userMapper,
            IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
            UserMapper = userMapper;
        }

        public override void ToModel(IncidentReportViewModel viewModel, IncidentReport model)
        {
            model.Comments = viewModel.Comments;
            model.StatusId = viewModel.StatusId;
        }

        public override void ToViewModel(IncidentReport model, IncidentReportViewModel viewModel)
        {
            viewModel.Title = model.IncidentType.ToString();
            viewModel.RequestDate = model.CreatedOn;
            viewModel.Comments = model.Comments;
            viewModel.SubmissionBy = UserMapper.ToViewModel(model.User);
            viewModel.StatusId = model.StatusId;
            viewModel.Id = model.Id.ToString();
            viewModel.UnitName = model.Unit?.Name;
            viewModel.BuildingName = model.Unit?.Building?.Name;

            viewModel.LatestCheckin = model.LatestCheckin?.ToIncidentCheckinBindingModel(_blobStorageService);
            viewModel.Checkins = model.Checkins.Select(p => p.ToIncidentCheckinBindingModel(_blobStorageService));
            //viewModel.Title = x.IncidentType.ToString();
            //viewModel.Comments = x.Comments;
            //viewModel.UnitName = x.Unit?.Name;
            //viewModel.BuildingName = x.Unit?.Building?.Name;
            //viewModel.RequestDate = x.CreatedOn;
            //viewModel.SubmissionBy = _userMapper.ToViewModel(x.User);// x.User.ToUserBindingModel(BlobStorageService);
            //viewModel.StatusId = x.StatusId;
            //viewModel.LatestCheckin = x.LatestCheckin?.ToIncidentCheckinBindingModel(_blobStorageService);
            viewModel.Id = model.Id.ToString();

        }
    }
    public class IncidentsService : StandardCrudService<IncidentReport> ,IIncidentsService
    {
        public IncidentsService(IRepository<IncidentReport> repository, IBlobStorageService blobStorageService, PropertyContext context, IMapper<ApplicationUser, UserBindingModel> userMapper, IKernel kernel) : base(kernel, repository)
        {
            _blobStorageService = blobStorageService;
            Context = context;
            UserMapper = userMapper;
        }

        public PropertyContext Context { get; set; }
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; }
        private IBlobStorageService _blobStorageService;


        public int SubmitIncidentReport(ApplicationUser user, string comments, IncidentType incidentReportTypeId, List<byte[]> images, int unitId = 0)
        {

            var incidentReport = new IncidentReport()
            {
                UserId = user.Id,
                Comments = comments,
                IncidentType = incidentReportTypeId,
                StatusId = "Reported",
                CreatedOn = user.TimeZone.Now(),
                GroupId = Guid.NewGuid(),
                UnitId = unitId
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
            Modules.ModuleHelper.EnabledModules.Signal<IIncidentReportSubmissionEvent>(_ => _.IncidentReportSubmited(incidentReport));
            

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
            Modules.ModuleHelper.EnabledModules.Signal<IIncidentReportCheckinEvent>( _ => _.IncidentReportCheckin(checkin, incidentReport));
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