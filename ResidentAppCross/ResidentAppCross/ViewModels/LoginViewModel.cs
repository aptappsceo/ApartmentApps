using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Commands;
using ResidentAppCross.Events;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross
{
    public class LoginViewModel : ViewModelBase
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
                    this.Publish(new TaskStarted(this) { Label = "Connecting..."});
                    if (await LoginManager.LoginAsync(Username, Password))
                    {
                        this.Publish(new TaskComplete(this) {Label = "Logged In"});
                            //This is where I fell in love with async/await <3
                        ShowViewModel<HomeMenuViewModel>();
                    }
                    else
                    {
                        this.Publish(new TaskFailed(this) { Label = "Failed to Log In", ShouldPrompt = true});
                    }
                }, () => true);
            }
        }

        public ICommand RemindPasswordCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    var httpLocalhostGeneralviews = "http://82.151.208.56:54683/generalviews";
                    ShowViewModel<GenericWebViewModel>(new { url = httpLocalhostGeneralviews });
                    Debug.WriteLine("Please implement \"RemindPasswordCommand\" @ LoginViewModel");
                });
            }
        }

        public ICommand SignUpCommand => StubCommands.NoActionSpecifiedCommand(this);
    }
}