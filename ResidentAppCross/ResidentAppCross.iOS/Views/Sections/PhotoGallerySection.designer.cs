// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ResidentAppCross.iOS
{
	[Register ("PhotoGallerySection")]
	partial class PhotoGallerySection
	{
		[Outlet]
		UIKit.UIButton _addPhotoButton { get; set; }

		[Outlet]
		UIKit.UILabel _headerLabel { get; set; }

		[Outlet]
		UIKit.UICollectionView _photoContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_photoContainer != null) {
				_photoContainer.Dispose ();
				_photoContainer = null;
			}

			if (_headerLabel != null) {
				_headerLabel.Dispose ();
				_headerLabel = null;
			}

			if (_addPhotoButton != null) {
				_addPhotoButton.Dispose ();
				_addPhotoButton = null;
			}
		}
	}
}
