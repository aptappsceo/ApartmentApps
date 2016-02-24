using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Commands;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels
{
    public class MaintenancePauseFormViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _appService;
        private IImageService _imageService;
        private string _comments;
        private DateTime _newRepairDate;
        private int _maintenanceRequestId;
        private MaitenanceRequest _request;

        MaintenancePauseFormViewModel(IApartmentAppsAPIService appService, IImageService imageService)
        {
            _appService = appService;
            _imageService = imageService;
        }

        public void Init(int id)
        {
            MaintenanceRequestId = id;
        }

        private Task<MaitenanceRequest> GetMaintenanceRequestById(int id)
        {
            throw new NotImplementedException();
            //TODO: Implement Maintenance Pause Get Maintenance Request By ID
        }

        public int MaintenanceRequestId
        {
            get { return _maintenanceRequestId; }
            set
            {
                SetProperty(ref _maintenanceRequestId, value);
                Task.Run(async () =>
                {
                    Request = await GetMaintenanceRequestById(MaintenanceRequestId);
                });
            }
        }

        public MaitenanceRequest Request
        {
            get { return _request; }
            set { SetProperty(ref _request, value); }
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

        public ImageBundleViewModel ImagesToUpload { get; set; } = new ImageBundleViewModel() {Title = "Photos"};
        public ICommand ApproveCommand => StubCommands.NoActionSpecifiedCommand(this);
        public ICommand DeclineCommand => StubCommands.NoActionSpecifiedCommand(this);
        public ICommand AddPhotoCommand => new MvxCommand(AddPhoto);


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
