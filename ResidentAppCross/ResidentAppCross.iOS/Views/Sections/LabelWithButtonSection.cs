using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class LabelWithButtonSection : SectionViewBase
	{
	    public LabelWithButtonSection()
	    {
	    }

	    public LabelWithButtonSection (IntPtr handle) : base (handle)
		{
			//ResidentAppCross.iOS.Services.IOSDialogService.LastButton = _button;
		}

	    public UILabel Label => _label;
	    public UIButton Button => _button;

	}
}
