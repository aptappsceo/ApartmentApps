using Foundation;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS
{
    [Register("NotificationsFormView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    partial class NotificationsFormView : BaseForm<NotificationsFormViewModel>
    {

        public NotificationsFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public NotificationsFormView()
        {
        }
    }
    [Register("NotificationsFormView")]
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
    }
}