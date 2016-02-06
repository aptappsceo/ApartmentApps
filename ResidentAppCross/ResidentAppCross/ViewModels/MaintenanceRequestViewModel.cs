using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using Cirrious.MvvmCross.ViewModels;
using ResidentAppCross.Extensions;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels
{

    public class MaintenanceRequestViewModel : MvxViewModel
    {

        private IApartmentAppsAPIService _service;
        private IImageService _imageService;

        private ObservableCollection<MaitenanceRequestType> _requestTypes =
            new ObservableCollection<MaitenanceRequestType>();

        private string _title;
        private MaitenanceRequestType _selectedRequestType;
        private string _details;

        public MaintenanceRequestViewModel(IApartmentAppsAPIService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;

            var maitenanceRequestType = new MaitenanceRequestType()
            {
                Name = "Request Type 1"
            };
            RequestTypes.Add(maitenanceRequestType);

            RequestTypes.Add(new MaitenanceRequestType()
            {
                Name = "Request Type 2"
            });

            RequestTypes.Add(new MaitenanceRequestType()
            {
                Name = "Request Type 3"
            });

            RequestTypes.Add(new MaitenanceRequestType()
            {
                Name = "Request Type 4"
            });
            SelectedRequestType = maitenanceRequestType;
        }

        public override void Start()
        {
            base.Start();
//            _service.Maitenance.GetMaitenanceRequestTypesWithOperationResponseAsync().ContinueWith(t =>
//            {
//                RequestTypes.AddRange(t.Result.Body);
//            });
        }

        public ObservableCollection<MaitenanceRequestType> RequestTypes
        {
            get { return _requestTypes; }
            set
            {
                _requestTypes = value;
                RaisePropertyChanged();
            }
        }

        public string Title => "Maintenance Request";

        public ICommand DoneCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    //TODO : Implement dialog complete
                    Close(this);
                });
            }
        }

        public ICommand AddPhotoCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _imageService.SelectImage(s=> ImagesToUpload.RawImages.Add(s) , ()=> {});
                });
            }
        }

        public ImageBundleViewModel ImagesToUpload { get; set; } = new ImageBundleViewModel() { Title = "Halo?" };

        public ICommand HomeCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Close(this);
                });
            }
        }

        public MaitenanceRequestType SelectedRequestType
        {
            get { return _selectedRequestType; }
            set
            {
                _selectedRequestType = value;
                RaisePropertyChanged();
            }
        }

        public string Details
        {
            get { return _details; }
            set
            {
                _details = value; 
                RaisePropertyChanged();
            }
        }

        public void OnRequestTypeSelected(MaitenanceRequestType type)
        {
            SelectedRequestType = type;
        }

        public ICommand SelectRequestTypeCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    MaintenanceRequestTypeSelectionViewModel.OnSelect = OnRequestTypeSelected;
                    MaintenanceRequestTypeSelectionViewModel.Options = RequestTypes.ToList();
                    ShowViewModel<MaintenanceRequestTypeSelectionViewModel>();
                });
            }
        }
    }
}
