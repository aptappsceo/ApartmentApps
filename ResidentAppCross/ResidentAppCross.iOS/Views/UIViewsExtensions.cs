using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Foundation;
using MvvmCross.Plugins.PictureChooser.iOS;
using Photos;
using SDWebImage;
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

        public static void ToRounded(this UIImageView view , UIColor borderColor, float borderWith = 4f)
        {
            view.Layer.MasksToBounds = true;
            view.Layer.CornerRadius = view.Frame.Width / 2;
            view.Layer.BorderWidth = borderWith;
            view.Layer.BorderColor = borderColor.CGColor;
        }

        public static void SetImageWithAsyncIndicator(this UIImageView view, string imageUrl, UIImage placeholder)
        {

            var activityIndicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.White);
            activityIndicator.Color = UIColor.White;
            activityIndicator.BackgroundColor = UIColor.Black.ColorWithAlpha(0.7f);
            view.AddSubview(activityIndicator);
            activityIndicator.Frame = view.Bounds;
            activityIndicator.HidesWhenStopped = true;
            activityIndicator.StartAnimating();
            //using (var data = NSData.FromUrl(new NSUrl(ViewModel.ProfileImageUrl)))
            view.SetImage(
                url: new NSUrl(imageUrl),
                placeholder: UIImage.FromFile("avatar-placeholder.png"),
                completedBlock: (image, error, type, url) =>
                {
                    UIView.Animate(0.4f, () =>
                    {
                        activityIndicator.Alpha = 0;

                    },()=> { activityIndicator.RemoveFromSuperview(); });
                    //activityIndicator.RemoveFromSuperview();
                });


        }

        public static void Shadow(this UIView view, UIColor color, CGSize shadowoffset, float opacity, float radius)
        {
            view.Layer.ShadowColor = color.CGColor;
            view.Layer.ShadowOffset = shadowoffset;
            view.Layer.ShadowOpacity = opacity;
            view.Layer.ShadowRadius = radius;
            view.ClipsToBounds = false;
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

        public static UIView FindFirstResponder(this UIView view)
        {
            if (view.IsFirstResponder) return view;

            foreach (var subview in view.Subviews)
            {
                var firstReponder = subview.FindFirstResponder();
                if (firstReponder != null) return firstReponder;
            }

            return null;
        }
    }
}
