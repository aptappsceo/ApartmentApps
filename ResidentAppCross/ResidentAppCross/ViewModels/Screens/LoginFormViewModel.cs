﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
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

        public bool IsAutologin = false;

        public LoginFormViewModel(ILoginManager loginManager, IVersionChecker versionChecker, IApartmentAppsAPIService data)
        {
            LoginManager = loginManager;
            VersionChecker = versionChecker;
            Data = data;
        }

        public override void Start()
        {
            base.Start();
            if (LoginManager.IsLoggedIn)
            {
                IsAutologin = true;
                LoginCommand.Execute(null);
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {

                    if(!IsAutologin) LoginManager.Logout();
                    if (VersionChecker != null)
                    {
                        var version = await Data.Version.GetAsync();
                        if (!VersionChecker.CheckVersion(version))
                        {
                            VersionChecker.OpenInStore(version);
                            
                            return;
                        }
                    }
                    this.TaskCommand(async context =>
                    {

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
                       if (EventAggregator.HasSubscriptionsFor<UserLoggedInEvent>())
                       {
                           var message = new UserLoggedInEvent(this);
                           this.Publish(message);
                           if (!message.PreventNavigation)
                           {
                               ShowViewModel<HomeMenuViewModel>();
                           }
                       }
                       else
                       {
                           ShowViewModel<HomeMenuViewModel>();
                       }
                   }).Execute(null);
                });

            }
        }

        public ICommand RemindPasswordCommand => new MvxCommand(() =>
        {
            ShowViewModel<RecoverPasswordViewModel>();
        });

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

    public class UserLoggedInEvent : MvxMessage
    {
        public UserLoggedInEvent(object sender) : base(sender)
        {
        }

        public bool PreventNavigation { get; set; }
    }



    public class RecoverPasswordViewModel : ViewModelBase
    {
        private string _email;

        public string Email
        {
            get { return _email; }
            set { this.SetProperty(ref _email, value); }
        }

        public ICommand RecoverPasswordCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    await Task.Delay(2000);
                })
                .OnStart("Recovering...")
                .OnComplete("Done! Further instructions were sent to your email.", () => Close(this));
            }
        }
    }

    public class MessageDetailsViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _service;

        public MessageDetailsViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public AlertBindingModel Data
        {
            get { return _data; }
            set
            {
                if (_data == value) return;
                _data = value;
                if (_data == null) return;
                Subject = _data.Title;
                Message = _data.Message;
                Date = _data.CreatedOn?.ToString("g") ?? "-";
            }
        }


        private string _subject = "Some important subject here";
        private string _message = "Very insteresting message should be here because otherwise noone's gonna read it. Also I need to ad some text just to see how multiline text looks like in this particular case so don;t blame me for a long string.";
        private string _date = "4/6/2015 22:02 AM";
        private AlertBindingModel _data;
        private int _messageId;

        public string Subject
        {
            get { return _subject; }
            set { SetProperty(ref _subject,value); }
        }

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public int MessageId
        {
            get { return _messageId; }
            set
            {
                SetProperty(ref _messageId, value);
                UpdateMessage.Execute(null);
            }
        }

        ICommand UpdateMessage
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    Data = await _service.Messaging.GetMessageAsync(MessageId);
                }).OnStart("Fetching Message...");
            }
        }

    }

    public class ChangePasswordViewModel : ViewModelBase
    {
        private string _oldPassword;
        private string _newPassword;
        private string _newPasswordConfirmation;
        private IApartmentAppsAPIService _service;

        public ChangePasswordViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public string OldPassword
        {
            get { return _oldPassword; }
            set { SetProperty(ref _oldPassword, value); }
        }

        public string NewPassword
        {
            get { return _newPassword; }
            set { SetProperty(ref _newPassword, value); }
        }

        public string NewPasswordConfirmation
        {
            get { return _newPasswordConfirmation; }
            set { SetProperty(ref _newPasswordConfirmation,value); }
        }

        public ICommand ChangePasswordCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    await _service.Account.ChangePasswordWithOperationResponseAsync(new ChangePasswordBindingModel()
                    {
                        OldPassword = OldPassword,
                        NewPassword = NewPassword,
                        ConfirmPassword = NewPasswordConfirmation
                    });
                }).OnStart("Changing Password...").OnComplete("Password Changed!", () =>
                {
                    Mvx.Resolve<HomeMenuViewModel>().SignOutCommand.Execute(null);
                });
            }
        }
    }


    public enum MessageType
    {
        Maintenance,
        Courtesy,
        Delivery,
        Other,
        Payment
    }

}