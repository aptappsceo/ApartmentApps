using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class TextViewSection : SectionViewBase
	{
	    public TextViewSection()
	    {
	    }

	    public TextViewSection (IntPtr handle) : base (handle)
		{
		}

	    public UIView TextViewContainer => _textViewContainer;
	    public UITextView TextView => _textView;
	    public UILabel HeaderLabel => _headerLabel;

	}
}
