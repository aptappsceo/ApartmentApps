using Foundation;
using System;
using System.CodeDom.Compiler;
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


	    public UILabel AddressLabel => _addressLabel;
	    public UILabel HeaderLabel => _headerLabel;
	    public UIImageView PhoneIcon => _phoneIcon;
	    public UILabel PhoneLabel => _phoneLabel;
	    public UIImageView TenantAvatar => _tenantAvatar;
	    public UIView TenantInformationContainer => _tenantInformationContainer;
	    public UILabel TenantNameLabel => _tenantNameLabel;



	}
}
