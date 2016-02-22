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
	[Register ("MaintenanceRequestView")]
	partial class MaintenanceRequestView
	{
		[Outlet]
		UIKit.UIButton AddPhotoButton { get; set; }

		[Outlet]
		UIKit.UITextField CommentsTextField { get; set; }

		[Outlet]
		UIKit.UITextView CommentsTextView { get; set; }

		[Outlet]
		UIKit.UISegmentedControl PetTypeSelector { get; set; }

		[Outlet]
		UIKit.UIStackView PhotosContainer { get; set; }

		[Outlet]
		UIKit.UIButton RequestTypeSelectionButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddPhotoButton != null) {
				AddPhotoButton.Dispose ();
				AddPhotoButton = null;
			}

			if (CommentsTextField != null) {
				CommentsTextField.Dispose ();
				CommentsTextField = null;
			}

			if (PetTypeSelector != null) {
				PetTypeSelector.Dispose ();
				PetTypeSelector = null;
			}

			if (RequestTypeSelectionButton != null) {
				RequestTypeSelectionButton.Dispose ();
				RequestTypeSelectionButton = null;
			}

			if (PhotosContainer != null) {
				PhotosContainer.Dispose ();
				PhotosContainer = null;
			}

			if (CommentsTextView != null) {
				CommentsTextView.Dispose ();
				CommentsTextView = null;
			}
		}
	}
}
