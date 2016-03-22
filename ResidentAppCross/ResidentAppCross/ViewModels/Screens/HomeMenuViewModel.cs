using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ResidentAppCross.Commands;
using ResidentAppCross.Resources;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross
{
    public class HomeMenuViewModel : ViewModelBase
    {
        public IApartmentAppsAPIService Data { get; set; }

        public HomeMenuViewModel(IApartmentAppsAPIService data, ILoginManager loginManager)
        {
            Data = data;

            if (loginManager.UserInfo.Roles.Contains("Maintenance"))
            {
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Resident Requests",
                    Icon = SharedResources.Icons.MaintenaceIcon,
                    Command = RequestsIndexCommand
                });
            }

            if (loginManager.UserInfo.Roles.Contains("PropertyAdmin"))
            {
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Configure Property",
                    Icon = SharedResources.Icons.HouseIcon,
                    Command = ConfigurePropertyCommand
                });
            }
            if (loginManager.UserInfo.Roles.Contains("Officer"))
            {
                MenuItems.Add(new HomeMenuItemViewModel()
                {
                    Name = "Incident Reports",
                    Icon = SharedResources.Icons.OfficerIcon,
                    Command = ConfigurePropertyCommand
                });
               
            }
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Notifications",
                Icon = SharedResources.Icons.HouseIcon,
                Command = HomeCommand
            });

            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Maitenance Request",
                Icon = SharedResources.Icons.MaintenaceIcon,
                BadgeLabel = "6",
                Command = MaintenaceRequestCommand
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Request Courtesy Officer",
                Icon = SharedResources.Icons.OfficerIcon,
                BadgeLabel = "12",
                Command = RequestCourtesyOfficerCommand
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Pay Rent",
                Icon = SharedResources.Icons.PayIcon,
                Command = PayRentCommand
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Community Partners",
                Icon = SharedResources.Icons.PartnersIcon,
                Command = CommunityPartnersCommand
            });
        }

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private ObservableCollection<HomeMenuItemViewModel> _menuItems =
            new ObservableCollection<HomeMenuItemViewModel>();

        private string _username;

        public ObservableCollection<HomeMenuItemViewModel> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                RaisePropertyChanged("MenuItems");
            }
        }

        public ICommand EditProfileCommand => StubCommands.NoActionSpecifiedCommand(this);

        public ICommand OpenSettingsCommand => StubCommands.NoActionSpecifiedCommand(this);

        public ICommand SignOutCommand => StubCommands.NoActionSpecifiedCommand(this);

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


    }
}