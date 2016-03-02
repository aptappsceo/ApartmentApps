using System.Threading.Tasks;
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