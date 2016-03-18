﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Plugins.PictureChooser;

namespace ResidentAppCross.Services
{
    public interface IImageService
    {
        void SelectImage(Action<byte[]> selected , Action cancelled);

    }

    public class ImageService : IImageService
    {
        private IMvxPictureChooserTask _pictureChooser => Mvx.Resolve<IMvxPictureChooserTask>();


        public void SelectImage(Action<byte[]> selected, Action cancelled)
        {
            _pictureChooser.ChoosePictureFromLibrary(1024, 64, data =>
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
