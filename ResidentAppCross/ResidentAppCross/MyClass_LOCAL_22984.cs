using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using ResidentAppCross.ServiceClient;

namespace ResidentAppCross
{
    public class App : MvxApplication
    {
        public App()
        {
            //Mvx.RegisterType<ICalculation, Calculation>();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginViewModel>());
            Mvx.RegisterSingleton(new ApplicationContext());
            Mvx.RegisterSingleton<IRestClient>(new RestClient());
            Mvx.RegisterType<ILoginManager,LoginService>();
        }
    }

    public interface IQueryMenuItems
    {
        
    }
    public class ApplicationContext
    {
        public string LoginId;
        public string Username;

    }
    public class LoginViewModel : MvxViewModel
    {
        public ILoginManager LoginManager { get; }
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value;
                SetProperty(ref _username, value, "Username");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value, "Password"); }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value, "ErrorMessage"); }
        }

        public LoginViewModel(ILoginManager loginManager)
        {
            LoginManager = loginManager;
        }

        public ICommand LoginCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var result = await LoginManager.Login(Username, Password);
                    if (result == null)
                    {
                        ShowViewModel<HomeViewModel>();
                    }
                    else
                    {
                        ErrorMessage = result;
                    }
                    //ShowViewModel<HomeViewModel>()
                }, () => true);
            }
        }
    }

    public class HomeViewModel : MvxViewModel
    {
        public HomeViewModel()
        {
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

    public class MenuItemViewModel : MvxViewModel
    {
        public string Name { get; set; }
    }
}



