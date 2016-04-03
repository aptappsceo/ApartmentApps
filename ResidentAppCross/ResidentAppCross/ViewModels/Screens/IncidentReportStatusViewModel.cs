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
using MvvmCross.Plugins.Messenger;
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
        private IDialogService _dialogService;

        private string _comments;
        private DateTime _newRepairDate;
        private int _incidentReportId;
        private IncidentReportBindingModel _request;
        private bool _shouldShowPhotos;
        private string _photoSectionTitle;
        private string _selectScheduleDateActionLabel;
        private ObservableCollection<PetStatus> _petStatuses;
        private string _unitAddressString;
        private ObservableCollection<IncidentCheckinBindingModel> _checkins;
        private IncidentCheckinBindingModel _selectedCheckin;

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

        public ObservableCollection<IncidentCheckinBindingModel> Checkins
        {
            get { return _checkins ?? (_checkins = new ObservableCollection<IncidentCheckinBindingModel>()); }
            set { _checkins = value; }
        }

        public IncidentCheckinBindingModel SelectedCheckin
        {
            get { return _selectedCheckin; }
            set { SetProperty(ref _selectedCheckin, value); }
        }

        public string CreatedOnLabel => Request?.CreatedOn?.ToString("g");

        public IncidentReportStatus CurrentMaintenanceRequestStatus
        {
            get
            {
                if (Request == null) return IncidentReportStatus.Reported;
                IncidentReportStatus status;
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

            UnitAddressString = $"Building - {Request?.BuildingName} Unit - {Request?.UnitName}";
            Checkins.Clear();
            Checkins.AddRange(Request.Checkins.OrderByDescending(x => x.Date));
            RaisePropertyChanged(nameof(CreatedOnLabel));
            this.Publish(new IncidentReportStatusUpdated(this));

        }).OnStart("Loading incident details...").OnFail(ex => { Close(this); });


        public bool CanOpen()
        {
            return CurrentMaintenanceRequestStatus == IncidentReportStatus.Reported ||
                         CurrentMaintenanceRequestStatus == IncidentReportStatus.Paused;
        }

        public bool CanPause()
        {
            return CurrentMaintenanceRequestStatus == IncidentReportStatus.Open;
        }

        public bool CanClose()
        {
            return CurrentMaintenanceRequestStatus == IncidentReportStatus.Reported || CurrentMaintenanceRequestStatus == IncidentReportStatus.Open;
        }

        public ICommand CloseIncidentCommand
        {
            get
            {

                return new MvxCommand(() =>
                {
                    ShowViewModel<CheckinFormViewModel>(vm =>
                    {
                        vm.HeaderText = "Incident Report";
                        vm.SubHeaderText = "Close";
                        vm.ActionText = "Close Incident";
                        vm.ShouldScanQr = false;
                        vm.ActionCommand = this.TaskCommand(async context =>
                        {
//                            var data = vm.QRScanResult?.Data;
//                            if (string.IsNullOrEmpty(data))
//                            {
//                                context.FailTask("No QR Code scanned.");
//                                return;
//                            }

                            if (CanClose())
                            {
                                await
                                    _appService.Courtesy.CloseIncidentReportWithOperationResponseAsync(
                                        IncidentReportId,
                                        vm.Comments,
                                        vm.Photos.ImagesAsBase64.ToList());

                                context.OnComplete("Incident closed!",
                                    () =>
                                    {
                                        Close(vm);
                                        UpdateIncidentReport.Execute(null);
                                    });
                            }
                            else
                            {
                                context.FailTask("Incident is already In Progress or Complete.");
                                Close(vm);
                            }

                        }).OnStart("Closing incident...");
                    });
                },CanClose);


            }
        }
        public ICommand PauseIncidentCommmand
        {
            get
            {

                return new MvxCommand(() =>
                {
                    ShowViewModel<CheckinFormViewModel>(vm =>
                    {
                        vm.HeaderText = "Incident Report";
                        vm.SubHeaderText = "Pause";
                        vm.ActionText = "Pause Incident";
                        vm.ShouldScanQr = false;

                        vm.ActionCommand = this.TaskCommand(async context =>
                        {
//                            var data = vm.QRScanResult?.Data;
//                            if (string.IsNullOrEmpty(data))
//                            {
//                                context.FailTask("No QR Code scanned.");
//                                return;
//                            }

                            if (CanPause())
                            {
                                await
                                  _appService.Courtesy.PauseIncidentReportWithOperationResponseAsync(IncidentReportId, vm.Comments, vm.Photos.ImagesAsBase64.ToList());

                                context.OnComplete("Incident paused!",
                                    () =>
                                    {
                                        Close(vm);
                                        UpdateIncidentReport.Execute(null);
                                    });
                            }
                            else
                            {
                                context.FailTask("Incident is not opened yet!");
                                Close(vm);
                            }

                        }).OnStart("Pausing incident...");
                    });
                },CanPause);

            }
        }


        public ICommand OpenIncidentCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<CheckinFormViewModel>(vm =>
                    {
                        vm.HeaderText = "Incident Report";
                        vm.SubHeaderText = "Open";
                        vm.ActionText = "Open Incident";
                        vm.ShouldScanQr = false;

                        vm.ActionCommand = this.TaskCommand(async context =>
                        {
//                            var data = vm.QRScanResult?.Data;
//                            if (string.IsNullOrEmpty(data))
//                            {
//                                context.FailTask("No QR Code scanned.");
//                                return;
//                            }

                            if (CanOpen())
                            {
                                await
                                  _appService.Courtesy.OpenIncidentReportWithOperationResponseAsync(IncidentReportId, vm.Comments, vm.Photos.ImagesAsBase64.ToList());

                                context.OnComplete("Incident Opened!",
                                    () =>
                                    {
                                        Close(vm);
                                        UpdateIncidentReport.Execute(null);
                                    });
                            }
                            else
                            {
                                context.FailTask("Incident is already opened or closed!");
                                Close(vm);
                            }

                        }).OnStart("Opening incident...");
                    });
                }, CanOpen);
            




            }



        }

        public ICommand ShowCheckinDetailsCommand => new MvxCommand(() =>
        {
            if (SelectedCheckin == null) return;
            ShowViewModel<IncidentReportCheckinDetailsViewModel>(vm => vm.Checkin = SelectedCheckin);
        });

        public ICommand SetUnitCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var units = await _appService.Lookups.GetUnitsAsync();
                    var selected = await _dialogService.OpenSearchableTableSelectionDialog(units,"Select Unit", p=>p.Value);
                    await Task.Delay(TimeSpan.FromMilliseconds(300));
                   
                    this.TaskCommand(async context =>
                    {
                        await _appService.Courtesy.AssignUnitToIncidentReportAsync(Request.Id.Value, Convert.ToInt32(selected.Key));
                    })
                    .OnStart("Applying...")
                    .OnComplete("Unit Set!", () => UpdateIncidentReport.Execute(null))
                    .Execute(null);

                });


            }
        }
    }

    public class IncidentReportStatusUpdated : MvxMessage
    {
        public IncidentReportStatusUpdated(object sender) : base(sender)
        {
        }
    }

    public enum IncidentReportStatusDisplayMode
    {
        Status,
        History
    }

    public enum IncidentReportStatus
    {
        Complete,
        Open,
        Paused,
        Reported
    }


}
