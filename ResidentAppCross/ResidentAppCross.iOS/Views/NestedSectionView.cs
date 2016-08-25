using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    [Register("NestedSectionView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    partial class NestedSectionView : BaseForm<NestedSectionsViewModel>
    {
        public override string Title => "Inspection";

        
    }
}
