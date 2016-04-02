using Foundation;
using System;
using System.CodeDom.Compiler;
using ResidentAppCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS
{
    public partial class ToggleSection : SectionViewBase
	{
        private bool _editable;

        public ToggleSection()
	    {
	    }

	    public ToggleSection (IntPtr handle) : base (handle)
		{
		}


        public bool Editable
        {
            get { return Switch.Enabled; }
            set { Switch.Enabled = value; }
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            HeightConstraint.Constant = AppTheme.SwitchSectionHeight;
            HeaderLabel.Font = AppFonts.SectionHeader;
            SubHeaderLabel.Font = AppFonts.Note;
            Switch.OnTintColor = AppTheme.FormControlColor;
        }

        public UISwitch Switch => _switch;
	    public UILabel HeaderLabel => _headerLabel;
	    public UILabel SubHeaderLabel => _subHeaderLabel;

	}
}
