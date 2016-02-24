using Foundation;
using UIKit;

namespace ResidentAppCross.iOS.Views.PhotoGallery
{
    public class ImageCell : UICollectionViewCell
    {
        public const string CellIdentifier = "PhotoGalleryImageCell";

        [Export("initWithFrame:")]
        public ImageCell(System.Drawing.RectangleF frame) : base(frame)
        {
            this.Initialize();
        }

        public UIImageView ImageView { get; set; }

        private void Initialize()
        {
            //          this.ImageView = new UIImageView (this.ContentView.Bounds);
            this.ImageView = new UIImageView(UIImage.FromBundle("HouseIcon"));
            this.ContentView.AddSubview(this.ImageView);
        }
    }
}