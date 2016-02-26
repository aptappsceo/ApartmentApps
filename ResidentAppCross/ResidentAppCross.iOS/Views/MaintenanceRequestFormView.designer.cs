// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ResidentAppCross.iOS.Views
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
