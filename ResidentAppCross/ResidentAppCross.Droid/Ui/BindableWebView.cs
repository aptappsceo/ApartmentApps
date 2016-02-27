using System;
using System.Collections.Generic;
using Android.Content;
using Android.Util;
using Android.Webkit;
using Android.Widget;

namespace MyApp.Droid.Ui.Controls
{
    public class BindableWebView : WebView
    {
        private string _text;
        private string _contentUrl;

        public BindableWebView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            this.SetWebChromeClient(new WebChromeClient());
            this.SetWebViewClient(new WebViewClient());
        }
        

        public string Text
        {
            get { return _text; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                _text = value;
                LoadData(_text, "text/html", "utf-8");
                UpdatedHtmlContent();
            }
        }

        public string ContentUrl
        {
            get { return _contentUrl; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                _contentUrl = value;

                var authorizationKey = App.ApartmentAppsClient.AparmentAppsDelegating.AuthorizationKey;
                if (!string.IsNullOrEmpty(authorizationKey))
                {
                    LoadUrl(_contentUrl, new Dictionary<string, string>()
                    {
                        {"Authorization", "Bearer " + authorizationKey}
                    });
                }
                else
                {
                    LoadUrl(_contentUrl);
                }
                UpdatedHtmlContent();
            }
        }


        public event EventHandler HtmlContentChanged;

        private void UpdatedHtmlContent()
        {
            HtmlContentChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}