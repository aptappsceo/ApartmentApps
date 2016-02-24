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
using ResidentAppCross.Events;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels.Data;

namespace ResidentAppCross.ViewModels
{
    public class MaintenanceStartFormViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _appService;
        private ICommand _startCommand;
        private IQRService _qrService;
        private MaitenanceRequest _request;
        private DateTime _repairDate;
        private int _maintenanceRequestId;

        public MaintenanceStartFormViewModel(IApartmentAppsAPIService appService, IQRService qrService)
        {
            _appService = appService;
            _qrService = qrService;
        }

        public ICommand ChangeDateCommand => StubCommands.NoActionSpecifiedCommand(this);
        public ICommand ChangeMaintenanceRequestTypeCommand => new MvxCommand(SubmitMaintenanceStart);
        public ICommand StartCommand => StubCommands.NoActionSpecifiedCommand(this);
        public ICommand RefreshMaintenanceRequestCommand => StubCommands.NoActionSpecifiedCommand(this);

        public MaitenanceRequest Request
        {
            get { return _request; }
            set { SetProperty(ref _request, value); }
        }

        public DateTime RepairDate
        {
            get { return _repairDate; }
            set { SetProperty(ref _repairDate, value); }
        }

        public void Init(int id)
        {
            MaintenanceRequestId = id;
        }

        public int MaintenanceRequestId
        {
            get { return _maintenanceRequestId; }
            set
            {
                SetProperty(ref _maintenanceRequestId, value);
                RefreshMaintenanceRequestCommand.Execute(null);
            }
        }

        private async void SubmitMaintenanceStart()
        {
                var qrData = await _qrService.ScanAsync();

                if (string.IsNullOrEmpty(qrData.Data))
                {
                    this.FailTaskWithPrompt("Please, scan a valid QR Code.");
                    return;
                }

                try
                {
                    this.StartTask("Submitting...");

                    //TODO: Implement Maintenance Start Submit

                    this.CompleteTaskWithPrompt("Complete!", () =>
                    {
                        //TODO: Implement Maintenance Start Complete
                    });

                }
                catch (Exception ex)
                {
                    this.FailTaskWithPrompt(ex.Message);
                }
        }

    }
}


