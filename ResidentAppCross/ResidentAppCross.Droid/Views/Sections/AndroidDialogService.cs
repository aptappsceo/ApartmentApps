using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Plugins.PictureChooser;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Services;
using Square.OkHttp;

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

        public IMvxMainThreadDispatcher Dispatcher => Mvx.Resolve<IMvxMainThreadDispatcher>();

        public AndroidDialogService(Application droidApp)
        {
            _droidApp = droidApp;
        }

        public Task<T> OpenSearchableTableSelectionDialog<T>(IList<T> items, string title, Func<T, string> itemTitleSelector,
            Func<T, string> itemSubtitleSelector = null, object arg = null)
        {

            return Task.Factory.StartNew(() =>
            {

                T result = default(T);


                ManualResetEvent waitForCompleteEvent = new ManualResetEvent(false);

                Dispatcher.RequestMainThreadAction(() => { 

                    var frag = new SearchDialog<T>()
                    {
                        Items = items,
                        TitleSelector = itemTitleSelector,
                    };

                    frag.OnItemSelected += obj =>
                    {
                        result = obj;
                        waitForCompleteEvent.Set();
                    };
    
                    frag.Show(CurrentTopActivity.FragmentManager, "Search Dialog");


                });

                waitForCompleteEvent.WaitOne();
                return result;

            });



        }

        public Task<DateTime?> OpenDateTimeDialog(string title)
        {
            return Task.Factory.StartNew(() =>
            {

                DateTime? result = null;


                ManualResetEvent waitForCompleteEvent = new ManualResetEvent(false);

                Dispatcher.RequestMainThreadAction(() => {

                    var frag = new DateTimePickerDialog()
                    {
                    };

                    frag.DateTimeSelected += obj =>
                    {
                        result = obj;
                        waitForCompleteEvent.Set();
                        frag.Dismiss();
                    };

                    frag.Show(CurrentTopActivity.FragmentManager, "Date Time Picker");

                });

                waitForCompleteEvent.WaitOne();
                return result;

            });

        }

        public Task<DateTime?> OpenDateDialog(string title)
        {
            throw new NotImplementedException();
        }

        public static int ImageDialogResult = 288823;

        public Task<byte[]> OpenImageDialog()
        {
            return Task.Factory.StartNew(() =>
            {

                byte[] result = null;

                ManualResetEvent waitForCompleteEvent = new ManualResetEvent(false);

                Dispatcher.RequestMainThreadAction(() => {

                var frag = new NotificationDialog
                {
                    TitleText = "Select Photo Source",
                    Mode = NotificationDialogMode.Select
                };
                frag.SetActions(new[]
                    {
                        new NotificationDialogItem()
                        {
                            Action = async () =>
                            {
                                result = await OpenImageTakeDialog();
                                waitForCompleteEvent.Set();
                            }, Title = "Take Photo",
                            ShouldDismiss = true
                        }, new NotificationDialogItem()
                        {
                            Action = async () =>
                            {
                                result = await OpenImagePickDialog();
                                waitForCompleteEvent.Set();
                            }, Title = "Select Photo",
                            ShouldDismiss = true
                        }, new NotificationDialogItem()
                        {
                            Action = ()=> { },
                            Title = "Cancel",
                            ShouldDismiss = true
                        }, 
                    });

                    frag.Show(CurrentTopActivity.FragmentManager, "Image Pick Dialog");

                });

                waitForCompleteEvent.WaitOne();
                return result;

            });
        }

        public async Task<byte[]> OpenImagePickDialog()
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


        public async Task<byte[]> OpenImageTakeDialog()
        {
            var stream = await PictureChooserTask.TakePicture(1024, 62);
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


        public void OpenNotification(string title, string subtitle, string ok, Action action = null)
        {

            if(action != null) throw new Exception("Handler is not currently supported on droid");

            var frag = new NotificationDialog()
            {
                
            };

            frag.Mode = NotificationDialogMode.Notify;
            frag.TitleText = title;
            frag.SubTitleText = subtitle;
            

            frag.SetActions(new NotificationDialogItem[]
            {
                new NotificationDialogItem()
                {
                    Action = () =>
                    {
                    }, Title = ok,
                    ShouldDismiss = true
                }
            });

            frag.Show(CurrentTopActivity.FragmentManager, "Notification Dialog");
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

        public void OpenUrl(string url)
        {
            Intent browserIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(url));
            CurrentTopActivity.StartActivity(browserIntent);
        }
    }
}