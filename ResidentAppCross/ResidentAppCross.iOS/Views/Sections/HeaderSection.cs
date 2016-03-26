using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class HeaderSection : SectionViewBase
	{
	    private string _headerText;
	    private string _subHeaderText;

	    public HeaderSection(IntPtr handle) : base(handle)
	    {
	    }

	    public HeaderSection()
	    {
	    }


	    public UIImageView LogoImage => LogoImageView;
	    public UILabel MainLabel => HeaderLabel;
	    public UILabel SubLabel => SubHeaderLabel;

	}
}
