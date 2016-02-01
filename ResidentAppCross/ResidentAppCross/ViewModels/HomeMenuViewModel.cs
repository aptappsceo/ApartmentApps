using System.Collections.ObjectModel;
using ApartmentApps.Client;
using Cirrious.MvvmCross.ViewModels;
using ResidentAppCross.Resources;
using ResidentAppCross.ServiceClient;

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
                Icon = SharedResources.Icons.HouseIcon
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Maitenance Request",
                Icon = SharedResources.Icons.MaintenaceIcon
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Request Courtesy Officer",
                Icon = SharedResources.Icons.OfficerIcon
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Pay Rent",
                Icon = SharedResources.Icons.PayIcon
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Community Partners",
                Icon = SharedResources.Icons.PartnersIcon
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Home",
                Icon = SharedResources.Icons.HouseIcon
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Maitenance Request",
                Icon = SharedResources.Icons.MaintenaceIcon
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Request Courtesy Officer",
                Icon = SharedResources.Icons.OfficerIcon
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Pay Rent",
                Icon = SharedResources.Icons.PayIcon
            });
            MenuItems.Add(new HomeMenuItemViewModel()
            {
                Name = "Community Partners",
                Icon = SharedResources.Icons.PartnersIcon
            });
        }

        private ObservableCollection<HomeMenuItemViewModel> _menuItems = new ObservableCollection<HomeMenuItemViewModel>();

        public ObservableCollection<HomeMenuItemViewModel> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; RaisePropertyChanged("MenuItems"); }
        }
      
    }
}