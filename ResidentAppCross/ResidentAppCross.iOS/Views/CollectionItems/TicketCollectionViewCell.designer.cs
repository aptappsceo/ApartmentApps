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
	[Register ("TicketCollectionViewCell")]
	partial class TicketCollectionViewCell
	{
		[Outlet]
		UIKit.UILabel _noPhotoLabel { get; set; }

		[Outlet]
		UIKit.UICollectionView _photoContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_noPhotoLabel != null) {
				_noPhotoLabel.Dispose ();
				_noPhotoLabel = null;
			}

			if (_photoContainer != null) {
				_photoContainer.Dispose ();
				_photoContainer = null;
			}
		}
	}
}
