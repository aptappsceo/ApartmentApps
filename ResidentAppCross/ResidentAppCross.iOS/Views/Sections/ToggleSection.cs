using Foundation;
using System;
using System.CodeDom.Compiler;
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
            get { return _editable; }
            set
            {
                _editable = value;
                Switch.Enabled = value;
            }
        }

        public UISwitch Switch => _switch;
	    public UILabel HeaderLabel => _headerLabel;
	    public UILabel SubHeaderLabel => _subHeaderLabel;

	}
}
