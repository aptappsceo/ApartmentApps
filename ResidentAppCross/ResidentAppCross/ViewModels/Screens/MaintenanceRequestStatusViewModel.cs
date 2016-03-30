using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Commands;
using ResidentAppCross.Extensions;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels.Screens
{
    public class MaintenanceRequestStatusViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _appService;
        private IImageService _imageService;
        private IQRService _qrService;
        private string _comments;
        private DateTime _newRepairDate;
        private int _maintenanceRequestId;
        private MaintenanceBindingModel _request;
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
        private ObservableCollection<MaintenanceCheckinBindingModel> _checkins;
        private MaintenanceCheckinBindingModel _selectedCheckin;

        public MaintenanceRequestStatusViewModel(IApartmentAppsAPIService appService, IImageService imageService, IQRService qrService, IDialogService dialogService)
        {
            _appService = appService;
            _imageService = imageService;
            _qrService = qrService;
            _dialogService = dialogService;
        }

        public int MaintenanceRequestId
        {
            get { return _maintenanceRequestId; }
            set
            {
                SetProperty(ref _maintenanceRequestId, value);
                UpdateMaintenanceRequest.Execute(null); //Start loading maintenance request as soon as id changes
            }
        }

        public MaintenanceBindingModel Request
        {
            get { return _request; }
            set { SetProperty(ref _request, value); }
        }

        public bool ForbidComplete
        {
            get { return _forbidComplete; }
            set { SetProperty(ref _forbidComplete,value); }
        }

        public bool ForbidPause
        {
            get { return _forbidPause; }
            set { SetProperty(ref _forbidPause,value); }
        }

        public bool ForbidStart
        {
            get { return _forbidStart; }
            set { SetProperty(ref _forbidStart,value); }
        }

        public bool ForbitSchedule
        {
            get { return _forbitSchedule; }
            set { SetProperty(ref _forbitSchedule, value); }
        }

        public MaintenanceRequestStatus CurrentMaintenanceRequestStatus
        {
            get
            {
                if(Request ==null) return MaintenanceRequestStatus.Submitted;
                MaintenanceRequestStatus status;
                Enum.TryParse(Request.Status, out status);
                return status;
            }
        }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }

        public string SelectScheduleDateActionLabel
        {
            get { return _selectScheduleDateActionLabel; }
            set { SetProperty(ref _selectScheduleDateActionLabel,value); }
        }

        public DateTime NewRepairDate
        {
            get { return _newRepairDate; }
            set { SetProperty(ref _newRepairDate, value); }
        }

        public QRData ScanResult { get; set; }

        public int SelectedPetStatus
        {
            get
            {
                if (Request?.PetStatus != null)
                {
                    return Request.PetStatus.Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        public string UnitAddressString
        {
            get { return _unitAddressString; }
            set { SetProperty(ref _unitAddressString, value); }
        }

        public ImageBundleViewModel Photos { get; set; } = new ImageBundleViewModel() { Title = "Photos" };

        public ICommand ApproveCommand => StubCommands.NoActionSpecifiedCommand(this);
        public ICommand DeclineCommand => StubCommands.NoActionSpecifiedCommand(this);

        public ICommand UpdateMaintenanceRequest => this.TaskCommand(async context =>
        {
          
                Request = await _appService.Maitenance.GetAsync(MaintenanceRequestId);
                Photos.RawImages.Clear();
                Photos.RawImages.AddRange(Request.Photos.Select(url => new ImageBundleItemViewModel()
                {
                    Uri = new Uri(url)
                }));

                SelectScheduleDateActionLabel = Request?.ScheduleDate?.ToString("g") ?? "Select Date";

                ForbidComplete = CurrentMaintenanceRequestStatus != MaintenanceRequestStatus.Started;
                ForbidPause = CurrentMaintenanceRequestStatus != MaintenanceRequestStatus.Started;
                ForbitSchedule = CurrentMaintenanceRequestStatus == MaintenanceRequestStatus.Complete || CurrentMaintenanceRequestStatus == MaintenanceRequestStatus.Started;
                ForbidStart = CurrentMaintenanceRequestStatus == MaintenanceRequestStatus.Started || CurrentMaintenanceRequestStatus == MaintenanceRequestStatus.Complete;
                Checkins.Clear();
                Checkins.AddRange(Request.Checkins.OrderByDescending(x=>x.Date));
                UnitAddressString = $"{Request?.BuildingName} {Request?.BuildingState} {Request?.BuildingCity} {Request?.BuildingPostalCode}";
            this.Publish(new MaintenanceRequestStatusUpdated(this));

        }).OnStart("Loading Request...").OnFail(ex=> { Close(this); });

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

                            if (CurrentMaintenanceRequestStatus == MaintenanceRequestStatus.Started)
                            {
                                await
                                    _appService.Maitenance.CompleteRequestWithOperationResponseAsync(
                                        MaintenanceRequestId,
                                        vm.Comments,
                                        vm.Photos.ImagesAsBase64.ToList());

                                context.OnComplete("Request Closed!",
                                    () =>
                                    {
                                        Close(vm);
                                        UpdateMaintenanceRequest.Execute(null);
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

                            if (CurrentMaintenanceRequestStatus == MaintenanceRequestStatus.Started)
                            {
                                await
                                  _appService.Maitenance.PauseRequestWithOperationResponseAsync(MaintenanceRequestId, vm.Comments, vm.Photos.ImagesAsBase64.ToList());

                                context.OnComplete("Request Paused!",
                                    () =>
                                    {
                                        Close(vm);
                                        UpdateMaintenanceRequest.Execute(null);
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

                        if (CurrentMaintenanceRequestStatus == MaintenanceRequestStatus.Submitted || CurrentMaintenanceRequestStatus == MaintenanceRequestStatus.Scheduled || CurrentMaintenanceRequestStatus == MaintenanceRequestStatus.Paused)
                        {
                            await _appService.Maitenance.StartRequestWithOperationResponseAsync(MaintenanceRequestId, string.Format("Request Started with Data: {0}", data), new List<string>());
                            context.OnComplete(string.Format("Request Started (QR: {0})", data), () =>
                            {
                                UpdateMaintenanceRequest.Execute(null);
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


        public ObservableCollection<PetStatus> PetStatuses
        {
            get
            {
                if (_petStatuses == null)
                {
                    _petStatuses = new ObservableCollection<PetStatus>
                    {
                        new PetStatus() {Title = "No Pet", Id = 0},
                        new PetStatus() {Title = "Yes, Contained", Id = 1},
                        new PetStatus() {Title = "Yes, Free", Id = 2}
                    };
                }
                return _petStatuses;
            }
            set { _petStatuses = value; }
        }

        public ICommand ScheduleMaintenanceCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    var date = (DateTime) context.Argument;
                    await _appService.Maitenance.ScheduleRequestWithOperationResponseAsync(MaintenanceRequestId, date);
                }).OnStart("Scheduling...").OnComplete("Maintenance Scheduled!",()=>UpdateMaintenanceRequest.Execute(null));
            }
        }

        public ICommand ScheduleCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var date = await _dialogService.OpenDateTimeDialog("hello");
                    if (!date.HasValue) return;
                    this.TaskCommand(async context =>
                    {
                        await _appService.Maitenance.ScheduleRequestWithOperationResponseAsync(MaintenanceRequestId, date.Value);
                    })
                    .OnStart("Scheduling...")
                    .OnComplete("Maintenance Scheduled!", () => UpdateMaintenanceRequest.Execute(null))
                    .Execute(null);

                });


            }
        }

        public ObservableCollection<MaintenanceCheckinBindingModel> Checkins
        {
            get { return _checkins ?? (_checkins = new ObservableCollection<MaintenanceCheckinBindingModel>()); }
            set { _checkins = value; }
        }

        public MaintenanceCheckinBindingModel SelectedCheckin
        {
            get { return _selectedCheckin; }
            set { SetProperty(ref _selectedCheckin, value); }
        }

        public ICommand ShowCheckinDetailsCommand => new MvxCommand(() =>
        {
            if (SelectedCheckin != null) ShowViewModel<MaintenanceCheckinDetailsViewModel>(vm => vm.Checkin = SelectedCheckin);
        });
    }

    public class PetStatus
    {
        public string Title { get; set; }
        public int Id { get; set; }
    }

    public class MaintenanceRequestStatusUpdated : MvxMessage
    {
        public MaintenanceRequestStatusUpdated(object sender) : base(sender)
        {
        }
    }

    public enum MaintenanceRequestStatusDisplayMode
    {
        Status,
        History
    }

    public enum MaintenanceRequestStatus
    {
        Complete,
        Paused,
        Scheduled,
        Started,
        Submitted
    }
}
