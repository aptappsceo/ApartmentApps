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
	[Register ("MaintenancePauseFormView")]
	partial class MaintenancePauseFormView
	{
		[Outlet]
		UIKit.UITextView CommentsTextView { get; set; }

		[Outlet]
		UIKit.UICollectionView PhotoContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
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
