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
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Extensions;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels
{

    public class MaintenanceRequestViewModel : MvxViewModel
    {

        private IApartmentAppsAPIService _service;
        private IImageService _imageService;

        private ObservableCollection<LookupPairModel> _requestTypes =
            new ObservableCollection<LookupPairModel>();

        private string _title;
        private LookupPairModel _selectedRequestType;
        private string _comments;

        public MaintenanceRequestViewModel(IApartmentAppsAPIService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;

            var maitenanceRequestType = new MaitenanceRequestType()
            {
                Name = "Request Type 1"
            };
            RequestTypes.AddRange(service.Maitenance.GetMaitenanceRequestTypes());
            SelectedRequestType = RequestTypes.FirstOrDefault();
        }

        public override void Start()
        {
            base.Start();
//            _service.Maitenance.GetMaitenanceRequestTypesWithOperationResponseAsync().ContinueWith(t =>
//            {
//                RequestTypes.AddRange(t.Result.Body);
//            });
        }

        public ObservableCollection<LookupPairModel> RequestTypes
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
                return new MvxCommand(async () =>
                {
                    var c = Comments;
                    Comments = "Submitting";
                    var result = await _service.Maitenance.SubmitRequestAsync(new MaitenanceRequestModel()
                    {
                        Comments = c,
                        MaitenanceRequestTypeId = Convert.ToInt32(SelectedRequestType.Key),
                        Images = ImagesToUpload.RawImages.Select(p=>Encoding.UTF8.GetString(p,0,p.Length)).ToList()
                    });
                 
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

        public LookupPairModel SelectedRequestType
        {
            get { return _selectedRequestType; }
            set
            {
                _selectedRequestType = value;
                RaisePropertyChanged();
            }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; RaisePropertyChanged(); }
        }

        public void OnRequestTypeSelected(LookupPairModel type)
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
