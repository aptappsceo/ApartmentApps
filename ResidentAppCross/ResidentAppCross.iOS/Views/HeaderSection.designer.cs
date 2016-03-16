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
	[Register ("HeaderSection")]
	partial class HeaderSection
	{
		[Outlet]
		UIKit.NSLayoutConstraint HeaderBottomAlignmentConstraint { get; set; }

		[Outlet]
		UIKit.UILabel HeaderLabel { get; set; }

		[Outlet]
		UIKit.UIImageView LogoImageView { get; set; }

		[Outlet]
		UIKit.UILabel SubHeaderLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (HeaderBottomAlignmentConstraint != null) {
				HeaderBottomAlignmentConstraint.Dispose ();
				HeaderBottomAlignmentConstraint = null;
			}

			if (HeaderLabel != null) {
				HeaderLabel.Dispose ();
				HeaderLabel = null;
			}

			if (LogoImageView != null) {
				LogoImageView.Dispose ();
				LogoImageView = null;
			}

			if (SubHeaderLabel != null) {
				SubHeaderLabel.Dispose ();
				SubHeaderLabel = null;
			}
		}
	}
}
