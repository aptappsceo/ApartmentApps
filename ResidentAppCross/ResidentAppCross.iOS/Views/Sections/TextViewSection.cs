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

	    public bool Editable
	    {
	        get { return TextView.Editable; }
	        set
	        {
                TextView.Editable = value; 
	            TextView.Layer.BorderColor = PrefferedBorderColor;
            }
        }

	    public void SetEditable(bool editable)
	    {
	        Editable = editable;
	    }

	    private CGColor PrefferedBorderColor
	        => TextView.Editable ? AppTheme.SecondaryBackgoundColor.CGColor : AppTheme.DeepBackgroundColor.CGColor;

	    public IScrollableView ScrollableParent => ParentController as IScrollableView;

	    public UIView TextViewContainer => _textViewContainer;
	    public UITextView TextView => _textView;
	    public UILabel HeaderLabel => _headerLabel;

	    public void FormTapped()
	    {
            if(TextView.IsFirstResponder) TextView.ResignFirstResponder();
	    }

	    public override void AwakeFromNib()
	    {
	        base.AwakeFromNib();
            HeaderLabel.Font = AppFonts.SectionHeader;
	        HeightConstraint.Constant = AppTheme.CommentsSectionHeight;
            TextView.Layer.CornerRadius = 6.0f;
            TextView.Layer.BorderColor = PrefferedBorderColor;
            TextView.Layer.BorderWidth = 1f;
            TextView.ClipsToBounds = true;
            TextViewContainer.BackgroundColor = UIColor.Clear;
	        HeaderLabel.Text = AppStrings.DefaultTextViewHeaderText;
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
