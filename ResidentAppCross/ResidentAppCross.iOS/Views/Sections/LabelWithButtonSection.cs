using Foundation;
using System;
using System.CodeDom.Compiler;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.Resources;
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

	    public override void AwakeFromNib()
	    {
	        base.AwakeFromNib();
	        HeightConstraint.Constant = AppTheme.LabelWithButtonSectionHeight;
            Button.Font = AppFonts.CellHeader;
            Label.Font = AppFonts.SectionHeader;
            Button.SetTitleColor(AppTheme.FormControlColor, UIControlState.Normal);
	    }

	    public UILabel Label => _label;
	    public UIButton Button => _button;

	}
}
