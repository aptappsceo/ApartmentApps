using System.Collections.ObjectModel;
using ApartmentApps.Client;
using Cirrious.MvvmCross.ViewModels;
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
//                MenuItems.Add(new MenuItemViewModel()
//                {
//                    Name = "Maitenance Request"
//                });
//            }
//            if (loginManager.UserInfo.Role.Contains("Officer"))
//            {
//                MenuItems.Add(new MenuItemViewModel()
//                {
//                    Name = "Report Incedent"
//                });
//                MenuItems.Add(new MenuItemViewModel()
//                {
//                    Name = "Check-Ins"
//                });
//                MenuItems.Add(new MenuItemViewModel()
//                {
//                    Name = "Daily Report"
//                });
//            }
//            if (loginManager.UserInfo.Role.Contains("PropertyAdmin"))
//            {
//                MenuItems.Add(new MenuItemViewModel()
//                {
//                    Name = "Maitenance Request"
//                });
//
//            }
            //MenuItems.Add(new MenuItemViewModel()
            //{
            //    Name = "Home"
            //});
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = "Maitenance Request"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = "Request Courtesy Officer"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = "Pay Rent"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = "Community Partners"
            });
        }

        private ObservableCollection<MenuItemViewModel> _menuItems = new ObservableCollection<MenuItemViewModel>();

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; RaisePropertyChanged("MenuItems"); }
        }
      
    }
}