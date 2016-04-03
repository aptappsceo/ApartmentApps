using CoreGraphics;
using Foundation;
using MvvmCross.Platform;
using ResidentAppCross.Services;
using UIKit;

namespace ResidentAppCross.iOS.Views.PhotoGallery
{
    public class PhotoGalleryCells : UICollectionViewCell
    {
        private UIImageView _imageView;
        public const string CellIdentifier = "PhotoGalleryImageCell";

        [Export("initWithFrame:")]
        public PhotoGalleryCells(System.Drawing.RectangleF frame) : base(frame)
        {
            this.Initialize();
        }

        public UIImageView ImageView
        {
            get { return _imageView; }
            set
            {
                _imageView = value;

                _imageView?.Shadow(
                    UIColor.Black, 
                    new CGSize(2, 2),
                    0.5f,
                    2f);

            }
        }

        public string LoadingUrl { get; set; }
        private void Initialize()
        {
            this.ImageView = new UIImageView (this.ContentView.Bounds);
                //Uncomment to debug cell images issues
            //ImageView.BackgroundColor = UIColor.Blue;
            this.ContentView.AddSubview(this.ImageView);
            ClipsToBounds = false;

            this.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                if (string.IsNullOrEmpty(LoadingUrl)) return;
                Mvx.Resolve<IDialogService>().OpenImageFullScreenFromUrl(LoadingUrl);
            }));


        }
    }
}