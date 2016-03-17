using System;
using System.Collections.Generic;
using System.Drawing;
using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels.Screens;
using SDWebImage;

namespace ResidentAppCross.iOS.Views
{

    [Register("CheckingFormView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public class CheckingFormView : BaseForm<CheckingFormViewModel> 
    {
        private HeaderSection _headerSection;
        private TextViewSection _commentsSection;
        private CallToActionSection _actionSection;
        private PhotoGallerySection _photosSection;

        public CheckingFormView()
        {
        }

        public CheckingFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = 100;
                    _headerSection.LogoImage.Image = UIImage.FromBundle("MaintenaceIcon");
                    _headerSection.MainLabel.Text = "Maintenance Request";
                    _headerSection.SubLabel.Text = "Pause";
                }
                return _headerSection;
            }
        }
        public TextViewSection CommentsSection
        {
            get
            {
                if (_commentsSection == null)
                {
                    _commentsSection = Formals.Create<TextViewSection>();
                    _commentsSection.HeightConstraint.Constant = 200;
                    _commentsSection.HeaderLabel.Text = "Comments & Details";
                    _commentsSection.TextView.Text =
                        "Some random text here to simulate sufficent amount of characters to test scrolling and behaviour of Comments Section";
                }
                return _commentsSection;
            }
        }
        public CallToActionSection ActionSection
        {
            get
            {
                if (_actionSection == null)
                {
                    _actionSection = Formals.Create<CallToActionSection>();
                    _actionSection.HeightConstraint.Constant = 100;
                    _actionSection.MainButton.SetTitle("Send Request");
                }
                return _actionSection;
            }
        }

        public PhotoGallerySection PhotosSection
        {
            get
            {
                if (_photosSection == null)
                {
                    _photosSection = Formals.Create<PhotoGallerySection>();
                    _photosSection.HeaderLabel.Text = "No Photos Attached";
                }
                return _photosSection;
            }
        }


        public override void BindForm()
        {
            base.BindForm();
            PhotosSection.BindViewModel(ViewModel.Photos);
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(HeaderSection);
            content.Add(CommentsSection);
            content.Add(PhotosSection);
            content.Add(ActionSection);

        }



    }

    public static class UIButtonExtensions
    {
        public static void SetTitle(this UIButton button, string title)
        {
            button.Enabled = false;
            button.SetTitle(title,UIControlState.Normal);
            button.SetNeedsLayout();
            button.Enabled = true;
        }
    }
}