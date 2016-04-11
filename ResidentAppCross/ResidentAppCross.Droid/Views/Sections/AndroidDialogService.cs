using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Plugins.PictureChooser;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Services;

namespace ResidentAppCross.Droid.Views.Sections
{
    public class AndroidDialogService : IDialogService
    {

        private Application _droidApp;
        private IMvxPictureChooserTask _pictureChooserTask;

        public Activity CurrentTopActivity => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

        public IMvxPictureChooserTask PictureChooserTask
        {
            get { return _pictureChooserTask ?? (_pictureChooserTask = Mvx.Resolve<IMvxPictureChooserTask>()); }
            set { _pictureChooserTask = value; }
        }

        public AndroidDialogService(Application droidApp)
        {
            _droidApp = droidApp;
        }

        public Task<T> OpenSearchableTableSelectionDialog<T>(IList<T> items, string title, Func<T, string> itemTitleSelector,
            Func<T, string> itemSubtitleSelector = null, object arg = null)
        {
            throw new NotImplementedException();
        }

        public Task<DateTime?> OpenDateTimeDialog(string title)
        {
            throw new NotImplementedException();
        }

        public Task<DateTime?> OpenDateDialog(string title)
        {
            throw new NotImplementedException();
        }

        public static int ImageDialogResult = 288823;

        public async Task<byte[]> OpenImageDialog()
        {
            var stream = await PictureChooserTask.ChoosePictureFromLibrary(1024, 62);
            if (stream == null) return null;
            byte[] buffer = new byte[stream.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public void OpenNotification(string title, string subtitle, string ok)
        {
            throw new NotImplementedException();
        }

        public void OpenImageFullScreen(object imageObject)
        {
            var data = imageObject as byte[];
            var frag = new PhotoViewerDialog() {CurrentData = data};
            frag.Show(CurrentTopActivity.FragmentManager, "Photo Viewer");
        }

        public void OpenImageFullScreenFromUrl(string url)
        {
            var frag = new PhotoViewerDialog() { CurrentUrl = url };
            frag.Show(CurrentTopActivity.FragmentManager, "Photo Viewer");
        }

    
    }
}