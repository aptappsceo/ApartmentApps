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
	[Register ("SegmentSelectionSection")]
	partial class SegmentSelectionSection
	{
		[Outlet]
		UIKit.NSLayoutConstraint _headerHeightConstraint { get; set; }

		[Outlet]
		UIKit.UILabel _headerTitle { get; set; }

		[Outlet]
		UIKit.UISegmentedControl _segmentSelector { get; set; }

		[Outlet]
		UIKit.UILabel HeaderLabel { get; set; }

		[Outlet]
		UIKit.UISegmentedControl SegmentSelector { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_headerHeightConstraint != null) {
				_headerHeightConstraint.Dispose ();
				_headerHeightConstraint = null;
			}

			if (_headerTitle != null) {
				_headerTitle.Dispose ();
				_headerTitle = null;
			}

			if (_segmentSelector != null) {
				_segmentSelector.Dispose ();
				_segmentSelector = null;
			}

			if (HeaderLabel != null) {
				HeaderLabel.Dispose ();
				HeaderLabel = null;
			}

			if (SegmentSelector != null) {
				SegmentSelector.Dispose ();
				SegmentSelector = null;
			}
		}
	}
}
