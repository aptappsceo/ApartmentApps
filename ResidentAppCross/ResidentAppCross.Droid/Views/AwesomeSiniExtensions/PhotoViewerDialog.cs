using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
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
                    _progressBar = new ProgressBar(InflatingContext).WithRelativeCenterInParent();
                    _progressBar.IndeterminateDrawable.SetColorFilter(Color.White,PorterDuff.Mode.Multiply);
                    _progressBar.Background = new ShapeDrawable(new OvalShape())
                    {
                        Bounds = new Rect(0, 0, 20, 20),
                        Paint =
                        {
                            Color = Resources.GetColor(Resource.Color.primary)
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
            ProgressBar.WithDimensions(120);
            Point point = new Point();
            Dialog.Window.WindowManager.DefaultDisplay.GetSize(point);
            TargetWidth = point.X;
            if (CurrentUrl != null) SetImage(CurrentUrl, null);
            else if (CurrentData != null) SetImage(CurrentData);
            return layout;
        }

        public int TargetWidth { get; set; }

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

            var image = await Task.Run(() =>
            {
                    return ImageExtensions.GetBitmapWithPicasso(src).Resize(TargetWidth, 0).Get();
            });
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