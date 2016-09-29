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

            if (AppTitleLabel != null) {
                AppTitleLabel.Dispose ();
                AppTitleLabel = null;
            }

            if (AppVersionLabel != null) {
                AppVersionLabel.Dispose ();
                AppVersionLabel = null;
            }

            if (ForgotPasswordButton != null) {
                ForgotPasswordButton.Dispose ();
                ForgotPasswordButton = null;
            }

            if (LoginButton != null) {
                LoginButton.Dispose ();
                LoginButton = null;
            }

            if (LoginImage != null) {
                LoginImage.Dispose ();
                LoginImage = null;
            }

            if (LoginTextField != null) {
                LoginTextField.Dispose ();
                LoginTextField = null;
            }

            if (NewHereLabel != null) {
                NewHereLabel.Dispose ();
                NewHereLabel = null;
            }

            if (PasswordTextField != null) {
                PasswordTextField.Dispose ();
                PasswordTextField = null;
            }
        }
    }
}