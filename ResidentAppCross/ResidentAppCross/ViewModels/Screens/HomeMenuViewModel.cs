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

        public HomeMenuViewModel(IApartmentAppsAPIService data, ILoginManager loginManager, IImageService imageService, IDialogService dialogService)
        {
            _loginManager = loginManager;
            _imageService = imageService;
            _dialogService = dialogService;
            Data = data;
			if (loginManager.UserInfo.Roles.Contains("Maintenance") || loginManager.UserInfo.Roles.Contains("PropertyAdmin"))
            {
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Resident Requests",
                    Icon = SharedResources.Icons.MaintenanceFolder,
                    BadgeLabel = "??",
                    Command = RequestsIndexCommand
                });
            }

			if (loginManager.UserInfo.Roles.Contains("Officer") || loginManager.UserInfo.Roles.Contains("PropertyAdmin"))
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
                    Command = new MvxCommand(() =>
                    {
                        ShowViewModel<CourtesyOfficerCheckinsViewModel>();
                    })
                });

            }

            if (loginManager.UserInfo.Roles.Contains("PropertyAdmin"))
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
                Icon = SharedResources.Icons.Alerts,
                Command = AlertsCommand
            });

            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Maintenance Request",
                Icon = SharedResources.Icons.Maintenance,
                Command = MaintenaceRequestCommand
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Request Courtesy Officer",
                Icon = SharedResources.Icons.Police,
                Command = RequestCourtesyOfficerCommand
            });
			if (loginManager.UserInfo.Roles.Contains ("Resident")) {
				MenuItems.Add(new HomeMenuItemViewModel()
					{
						Name = "Pay Rent",
						Icon = SharedResources.Icons.Wallet,
						Command = PayRentCommand
					});
				MenuItems.Add(new HomeMenuItemViewModel()
					{
						Name = "Community Partners",
						Icon = SharedResources.Icons.Partners,
						Command = CommunityPartnersCommand
					});
			}
           
        }

        public ICommand AlertsCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<NotificationIndexFormViewModel>();
                });
            }
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
            this.Close(this);
            //this.ShowViewModel<LoginFormViewModel>();
        });

        public ICommand RequestStatusCommand => new MvxCommand(() =>
        {
            ShowViewModel<MaintenanceStartFormViewModel>();
        });
        public ICommand ConfigurePropertyCommand => new MvxCommand(() =>
        {
            ShowViewModel<PropertyConfigFormViewModel>(vm =>
            {
                //vm.Url = Mvx.Resolve<IApartmentAppsAPIService>().BaseUri + "/generalviews/index";
            });
        });
        public ICommand IncidentsIndexCommand => new MvxCommand(() =>
        {
            ShowViewModel<IncidentReportIndexViewModel>();
        });
        public ICommand RequestsIndexCommand => new MvxCommand(() =>
        {
            ShowViewModel<MaintenanceRequestIndexViewModel>();
        });

        public ICommand HomeCommand => new MvxCommand(() =>
        {
            ShowViewModel<NotificationsFormViewModel>(vm =>
            {
                
            });
        });

        public ICommand MaintenaceRequestCommand => new MvxCommand(() =>
        {
            ShowViewModel<MaintenanceRequestFormViewModel>();
        });

        public ICommand RequestCourtesyOfficerCommand => new MvxCommand(() =>
        {
            ShowViewModel<IncidentReportFormViewModel>(vm =>
            {
                //vm.Url = Mvx.Resolve<IApartmentAppsAPIService>().BaseUri + "/generalviews/index";
            });
        });

        public ICommand PayRentCommand => StubCommands.NoActionSpecifiedCommand(this);

        public ICommand CommunityPartnersCommand => StubCommands.NoActionSpecifiedCommand(this);

        public string ProfileImageUrl => this._loginManager.UserInfo.ImageUrl;
        public string Username => _loginManager.UserInfo.Email;
    }

    public class UserInfoUpdated : MvxMessage
    {
        public UserInfoUpdated(object sender) : base(sender)
        {

        }
    }
}