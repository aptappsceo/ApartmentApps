using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using MvvmCross.Plugins.PictureChooser.iOS;
using Photos;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public static class UIViewsExtensions
    {


        public static void SetLeftIcon(this UIButton button, UIImage image, bool resizeToFit = true)
        {
            var height = button.Frame.Size.Height;
            var img = image;
            if (resizeToFit) img = img.ImageToFitSize(new CGSize(height, height));
            button.SetImage(img, UIControlState.Normal);
        }

        public static void SetRightIcon(this UIButton button, UIImage image, bool resizeToFit = true)
        {

            button.SetLeftIcon(image,resizeToFit);
            button.Transform = CGAffineTransform.MakeScale(-1.0f, 1.0f);
            button.TitleLabel.Transform = CGAffineTransform.MakeScale(-1.0f, 1.0f);
            button.ImageView.Transform = CGAffineTransform.MakeScale(-1.0f, 1.0f);
        }

        public static void SetLeftIcon(this UIButton button, string icon, bool resizeToFit = true)
        {
            button.SetLeftIcon(UIImage.FromBundle(icon),resizeToFit);
        }

        public static void SetRightIcon(this UIButton button, string icon, bool resizeToFit = true)
        {
            button.SetRightIcon(UIImage.FromBundle(icon),resizeToFit);
        }

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


        public static UIImage Blend(this UIImage bottom, UIImage top)
        {
            throw new NotImplementedException();
//            CGSize newSize = CGSizeMake(width, height);
//            UIGraphicsBeginImageContext(newSize);
//
//            // Use existing opacity as is
//                    [bottomImage drawInRect:CGRectMake(0, 0, newSize.width, newSize.height)];
//            // Apply supplied opacity
//            [image drawInRect:CGRectMake(0, 0, newSize.width, newSize.height) blendMode:kCGBlendModeNormal alpha:0.8];
//
//            UIImage* newImage = UIGraphicsGetImageFromCurrentImageContext();
//
//            UIGraphicsEndImageContext();
        }

        public static CGRect PadInside(this CGRect frame, float horisontal, float vertical)
        {
            return new CGRect(frame.X + horisontal, frame.Y + vertical, frame.Width - horisontal * 2, frame.Height - vertical * 2);
        }

        public static CGRect WithSize(this CGRect frame, float width, float height)
        {
            return new CGRect(frame.X, frame.Y, width, height);
        }

    }
}
