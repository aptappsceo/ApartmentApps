using System;
using System.Threading.Tasks;
using ObjCRuntime;
using ResidentAppCross.Services;
using UIKit;
using ZXing.Mobile;

namespace ResidentAppCross.iOS.Services
{
    public class IOSQRService : IQRService
    {
        private MobileBarcodeScanner _scanner;

        public MobileBarcodeScanner Scanner
        {
            get { return _scanner ?? (_scanner = new MobileBarcodeScanner()
            {
                BottomText = "Please, point to appartment QR Code"
            }); }
            set { _scanner = value; }
        }

        public async Task<QRData> ScanAsync()
        {

            if (ObjCRuntime.Runtime.Arch == Arch.SIMULATOR)
            {
                return new QRData()
                {
                    Data = "Simulated Text",
                    ImageData = new byte[0],
                    Timestamp = DateTime.Now.Ticks
                }; 
            }

            var view = new AVCaptureScannerViewController(new MobileBarcodeScanningOptions()
            {
            },
            new MobileBarcodeScanner()
            {
            });

            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController.PresentedViewController;



            QRData result = null;

            view.OnScannedResult += _ =>
            {
                
                result = new QRData()
                {
                    Data = _.Text,
                    ImageData = _.RawBytes,
                    Timestamp = _.Timestamp
                };

                view.DismissViewController(true, ()=> {});
            };


            await vc.PresentViewControllerAsync(view,true);

            return result;
        }
    

//        public async Task<QRData> ScanAsync()
//        {
//            var data = await Scanner.Scan();
//
//            return new QRData()
//            {
//                Data = data.Text,
//                ImageData = data.RawBytes,
//                Timestamp = data.Timestamp
//            };
//        }
    }
}