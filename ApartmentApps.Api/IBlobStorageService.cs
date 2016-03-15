using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Encoder = System.Text.Encoder;

namespace ApartmentApps.Api
{
    public interface IBlobStorageService
    {
        string UploadPhoto(byte[] data, string photoKey);
        string GetPhotoUrl(string filename);
    }

    public class BlobStorageService : IBlobStorageService
    {

        CloudStorageAccount _storageAccount;
        CloudBlobClient _blobClient;
        CloudBlobContainer _photoBlobContainer;

        public BlobStorageService()
        {
            _storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=apartmentapps;AccountKey=AfGlM/AKQ6p62MlWtR1gRdezYflU9BUL8n19J4Dtkjkb5xgP3by0/N64uDP1i3hG1CXWtjVpWZ6WAUIDYMmI4w==;BlobEndpoint=https://apartmentapps.blob.core.windows.net/;TableEndpoint=https://apartmentapps.table.core.windows.net/;QueueEndpoint=https://apartmentapps.queue.core.windows.net/;FileEndpoint=https://apartmentapps.file.core.windows.net/");
            _blobClient = _storageAccount.CreateCloudBlobClient();

            _photoBlobContainer = _blobClient.GetContainerReference("photos");
            _photoBlobContainer.CreateIfNotExists();
        }

        //        _storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["webjobstorage"]);
        //            //Create a Table Client Object
        //            _blobClient = _storageAccount.CreateCloudTableClient();
        // 
        //            //Create Table if it does not exist
        //            CloudTable table = _blobClient.GetTableReference("ProfileEntityTable");
        //        table.CreateIfNotExists();
        public string UploadPhoto(byte[] data, string photoKey)
        {

            var header = new byte[4];
            Array.Copy(data,header,4);
            string photoFileName;

            if (IsJpegHeader(header))
            {
                photoFileName = photoKey + ".jpeg";
            }
            else if (IsPngHeader(header))
            {
                photoFileName = photoKey + ".png";
            }
            else
            {
                throw new Exception("Not a valid image");
            }

            var blob = _photoBlobContainer.GetBlockBlobReference(photoFileName);

            blob.UploadFromByteArray(data,0,data.Length);

            return photoFileName;

        }

        public string GetPhotoUrl(string filename)
        {
            var blob = _photoBlobContainer.GetBlobReference(filename);
            return blob.Uri.ToString();
        }

        static bool IsJpegHeader(byte[] fourByteHeader)
        {
            UInt16 soi = BitConverter.ToUInt16(fourByteHeader, 0);  // Start of Image (SOI) marker (FFD8)
            UInt16 marker = BitConverter.ToUInt16(fourByteHeader, 2); // JFIF marker (FFE0) or EXIF marker(FF01)
            return soi == 0xd8ff && (marker & 0xe0ff) == 0xe0ff;
        }

        static bool IsPngHeader(byte[] fourByteHeader)
        {
            var format = Encoding.ASCII.GetString(fourByteHeader.Take(4).ToArray()).ToLower();
            return "png" == format;
        }

    }

}
