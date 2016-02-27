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
	[Register ("MaintenanceStartFormView")]
	partial class MaintenanceStartFormView
	{
		[Outlet]
		UIKit.UITextView CommentsTextView { get; set; }

		[Outlet]
		UIKit.UISwitch EntrancePermissionSwitch { get; set; }

		[Outlet]
		UIKit.UILabel LastDateChangeDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel LastDateChangeTitleLabel { get; set; }

		[Outlet]
		UIKit.UILabel LastRequestTypeChangeTitleLabel { get; set; }

		[Outlet]
		UIKit.UISegmentedControl PetSelection { get; set; }

		[Outlet]
		UIKit.UICollectionView PhotosContainer { get; set; }

		[Outlet]
		UIKit.UILabel RequestTypeTitleLabel { get; set; }

		[Outlet]
		UIKit.UIButton SelectRepairDateButton { get; set; }

		[Outlet]
		UIKit.UIButton SelectRequestTypeButton { get; set; }

		[Outlet]
		UIKit.UIButton StartButton { get; set; }

		[Outlet]
		UIKit.UILabel TenantAddressSecondLineLabel { get; set; }

		[Outlet]
		UIKit.UILabel TenantAdressFirstLineLabel { get; set; }

		[Outlet]
		UIKit.UIImageView TenantAvatarImage { get; set; }

		[Outlet]
		UIKit.UILabel TenantFullNameLabel { get; set; }

		[Outlet]
		UIKit.UILabel TenantPhoneLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (RequestTypeTitleLabel != null) {
				RequestTypeTitleLabel.Dispose ();
				RequestTypeTitleLabel = null;
			}

			if (SelectRepairDateButton != null) {
				SelectRepairDateButton.Dispose ();
				SelectRepairDateButton = null;
			}

			if (LastDateChangeTitleLabel != null) {
				LastDateChangeTitleLabel.Dispose ();
				LastDateChangeTitleLabel = null;
			}

			if (LastDateChangeDateLabel != null) {
				LastDateChangeDateLabel.Dispose ();
				LastDateChangeDateLabel = null;
			}

			if (TenantAdressFirstLineLabel != null) {
				TenantAdressFirstLineLabel.Dispose ();
				TenantAdressFirstLineLabel = null;
			}

			if (TenantAddressSecondLineLabel != null) {
				TenantAddressSecondLineLabel.Dispose ();
				TenantAddressSecondLineLabel = null;
			}

			if (TenantFullNameLabel != null) {
				TenantFullNameLabel.Dispose ();
				TenantFullNameLabel = null;
			}

			if (TenantPhoneLabel != null) {
				TenantPhoneLabel.Dispose ();
				TenantPhoneLabel = null;
			}

			if (TenantAvatarImage != null) {
				TenantAvatarImage.Dispose ();
				TenantAvatarImage = null;
			}

			if (SelectRequestTypeButton != null) {
				SelectRequestTypeButton.Dispose ();
				SelectRequestTypeButton = null;
			}

			if (LastRequestTypeChangeTitleLabel != null) {
				LastRequestTypeChangeTitleLabel.Dispose ();
				LastRequestTypeChangeTitleLabel = null;
			}

			if (CommentsTextView != null) {
				CommentsTextView.Dispose ();
				CommentsTextView = null;
			}

			if (PhotosContainer != null) {
				PhotosContainer.Dispose ();
				PhotosContainer = null;
			}

			if (EntrancePermissionSwitch != null) {
				EntrancePermissionSwitch.Dispose ();
				EntrancePermissionSwitch = null;
			}

			if (PetSelection != null) {
				PetSelection.Dispose ();
				PetSelection = null;
			}

			if (StartButton != null) {
				StartButton.Dispose ();
				StartButton = null;
			}
		}
	}
}
