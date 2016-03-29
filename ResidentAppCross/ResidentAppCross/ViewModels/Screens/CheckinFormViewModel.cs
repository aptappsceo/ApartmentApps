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
}
