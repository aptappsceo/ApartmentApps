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
            set { SetProperty(ref _request, value); }
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

        public DateTime NewRepairDate
        {
            get { return _newRepairDate; }
            set { SetProperty(ref _newRepairDate, value); }
        }

        public ImageBundleViewModel ImagesToUpload { get; set; } = new ImageBundleViewModel() { Title = "Photos" };
        public ICommand ApproveCommand => StubCommands.NoActionSpecifiedCommand(this);
        public ICommand DeclineCommand => StubCommands.NoActionSpecifiedCommand(this);
        public ICommand AddPhotoCommand => new MvxCommand(AddPhoto);

        public ICommand UpdateMaintenanceRequest => this.TaskCommand(async context =>
        {
            try
            {
                Request = await _appService.Maitenance.GetAsync(MaintenanceRequestId);
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
                        context.OnComplete(string.Format("Request Started: {0}", ScanResult?.Data));
                    }
                    else
                    {
                       context.FailTask("Request is already In Progress or Complete.");
                    }
                }).OnStart("Updating Request...");
            }
        }

        public QRData ScanResult { get; set; }

        private void AddPhoto()
        {
            _imageService.SelectImage(s =>
            {
                ImagesToUpload.RawImages.Add(new ImageBundleItemViewModel()
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
