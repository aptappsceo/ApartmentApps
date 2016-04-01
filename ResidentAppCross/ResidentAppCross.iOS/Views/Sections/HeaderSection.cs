using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using ResidentAppCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class HeaderSection : SectionViewBase
	{
	    private string _headerText;
	    private string _subHeaderText;

	    public HeaderSection(IntPtr handle) : base(handle)
	    {
            Debug.WriteLine("");
	    }

	    public HeaderSection()
	    {
	    }

	    public override void AwakeFromNib()
	    {
	        base.AwakeFromNib();
	    }

	    public UIImageView LogoImage => LogoImageView;
	    public UILabel MainLabel => HeaderLabel;
	    public UILabel SubLabel => SubHeaderLabel;

	}
}
