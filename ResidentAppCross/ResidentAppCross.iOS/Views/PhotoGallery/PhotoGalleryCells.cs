using Foundation;
using UIKit;

namespace ResidentAppCross.iOS.Views.PhotoGallery
{
    public class PhotoGalleryCells : UICollectionViewCell
    {
        public const string CellIdentifier = "PhotoGalleryImageCell";

        [Export("initWithFrame:")]
        public PhotoGalleryCells(System.Drawing.RectangleF frame) : base(frame)
        {
            this.Initialize();
        }

        public UIImageView ImageView { get; set; }

        private void Initialize()
        {
            this.ImageView = new UIImageView (this.ContentView.Bounds);
            this.ContentView.AddSubview(this.ImageView);
        }
    }
}