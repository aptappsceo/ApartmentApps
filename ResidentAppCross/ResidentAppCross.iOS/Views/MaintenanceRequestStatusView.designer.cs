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
	[Register ("MaintenanceRequestStatusView")]
	partial class MaintenanceRequestStatusView
	{
		[Outlet]
		UIKit.UITextView CommentsTextView { get; set; }

		[Outlet]
		UIKit.UISwitch EntrancePermissionSwitch { get; set; }

		[Outlet]
		UIKit.UIButton FooterFinishButton { get; set; }

		[Outlet]
		UIKit.UIButton FooterPauseButton { get; set; }

		[Outlet]
		UIKit.UIView FooterSectionPending { get; set; }

		[Outlet]
		UIKit.UIView FooterSectionStart { get; set; }

		[Outlet]
		UIKit.UIButton FooterStartButton { get; set; }

		[Outlet]
		UIKit.UILabel HeaderPauseDateLabel { get; set; }

		[Outlet]
		UIKit.UIView HeaderRequestTypeLabel { get; set; }

		[Outlet]
		UIKit.UIView HeaderSectionPaused { get; set; }

		[Outlet]
		UIKit.UIView HeaderSectionPending { get; set; }

		[Outlet]
		UIKit.UISegmentedControl PetSelection { get; set; }

		[Outlet]
		UIKit.UICollectionView PhotoContainer { get; set; }

		[Outlet]
		UIKit.UILabel RepairDateChangeDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel RepairDateChangeTitleLabel { get; set; }

		[Outlet]
		UIKit.UILabel RequestTypeChangeTitleLabel { get; set; }

		[Outlet]
		UIKit.UIButton SelectRepairDateButton { get; set; }

		[Outlet]
		UIKit.UIButton SelectRequestTypeButton { get; set; }

		[Outlet]
		UIKit.UILabel TenantAddressFirstLineLabel { get; set; }

		[Outlet]
		UIKit.UILabel TenantAddressSecondLineLabel { get; set; }

		[Outlet]
		UIKit.UIImageView TenantAvatarImageView { get; set; }

		[Outlet]
		UIKit.UILabel TenantFullNameLabel { get; set; }

		[Outlet]
		UIKit.UILabel TenantPhoneLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (HeaderSectionPending != null) {
				HeaderSectionPending.Dispose ();
				HeaderSectionPending = null;
			}

			if (HeaderSectionPaused != null) {
				HeaderSectionPaused.Dispose ();
				HeaderSectionPaused = null;
			}

			if (HeaderRequestTypeLabel != null) {
				HeaderRequestTypeLabel.Dispose ();
				HeaderRequestTypeLabel = null;
			}

			if (HeaderPauseDateLabel != null) {
				HeaderPauseDateLabel.Dispose ();
				HeaderPauseDateLabel = null;
			}

			if (SelectRepairDateButton != null) {
				SelectRepairDateButton.Dispose ();
				SelectRepairDateButton = null;
			}

			if (RepairDateChangeTitleLabel != null) {
				RepairDateChangeTitleLabel.Dispose ();
				RepairDateChangeTitleLabel = null;
			}

			if (RepairDateChangeDateLabel != null) {
				RepairDateChangeDateLabel.Dispose ();
				RepairDateChangeDateLabel = null;
			}

			if (TenantAddressFirstLineLabel != null) {
				TenantAddressFirstLineLabel.Dispose ();
				TenantAddressFirstLineLabel = null;
			}

			if (TenantAddressSecondLineLabel != null) {
				TenantAddressSecondLineLabel.Dispose ();
				TenantAddressSecondLineLabel = null;
			}

			if (TenantAvatarImageView != null) {
				TenantAvatarImageView.Dispose ();
				TenantAvatarImageView = null;
			}

			if (TenantFullNameLabel != null) {
				TenantFullNameLabel.Dispose ();
				TenantFullNameLabel = null;
			}

			if (TenantPhoneLabel != null) {
				TenantPhoneLabel.Dispose ();
				TenantPhoneLabel = null;
			}

			if (SelectRequestTypeButton != null) {
				SelectRequestTypeButton.Dispose ();
				SelectRequestTypeButton = null;
			}

			if (RequestTypeChangeTitleLabel != null) {
				RequestTypeChangeTitleLabel.Dispose ();
				RequestTypeChangeTitleLabel = null;
			}

			if (CommentsTextView != null) {
				CommentsTextView.Dispose ();
				CommentsTextView = null;
			}

			if (PhotoContainer != null) {
				PhotoContainer.Dispose ();
				PhotoContainer = null;
			}

			if (EntrancePermissionSwitch != null) {
				EntrancePermissionSwitch.Dispose ();
				EntrancePermissionSwitch = null;
			}

			if (PetSelection != null) {
				PetSelection.Dispose ();
				PetSelection = null;
			}

			if (FooterStartButton != null) {
				FooterStartButton.Dispose ();
				FooterStartButton = null;
			}

			if (FooterPauseButton != null) {
				FooterPauseButton.Dispose ();
				FooterPauseButton = null;
			}

			if (FooterFinishButton != null) {
				FooterFinishButton.Dispose ();
				FooterFinishButton = null;
			}

			if (FooterSectionPending != null) {
				FooterSectionPending.Dispose ();
				FooterSectionPending = null;
			}

			if (FooterSectionStart != null) {
				FooterSectionStart.Dispose ();
				FooterSectionStart = null;
			}
		}
	}
}
