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
	[Register ("SignUpFormView")]
	partial class SignUpFormView
	{
		[Outlet]
		UIKit.UITextField _birthdayField { get; set; }

		[Outlet]
		UIKit.UITextField _emailTextField { get; set; }

		[Outlet]
		UIKit.UITextField _firstLastNameTextField { get; set; }

		[Outlet]
		UIKit.UITextField _passwordConfirmationField { get; set; }

		[Outlet]
		UIKit.UITextField _passwordField { get; set; }

		[Outlet]
		UIKit.UIButton _signUpButton { get; set; }

		[Outlet]
		UIKit.UITextField _usernameField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_firstLastNameTextField != null) {
				_firstLastNameTextField.Dispose ();
				_firstLastNameTextField = null;
			}

			if (_emailTextField != null) {
				_emailTextField.Dispose ();
				_emailTextField = null;
			}

			if (_birthdayField != null) {
				_birthdayField.Dispose ();
				_birthdayField = null;
			}

			if (_usernameField != null) {
				_usernameField.Dispose ();
				_usernameField = null;
			}

			if (_passwordField != null) {
				_passwordField.Dispose ();
				_passwordField = null;
			}

			if (_passwordConfirmationField != null) {
				_passwordConfirmationField.Dispose ();
				_passwordConfirmationField = null;
			}

			if (_signUpButton != null) {
				_signUpButton.Dispose ();
				_signUpButton = null;
			}
		}
	}
}
