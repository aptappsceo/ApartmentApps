using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using ObjCRuntime;
using ResidentAppCross.iOS.Extensions;
using ResidentAppCross.ViewModels;
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
            var photo = Photos.RawImages[indexPath.Row].Data;
            photoCell.ImageView.Image = photo.ToImage();
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
