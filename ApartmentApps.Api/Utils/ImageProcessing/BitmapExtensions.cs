using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Api.Utils.ImageProcessing
{
    public static class BitmapExtensions
    {

        public static byte[] ToByteArray(this Bitmap bitmap)
        {
            using (System.IO.MemoryStream sampleStream = new System.IO.MemoryStream())
            {
                bitmap.Save(sampleStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return sampleStream.ToArray();
            }
        }

    }
}
