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
			if (LoginTextField != null) {
				LoginTextField.Dispose ();
				LoginTextField = null;
			}

			if (PasswordTextField != null) {
				PasswordTextField.Dispose ();
				PasswordTextField = null;
			}

			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}

			if (ForgotPasswordButton != null) {
				ForgotPasswordButton.Dispose ();
				ForgotPasswordButton = null;
			}

			if (VersionLabel != null) {
				VersionLabel.Dispose ();
				VersionLabel = null;
			}

			if (SignUpButton != null) {
				SignUpButton.Dispose ();
				SignUpButton = null;
			}
		}
	}
}
