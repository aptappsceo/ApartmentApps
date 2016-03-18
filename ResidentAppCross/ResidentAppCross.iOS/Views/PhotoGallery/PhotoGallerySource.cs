using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using ObjCRuntime;
using ResidentAppCross.iOS.Extensions;
using ResidentAppCross.ViewModels;
using SDWebImage;
using UIKit;

namespace ResidentAppCross.iOS.Views.PhotoGallery
{
    class PhotoGallerySource : UICollectionViewSource
    {
        private ImageBundleViewModel _photos;

        public ImageBundleViewModel Photos
        {
            get { return _photos ?? (_photos = new ImageBundleViewModel()); }
            set { _photos = value; }
        }

        public PhotoGallerySource()
        {
        }

        public PhotoGallerySource(ImageBundleViewModel photos)
        {
            Photos = photos;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var photoCell = (PhotoGalleryCells)collectionView.DequeueReusableCell((NSString)PhotoGalleryCells.CellIdentifier, indexPath);
            var photo = Photos.RawImages[indexPath.Row];

			photoCell.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

			photoCell.AutosizesSubviews = true;
            photoCell.TranslatesAutoresizingMaskIntoConstraints = false;
			photoCell.ImageView.ClipsToBounds = true;
			photoCell.ImageView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			photoCell.LayoutIfNeeded ();
			photoCell.LayoutSubviews ();
			if (photo.Data != null)
            {
                photoCell.ImageView.Image = photo.Data.ToImage();
            }
            else
            {
                photoCell.ImageView.SetImage(
                    url: new NSUrl(photo.Uri.ToString()),
					placeholder: UIImage.FromBundle("HouseIcon"),
					completedBlock: (image, error, type, url) =>{
						photoCell.LayoutIfNeeded ();
						photoCell.LayoutSubviews ();
					}

                );
            }

            return photoCell;

        }


        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return Photos.RawImages.Count;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

//        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
//        {
//            var cell = collectionView.CellForItem(indexPath);
//            cell.ContentView.BackgroundColor = UIColor.Yellow;
//        }
//
//        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
//        {
//            var cell = collectionView.CellForItem(indexPath);
//            cell.ContentView.BackgroundColor = UIColor.White;
//        }

    }
}
