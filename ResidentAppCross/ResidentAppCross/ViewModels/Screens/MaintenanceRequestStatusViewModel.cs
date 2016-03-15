using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class MaintenanceRequestStatusViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _appService;
        private IImageService _imageService;
        private IQRService _qrService;
        private string _comments;
        private DateTime _newRepairDate;
        private int _maintenanceRequestId;
        private MaintenanceBindingModel _request;

        public MaintenanceRequestStatusViewModel(IApartmentAppsAPIService appService, IImageService imageService, IQRService qrService)
        {
            _appService = appService;
            _imageService = imageService;
            _qrService = qrService;
        }

        private Task<MaintenanceBindingModel> GetMaintenanceRequestById(int id)
        {
            return _appService.Maitenance.GetAsync(MaintenanceRequestId);
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
            set
            {
                SetProperty(ref _request, value); 
                RaisePropertyChanged("SelectScheduleDateActionLabel");
            }
        }

        public RequestStatus CurrentRequestStatus
        {
            get
            {
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

        public string SelectScheduleDateActionLabel => Request?.ScheduleDate?.ToString("g") ?? "Select Date";

        public DateTime NewRepairDate
        {
            get { return _newRepairDate; }
            set { SetProperty(ref _newRepairDate, value); }
        }

        public ImageBundleViewModel Photos { get; set; } = new ImageBundleViewModel() { Title = "Photos" };

        public ICommand ApproveCommand => StubCommands.NoActionSpecifiedCommand(this);
        public ICommand DeclineCommand => StubCommands.NoActionSpecifiedCommand(this);

        public ICommand UpdateMaintenanceRequest => this.TaskCommand(async context =>
        {
            try
            {
                Request = await _appService.Maitenance.GetAsync(MaintenanceRequestId);
                Photos.RawImages.AddRange(Request.Photos.Select(url => new ImageBundleItemViewModel()
                {
                    Uri = new Uri(url)
                }));
                Debug.WriteLine("Images loaded");
            }
            catch (Exception ex)
            {
                //TODO: Fix it here.
            }
        }).OnStart("Loading Request...").OnFail(ex=> { Close(this); });

        public ICommand ScanBarCodeCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    ScanResult = await _qrService.ScanAsync();
                    StartOrResumeCommand.Execute(null);
                });
            }
        }

        public ICommand FinishCommmand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    var data = ScanResult?.Data;
                    if (string.IsNullOrEmpty(data))
                    {
                        this.FailTaskWithPrompt("No QR Code scanned.");
                        return;
                    }

                    if (CurrentRequestStatus == RequestStatus.Started)
                    {
                        await _appService.Maitenance.CompleteRequestWithOperationResponseAsync(MaintenanceRequestId, string.Format("Request Paused with Data: {0}", ScanResult?.Data), new List<string>());
                        context.OnComplete(string.Format("Request Finished (QR: {0})", ScanResult?.Data),()=>UpdateMaintenanceRequest.Execute(null));
                    }
                    else
                    {
                        context.FailTask("Request is already In Progress or Complete.");
                    }
                }).OnStart("Updating Request...");
            }
        }
        public ICommand PauseCommmand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<MaintenancePauseFormViewModel>(vm =>
                    {
                        vm.MaintenanceRequestId = MaintenanceRequestId;
                        vm.OnDismissed = () => UpdateMaintenanceRequest.Execute(null);
                    });
                });
            }
        }

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

        public ICommand StartOrResumeCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    var data = ScanResult?.Data;
                    if (string.IsNullOrEmpty(data))
                    {
                        this.FailTaskWithPrompt("No QR Code scanned.");
                        return;
                    }

                    if (CurrentRequestStatus == RequestStatus.Submitted ||
                        CurrentRequestStatus == RequestStatus.Scheduled ||
                        CurrentRequestStatus == RequestStatus.Paused)
                    {
                        await _appService.Maitenance.StartRequestWithOperationResponseAsync(MaintenanceRequestId, string.Format("Request Started with Data: {0}", ScanResult?.Data), new List<string>());
                        context.OnComplete(string.Format("Request Started (QR: {0})", ScanResult?.Data), () =>
                        {
                            UpdateMaintenanceRequest.Execute(null);
                        });
                    }
                    else
                    {
                       context.FailTask("Request is already In Progress or Complete.");
                    }
                }).OnStart("Updating Request...");
            }
        }

        public QRData ScanResult { get; set; }

        public ICommand ScheduleMaintenanceCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    var date = (DateTime) context.Argument;

                    await
                        _appService.Maitenance.ScheduleRequestWithOperationResponseAsync(MaintenanceRequestId, date);

                }).OnStart("Scheduling...").OnComplete("Maintenance Scheduled!",()=>UpdateMaintenanceRequest.Execute(null));
            }
        }

        private void AddPhoto()
        {
            _imageService.SelectImage(s =>
            {
                Photos.RawImages.Add(new ImageBundleItemViewModel()
                {
                    Data = s
                });
            }, () => { });
        }



    }

    public enum RequestStatus
    {
        Complete,
        Paused,
        Scheduled,
        Started,
        Submitted
    }
}
