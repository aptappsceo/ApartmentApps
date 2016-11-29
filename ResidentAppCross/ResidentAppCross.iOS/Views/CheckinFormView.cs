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
	public class ProspectApplicationFormView : BaseForm<ProspectApplicationFormViewModel> 
    {
        private HeaderSection _headerSection;
        private TextViewSection _firstNameSection;
		private TextViewSection _lastNameSection;
	
        private CallToActionSection _actionSection;
        private PhotoGallerySection _photosSection;
        private TextViewSection _addressLine1Section;
        private TextViewSection _addressLine2Section;
        private TextViewSection _addressCitySection;
        private TextViewSection _addressStateSection;
        private TextViewSection _ZipCodeSection;
        private TextViewSection _emailSection;
        private TextViewSection _phoneNumberSection;
        private LabelWithButtonSection _desiredMoveInDateSection;
       

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
        public TextViewSection AddressLine1Section
        {
            get
            {
                if (_addressLine1Section == null)
                {
                    _addressLine1Section = Formals.Create<TextViewSection>();
                    _addressLine1Section.HeaderLabel.Text = "Address Line 1";
                    _addressLine1Section.HeightConstraint.Constant = 100;
                    _addressLine1Section.SetEditable(true);
                }
                return _addressLine1Section;
            }
        }

        public TextViewSection AddressLine2Section
        {
            get
            {
                if (_addressLine2Section == null)
                {
                    _addressLine2Section = Formals.Create<TextViewSection>();
                    _addressLine2Section.HeaderLabel.Text = "Address Line 2";
                    _addressLine2Section.HeightConstraint.Constant = 100;
                    _addressLine2Section.SetEditable(true);
                }
                return _addressLine2Section;
            }
        }

        public TextViewSection AddressCitySection
        {
            get
            {
                if (_addressCitySection == null)
                {
                    _addressCitySection = Formals.Create<TextViewSection>();
                    _addressCitySection.HeaderLabel.Text = "Address City";
                    _addressCitySection.HeightConstraint.Constant = 100;
                    _addressCitySection.SetEditable(true);
                }
                return _addressCitySection;
            }
        }

        public TextViewSection AddressStateSection
        {
            get
            {
                if (_addressStateSection == null)
                {
                    _addressStateSection = Formals.Create<TextViewSection>();
                    _addressStateSection.HeaderLabel.Text = "Address State";
                    _addressStateSection.HeightConstraint.Constant = 100;
                    _addressStateSection.SetEditable(true);
                }
                return _addressStateSection;
            }
        }


        public TextViewSection ZipCodeSection
        {
            get
            {
                if (_ZipCodeSection == null)
                {
                    _ZipCodeSection = Formals.Create<TextViewSection>();
                    _ZipCodeSection.HeaderLabel.Text = "Zip Code";
                    _ZipCodeSection.HeightConstraint.Constant = 100;
                    _ZipCodeSection.SetEditable(true);
                }
                return _ZipCodeSection;
            }
        }


        public TextViewSection EmailSection
        {
            get
            {
                if (_emailSection == null)
                {
                    _emailSection = Formals.Create<TextViewSection>();
                    _emailSection.HeaderLabel.Text = "Email";
                    _emailSection.HeightConstraint.Constant = 100;
                    _emailSection.SetEditable(true);
                }
                return _emailSection;
            }
        }
        public TextViewSection PhoneNumberSection
        {
            get
            {
                if (_phoneNumberSection == null)
                {
                    _phoneNumberSection = Formals.Create<TextViewSection>();
                    _phoneNumberSection.HeaderLabel.Text = "Phone Number";
                    _phoneNumberSection.HeightConstraint.Constant = 100;
                    _phoneNumberSection.SetEditable(true);
                }
                return _phoneNumberSection;
            }
        }
        public LabelWithButtonSection DesiredMoveInDateSection
        {
            get
            {
                if (_desiredMoveInDateSection == null)
                {
                    _desiredMoveInDateSection = Formals.Create<LabelWithButtonSection>();
                    _desiredMoveInDateSection.Label.Text = "Desired Move-In Date";
                    //_desiredMoveInDateSection.HeightConstraint.Constant = 100;
                }
                return _desiredMoveInDateSection;
            }
        }
		public CallToActionSection CaptureIdSection
		{
			get
			{
				if (_captureIdSection == null)
				{
					_captureIdSection = Formals.Create<CallToActionSection>();
					_captureIdSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
					_captureIdSection.MainButton.SetTitle("Capture");
				}

		
				return _captureIdSection;
			}
		}
		CallToActionSection _captureIdSection;

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
            

			var set = this.CreateBindingSet<ProspectApplicationFormView, ProspectApplicationFormViewModel>();
			set.Bind(ActionSection.MainButton).To(vm => vm.SubmitApplicationCommand);
			set.Bind(ActionSection.MainButton).To(vm => vm.CaptureIdCommand);
			set.Bind(FirstNameSection.TextView).For(t=>t.Text).TwoWay().To(vm => vm.FirstName);
			set.Bind(LastNameSection.TextView).For(t => t.Text).TwoWay().To(vm => vm.LastName);
			set.Bind(AddressLine1Section.TextView).For(t => t.Text).TwoWay().To(vm => vm.AddressLine1);
			set.Bind(AddressLine2Section.TextView).For(t => t.Text).TwoWay().To(vm => vm.AddressLine2);
			set.Bind(AddressCitySection.TextView).For(t => t.Text).TwoWay().To(vm => vm.AddressCity);
			set.Bind(AddressStateSection.TextView).For(t => t.Text).TwoWay().To(vm => vm.AddressState);
			set.Bind(ZipCodeSection.TextView).For(t => t.Text).TwoWay().To(vm => vm.ZipCode);
			set.Bind(EmailSection.TextView).For(t => t.Text).TwoWay().To(vm => vm.Email);
			set.Bind(PhoneNumberSection.TextView).For(t => t.Text).TwoWay().To(vm => vm.PhoneNumber);
			set.Bind(DesiredMoveInDateSection.Button).To(vm => vm.DesiredMoveInDateCommand);
			//set.Bind(LastNameSection.TextView).For(t => t.Text).TwoWay().To(vm => vm.LastName);
			//set.Bind(DesiredMoveInDateSection.TextView).For(t => t.Text).TwoWay().To(vm => vm.LastName);
            set.Apply();
			ViewModel.LoadProspectInfo.Execute(null);
        }


        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(HeaderSection);
			content.Add(CaptureIdSection);
			content.Add(FirstNameSection);
			content.Add(LastNameSection);
			content.Add(AddressLine1Section);
			content.Add(AddressLine2Section);
			content.Add(AddressCitySection);
			content.Add(AddressStateSection);
			content.Add(ZipCodeSection);
			content.Add(EmailSection);
			content.Add(PhoneNumberSection);
			content.Add(DesiredMoveInDateSection);
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