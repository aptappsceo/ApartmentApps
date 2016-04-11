using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Grantland.Widget;
using Java.Net;
using Java.Util;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Views;
using MvvmCross.Platform.Platform;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using IOException = Java.IO.IOException;
using Object = Java.Lang.Object;

namespace ResidentAppCross.Droid.Views.Sections
{
    public class PhotoGallerySection : BaseSection
    {
        private LinearLayout _sectionContainer;
        private TextView _sectionHeader;
        private Button _button;
        private string _headerText;
        private string _buttonText;
        private LinearLayout _headerlineContainer;
        private RecyclerView _photosContainer;

        public PhotoGallerySection(Context context) : base(context)
        {

        }

        public override int SectionHeight { get; set; } = AppTheme.SingleLineSection;

        public override ViewGroup ContentView => SectionContainer;

        public RecyclerView PhotosContainer
        {
            get
            {
                if (_photosContainer == null)
                {
                    _photosContainer = new RecyclerView(Context)
                    {
                        
                    }
                    .WithWidthMatchParent()
                        .WithHeight(120);
                    _photosContainer.VerticalScrollBarEnabled = true;
                    _photosContainer.SetLayoutManager(new StaggeredGridLayoutManager(2,StaggeredGridLayoutManager.Horizontal));

//                    _photosContainer.SetNumColumns(3);
//                    _photosContainer.SetDrawSelectorOnTop(true);
//                    _photosContainer.StretchMode = StretchMode.StretchColumnWidth;
//                    _photosContainer.Focusable = true;
//                    _photosContainer.Clickable = true;
//                    _photosContainer.SetGravity(GravityFlags.Center);
//                    _photosContainer.SetColumnWidth(100.ToPx());
//                    _photosContainer.SetVerticalSpacing(5.ToPx());
//                    _photosContainer.SetHorizontalSpacing(5.ToPx());
//                    _photosContainer.EnsureLinearLayoutParams().TopMargin = 8.ToPx();
//
//                    _photosContainer.ItemClick += (sender, args) =>
//                    {
//                        var image = Photos.RawImages[(int)args.Id];
//                        if (image.Data != null)
//                        {
//                            Mvx.Resolve<IDialogService>().OpenImageFullScreen(image.Data);
//                        }
//                        else if(image.Uri != null)
//                        {
//                            Mvx.Resolve<IDialogService>().OpenImageFullScreenFromUrl(image.Uri.ToString());
//                        }
//                    };

                }
                return _photosContainer;
            }
            set { _photosContainer = value; }
        }

        public LinearLayout SectionContainer
        {
            get
            {
                if (_sectionHeader == null)
                {
                    _sectionContainer = new LinearLayout(Context)
                    {
                        Orientation = Orientation.Vertical,
                        Background = new ColorDrawable(Color.White),
                    }
                        .WithWidthMatchParent()
                        .WithHeightWrapContent()
                        .WithStandardPadding();

                    _sectionContainer.AddView(HeadlineContainer);
                    _sectionContainer.AddView(PhotosContainer);
                }
                return _sectionContainer;
            }
            set { _sectionContainer = value; }
        }

        public LinearLayout HeadlineContainer
        {
            get
            {
                if (_headerlineContainer == null)
                {
                    _headerlineContainer = new LinearLayout(Context)
                    {
                        Orientation = Orientation.Horizontal,
                    }
                        .WithWidthMatchParent()
                        .WithHeight(AppTheme.SectionHeadlineHeight);

                    _headerlineContainer.AddView(SectionHeader);
                    _headerlineContainer.AddView(new Space(Context).WithDimensionsMatchParent().WithLinearWeight(1));
                    _headerlineContainer.AddView(Button);
                }
                return _headerlineContainer;
            }
            set { _headerlineContainer = value; }
        }

        public TextView SectionHeader
        {
            get
            {
                if (_sectionHeader == null)
                {
                    _sectionHeader = new TextView(Context)
                    {
                        Gravity = GravityFlags.CenterVertical | GravityFlags.Left,
                        Text = HeaderText,
                    }
                        .WithWidthWrapContent()
                        .WithHeightWrapContent()
                        .WithFont(AppFonts.SectionHeadline);
                }
                return _sectionHeader;
            }
            set { _sectionHeader = value; }
        }

