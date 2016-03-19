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
