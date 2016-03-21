using System;
using System.Diagnostics;
using System.Windows.Input;
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

        public LoginFormViewModel(ILoginManager loginManager)
        {
            LoginManager = loginManager;
        }

        public ICommand LoginCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    var username = string.IsNullOrEmpty(Username) ? "micahosborne@gmail.com" : Username;
                    var password = string.IsNullOrEmpty(Password) ? "Asdf1234!" : Password;
                    if (!await LoginManager.LoginAsync(username, password))
                    {
                        context.FailTask("Invalid login or password!");
                    }
                })
                .OnStart("Logging In...")
                .OnComplete("Logged In!", () => ShowViewModel<HomeMenuViewModel>(homeViewModel =>
                {
                    homeViewModel.Username = Username;
                }));
            }
        }

        public ICommand RemindPasswordCommand => StubCommands.NoActionSpecifiedCommand(this);

        public ICommand SignUpCommand => StubCommands.NoActionSpecifiedCommand(this);

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