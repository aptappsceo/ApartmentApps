using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Commands;
using ResidentAppCross.Extensions;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels.Screens
{
    public class IncidentReportStatusViewModel : ViewModelBase
    {
   
        private IApartmentAppsAPIService _appService;
        private IImageService _imageService;
        private IQRService _qrService;
        private string _comments;
        private DateTime _newRepairDate;
        private int _incidentReportId;
        private IncidentReportBindingModel _request;
        private bool _shouldShowPhotos;
        private string _photoSectionTitle;
        private bool _forbidComplete;
        private bool _forbidPause;
        private bool _forbidStart;
        private bool _forbitSchedule;
        private string _selectScheduleDateActionLabel;
        private ObservableCollection<PetStatus> _petStatuses;
        private string _unitAddressString;
        private IDialogService _dialogService;
        public IncidentReportStatusViewModel(IApartmentAppsAPIService appService, IImageService imageService, IQRService qrService, IDialogService dialogService)
        {
            _appService = appService;
            _imageService = imageService;
            _qrService = qrService;
            _dialogService = dialogService;
        }

        public int IncidentReportId
        {
            get { return _incidentReportId; }
            set
            {
                SetProperty(ref _incidentReportId, value);
                UpdateIncidentReport.Execute(null); //Start loading maintenance request as soon as id changes
            }
        }

        public IncidentReportBindingModel Request
        {
            get { return _request; }
            set { SetProperty(ref _request, value); }
        }

        public bool ForbidComplete
        {
            get { return _forbidComplete; }
            set { SetProperty(ref _forbidComplete, value); }
        }

        public bool ForbidPause
        {
            get { return _forbidPause; }
            set { SetProperty(ref _forbidPause, value); }
        }

        public bool ForbidStart
        {
            get { return _forbidStart; }
            set { SetProperty(ref _forbidStart, value); }
        }

        public bool ForbitSchedule
        {
            get { return _forbitSchedule; }
            set { SetProperty(ref _forbitSchedule, value); }
        }

        public RequestStatus CurrentRequestStatus
        {
            get
            {
                if (Request == null) return RequestStatus.Submitted;
                RequestStatus status;
                Enum.TryParse(Request.Status, out status);
                return status;
            }
        }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }



        public string UnitAddressString
        {
            get { return _unitAddressString; }
            set { SetProperty(ref _unitAddressString, value); }
        }

        public ImageBundleViewModel Photos { get; set; } = new ImageBundleViewModel() { Title = "Photos" };

        public ICommand UpdateIncidentReport => this.TaskCommand(async context =>
        {

            Request = await _appService.Courtesy.GetAsync(IncidentReportId);
            Photos.RawImages.Clear();
            Photos.RawImages.AddRange(Request.Photos.Select(url => new ImageBundleItemViewModel()
            {
                Uri = new Uri(url)
            }));

           

            ForbidComplete = CurrentRequestStatus != RequestStatus.Started;
            ForbidPause = CurrentRequestStatus != RequestStatus.Started;
            ForbitSchedule = CurrentRequestStatus == RequestStatus.Complete || CurrentRequestStatus == RequestStatus.Started;
            ForbidStart = CurrentRequestStatus == RequestStatus.Started || CurrentRequestStatus == RequestStatus.Complete;

            UnitAddressString = $"Building - {Request?.BuildingName} Unit - {Request?.UnitName}";


        }).OnStart("Loading Request...").OnFail(ex => { Close(this); });

        public ICommand FinishCommmand
        {
            get
            {

                return new MvxCommand(() =>
                {
                    ShowViewModel<CheckinFormViewModel>(vm =>
                    {
                        vm.HeaderText = "Maintenance";
                        vm.SubHeaderText = "Finish";
                        vm.ActionText = "Finish Maintenance";
                        vm.ShouldScanQr = true;
                        vm.ActionCommand = this.TaskCommand(async context =>
                        {
                            var data = vm.QRScanResult?.Data;
                            if (string.IsNullOrEmpty(data))
                            {
                                context.FailTask("No QR Code scanned.");
                                return;
                            }

                            if (CurrentRequestStatus == RequestStatus.Started)
                            {
                                await
                                    _appService.Courtesy.CloseIncidentReportWithOperationResponseAsync(
                                        IncidentReportId,
                                        vm.Comments,
                                        vm.Photos.ImagesAsBase64.ToList());

                                context.OnComplete("Report Closed!",
                                    () =>
                                    {
                                        Close(vm);
                                        UpdateIncidentReport.Execute(null);
                                    });
                            }
                            else
                            {
                                context.FailTask("Request is already In Progress or Complete.");
                                Close(vm);
                            }

                        }).OnStart("Closing Request...");
                    });
                });


            }
        }
        public ICommand PauseCommmand
        {
            get
            {

                return new MvxCommand(() =>
                {
                    ShowViewModel<CheckinFormViewModel>(vm =>
                    {
                        vm.HeaderText = "Maintenance";
                        vm.SubHeaderText = "Pause";
                        vm.ActionText = "Pause Maintenance";
                        vm.ShouldScanQr = true;

                        vm.ActionCommand = this.TaskCommand(async context =>
                        {
                            var data = vm.QRScanResult?.Data;
                            if (string.IsNullOrEmpty(data))
                            {
                                context.FailTask("No QR Code scanned.");
                                return;
                            }

                            if (CurrentRequestStatus == RequestStatus.Started)
                            {
                                await
                                  _appService.Courtesy.PauseIncidentReportWithOperationResponseAsync(IncidentReportId, vm.Comments, vm.Photos.ImagesAsBase64.ToList());

                                context.OnComplete("Request Paused!",
                                    () =>
                                    {
                                        Close(vm);
                                        UpdateIncidentReport.Execute(null);
                                    });
                            }
                            else
                            {
                                context.FailTask("Request is not started yet!");
                                Close(vm);
                            }

                        }).OnStart("Pausing Request...");
                    });
                });

            }
        }

        public ICommand ScanAndStartCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var qr = await _qrService.ScanAsync();

                    var data = qr?.Data;

                    this.TaskCommand(async context =>
                    {

                        if (string.IsNullOrEmpty(data))
                        {
                            context.FailTask("No QR Code scanned.");
                            return;
                        }

                        if (CurrentRequestStatus == RequestStatus.Submitted || CurrentRequestStatus == RequestStatus.Scheduled || CurrentRequestStatus == RequestStatus.Paused)
                        {
                            await _appService.Courtesy.OpenIncidentReportWithOperationResponseAsync(IncidentReportId, string.Format("Request Started with Data: {0}", data), new List<string>());
                            context.OnComplete(string.Format("Request Started (QR: {0})", data), () =>
                            {
                                UpdateIncidentReport.Execute(null);
                            });
                        }
                        else
                        {
                            context.FailTask("Request is already In Progress or Complete.");
                        }
                    }).OnStart("Starting...").Execute(null);

                });
            }
        }

   

    }
    public enum IncidentRequestStatus
    {
        Reported,
        Open,
        Paused,
        Started,
        Submitted
    }
}
