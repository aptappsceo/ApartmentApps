using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using CoreImage;
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

        public static UIImage InvertImage(this UIImage image)
        {
            CIFilter filter = CIFilter.FromName("CIColorInvert");
            filter.SetDefaults();
            filter.SetValueForKey(image.CIImage,new NSString("inputImage"));
            return new UIImage(filter.OutputImage);
        }

        public static UIImage TintBlack(this UIImage image, UIColor uiColor)
        {

            var color = uiColor.CGColor;
            var imageSize = image.Size;
            UIGraphics.BeginImageContext(imageSize);
            var context = UIGraphics.GetCurrentContext();

            // flip the image
            context.ScaleCTM(1.0f, -1.0f);
            context.TranslateCTM(0.0f, -imageSize.Height);

            // multiply blend mode
            var rect = new CGRect(0, 0, imageSize.Width, imageSize.Height);
            context.SetBlendMode(CGBlendMode.Multiply);
            context.ClipToMask(rect, image.CGImage);
            context.SetFillColor(color);
            context.FillRect(rect);

            //create uiimage
            var newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return newImage;
        }
    }


    public class UILayeredIconView : UIImageView
    {
        private UILayeredIconLayer _backgroundLayer;
        private UILayeredIconLayer _iconLayer;

        public UILayeredIconView(CGRect frame) : base(frame)
        {
        }

        public UILayeredIconView()
        {
        }

        protected internal UILayeredIconView(IntPtr handle) : base(handle)
        {
        }


        public UILayeredIconLayer BackgroundLayer
        {
            get
            {
                if (_backgroundLayer == null)
                {
                    _backgroundLayer = new UILayeredIconLayer();
                    AddSubview(_backgroundLayer.View);
                }
                return _backgroundLayer;
            }
            set
            {
                if(value == null) _backgroundLayer?.View?.RemoveFromSuperview();
                _backgroundLayer = value;
            }
        }

        public UILayeredIconLayer IconLayer
        {
            get
            {
                if (_iconLayer == null)
                {
                    _iconLayer = new UILayeredIconLayer();
                    AddSubview(_iconLayer.View);
                }
                return _iconLayer;
            }
            set
            {
                if(value == null) _iconLayer?.View?.RemoveFromSuperview();
                _iconLayer = value;
            }
        }

        public UILayeredIconLayer MainIconLayer { get; set; }

        public void SetBackgroundLayer(UIImage image, UIColor tintColor = null, float padH = 0, float padV = 0)
        {

            BackgroundLayer.Image = image;
            BackgroundLayer.TintColor = tintColor;
            BackgroundLayer.Padding = new CGSize(padH, padV);
            BackgroundLayer.View.Frame = Bounds.PadInside(padH, padV);
        }

        public void SetBackgroundRounded(UIColor color)
        {
            BackgroundLayer.View.ToRounded(color,2f);
        }

        public void SetIconLayerLayer(UIImage image, UIColor tintColor = null, float padH = 0, float padV = 0)
        {
            IconLayer.Image = image;
            IconLayer.TintColor = tintColor;
            IconLayer.Padding = new CGSize(padH, padV);
            IconLayer.View.Frame = Bounds.PadInside(padH, padV);
        }

        public override void WillMoveToSuperview(UIView newsuper)
        {
            base.WillMoveToSuperview(newsuper);
        }

    }

    public class UILayeredIconLayer
    {
        private UIImageView _view;
        private UIImage _image;

        public UIImage Image
        {
            get { return View.Image; }
            set { View.Image = value; }
        }

        public UIImageView View
        {
            get { return _view ?? (_view = new UIImageView()); }
            set { _view = value; }
        }

        public UIColor TintColor
        {
            get { return View.TintColor; }
            set { View.TintColor = value; }
        }

        public CGSize Padding { get; set; }

        public static UILayeredIconLayer Create(UIImage image)
        {
            return new UILayeredIconLayer() { Image = image };
        }
    }
}
