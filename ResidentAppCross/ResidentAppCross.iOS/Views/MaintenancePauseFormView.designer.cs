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
	[Register ("MaintenancePauseFormView")]
	partial class MaintenancePauseFormView
	{
		[Outlet]
		UIKit.UIButton AddPhotoButton { get; set; }

		[Outlet]
		UIKit.UITextView CommentsTextView { get; set; }

		[Outlet]
		UIKit.UICollectionView PhotoContainer { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AddPhotoButton != null) {
				AddPhotoButton.Dispose ();
				AddPhotoButton = null;
			}
			if (CommentsTextView != null) {
				CommentsTextView.Dispose ();
				CommentsTextView = null;
			}
			if (PhotoContainer != null) {
				PhotoContainer.Dispose ();
				PhotoContainer = null;
			}
		}
	}
}
