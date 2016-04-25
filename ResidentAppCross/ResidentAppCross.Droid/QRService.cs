using System;
using System.Threading.Tasks;
using Android.OS;
using ResidentAppCross.Services;
using ZXing.Mobile;

namespace ResidentAppCross.Droid.Services
{
    public class AndroidQRService : IQRService
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

            //Check if emulator and return emulated result
            string fing = Build.Fingerprint;
            bool isEmulator = false;
            if (fing != null)
            {
                isEmulator = fing.Contains("vbox") || fing.Contains("generic") || fing.Contains("vsemu");
            }

            if (isEmulator)
            {
                return new QRData()
                {
                    Data = "http://www.apartmentapps.com?coloc=17",
                    ImageData = new byte[0],
                    Timestamp = DateTime.Now.Ticks
                };
            }

            var data = await Scanner.Scan(new MobileBarcodeScanningOptions());

            return new QRData()
            {
                Data = data.Text,
                ImageData = data.RawBytes,
                Timestamp = data.Timestamp
            };
        }
    }
}