using Foundation;
using System;
using System.CodeDom.Compiler;
using CoreGraphics;
using ResidentAppCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class TextFieldSection : SectionViewBase, IFormTapListener, IFormEventsListener, ISoftKeyboardEventsListener
    {
		public TextFieldSection (IntPtr handle) : base (handle)
		{
		}

	    public TextFieldSection()
	    {
	    }

	    public override void AwakeFromNib()
	    {
	        base.AwakeFromNib();
            LayoutMargins = new UIEdgeInsets(0, 8, 0, 8);
	        HeightConstraint.Constant = AppTheme.TextFieldSectionHeight;
	    }

        public UITextField TextField => _textField;

	    public TextFieldSection WithNextResponder(UIView responder)
	    {
	        TextField.WithNextResponder(responder);
	        return this;
	    }

	    public TextFieldSection WithNextResponder(TextFieldSection responder)
	    {
	        TextField.WithNextResponder(responder.TextField);
	        return this;
	    }

	    public TextFieldSection WithNextResponder(Action responder)
	    {
	        TextField.WithNextResponder(responder);
	        return this;
	    }

	    public TextFieldSection WithPlaceholder(string placeholder)
	    {
	        TextField.WithPlaceholder(placeholder);
	        return this;
	    }

	    public TextFieldSection WithSecureTextEntry()
	    {
	        TextField.WithSecureTextEntry();
	        return this;
	    }

	    public void FormTapped()
	    {
            if (TextField.IsFirstResponder) TextField.ResignFirstResponder();
        }

        public void FormDidDisappear()
	    {
	    }

	    public void FormDidAppear()
	    {
	    }

	    public void FormWillAppear()
	    {
            if (TextField.IsFirstResponder) TextField.ResignFirstResponder();
        }

	    public void FormWillDisappear()
	    {
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
	        var frame = Frame;
	        if (frame.Y - 20 >= 0)
	        {
	            frame.Y -= 20;
	        }
            if (TextField.IsFirstResponder) overrideDefaultScroll = frame;
        }

	    public void WillHideKeyboard(ref CGRect overrideDefaultScroll)
	    {
	    }
    }
}
