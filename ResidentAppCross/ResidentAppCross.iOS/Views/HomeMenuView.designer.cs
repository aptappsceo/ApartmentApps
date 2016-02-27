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
	[Register ("HomeMenuView")]
	partial class HomeMenuView
	{
		[Outlet]
		UIKit.UILabel CopyrightLabel { get; set; }

		[Outlet]
		UIKit.UIButton EditProfileButton { get; set; }

		[Outlet]
		UIKit.UITableView MenuTable { get; set; }

		[Outlet]
		UIKit.UIButton SettingsButton { get; set; }

		[Outlet]
		UIKit.UIButton SignOutButton { get; set; }

		[Outlet]
		UIKit.UIImageView UsernameAvatarImage { get; set; }

		[Outlet]
		UIKit.UILabel UsernameLabel { get; set; }

		[Outlet]
		UIKit.UILabel VersionLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CopyrightLabel != null) {
				CopyrightLabel.Dispose ();
				CopyrightLabel = null;
			}
			if (EditProfileButton != null) {
				EditProfileButton.Dispose ();
				EditProfileButton = null;
			}
			if (MenuTable != null) {
				MenuTable.Dispose ();
				MenuTable = null;
			}
			if (SettingsButton != null) {
				SettingsButton.Dispose ();
				SettingsButton = null;
			}
			if (SignOutButton != null) {
				SignOutButton.Dispose ();
				SignOutButton = null;
			}
			if (UsernameAvatarImage != null) {
				UsernameAvatarImage.Dispose ();
				UsernameAvatarImage = null;
			}
			if (UsernameLabel != null) {
				UsernameLabel.Dispose ();
				UsernameLabel = null;
			}
			if (VersionLabel != null) {
				VersionLabel.Dispose ();
				VersionLabel = null;
			}
		}
	}
}
