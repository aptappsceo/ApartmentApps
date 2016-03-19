// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

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
			if (_addPhotoButton != null) {
				_addPhotoButton.Dispose ();
				_addPhotoButton = null;
			}
			if (_headerLabel != null) {
				_headerLabel.Dispose ();
				_headerLabel = null;
			}
			if (_photoContainer != null) {
				_photoContainer.Dispose ();
				_photoContainer = null;
			}
		}
	}
}
