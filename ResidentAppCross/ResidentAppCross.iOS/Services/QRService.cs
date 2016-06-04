using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.iOS.Views;
using MvvmCross.Platform.Core;
using ObjCRuntime;
using ResidentAppCross.Services;
using UIKit;
using ZXing;
using ZXing.Mobile;

namespace ResidentAppCross.iOS.Services
{
    public class IOSQRService : IQRService
    {
        private MobileBarcodeScanner _scanner;

        public MobileBarcodeScanner Scanner
        {
            get { return _scanner ?? (_scanner = new MobileBarcodeScanner(UIApplication.SharedApplication.KeyWindow.RootViewController)
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
                    Data = "http://www.apartmentapps.com?coloc=17",
                    ImageData = new byte[0],
                    Timestamp = DateTime.Now.Ticks
                }; 
            }

            var scan = await Scanner.Scan();
            if (scan == null) return null;
            return new QRData()
            {
                Data = scan?.Text,
                ImageData = scan?.RawBytes,
                Timestamp = scan?.Timestamp ?? 0
            };


////
//            var view = new AVCaptureScannerViewController(new MobileBarcodeScanningOptions()
//            {
//            },
//            new MobileBarcodeScanner()
//            {
//            });
//
//            var window = UIApplication.SharedApplication.KeyWindow;
//            var vc = window.RootViewController as UINavigationController;
//
//            if (vc == null)
//            {
//                throw new Exception("Wowowowo");
//            }
//
//            QRData result = null;
//
//            view.OnScannedResult += _ =>
//            {
//                result =  new QRData()
//            {
//                Data = _?.Text,
//                ImageData = _?.RawBytes,
//                Timestamp = _?.Timestamp ?? 0
//            };
//                view.DismissViewController(true, ()=> {});
//            };
//
//            await vc.PresentViewControllerAsync(view,true);
//
//            return result;
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