using Foundation;
using System;
using System.CodeDom.Compiler;
using ResidentAppCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class TenantDataSection : SectionViewBase
	{
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
	        TenantNameLabel.Font = AppFonts.CellHeader;
	        PhoneLabel.Font = AppFonts.Note;
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
