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
    [Register ("SegmentSelectionSection")]
    partial class SegmentSelectionSection
    {
        [Outlet]
        UIKit.NSLayoutConstraint _headerHeightConstraint { get; set; }


        [Outlet]
        UIKit.UILabel _headerTitle { get; set; }


        [Outlet]
        UIKit.UISegmentedControl _segmentSelector { get; set; }


        [Outlet]
        UIKit.UILabel HeaderLabel { get; set; }


        [Outlet]
        UIKit.UISegmentedControl SegmentSelector { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_headerHeightConstraint != null) {
                _headerHeightConstraint.Dispose ();
                _headerHeightConstraint = null;
            }

            if (_headerTitle != null) {
                _headerTitle.Dispose ();
                _headerTitle = null;
            }

            if (_segmentSelector != null) {
                _segmentSelector.Dispose ();
                _segmentSelector = null;
            }

            if (HeaderLabel != null) {
                HeaderLabel.Dispose ();
                HeaderLabel = null;
            }

            if (SegmentSelector != null) {
                SegmentSelector.Dispose ();
                SegmentSelector = null;
            }
        }
    }
}