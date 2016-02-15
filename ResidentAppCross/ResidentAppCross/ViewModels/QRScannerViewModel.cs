using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels
{
    public class QRScannerViewModel : ViewModelBase
    {

        private readonly IQRService _qrService;
        private string _scannedText = "Nothing";

        public QRScannerViewModel(IQRService qrService)
        {
            _qrService = qrService;
        }

        public string ScannedText
        {
            get { return _scannedText; }
            set { SetProperty(ref _scannedText, value); }
        }

        public ICommand ScanCommand
        {
            get { return new MvxCommand(() =>
            {
                Task.Run(async () =>
                {
                    var data = await _qrService.ScanAsync();
                    ScannedText = data.Data;
                });
            }); }
        }
    }
}
