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
	[Register ("LoginFormView")]
	partial class LoginFormView
	{
		[Outlet]
		UIKit.UIButton ForgotPasswordButton { get; set; }

		[Outlet]
		UIKit.UIButton LoginButton { get; set; }

		[Outlet]
		UIKit.UITextField LoginTextField { get; set; }

		[Outlet]
		UIKit.UITextField PasswordTextField { get; set; }

		[Outlet]
		UIKit.UIButton SignUpButton { get; set; }

		[Outlet]
		UIKit.UILabel VersionLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ForgotPasswordButton != null) {
				ForgotPasswordButton.Dispose ();
				ForgotPasswordButton = null;
			}
			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}
			if (LoginTextField != null) {
				LoginTextField.Dispose ();
				LoginTextField = null;
			}
			if (PasswordTextField != null) {
				PasswordTextField.Dispose ();
				PasswordTextField = null;
			}
			if (VersionLabel != null) {
				VersionLabel.Dispose ();
				VersionLabel = null;
			}
		}
	}
}
