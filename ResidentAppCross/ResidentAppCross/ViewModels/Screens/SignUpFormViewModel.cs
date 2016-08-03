using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
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
        private readonly IApartmentAppsAPIService _apiService;
        private IDialogService _dialogService;
        private string _phoneNumber;
        private string _firstName;
        private string _LastName;

        public SignUpFormViewModel(IApartmentAppsAPIService apiService, IDialogService dialogService)
        {
            _apiService = apiService;
            _dialogService = dialogService;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { SetProperty(ref _LastName, value); }
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

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
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

        public ICommand SignUpCommand => this.TaskCommand(async (context) =>
        {
            var response = await _apiService.Account.RegisterFromPhoneWithOperationResponseAsync(new RegisterFromPhoneBindingModel()
            {
                Email = Email,
                Password = Password,
                ConfirmPassword = PasswordConfirmation,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber
            });
            if (!response.Response.IsSuccessStatusCode)
            {
                context.FailTask(response.Response.ReasonPhrase);
                return;
            }
        }).OnStart("Signing Up").OnComplete("Sign Up Complete",()=> Close(this));

        public ICommand SelectBirthdayCommand => new MvxCommand(async () =>
        {
            var date = await _dialogService.OpenDateDialog("Birthday");
            if(date.HasValue) PhoneNumber = date.Value.ToString("g");
        });
    }
}
