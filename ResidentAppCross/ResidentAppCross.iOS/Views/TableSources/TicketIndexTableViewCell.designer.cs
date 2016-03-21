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
	[Register ("TicketIndexTableViewCell")]
	partial class TicketIndexTableViewCell
	{
		[Outlet]
		UIKit.UILabel _commentsLabel { get; set; }

		[Outlet]
		UIKit.UILabel _dateLabel { get; set; }

		[Outlet]
		UIKit.UIImageView _headerIcon { get; set; }

		[Outlet]
		UIKit.UILabel _headerLabel { get; set; }

		[Outlet]
		UIKit.UILabel _noPhotosLabel { get; set; }

		[Outlet]
		UIKit.UICollectionView _photoContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_headerIcon != null) {
				_headerIcon.Dispose ();
				_headerIcon = null;
			}

			if (_commentsLabel != null) {
				_commentsLabel.Dispose ();
				_commentsLabel = null;
			}

			if (_headerLabel != null) {
				_headerLabel.Dispose ();
				_headerLabel = null;
			}

			if (_noPhotosLabel != null) {
				_noPhotosLabel.Dispose ();
				_noPhotosLabel = null;
			}

			if (_photoContainer != null) {
				_photoContainer.Dispose ();
				_photoContainer = null;
			}

			if (_dateLabel != null) {
				_dateLabel.Dispose ();
				_dateLabel = null;
			}
		}
	}
}
