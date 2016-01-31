using System.Collections.ObjectModel;
using ApartmentApps.Client;
using Cirrious.MvvmCross.ViewModels;

namespace ResidentAppCross
{
    public class HomeMenuViewModel : MvxViewModel
    {
        public IApartmentAppsAPIService Data { get; set; }

        public HomeMenuViewModel(IApartmentAppsAPIService data)
        {
            Data = data;
//            var values = Data.Values.Get();
//            foreach (var item in values)
//            {
//                MenuItems.Add(new MenuItemViewModel()
//                {
//                    Name = item
//                });
//            }
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = "Home"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = "Maitenance Request"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = "Request Courtest Officer"
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