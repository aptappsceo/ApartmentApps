using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.Utils.ImageProcessing;
using ApartmentApps.Data;
using ExifLib;
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
        IEnumerable<string> GetImages(Guid groupId);
    }

    public class BlobStorageService : IBlobStorageService
    {
        private readonly ApplicationDbContext _context;

        CloudStorageAccount _storageAccount;
        CloudBlobClient _blobClient;
        CloudBlobContainer _photoBlobContainer;

        public BlobStorageService(ApplicationDbContext context)
        {
            _context = context;
            _storageAccount =
                CloudStorageAccount.Parse(
                    "DefaultEndpointsProtocol=https;AccountName=apartmentapps;AccountKey=AfGlM/AKQ6p62MlWtR1gRdezYflU9BUL8n19J4Dtkjkb5xgP3by0/N64uDP1i3hG1CXWtjVpWZ6WAUIDYMmI4w==;BlobEndpoint=https://apartmentapps.blob.core.windows.net/;TableEndpoint=https://apartmentapps.table.core.windows.net/;QueueEndpoint=https://apartmentapps.queue.core.windows.net/;FileEndpoint=https://apartmentapps.file.core.windows.net/");
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


        private byte[] PreProcessJpeg(byte[] data)
        {
            // Rotate the image according to EXIF data
           
            Bitmap bmp = null;
            using (var exifReader = new ExifReader(new MemoryStream(data)))
            {
                ushort orient;
                //Using lightweight exifreader to make sure that we need modify the image
                if (!exifReader.GetTagValue(ExifTags.Orientation, out orient)) return data;
                var flipType = ExifOrientationToBitmapFlipType(orient);
                if (flipType == RotateFlipType.RotateNoneFlipNone) return data;
                using (var ms = new MemoryStream(data))
                {
                    //Then kick in heavy instruments
                    bmp = new Bitmap(ms);
                    bmp.RotateFlip(flipType);

                    var exif = bmp.PropertyItems.FirstOrDefault(p=> p.Id == 0x0112);

                    if (exif != null)
                    {
                        exif.Value = new[] { (byte)1, (byte)0}; // RotateFlipType.RotateNoneFlipNone; -> EXIF orientation reset
                    }

                    bmp.SetPropertyItem(exif);

                    //exif.setTag(0x112, "1"); // Optional: reset orientation tag

                    var preProcessJpeg = bmp.ToByteArray();
                    return preProcessJpeg;
                }
            }
        }
        

        private static RotateFlipType ExifOrientationToBitmapFlipType(int orientationByte)
        {
            switch (orientationByte)
            {
                case 1:
                    return RotateFlipType.RotateNoneFlipNone;
                case 2:
                    return RotateFlipType.RotateNoneFlipX;
                case 3:
                    return RotateFlipType.Rotate180FlipNone;
                case 4:
                    return RotateFlipType.Rotate180FlipX;
                case 5:
                    return RotateFlipType.Rotate90FlipX;
                case 6:
                    return RotateFlipType.Rotate90FlipNone;
                case 7:
                    return RotateFlipType.Rotate270FlipX;
                case 8:
                    return RotateFlipType.Rotate270FlipNone;
                default:
                    return RotateFlipType.RotateNoneFlipNone;
            }
        }


        public string UploadPhoto(byte[] data, string photoKey)
        {
            var header = new byte[4];
            Array.Copy(data, header, 4);
            string photoFileName;
            string contentType = "image/";
            if (IsJpegHeader(header))
            {
                photoFileName = photoKey + ".jpeg";
                contentType += "jpeg";
                try
                {
                    data = PreProcessJpeg(data);
                }
                catch (Exception ex)
                {
                    //Fallback to original
                }

            }
            else if (IsPngHeader(header))
            {
                photoFileName = photoKey + ".png";
                contentType += "png";
            }
            else
            {
                throw new Exception("Not a valid image");
            }

            var blob = _photoBlobContainer.GetBlockBlobReference(photoFileName);
            blob.Properties.ContentType = contentType;
            blob.UploadFromByteArray(data, 0, data.Length);

            return photoFileName;
        }

        public IEnumerable<string> GetImages(Guid groupId)
        {
            var imageReferences = _context.ImageReferences.Where(r => r.GroupId == groupId).ToList();
            foreach (var reference in imageReferences)
            {
                yield return GetPhotoUrl(reference.Url);
                    //This call replaces RELATIVE url with ABSOLUTE url. ( STORAGE SERVICE + IMAGE URL)
                //This is done to make URLs independent from the service, which is used to store them.                            
                //It needs some cleanup later maybe
            }
        }

        public string GetPhotoUrl(string filename)
        {
            if (filename == null) return null;
            var blob = _photoBlobContainer.GetBlobReference(filename);
            return blob.Uri.ToString();
        }

        static bool IsJpegHeader(byte[] fourByteHeader)
        {
            UInt16 soi = BitConverter.ToUInt16(fourByteHeader, 0); // Start of Image (SOI) marker (FFD8)
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