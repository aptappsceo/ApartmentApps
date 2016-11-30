using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Commands;
using ResidentAppCross.Resources;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross
{
    public class HomeMenuViewModel : ViewModelBase
    {
        private readonly ILoginManager _loginManager;
        private readonly IImageService _imageService;
        private readonly IDialogService _dialogService;
        public IApartmentAppsAPIService Data { get; set; }

        public HomeMenuViewModel(IApartmentAppsAPIService data, ILoginManager loginManager, IImageService imageService,
            IDialogService dialogService)
        {
            _loginManager = loginManager;
            _imageService = imageService;
            _dialogService = dialogService;
            Data = data;

            UpdateMenuItems();
        }

        public void UpdateMenuItems()
        {
            MenuItems.Clear();

            var courtesyEnabled = _loginManager.UserInfo?.PropertyConfig?.ModuleInfo?.CourtesyConfig?.Enabled ?? false;
            var maintenanceEnabled = _loginManager.UserInfo?.PropertyConfig?.ModuleInfo?.MaintenanceConfig?.Enabled ?? false;
            var messagingEnabled = _loginManager.UserInfo?.PropertyConfig?.ModuleInfo?.MessagingConfig?.Enabled ?? false;
			var prospectEnabled = _loginManager.UserInfo?.PropertyConfig?.ModuleInfo?.ProspectConfig?.Enabled ?? false;

            if (_loginManager?.UserInfo?.Roles == null)
            {
                this.Publish(new HomeMenuUpdatedEvent(this));
                return;
            }



            if(maintenanceEnabled)
            if (_loginManager.UserInfo.Roles.Contains("Maintenance") ||
                _loginManager.UserInfo.Roles.Contains("PropertyAdmin"))
            {
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Resident Requests",
                    Icon = SharedResources.Icons.MaintenanceFolder,
                    Command = RequestsIndexCommand
                });
            }

            if(courtesyEnabled)
            if (_loginManager.UserInfo.Roles.Contains("Officer") ||
                _loginManager.UserInfo.Roles.Contains("PropertyAdmin"))
            {
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Incident Reports",
                    Icon = SharedResources.Icons.PoliceFolder,
                    Command = IncidentsIndexCommand
                });
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Checkins",
                    Icon = SharedResources.Icons.LocationOk,
                    Command = new MvxCommand(() => { ShowViewModel<CourtesyOfficerCheckinsViewModel>(); })
                });
            }


            if (_loginManager.UserInfo.Roles.Contains("PropertyAdmin"))
            {
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Configure Property",
                    Icon = SharedResources.Icons.HomeConfig,
                    Command = ConfigurePropertyCommand
                });
            }

            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Notifications",
           //     BadgeLabel = "+12",
                Icon = SharedResources.Icons.Inbox,
                Command = AlertsCommand
            });

            if(maintenanceEnabled)
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Maintenance Request",
                Icon = SharedResources.Icons.Maintenance,
                Command = MaintenaceRequestCommand
            });
			if (prospectEnabled && (
				_loginManager.UserInfo.Roles.Contains("PropertyAdmin") || 
				_loginManager.UserInfo.Roles.Contains("Admin") ||
				_loginManager.UserInfo.Roles.Contains("ProspectAdmin")
			))
			{
				MenuItems.Add(new HomeMenuItemViewModel()
				{
					Name = "Scan Prospect Id",
					Icon = SharedResources.Icons.Wallet,
					Command = ScanIdCommand
				});

			}
            if(courtesyEnabled)
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Request Courtesy Officer",
                Icon = SharedResources.Icons.Police,
                Command = RequestCourtesyOfficerCommand
            });

            if (_loginManager.UserInfo.Roles.Contains("Resident"))
            {
             
                if(PayRentCommand.CanExecute(null))
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Pay Rent",
                    Icon = SharedResources.Icons.Wallet,
                    Command = PayRentCommand
                });

                /*
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Community Partners",
                    Icon = SharedResources.Icons.Partners,
                    Command = CommunityPartnersCommand
                });
                */
            }

            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Change Password",
                Icon = SharedResources.Icons.Settings,
                Command = ChangePasswordCommand
            });
            this.Publish(new HomeMenuUpdatedEvent(this));

        }

        public ICommand ChangePasswordCommand => new MvxCommand(() =>
        {
            ShowViewModel<ChangePasswordViewModel>();
        });


        public string PaymentUrl => _loginManager?.UserInfo?.PropertyConfig?.ModuleInfo?.PaymentsConfig?.Url;

        public ICommand AlertsCommand
        {
            get { return new MvxCommand(() => { ShowViewModel<NotificationIndexFormViewModel>(); }); }
        }

        private ObservableCollection<HomeMenuItemViewModel> _menuItems =
            new ObservableCollection<HomeMenuItemViewModel>();


        public ObservableCollection<HomeMenuItemViewModel> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        public ICommand EditProfileCommand => this.TaskCommand(async context =>
        {
            var image = await _dialogService.OpenImageDialog();
            if (image == null) return;
            context.Update("Updating account picture...");
            await Data.Account.SetProfilePictureWithOperationResponseAsync(Convert.ToBase64String(image));
            _loginManager.RefreshUserInfo();

            this.Publish(new UserInfoUpdated(this));
        });


        public ICommand OpenSettingsCommand => StubCommands.NoActionSpecifiedCommand(this);

        public ICommand SignOutCommand => new MvxCommand(() =>
        {
            _loginManager.Logout();
            this.ShowViewModel<LoginFormViewModel>();
            //this.ShowViewModel<LoginFormViewModel>();
        });

        public ICommand RequestStatusCommand
            => new MvxCommand(() => { ShowViewModel<MaintenanceStartFormViewModel>(); });

        public ICommand ConfigurePropertyCommand => new MvxCommand(() =>
        {
            ShowViewModel<PropertyConfigFormViewModel>(vm =>
            {
                //vm.Url = Mvx.Resolve<IApartmentAppsAPIService>().BaseUri + "/generalviews/index";
            });
        });

        public ICommand IncidentsIndexCommand
            => new MvxCommand(() => { ShowViewModel<IncidentReportIndexViewModel>(); });

        public ICommand RequestsIndexCommand
            => new MvxCommand(() => { ShowViewModel<MaintenanceRequestIndexViewModel>(); });

        public ICommand HomeCommand => new MvxCommand(() => { ShowViewModel<NotificationsFormViewModel>(vm => { }); });

        public ICommand MaintenaceRequestCommand
            => new MvxCommand(() => { ShowViewModel<MaintenanceRequestFormViewModel>(); });

        public ICommand RequestCourtesyOfficerCommand => new MvxCommand(() =>
        {
            ShowViewModel<IncidentReportFormViewModel>(vm =>
            {
                //vm.Url = Mvx.Resolve<IApartmentAppsAPIService>().BaseUri + "/generalviews/index";
            });
        });
		public ICommand ScanIdCommand => new MvxCommand( () =>
	   {
			//var image = await Mvx.Resolve<IDialogService>().OpenImageDialog();
		   //var image = await Mvx.Resolve<IQRService>().ScanIDAsync();

			ShowViewModel<ProspectApplicationFormViewModel>(vm =>
		    {
				//vm.Image = image;
				//vm.Url = Mvx.Resolve<IApartmentAppsAPIService>().BaseUri + "/generalviews/index";
			});
	   });
        public ICommand PayRentCommand => new MvxCommand(() =>
        {
            if (_loginManager.UserInfo?.PropertyConfig?.ModuleInfo?.PaymentsConfig?.UseUrl ?? false)
            {
                if (!string.IsNullOrEmpty(PaymentUrl))
                {
                    _dialogService.OpenUrl(PaymentUrl);
                }
                else
                {
                    _dialogService.OpenNotification("We are sorry.","Your property has not provided URL for paying rent.","Ok",()=> {});
                }
            }
            else
            {
                ShowViewModel<RentSummaryViewModel>();
            }
        },()=> _loginManager.UserInfo?.PropertyConfig?.ModuleInfo?.PaymentsConfig?.Enabled ?? false );

        public ICommand CommunityPartnersCommand => StubCommands.NoActionSpecifiedCommand(this);

        public string ProfileImageUrl => this._loginManager?.UserInfo?.ImageUrl;
        public string Username => _loginManager?.UserInfo?.FullName;
        public string Email => _loginManager?.UserInfo?.Email;
    }

    public class UserInfoUpdated : MvxMessage
    {
        public UserInfoUpdated(object sender) : base(sender)
        {
        }
    }

    public class HomeMenuUpdatedEvent : MvxMessage
    {
        public HomeMenuUpdatedEvent(object sender) : base(sender)
        {
        }
    }
}