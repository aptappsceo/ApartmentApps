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
	[Register ("MaintenanceRequestView")]
	partial class MaintenanceRequestView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton AddPhotoButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField CommentsTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISegmentedControl PetTypeSelector { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton RequestTypeSelectionButton { get; set; }

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
		}
	}
}
