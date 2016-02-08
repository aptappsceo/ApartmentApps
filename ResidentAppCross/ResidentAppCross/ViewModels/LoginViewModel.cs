using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.ServiceClient;

namespace ResidentAppCross
{
    public class LoginViewModel : MvxViewModel
    {
        public ILoginManager LoginManager { get; set; }
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;
        private bool _isOperating;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public bool IsOperating
        {
            get { return _isOperating; }
            set { SetProperty(ref _isOperating, value); }
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
                    IsOperating = true;
                    if (await LoginManager.LoginAsync(Username, Password))
                    {
                        ShowViewModel<HomeMenuViewModel>();
                    }
                    IsOperating = false; //This is where I fell in love with async/await <3
                }, () => true);
            }
        }

        public ICommand RemindPasswordCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<HomeMenuViewModel>();
                    Debug.WriteLine("Please implement \"RemindPasswordCommand\" @ LoginViewModel");
                });
            }
        }

        public ICommand SignUpCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Debug.WriteLine("Please implement \"SignUpCommand\" @ LoginViewModel");
                });
            }
        }
    }
}