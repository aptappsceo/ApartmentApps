using Foundation;
using MvvmCross.Plugins.PictureChooser.iOS;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using UIKit;

namespace ResidentAppCross.iOS
{
    [Register("SettingsFormView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    partial class SettingsFormView : BaseForm<SettingsFormViewModel>
    {

        public SettingsFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public SettingsFormView()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }
    }
}