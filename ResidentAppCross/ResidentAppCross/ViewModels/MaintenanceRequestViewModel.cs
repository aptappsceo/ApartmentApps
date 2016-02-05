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
using Cirrious.MvvmCross.ViewModels;
using ResidentAppCross.Extensions;

namespace ResidentAppCross.ViewModels
{

    public class MaintenanceRequestViewModel : MvxViewModel
    {

        private IApartmentAppsAPIService _service;

        private ObservableCollection<MaitenanceRequestType> _requestTypes =
            new ObservableCollection<MaitenanceRequestType>();

        private ObservableCollection<MaitenanceRequestType> _photosToUpload = new ObservableCollection<MaitenanceRequestType>();
        private string _title;
        private MaitenanceRequestType _selectedRequestType;

        public MaintenanceRequestViewModel(IApartmentAppsAPIService service)
        {
            _service = service;

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

        public ObservableCollection<MaitenanceRequestType> PhotosToUpload
        {
            get { return _photosToUpload; }
            set
            {
                _photosToUpload = value;
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
                    Debug.WriteLine("Should Send Maintenance Request");
                });
            }
        }

        public ICommand HomeCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Debug.WriteLine("Should Send Maintenance Request");
                });
            }
        }

        public void SelectImage()
        {
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
