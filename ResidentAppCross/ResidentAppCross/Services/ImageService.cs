using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Plugins.PictureChooser;

namespace ResidentAppCross.Services
{
    public interface IImageService
    {
        void SelectImage(Action<byte[]> selected , Action cancelled);
    }

    public class ImageService : IImageService
    {
        private IMvxPictureChooserTask _pictureChooser;

        public ImageService(IMvxPictureChooserTask pictureChooser)
        {
            _pictureChooser = pictureChooser;
        }

        public void SelectImage(Action<byte[]> selected, Action cancelled)
        {
            _pictureChooser.ChoosePictureFromLibrary(2048, 100, data =>
            {
                byte[] result;
                using (var memoryStream = new MemoryStream())
                {
                    data.CopyTo(memoryStream);
                    result = memoryStream.ToArray();
                }
                selected(result);
            }, cancelled);
        }
    }
}
