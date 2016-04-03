// WARNING
//
// This file has been generated automatically by Xamarin Studio Business to store outlets and
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
		UIKit.UITextField _emailTextField { get; set; }

		[Outlet]
		UIKit.UITextField _firstNameField { get; set; }

		[Outlet]
		UIKit.UITextField _lastNameField { get; set; }

		[Outlet]
		UIKit.UITextField _passwordConfirmationField { get; set; }

		[Outlet]
		UIKit.UITextField _passwordField { get; set; }

		[Outlet]
		UIKit.UITextField _phoneNumberField { get; set; }

		[Outlet]
		UIKit.UIButton _signUpButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_emailTextField != null) {
				_emailTextField.Dispose ();
				_emailTextField = null;
			}

			if (_phoneNumberField != null) {
				_phoneNumberField.Dispose ();
				_phoneNumberField = null;
			}

			if (_passwordConfirmationField != null) {
				_passwordConfirmationField.Dispose ();
				_passwordConfirmationField = null;
			}

			if (_passwordField != null) {
				_passwordField.Dispose ();
				_passwordField = null;
			}

			if (_signUpButton != null) {
				_signUpButton.Dispose ();
				_signUpButton = null;
			}

			if (_firstNameField != null) {
				_firstNameField.Dispose ();
				_firstNameField = null;
			}

			if (_lastNameField != null) {
				_lastNameField.Dispose ();
				_lastNameField = null;
			}
		}
	}
}
