using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Linq;
using ResidentAppCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class ButtonToolbarSection : SectionViewBase
	{
		public ButtonToolbarSection (IntPtr handle) : base (handle)
		{
		}

	    public ButtonToolbarSection()
	    {
	    }

	    public UIButton AddButton(string title, UIViewStyle style)
	    {
	        var button = new UIButton();

            button.SetTitle(title, UIControlState.Normal);
	        button.BackgroundColor = style.BackgroundColor;
            button.SetTitleColor(style.ForegroundColor,UIControlState.Normal);
            button.TitleLabel.Font = UIFont.PreferredCallout;
            ButtonBar.AddArrangedSubview(button);
        
	        return button;
	    }

	    public override void AwakeFromNib()
	    {
	        base.AwakeFromNib();
	        HeightConstraint.Constant = AppTheme.ButtonToolbarSectionHeight;
	    }

	    public void ClearButtons()
	    {
	        foreach (var button in ButtonBar.Subviews.ToArray())
	        {
	            button.RemoveFromSuperview();
	        }
	    }

	}

    public struct UIViewStyle
    {
        public UIColor ForegroundColor;
        public UIColor BackgroundColor;
        public float FontSize;
    }

}
