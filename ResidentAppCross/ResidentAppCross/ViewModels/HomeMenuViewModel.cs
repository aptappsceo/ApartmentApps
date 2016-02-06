using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using Cirrious.MvvmCross.ViewModels;
using ResidentAppCross.Resources;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross
{
    public class HomeMenuViewModel : MvxViewModel
    {
        public IApartmentAppsAPIService Data { get; set; }

        public HomeMenuViewModel(IApartmentAppsAPIService data, ILoginManager loginManager)
        {
            Data = data;
            
//            if (loginManager.UserInfo.Role.Contains("Maitenance"))
//            {
//                MenuItems.Add(new HomeMenuItemViewModel()
//                {
//                    Name = "Maitenance Request"
//                });
//            }
//            if (loginManager.UserInfo.Role.Contains("Officer"))
//            {
//                MenuItems.Add(new HomeMenuItemViewModel()
//                {
//                    Name = "Report Incedent"
//                });
//                MenuItems.Add(new HomeMenuItemViewModel()
//                {
//                    Name = "Check-Ins"
//                });
//                MenuItems.Add(new HomeMenuItemViewModel()
//                {
//                    Name = "Daily Report"
//                });
//            }
//            if (loginManager.UserInfo.Role.Contains("PropertyAdmin"))
//            {
//                MenuItems.Add(new HomeMenuItemViewModel()
//                {
//                    Name = "Maitenance Request"
//                });
//
//            }
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Home",
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

        private ObservableCollection<HomeMenuItemViewModel> _menuItems =
            new ObservableCollection<HomeMenuItemViewModel>();

        public ObservableCollection<HomeMenuItemViewModel> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                RaisePropertyChanged("MenuItems");
            }
        }


        public ICommand EditProfileCommand
        {
            get { return new MvxCommand(() => { Debug.WriteLine("Should Execute EditProfileCommand"); }); }
        }

        public ICommand OpenSettingsCommand
        {
            get { return new MvxCommand(() => { Debug.WriteLine("Should Execute OpenSettingsCommand"); }); }
        }

        public ICommand SignOutCommand
        {
            get { return new MvxCommand(() => { Debug.WriteLine("Should Execute SignOutCommand"); }); }
        }

        public ICommand HomeCommand
        {
            get { return new MvxCommand(() => { Debug.WriteLine("Should Execute HomeCommand"); }); }
        }

        public ICommand MaintenaceRequestCommand
        {
            get { return new MvxCommand(() => { ShowViewModel<MaintenanceRequestViewModel>(); }); }
        }

        public ICommand RequestCourtesyOfficerCommand
        {
            get { return new MvxCommand(() => { Debug.WriteLine("Should Execute RequestCourtesyOfficerCommand"); }); }
        }

        public ICommand PayRentCommand
        {
            get { return new MvxCommand(() => { Debug.WriteLine("Should Execute PayRentCommand"); }); }
        }

        public ICommand CommunityPartnersCommand
        {
            get { return new MvxCommand(() => { Debug.WriteLine("Should Execute CommunityPartnersCommand"); }); }
        }

    }
}