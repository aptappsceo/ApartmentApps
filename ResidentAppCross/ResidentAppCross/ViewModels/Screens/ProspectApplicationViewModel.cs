using System;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels.Screens
{
    public class ProspectApplicationViewModel : ViewModelBase
    {
        private string _comments = "";
        private string _actionText = "";
        private string _headerText = "";
        private string _subHeaderText = "";
	

        public bool ShouldScanQr { get; set; } = true;
        public IApartmentAppsAPIService _service;
        public IDialogService _dialogService;
        public ProspectApplicationViewModel( IApartmentAppsAPIService service, IDialogService dialogService)
        {

            _service = service;
            _dialogService = dialogService;
        }

        public ICommand SubmitApplicationCommand
        {	
            get
            {
                return this.TaskCommand(async context =>
                {
                    var result = await _service.Prospect.SubmitApplicantAsync(new ProspectApplicationBindingModel()
                    {
                        FirstName = FirstName,
                        LastName = LastName
                    });

                }).OnStart("Submitting Application").OnComplete("Application Submitted!", () => this.Close(this));
			
            }
        }

        public void SetProsepectInfo(byte[] image)
        {
            if (image != null)
            {
                var base64 = Convert.ToBase64String(image);
                var result = _service.Prospect.ScanId(base64);
                if (result != null)
                {
                    FirstName = result.FirstName;
                    LastName = result.LastName;
                }
                else {
                    _dialogService.OpenNotification("Error", "Couldn't scan ID", "OK", () => { } );
                }
            }


        }
        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }



        string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        public string _lastName;
        string _addressLine1;

        public string AddressLine1
        {
            get { return _addressLine1; }
            set { SetProperty(ref _addressLine1, value); }
        }
        string _addressLine2;

        public string AddressLine2
        {
            get { return _addressLine2; }
            set { SetProperty(ref _addressLine2, value); }
        }



        string _addressCity;

        public string AddressCity
        {
            get { return _addressCity; }
            set { SetProperty(ref _addressCity, value); }
        }


        string _addressState;

        public string AddressState
        {
            get { return _addressState; }
            set { SetProperty(ref _addressState, value); }
        }


        string _zipCode;

        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }


        string _email;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }



        string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }



        string _desiredMoveInDate;

        public string DesiredMoveInDate
        {
            get { return _desiredMoveInDate; }
            set { SetProperty(ref _desiredMoveInDate, value); }
        }



        public string ActionText
        {
            get { return _actionText; }
            set { SetProperty(ref _actionText, value); }
        }

        public string HeaderText
        {
            get { return _headerText; }
            set { SetProperty(ref _headerText, value); }
        }

        public string SubHeaderText
        {
            get { return _subHeaderText; }
            set { SetProperty(ref _subHeaderText, value); }
        }

    }
}