        public string HeaderText
        {
            get { return _headerText; }
            set
            {
                _headerText = value;
                if (_sectionHeader != null) _sectionHeader.Text = value;
            }
        }

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                if (_button != null) _button.Text = value;
            }
        }

        public PhotoGalleryAdapter Adapter { get; private set; }
        public ImageBundleViewModel Photos { get; private set; }

        public void BindTo(ImageBundleViewModel bundle)
        {
            Photos = bundle;
            Adapter = new PhotoGalleryAdapter(bundle);
            PhotosContainer.SetAdapter(Adapter);
        }

        public Button Button
        {
            get
            {
                if (_button == null)
                {
                    _button = new Button(Context)
                    {
                        Gravity = GravityFlags.Center
                    }
                              .WithPaddingDp(8, 0, 8, 0)
                              .WithFont(AppFonts.SectionSubHeadlineInvert)
                              .WithWidthWrapContent()
                              .WithHeightMatchParent()
                              .WithBackgroundColor(AppTheme.SecondaryBackgoundColor);
                    _button.Text = _buttonText;
                    _button.Click += async (sender, args) =>
                    {
                        await AddPhoto();
                        Toast.MakeText(Context, "Photo Added", ToastLength.Short);
                    };
                }
                return _button;
            }
            set { _button = value; }
        }

        public async Task AddPhoto()
        {
            var service = Mvx.Resolve<IDialogService>();
            var photo = await service.OpenImageDialog();
            if (photo != null)
            {
                Photos.RawImages.Add(new ImageBundleItemViewModel() { Data = photo });
            }
            Adapter.NotifyDataSetChanged();
        }

    }

    public class PhotoGalleryAdapter : RecyclerView.Adapter
    {

        private ImageBundleViewModel photos;

        public PhotoGalleryAdapter(ImageBundleViewModel misFotos)
        {
            photos = misFotos;
        }

        public int? ItemHeight;

        public Object GetItem(int position)
        {
            return null;
        }

        public int GetCount()
        {
            return photos.RawImages.Count;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var view = (holder as GenericViewHolder<AsyncImageView>)?.View;
            if (view == null) return;
            var photo = photos.RawImages[position];
            if (photo.Uri != null)
            { 
                view.SetImage(photo.Uri.ToString(), null);
            }
            else if (photo.Data != null)
            {
                view.SetImage(photo.Data);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var item = new AsyncImageView(parent.Context).WithHeightWrapContent().WithWidth(150);
            var viewHolder = new GenericViewHolder<AsyncImageView>(item);
            return viewHolder;
        }

        public override int ItemCount => photos.RawImages.Count;

    }


    public class GenericViewHolder<T> : RecyclerView.ViewHolder where T : class
    {
        public T View { get; set; }

        public GenericViewHolder(View itemView) : base(itemView)
        {
            var view = itemView as T;
            if(view == null) throw new Exception("Fuck");
            View = view;
        }

    }

    public class AsyncImageView : FrameLayout
    {
        private ImageView _imageView;
        private ProgressBar _progressBar;

        public AsyncImageView(Context context) : base(context)
        {
            this.AddView(ImageView);
            this.AddView(ProgressBar);
        }

        public ProgressBar ProgressBar
        {
            get
            {
                if (_progressBar == null)
                {
                    _progressBar = new ProgressBar(Context);
                    _progressBar.WithDimensionsMatchParent();
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

        public ImageView ImageView
        {
            get
            {
                if (_imageView == null)
                {
                    _imageView = new ImageView(Context).WithDimensionsWrapContent();
                    _imageView.SetScaleType(ImageView.ScaleType.FitCenter);
                    _imageView.SetPadding(0, 0, 0, 0);
                    //_imageView.Visibility = ViewStates.Gone;;
                }
                return _imageView;
            }
            set { _imageView = value; }
        }

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

            var image = await Task.Run(()=>ImageExtensions.GetBitmapFromURL(src));
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
            ProgressBar.Alpha = 0;
            ImageView.SetImageBitmap(data.ToBitmap());
        }
    }


    public static class ImageExtensions
    {

        public static Bitmap GetBitmapFromURL(string src)
        {
            try
            {
                URL url = new URL(src);
                HttpURLConnection connection = (HttpURLConnection)url.OpenConnection();
                connection.DoInput = true;
                connection.Connect();
                Bitmap myBitmap = BitmapFactory.DecodeStream(connection.InputStream);
                return myBitmap;
            }
            catch (IOException e)
            {
                // Log exception
                return null;
            }
        }

        public static Bitmap ToBitmap(this byte[] data)
        {
            return BitmapFactory.DecodeByteArray(data, 0, data.Length, new BitmapFactory.Options { InMutable = true });
        }
    }

}