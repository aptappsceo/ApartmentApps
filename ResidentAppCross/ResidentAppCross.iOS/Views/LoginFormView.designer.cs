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
		UIKit.UIButton _signUpButton { get; set; }

		[Outlet]
		UIKit.UIView _textFieldsContainer { get; set; }

		[Outlet]
		UIKit.UILabel AppTitleLabel { get; set; }

		[Outlet]
		UIKit.UILabel AppVersionLabel { get; set; }

		[Outlet]
		UIKit.UIButton ForgotPasswordButton { get; set; }

		[Outlet]
		UIKit.UIButton LoginButton { get; set; }

		[Outlet]
		UIKit.UIImageView LoginImage { get; set; }

		[Outlet]
		UIKit.UITextField LoginTextField { get; set; }

		[Outlet]
		UIKit.UILabel NewHereLabel { get; set; }

		[Outlet]
		UIKit.UITextField PasswordTextField { get; set; }

		[Outlet]
		UIKit.UILabel VersionLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_signUpButton != null) {
				_signUpButton.Dispose ();
				_signUpButton = null;
			}

			if (_textFieldsContainer != null) {
				_textFieldsContainer.Dispose ();
				_textFieldsContainer = null;
			}

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

			if (AppTitleLabel != null) {
				AppTitleLabel.Dispose ();
				AppTitleLabel = null;
			}

			if (AppVersionLabel != null) {
				AppVersionLabel.Dispose ();
				AppVersionLabel = null;
			}

			if (NewHereLabel != null) {
				NewHereLabel.Dispose ();
				NewHereLabel = null;
			}

			if (LoginImage != null) {
				LoginImage.Dispose ();
				LoginImage = null;
			}
		}
	}
}
