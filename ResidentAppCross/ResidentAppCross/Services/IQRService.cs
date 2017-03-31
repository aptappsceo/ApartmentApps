using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAppCross.Services
{
    public interface IQRService
    {
        Task<QRData> ScanAsync();
		//Task<QRData> ScanIDAsync();
    }

    public class QRData
    {
        public byte[] ImageData { get; set; }
        public long Timestamp { get; set; }
        public string Data { get; set; }
    }
}
