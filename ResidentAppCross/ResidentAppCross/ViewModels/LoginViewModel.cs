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

        public override void Start()
        {
            base.Start();

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
                    Debug.WriteLine(string.Format("Should login {0}:{1}", Username, Password));
                    if (await LoginManager.LoginAsync(Username, Password))
                    {
                        ShowViewModel<HomeMenuViewModel>();
                    }
                    
                }
                    , () => true);
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