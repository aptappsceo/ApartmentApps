using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Commands;
using ResidentAppCross.Services;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;

namespace ResidentAppCross.ViewModels.Screens
{
    public class CheckinFormViewModel : ViewModelBase
    {
        private string _comments = "";
        private ImageBundleViewModel _photos;
        private string _actionText = "";
        private string _headerText = "";
        private string _subHeaderText = "";
        private IQRService _qrService;
        public QRData QRScanResult { get; set; }
        public bool ShouldScanQr { get; set; } = true;

        public CheckinFormViewModel(IQRService qrService)
        {
            _qrService = qrService;
        }

        public ICommand SubmitCheckinCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    if(ShouldScanQr) QRScanResult = await _qrService.ScanAsync();
                    await Task.Delay(500);
                    ActionCommand?.Execute(null);
                });
            }
        }

        public ICommand ActionCommand { get; set; }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }

        public ImageBundleViewModel Photos
        {
            get { return _photos ?? (_photos = new ImageBundleViewModel()); }
            set { SetProperty(ref _photos,value); }
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
            set { SetProperty(ref _subHeaderText,value); }
        }

    }
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
