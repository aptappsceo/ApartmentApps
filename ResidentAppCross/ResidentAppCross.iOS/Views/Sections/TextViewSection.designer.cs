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
	[Register ("TextViewSection")]
	partial class TextViewSection
	{
		[Outlet]
		UIKit.UILabel _headerLabel { get; set; }

		[Outlet]
		UIKit.UITextView _textView { get; set; }

		[Outlet]
		UIKit.UIView _textViewContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_headerLabel != null) {
				_headerLabel.Dispose ();
				_headerLabel = null;
			}

			if (_textViewContainer != null) {
				_textViewContainer.Dispose ();
				_textViewContainer = null;
			}

			if (_textView != null) {
				_textView.Dispose ();
				_textView = null;
			}
		}
	}
}
