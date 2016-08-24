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
    [Register ("LabelWithLabelSection")]
    partial class LabelWithLabelSection
    {
        [Outlet]
        UIKit.UILabel _firstLabel { get; set; }


        [Outlet]
        UIKit.UILabel _secondLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_firstLabel != null) {
                _firstLabel.Dispose ();
                _firstLabel = null;
            }

            if (_secondLabel != null) {
                _secondLabel.Dispose ();
                _secondLabel = null;
            }
        }
    }
}