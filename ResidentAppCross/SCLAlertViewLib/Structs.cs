using System;
using System.Collections.Generic;
using System.Text;
using ObjCRuntime;

namespace SCLAlertViewLib
{
    [Native]
    public enum SCLActionType : long
    {
        None,
        Selector,
        Block
    }

    [Native]
    public enum SCLAlertViewStyle : long
    {
        Success,
        Error,
        Notice,
        Warning,
        Info,
        Edit,
        Waiting,
        Custom
    }

    [Native]
    public enum SCLAlertViewHideAnimation : long
    {
        FadeOut,
        SlideOutToBottom,
        SlideOutToTop,
        SlideOutToLeft,
        SlideOutToRight,
        SlideOutToCenter,
        SlideOutFromCenter
    }

    [Native]
    public enum SCLAlertViewShowAnimation : long
    {
        FadeIn,
        SlideInFromBottom,
        SlideInFromTop,
        SlideInFromLeft,
        SlideInFromRight,
        SlideInFromCenter,
        SlideInToCenter
    }

    [Native]
    public enum SCLAlertViewBackground : long
    {
        Shadow,
        Blur,
        Transparent
    }
}
