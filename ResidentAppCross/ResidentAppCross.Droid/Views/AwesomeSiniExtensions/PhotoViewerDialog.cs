using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using ImageViews.Photo;
using ResidentAppCross.Droid.Views.Sections;

namespace ResidentAppCross.Droid.Views.AwesomeSiniExtensions
{
    public class PhotoViewerDialog : DialogFragment
    {
        private PhotoView _imageView;
        private ProgressBar _progressBar;

        public override void OnStart()
        {
            base.OnStart();
            Dialog?.Window?.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
        }

        public ProgressBar ProgressBar
        {
            get
            {
                if (_progressBar == null)
                {
                    _progressBar = new ProgressBar(InflatingContext).WithRelativeCopyOfParent();
                    _progressBar.ProgressDrawable = new ColorDrawable(Color.White);
                    _progressBar.Background = new ShapeDrawable(new OvalShape())
                    {
                        Bounds = new Rect(0, 0, 20, 20),
                        Paint =
                        {
                            Color = AppTheme.SecondaryBackgoundColor
                        }
                    };
                    _progressBar.Alpha = 0.8f;
                }
                return _progressBar;
            }
            set { _progressBar = value; }
        }

        public PhotoView ImageView
        {
            get
            {
                if (_imageView == null)
                {
                    _imageView = new PhotoView(InflatingContext).WithRelativeCopyOfParent();
                    _imageView.SetPadding(0, 0, 0, 0);
                    //_imageView.Visibility = ViewStates.Gone;;
                }
                return _imageView;
            }
            set { _imageView = value; }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            InflatingContext = inflater.Context;
            var layout  = new RelativeLayout(InflatingContext)
            {
            }.WithDimensionsMatchParent();
            layout.AddView(ImageView);
            layout.AddView(ProgressBar);

            if (CurrentUrl != null) SetImage(CurrentUrl, null);
            else if (CurrentData != null) SetImage(CurrentData);
            return layout;
        }

        public Context InflatingContext { get; set; }

        public void SetImage(string src, int placeholderId)
        {
            var placeholder = ContextCompat.GetDrawable(Context, placeholderId);
            SetImage(src, placeholder);
        }

        public async Task SetImage(string src, Drawable placeholder)
        {

            ProgressBar.Alpha = 0;

            var iAnimate = ImageView.Animate();
            iAnimate.SetDuration(300);
            iAnimate.Alpha(0);

            var pAnimate = ProgressBar.Animate();
            pAnimate.SetDuration(300);
            //animate.SetInterpolator(new AccelerateInterpolator(0.3f));
            pAnimate.Alpha(0.8f);

            iAnimate.Start();
            pAnimate.Start();

            var image = await Task.Run(() => ImageExtensions.GetBitmapFromURL(src));
            if (image == null)
            {
                return;
            }

            ImageView.SetImageBitmap(image);

            iAnimate = ImageView.Animate();
            iAnimate.SetDuration(300);
            iAnimate.Alpha(1);

            pAnimate = ProgressBar.Animate();
            pAnimate.SetDuration(300);
            //animate.SetInterpolator(new AccelerateInterpolator(0.3f));
            pAnimate.Alpha(0f);

            iAnimate.Start();
            pAnimate.Start();

        }

        public void SetImage(byte[] data)
        {
            SetImage(data.ToBitmap());
        }

        public void SetImage(Bitmap data)
        {
            ProgressBar.Alpha = 0;
            ImageView.SetImageBitmap(data);
        }

        public string CurrentUrl { get; set; }
        public byte[] CurrentData { get; set; }
    }
}