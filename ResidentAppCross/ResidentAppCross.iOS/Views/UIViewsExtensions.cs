using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public static class UIViewsExtensions
    {

        public static void SetLeftIcon(this UITextField textField, string iconBundle)
        {
            var loginIconView = new UIImageView(UIImage.FromBundle(iconBundle))
            {
                Frame = new CGRect(0, 0, textField.Frame.Height, textField.Frame.Height),
                ContentMode = UIViewContentMode.ScaleAspectFit,
                TranslatesAutoresizingMaskIntoConstraints = true
            };

            textField.LeftView = loginIconView;

            textField.LeftViewMode = UITextFieldViewMode.UnlessEditing;

            textField.EditingDidBegin += (sender, args) =>
            {
                textField.LeftViewMode = UITextFieldViewMode.Never;
            };
            textField.EditingDidEnd += (sender, args) =>
            {
                textField.LeftViewMode = UITextFieldViewMode.UnlessEditing;
            };
        }
    }
}
