using System;
using System.Collections.Generic;
using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels;
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

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

      
            content.Add(HeaderSection);
            content.Add(CommentsSection);
            content.Add(ActionSection);

        }



    }

    public class BaseForm<T> : ViewBase<T> where T : ViewModelBase
    {
        private UIScrollView _sectionsContainer;

        public BaseForm(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public BaseForm() : base (null,null)
		{
        }

        public UIScrollView SectionsContainer
        {
            get
            {
                if (_sectionsContainer == null)
                {
                    EdgesForExtendedLayout = UIRectEdge.None;
                    View.BackgroundColor = AppTheme.DeepBackgroundColor;

                    _sectionsContainer = new UIScrollView().AddTo(View);
                    _sectionsContainer.TranslatesAutoresizingMaskIntoConstraints = false;
                    View.AddConstraints(
                            _sectionsContainer.WithSameWidth(View),
                            _sectionsContainer.WithSameHeight(View),
                            _sectionsContainer.AtTopOf(View),
                            _sectionsContainer.AtLeftOf(View)
                        );
                }
                return _sectionsContainer;
            }
            set { _sectionsContainer = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BindForm();
            RefreshContent();
        }

        public virtual void BindForm()
        {
        }

        public virtual void UnbindForm()
        {
        }

        public virtual void RefreshContent()
        {

            foreach (var subview in SectionsContainer.Subviews)
            {
                subview.RemoveFromSuperview();
            }

            SectionsContainer.RemoveConstraints(SectionsContainer.Constraints);

            List<UIView> content = new List<UIView>();
            GetContent(content);

            foreach (var uiView in content)
            {
                SectionsContainer.Add(uiView);
            }

            var constraints = SectionsContainer.VerticalStackPanelConstraints(
                                           new Margins(0, 0, 0, 20, 0, 15),
                                           SectionsContainer.Subviews);

            SectionsContainer.AddConstraints(constraints);

        }

        public virtual void GetContent(List<UIView> content)
        {
            
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