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
			if (_textView != null) {
				_textView.Dispose ();
				_textView = null;
			}
			if (_textViewContainer != null) {
				_textViewContainer.Dispose ();
				_textViewContainer = null;
			}
		}
	}
}
