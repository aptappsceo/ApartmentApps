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
	[Register ("MaintenanceRequestFormView")]
	partial class MaintenanceRequestFormView
	{
		[Outlet]
		UIKit.UIButton AddPhotoButton { get; set; }

		[Outlet]
		UIKit.UITextView CommentsTextView { get; set; }

		[Outlet]
		UIKit.UISegmentedControl PetTypeSelection { get; set; }

		[Outlet]
		UIKit.UICollectionView PhotoContainer { get; set; }

		[Outlet]
		UIKit.UIButton SelectRequestTypeButton { get; set; }

		[Action ("AddPhotoStuffPressed:")]
		partial void AddPhotoStuffPressed (UIKit.UIButton sender);

		[Action ("PetTypeChanged:")]
		partial void PetTypeChanged (UIKit.UISegmentedControl sender);

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
			if (PetTypeSelection != null) {
				PetTypeSelection.Dispose ();
				PetTypeSelection = null;
			}
			if (PhotoContainer != null) {
				PhotoContainer.Dispose ();
				PhotoContainer = null;
			}
			if (SelectRequestTypeButton != null) {
				SelectRequestTypeButton.Dispose ();
				SelectRequestTypeButton = null;
			}
		}
	}
}
