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
using ResidentAppCross.ViewModels.Screens;
using ResidentAppCross.ServiceClient;
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
		private LookupPairModel _selectedUnit;
		private string _selectedUnitTitle;
        private string _comments;
        private string _requestTypeSearchText;
        private int? _selectedPetStatus;
        private string _selectRequestTypeActionTitle;
        private bool _entrancePermission = true;
        
		public LookupPairModel SelectedUnit {
        	get{
        		return _selectedUnit;
        	}
        	set{
        		SetProperty(ref _selectedUnit, value, "SelectedUnit");
        	}
        }
         public string SelectedUnitTitle {
        	get{
        		return _selectedUnitTitle ?? "Select Unit...";
        	}
        	set{
        		SetProperty(ref _selectedUnitTitle, value, "SelectedUnitTitle");
        	}
        }
        public bool ShouldSelectUnit => !_loginService.UserInfo.Roles.Contains("Resident");
	public ICommand SetUnitCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var units = await _service.Lookups.GetUnitsAsync();
                    var selected = await _dialogService.OpenSearchableTableSelectionDialog(units,"Select Unit", p=>p.Value);
                    await Task.Delay(TimeSpan.FromMilliseconds(300));
                    SelectedUnit = selected;
		            SelectedUnitTitle = selected.Value; 
                });


            }
        }private ILoginManager _loginService;
        public MaintenanceRequestFormViewModel(IApartmentAppsAPIService service, IImageService imageService, IDialogService dialogService, ILoginManager loginService)
        {
            _service = service;
            _imageService = imageService;
            _dialogService = dialogService;
			_loginService = loginService;
        }

        public string CompanyPhone
            => _loginService?.UserInfo?.PropertyConfig?.ModuleInfo?.CompanySettingsConfig?.PhoneNumber;

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

        public string SelectRequestTypeActionTitle => SelectedRequestType?.Value ?? "Select...";

        public ImageBundleViewModel Photos { get; set; } = new ImageBundleViewModel() { Title = "Photos?" };

        public LookupPairModel SelectedRequestType
        {
            get { return _selectedRequestType; }
            set
            {
                SetProperty(ref _selectedRequestType, value); 
                RaisePropertyChanged("SelectRequestTypeActionTitle");
            }
        }

        public int? SelectedPetStatus
        {
            get { return _selectedPetStatus; }
            set { SetProperty(ref _selectedPetStatus, value); }
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


        IDialogService _dialogService;

        private ObservableCollection<PetStatus> _petStatuses;

        public ICommand SelectRequestTypeCommand
        {
            get
            {
				
				return new MvxCommand<object>(async (p) =>
                {
                    var type =await
                        _dialogService.OpenSearchableTableSelectionDialog(RequestTypes, "Select Request Type",
                            item => item.Value,null, p);


                    SelectedRequestType = type;
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
                    if (SelectedRequestType == null)
                    {
                        context.FailTask("Please, select request type.");
                        return;
                    }
                    if (string.IsNullOrEmpty(Comments))
                    {
                        context.FailTask("Please, fill the comments section.");
                        return;
                    }
                    if (!EntrancePermission && _loginService.UserInfo.Roles.Contains("Resident") && _loginService.UserInfo.Roles.Count == 1)
                    {
                        if ( string.IsNullOrEmpty( CompanyPhone ) )
                        {
                            context.FailTask(
                                "You have not given permission to enter. Please, contact the office to submit your request.");
                        }
                        else
                        {
                            context.FailTask(
                                $"You have not given permission to enter. Please, call { CompanyPhone } to submit your request.");
                        }
                        return;
                    }



                    var images = Photos.RawImages.Select(p =>
                    {
                        return Convert.ToBase64String(p.Data);
                    }).ToList();

                    var maitenanceRequestModel = new MaitenanceRequestModel()
                    {
                        PermissionToEnter = EntrancePermission,
                        PetStatus = SelectedPetStatus,
                        Comments = Comments,
                        MaitenanceRequestTypeId = Convert.ToInt32(SelectedRequestType.Key),
                        Images = images,
						UnitId = ShouldSelectUnit ? (int?)Convert.ToInt32(SelectedUnit.Key) : null,
                    };

                    await _service.Maitenance.SubmitRequestAsync(maitenanceRequestModel);
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
                        Photos.RawImages.Add(new ImageBundleItemViewModel()
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
                    //SelectedRequestType = RequestTypes.FirstOrDefault();
                    UpdateRequestTypeSearch();
                }).OnStart("Loading Request Types...");
            }
        }

        public bool EntrancePermission
        {
            get { return _entrancePermission; }
            set
            {
                SetProperty(ref _entrancePermission,value); 
            }
        }

        public ObservableCollection<PetStatus> PetStatuses
        {
            get
            {
                if (_petStatuses == null)
                {
                    _petStatuses = new ObservableCollection<PetStatus>
                    {
                        new PetStatus() {Title = "No Pet", Id = 0},
                        new PetStatus() {Title = "Yes, Contained", Id = 1},
                        new PetStatus() {Title = "Yes, Free", Id = 2}
                    };
                }
                return _petStatuses;
            }
            set { _petStatuses = value; }
        }
    }
}
