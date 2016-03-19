using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
    public partial class ToggleSection : SectionViewBase
	{
	    public ToggleSection()
	    {
	    }

	    public ToggleSection (IntPtr handle) : base (handle)
		{
		}

	    public UISwitch Switch => _switch;
	    public UILabel HeaderLabel => _headerLabel;
	    public UILabel SubHeaderLabel => _subHeaderLabel;

	}
}
