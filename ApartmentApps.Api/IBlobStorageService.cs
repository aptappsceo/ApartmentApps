using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Threading.Tasks;
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
}