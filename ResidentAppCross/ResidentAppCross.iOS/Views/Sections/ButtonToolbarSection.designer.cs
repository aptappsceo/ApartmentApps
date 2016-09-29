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
    [Register ("ButtonToolbarSection")]
    partial class ButtonToolbarSection
    {
        [Outlet]
        UIKit.UIStackView ButtonBar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonBar != null) {
                ButtonBar.Dispose ();
                ButtonBar = null;
            }
        }
    }
}