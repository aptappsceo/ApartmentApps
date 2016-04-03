using CoreGraphics;
using Foundation;
using MvvmCross.Platform;
using ResidentAppCross.Services;
using SDWebImage;
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

        public void SetImage(UIImage image)
        {
            ActivityIndicator?.RemoveFromSuperview();
            ImageView.Image = image;
            LoadingUrl = null;
        }

        public void SetImageFromUrl(string loadingUrl)
        {
            if (loadingUrl == LoadingUrl) return;
            ActivityIndicator?.RemoveFromSuperview();
            ActivityIndicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.White);
            ActivityIndicator.Color = UIColor.White;
            ActivityIndicator.BackgroundColor = UIColor.Black.ColorWithAlpha(0.7f);
            ImageView.AddSubview(ActivityIndicator);
            ActivityIndicator.Frame = ImageView.Bounds;
            ActivityIndicator.HidesWhenStopped = true;
            ActivityIndicator.StartAnimating();

            //using (var data = NSData.FromUrl(new NSUrl(ViewModel.ProfileImageUrl)))
            CurrentUrl = loadingUrl;
            ImageView.SetImage(
                url: new NSUrl(loadingUrl),
                placeholder: UIImage.FromFile("avatar-placeholder.png"),
                completedBlock: (image, error, type, url) =>
                {
                    UIView.Animate(0.4f, () =>
                    {
                        ActivityIndicator.Alpha = 0;

                    }, () => { ActivityIndicator.RemoveFromSuperview(); });
                    //activityIndicator.RemoveFromSuperview();
                });
            
        }

        public string CurrentUrl { get; set; }

        public UIActivityIndicatorView ActivityIndicator { get; set; }
    }
}