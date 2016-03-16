using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class ExampleSectionView : UIView
	{
	    private NSLayoutConstraint _heightConstraint;

	    public ExampleSectionView (IntPtr handle) : base (handle)
		{
		}

	    public void SetHeaderLabelText(string text)
	    {
	        HeaderLabel.Text = text;
	    }

	    public void SetTextViewText(string text)
	    {
	        TextView.Text = text;
	    }

	    public void ScrollTextViewToTop()
	    {
            TextView.ScrollRangeToVisible(new NSRange(0,0));
        }

	    public NSLayoutConstraint HeightConstraint
	    {
	        get
	        {
	            if (_heightConstraint == null)
	            {
                    _heightConstraint = NSLayoutConstraint.Create(this, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 200);
                    _heightConstraint.Priority = 700;
                    this.AddConstraint(_heightConstraint);
                }
                return _heightConstraint;
	        }
	    }
	}

}
