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
        private string _comments;
        private DateTime _newRepairDate;
        private int _maintenanceRequestId;
        private MaintenanceBindingModel _request;

        public MaintenanceRequestStatusViewModel(IApartmentAppsAPIService appService, IImageService imageService)
        {
            _appService = appService;
            _imageService = imageService;
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
