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
	[Register ("TextFieldSection")]
	partial class TextFieldSection
	{
		[Outlet]
		UIKit.UITextField _textField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_textField != null) {
				_textField.Dispose ();
				_textField = null;
			}
		}
	}
}
