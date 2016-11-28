using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.Resources;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class TenantDataSection : SectionViewBase
	{
	    private string _phoneNumber;

	    public TenantDataSection (IntPtr handle) : base (handle)
		{
		}

	    public TenantDataSection()
	    {
	    }

	    public override void AwakeFromNib()
	    {
	        base.AwakeFromNib();
	        HeightConstraint.Constant = AppTheme.TenantDataSectionHeight;
	        HeaderLabel.Font = AppFonts.SectionHeader;
	        AddressLabel.Font = AppFonts.CellHeader;
	        TenantNameLabel.Font = AppFonts.SectionHeader;
	        PhoneLabel.Font = AppFonts.Note;
            TenantAvatar.ContentMode = UIViewContentMode.ScaleAspectFill;
	        PhoneIcon.Image = AppTheme.GetIcon(SharedResources.Icons.Call, SharedResources.Size.S);

	        PhoneIcon.AddGestureRecognizer(new UITapGestureRecognizer(() =>
	        {
	            if (string.IsNullOrEmpty(_phoneNumber)) return;
	            CallPhone(_phoneNumber);
	        }));


	    }

	    public void SetPhone(string phone)
	    {
	        _phoneNumber = phone;
	    }

	    private void CallPhone(string phone )
	    {
	        var sharedApplication = UIApplication.SharedApplication;
	        var promtTel = NSUrl.FromString(@"telprompt://"+phone);
	        var tel = NSUrl.FromString(@"tel://"+phone);

	        if (sharedApplication.CanOpenUrl(promtTel))
	        {
	            sharedApplication.OpenUrl(promtTel);
	        }
	        else
	        {
	            sharedApplication.OpenUrl(tel);
	        }
	    }

	    public override void WillMoveToSuperview(UIView newsuper)
	    {
	        base.WillMoveToSuperview(newsuper);
            TenantAvatar.ToRounded(AppTheme.DeepBackgroundColor, 2f);
        }

        public UILabel AddressLabel => _addressLabel;
	    public UILabel HeaderLabel => _headerLabel;
	    public UIImageView PhoneIcon => _phoneIcon;
	    public UILabel PhoneLabel => _phoneLabel;
	    public UIImageView TenantAvatar => _tenantAvatar;
	    public UIView TenantInformationContainer => _tenantInformationContainer;
	    public UILabel TenantNameLabel => _tenantNameLabel;



	}
}
