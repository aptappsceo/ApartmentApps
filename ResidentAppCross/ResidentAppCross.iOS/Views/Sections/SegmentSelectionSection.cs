using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class SegmentSelectionSection : SectionViewBase
	{
	    public SegmentSelectionSection()
	    {
	    }

	    public SegmentSelectionSection (IntPtr handle) : base (handle)
		{
		}

	    public UILabel Label => _headerTitle;
	    public UISegmentedControl Selector => _segmentSelector;

	}
}
