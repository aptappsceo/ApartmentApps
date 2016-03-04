using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using Microsoft.Rest;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Events;
using ResidentAppCross.Extensions;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels
{

    public class MaintenanceRequestFormViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _service;
        private IImageService _imageService;
        
        private ObservableCollection<LookupPairModel> _requestTypes =
            new ObservableCollection<LookupPairModel>();

        private ObservableCollection<LookupPairModel> _requestTypesFiltered =
            new ObservableCollection<LookupPairModel>();

        private string _title;
        private LookupPairModel _selectedRequestType;
        private string _comments;
        private string _requestTypeSearchText;

        public MaintenanceRequestFormViewModel(IApartmentAppsAPIService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        public override void Start()
        {
            base.Start();
            UpdateRequestTypes.Execute(null);
        }

        public ObservableCollection<LookupPairModel> RequestTypes
        {
            get { return _requestTypes; }
            set { SetProperty(ref _requestTypes, value); }
        }

        public ObservableCollection<LookupPairModel> RequestTypesFiltered
        {
            get { return _requestTypesFiltered; }
            set { SetProperty(ref _requestTypesFiltered, value); }
        }

        public string Title => "Maintenance Request";

        public ImageBundleViewModel ImagesToUpload { get; set; } = new ImageBundleViewModel() { Title = "Photos?" };

        public LookupPairModel SelectedRequestType
        {
            get { return _selectedRequestType; }
            set { SetProperty(ref _selectedRequestType, value); }
        }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }

        public string RequestTypeSearchText
        {
            get { return _requestTypeSearchText; }
            set
            {
                SetProperty(ref _requestTypeSearchText, value);
                UpdateRequestTypeSearch();
            }
        }

        private void UpdateRequestTypeSearch()
        {
            RequestTypesFiltered.Clear();

            if (string.IsNullOrEmpty(RequestTypeSearchText))
            {
                RequestTypesFiltered.AddRange(RequestTypes);
            }
            else
            {
                RequestTypesFiltered.AddRange(RequestTypes.Where(m => m.Value.ToLowerInvariant().Contains(RequestTypeSearchText.ToLowerInvariant())));
            }
        }


        public void OnRequestTypeSelected(LookupPairModel type)
        {
            SelectedRequestType = type;
        }


        public ICommand UpdateRequestTypeSelection
        {
            get
            {
                return new MvxCommand<LookupPairModel>(type =>
                {
                        SelectedRequestType = type;
                });
            }
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

        public ICommand DoneCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    await _service.Maitenance.SubmitRequestAsync(new MaitenanceRequestModel()
                    {
                        Comments = Comments,
                        MaitenanceRequestTypeId = Convert.ToInt32(SelectedRequestType.Key),
                        Images =
                            ImagesToUpload.RawImages.Select(p => Encoding.UTF8.GetString(p.Data, 0, p.Data.Length))
                                .ToList()
                    });
                }).OnStart("Sending Request...")
                .OnComplete("Request Sent", () => Close(this));
            }
        }

        public ICommand AddPhotoCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _imageService.SelectImage(s =>
                    {
                        ImagesToUpload.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Data = s
                        });
                    }, () => { });
                });
            }
        }

        public ICommand UpdateRequestTypes
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    var operation = await _service.Maitenance.GetMaitenanceRequestTypesWithOperationResponseAsync();
                    var lookupPairModels = operation?.Body?.ToArray();
                    if (lookupPairModels == null || lookupPairModels.Length == 0)
                    {
                        context.FailTask("Failed to load Request Types");
                    }
                    RequestTypes.AddRange(lookupPairModels);
                    SelectedRequestType = RequestTypes.FirstOrDefault();
                    UpdateRequestTypeSearch();
                }).OnStart("Loading Request Types...");
            }
        }
    }
}
