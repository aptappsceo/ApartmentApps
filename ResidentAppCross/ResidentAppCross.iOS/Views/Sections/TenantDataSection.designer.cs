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
    [Register ("TenantDataSection")]
    partial class TenantDataSection
    {
        [Outlet]
        UIKit.UILabel _addressLabel { get; set; }


        [Outlet]
        UIKit.UILabel _headerLabel { get; set; }


        [Outlet]
        UIKit.UIImageView _phoneIcon { get; set; }


        [Outlet]
        UIKit.UILabel _phoneLabel { get; set; }


        [Outlet]
        UIKit.NSLayoutConstraint _sectionHeaderHeightConstraint { get; set; }


        [Outlet]
        UIKit.UIImageView _tenantAvatar { get; set; }


        [Outlet]
        UIKit.UIView _tenantInformationContainer { get; set; }


        [Outlet]
        UIKit.UILabel _tenantNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_addressLabel != null) {
                _addressLabel.Dispose ();
                _addressLabel = null;
            }

            if (_headerLabel != null) {
                _headerLabel.Dispose ();
                _headerLabel = null;
            }

            if (_phoneIcon != null) {
                _phoneIcon.Dispose ();
                _phoneIcon = null;
            }

            if (_phoneLabel != null) {
                _phoneLabel.Dispose ();
                _phoneLabel = null;
            }

            if (_sectionHeaderHeightConstraint != null) {
                _sectionHeaderHeightConstraint.Dispose ();
                _sectionHeaderHeightConstraint = null;
            }

            if (_tenantAvatar != null) {
                _tenantAvatar.Dispose ();
                _tenantAvatar = null;
            }

            if (_tenantInformationContainer != null) {
                _tenantInformationContainer.Dispose ();
                _tenantInformationContainer = null;
            }

            if (_tenantNameLabel != null) {
                _tenantNameLabel.Dispose ();
                _tenantNameLabel = null;
            }
        }
    }
}