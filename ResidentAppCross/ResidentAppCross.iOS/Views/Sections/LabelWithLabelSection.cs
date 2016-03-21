using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
    public partial class LabelWithLabelSection : SectionViewBase
	{
        public LabelWithLabelSection()
        {
        }

        public LabelWithLabelSection (IntPtr handle) : base (handle)
		{
		}

        public UILabel FirstLabel => _firstLabel;
        public UILabel SecondLabel => _secondLabel;

    }
}
