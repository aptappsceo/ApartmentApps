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

    [Register("ProspectApplicationFormView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
	public class ProspectApplicationFormView : BaseForm<ProspectApplicationViewModel> 
    {
        private HeaderSection _headerSection;
        private TextViewSection _firstNameSection;
		private TextViewSection _lastNameSection;
	
        private CallToActionSection _actionSection;
        private PhotoGallerySection _photosSection;

        public ProspectApplicationFormView()
        {
        }

        public ProspectApplicationFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
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
                    _headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
                    _headerSection.LogoImage.Image = UIImage.FromBundle("MaintenaceIcon");
                    _headerSection.MainLabel.Text = "Prospect Application";
                    _headerSection.SubLabel.Text = "Fill out the form.";
                }
                return _headerSection;
            }
        }

        public TextViewSection FirstNameSection
        {
            get
            {
				if (_firstNameSection == null)
                {
                    _firstNameSection = Formals.Create<TextViewSection>();
                    _firstNameSection.HeaderLabel.Text = "First Name";
					_firstNameSection.HeightConstraint.Constant = 100;
                    _firstNameSection.SetEditable(true);
                }
                return _firstNameSection;
            }
        }
		public TextViewSection LastNameSection
		{
			get
			{
				if (_lastNameSection == null)
				{
					_lastNameSection = Formals.Create<TextViewSection>();
					_lastNameSection.HeaderLabel.Text = "Last Name";
					_lastNameSection.HeightConstraint.Constant = 100;
					_lastNameSection.SetEditable(true);
				}
				return _lastNameSection;
			}
		}

		public CallToActionSection ActionSection
        {
            get
            {
                if (_actionSection == null)
                {
                    _actionSection = Formals.Create<CallToActionSection>();
                    _actionSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
					_actionSection.MainButton.SetTitle("Submit Application");
                }
                return _actionSection;
            }
        }



        public override void BindForm()
        {
            base.BindForm();
            

			var set = this.CreateBindingSet<ProspectApplicationFormView, ProspectApplicationViewModel>();
			set.Bind(ActionSection.MainButton).To(vm => vm.SubmitApplicationCommand);
			set.Bind(FirstNameSection.TextView).For(t=>t.Text).TwoWay().To(vm => vm.FirstName);
			set.Bind(LastNameSection.TextView).For(t => t.Text).TwoWay().To(vm => vm.LastName);
            set.Apply();

        }


        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(HeaderSection);
			content.Add(FirstNameSection);
			content.Add(LastNameSection);
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
					_headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
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
					_actionSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
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
			set.Bind(ActionSection.MainButton).To(vm => vm.SubmitCheckinCommand);
			set.Bind(CommentsSection.TextView).For(t => t.Text).TwoWay().To(vm => vm.Comments);

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
}