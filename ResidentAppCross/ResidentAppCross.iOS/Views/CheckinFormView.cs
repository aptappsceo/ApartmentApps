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

    [Register("CheckinFormView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public class CheckinFormView : BaseForm<CheckinFormViewModel> 
    {
        private HeaderSection _headerSection;
        private TextViewSection _commentsSection;
        private CallToActionSection _actionSection;
        private PhotoGallerySection _photosSection;

        public CheckinFormView()
        {
        }

        public CheckinFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public override string Title => "Check In";

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = 100;
                    _headerSection.LogoImage.Image = UIImage.FromBundle("MaintenaceIcon");
                    _headerSection.MainLabel.Text = "Maintenance";
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
                    _commentsSection.SetEditable(true);
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
                }
                return _photosSection;
            }
        }

        public override void BindForm()
        {
            base.BindForm();
            PhotosSection.BindViewModel(ViewModel.Photos);

            var set = this.CreateBindingSet<CheckinFormView, CheckinFormViewModel>();

            set.Bind(HeaderSection.MainLabel).For(l => l.Text).To(vm => vm.HeaderText);
            set.Bind(HeaderSection.SubLabel).For(l => l.Text).To(vm => vm.SubHeaderText);
            set.Bind(ActionSection.MainButton).For("Title").To(vm => vm.ActionText);
            set.Bind(ActionSection.MainButton).To(vm => vm.ActionCommand);
            set.Bind(CommentsSection.TextView).To(vm => vm.Comments);
            
            set.Apply();

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