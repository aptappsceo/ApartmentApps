using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Commands;
using ResidentAppCross.Events;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross
{
    public class LoginFormViewModel : ViewModelBase
    {
        public ILoginManager LoginManager { get; set; }
        public IVersionChecker VersionChecker { get; set; }
        public IApartmentAppsAPIService Data { get; set; }
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

        public LoginFormViewModel(ILoginManager loginManager, IVersionChecker versionChecker, IApartmentAppsAPIService data)
        {
            LoginManager = loginManager;
            VersionChecker = versionChecker;
            Data = data;
        }

        public override void Start()
        {
            base.Start();
//            if (LoginManager.IsLoggedIn)
//            {
//                LoginCommand.Execute(null);
//            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    if (VersionChecker != null)
                    {
                        var version = await Data.Version.GetAsync();
                        if (!VersionChecker.CheckVersion(version))
                        {
                            VersionChecker.OpenInStore(version);
                            context.FailTask("Please update your version");
                            return;
                        }
                    }
#if DEBUG
                    var username = string.IsNullOrEmpty(Username) ? "micahosborne@gmail.com" : Username;
                    var password = string.IsNullOrEmpty(Password) ? "Asdf1234!" : Password;
#else
                    var username =  Username;
                    var password =  Password;
#endif

                    if (!await LoginManager.LoginAsync(username, password))
                    {
                        context.FailTask("Invalid login or password!");
                    }
                    else
                    {
                        
                    }
                })
                .OnStart("Logging In...")
                .OnComplete(null, () =>
                {
                    ShowViewModel<HomeMenuViewModel>();
                });
            }
        }

        public ICommand RemindPasswordCommand => StubCommands.NoActionSpecifiedCommand(this);

        public ICommand SignUpCommand => new MvxCommand(() =>
        {
            ShowViewModel<SignUpFormViewModel>();
        });

        public ICommand OpenTestFormCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<TestFormViewModel>();
                });
            }
        }
    }
}