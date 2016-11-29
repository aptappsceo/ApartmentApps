using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Commands;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.ViewModels
{
    public class MaintenancePauseFormViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _appService;
        private IImageService _imageService;
        private string _comments;
        private DateTime _newRepairDate;
        private MaitenanceRequest _request;

        public MaintenancePauseFormViewModel(IApartmentAppsAPIService appService, IImageService imageService)
        {
            _appService = appService;
            _imageService = imageService;
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

        public Action OnDismissed { get; set; }

        public ImageBundleViewModel ImagesToUpload { get; set; } = new ImageBundleViewModel() {Title = "Photos"};

        public ICommand AddPhotoCommand => new MvxCommand(AddPhoto);

        public QRData ScanResult { get; set; }

        public ICommand DoneCommand
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


                    await
                        _appService.Maitenance.PauseRequestWithOperationResponseAsync(MaintenanceRequestId,Comments, new List<string>());
                }).OnStart("Please, wait...").OnComplete("Maintenance Paused!", () =>
                {
                    Close(this);
                    OnDismissed?.Invoke();
                });
            }
        }

        public int MaintenanceRequestId { get; set; }

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

}
