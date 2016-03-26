using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Commands;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels.Screens
{
    public class SignUpFormViewModel : ViewModelBase
    {
        private string _firstLastName;
        private string _email;
        private DateTime _birthday;
        private string _username;
        private string _password;
        private string _passwordConfirmation;
        private IDialogService _dialogService;
        private string _birthdayTitle;

        public SignUpFormViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public string FirstLastName
        {
            get { return _firstLastName; }
            set { SetProperty(ref _firstLastName,value); }
        }

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { SetProperty(ref _birthday, value); }
        }

        public string BirthdayTitle
        {
            get { return _birthdayTitle; }
            set { SetProperty(ref _birthdayTitle, value); }
        }

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public string PasswordConfirmation
        {
            get { return _passwordConfirmation; }
            set { SetProperty(ref _passwordConfirmation, value); }
        }

        public ICommand SignUpCommand => StubCommands.NoActionSpecifiedCommand(this);
        public ICommand SelectBirthdayCommand => new MvxCommand(async () =>
        {
            var date = await _dialogService.OpenDateDialog("Birthday");
            if(date.HasValue) BirthdayTitle = date.Value.ToString("g");
        });
    }
}
