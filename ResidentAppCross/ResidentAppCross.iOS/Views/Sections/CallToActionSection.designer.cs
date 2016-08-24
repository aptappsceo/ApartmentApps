// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
    [Register ("CallToActionSection")]
    partial class CallToActionSection
    {
        [Outlet]
        UIKit.UIButton ActionButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActionButton != null) {
                ActionButton.Dispose ();
                ActionButton = null;
            }
        }
    }
}