using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS.Views
{

    [Register("NotificationDetailsFormView")]
    [NavbarStyling]
    [StatusBarStyling]
    public class NotificationDetailsFormView : BaseForm<NotificationDetailsFormViewModel>
    {
        private UIWebView _webView;

        public UIWebView WebView
        {
            get
            {
                if (_webView == null)
                {
                    _webView = new UIWebView().WithHeight(600,1000);
                    _webView.TranslatesAutoresizingMaskIntoConstraints = false;
                }
                return _webView;
            }
            set { _webView = value; }
        }

        public override void BindForm()
        {
            base.BindForm();
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(WebView);
        }
    }


}
