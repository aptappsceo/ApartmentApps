using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using CoreGraphics;
using ResidentAppCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class TextViewSection : SectionViewBase, IFormTapListener, IFormEventsListener, ISoftKeyboardEventsListener
    {
	    public TextViewSection()
	    {
	    }

	    public TextViewSection (IntPtr handle) : base (handle)
		{
		}

	    public void SetEditable(bool editable)
	    {
	        TextView.Editable = editable;
	        if (editable)
	        {
	            TextViewContainer.BackgroundColor = AppTheme.SecondaryBackgoundColor;
	        }
	        else
	        {
	            TextViewContainer.BackgroundColor = AppTheme.DeepBackgroundColor;
	        }
	    }

	    public IScrollableView ScrollableParent => ParentController as IScrollableView;


	    public UIView TextViewContainer => _textViewContainer;
	    public UITextView TextView => _textView;
	    public UILabel HeaderLabel => _headerLabel;

	    public void FormTapped()
	    {
            if(TextView.IsFirstResponder) TextView.ResignFirstResponder();
	    }

	    public void FormDidDisappear()
	    {
        }

        public void FormDidAppear()
	    {
	    }

	    public void FormWillAppear()
	    {
	    }

	    public void FormWillDisappear()
	    {
            if (TextView.IsFirstResponder) TextView.ResignFirstResponder();
        }

	    public void WillShowNotification()
	    {
        }

        public void WillHideNotification()
	    {
	    }

	    public void DidShowKeyboard()
	    {
        }

	    public void DidHideKeyboard()
	    {
	    }

	    public void WillShowKeyboard(ref CGRect overrideDefaultScroll)
	    {
            if(TextView.IsFirstResponder) overrideDefaultScroll = Frame;
	    }

	    public void WillHideKeyboard(ref CGRect overrideDefaultScroll)
	    {
	    }
    }
}
