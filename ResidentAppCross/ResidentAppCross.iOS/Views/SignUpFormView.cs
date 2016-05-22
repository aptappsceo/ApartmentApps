using System;
using System.Collections.Generic;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Plugins.PictureChooser.iOS;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS
{

    [NavbarStyling]
    [StatusBarStyling]
    [Register("SignUpFormView")]
    public partial class SignUpFormView : BaseForm<SignUpFormViewModel>
	{
        private TextFieldSection _firstNameFieldSection;
        private UIButton _signUpButton;
        private TextFieldSection _lastNameFieldSection;
        private TextFieldSection _emailFieldSection;
        private TextFieldSection _phoneFieldSection;
        private TextFieldSection _passwordFieldSection;
        private TextFieldSection _passwordConfirmationFieldSection;
        private CallToActionSection _signUpSection;

        public SignUpFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public SignUpFormView()
        {
        }

        public TextFieldSection FirstNameFieldSection
        {
            get
            {
                return _firstNameFieldSection ?? (_firstNameFieldSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("First Name...")
                    .WithClearBackground()
                    .WithNextResponder(LastNameFieldSection));
            }
        }

        public TextFieldSection LastNameFieldSection
        {
            get
            {
                return _lastNameFieldSection ?? (_lastNameFieldSection = Formals.Create<TextFieldSection>()
                    .WithClearBackground()
                    .WithPlaceholder("Last Name...")

                    .WithNextResponder(EmailNameFieldSection));
            }
        }

        public TextFieldSection EmailNameFieldSection
        {
            get
            {
                return _emailFieldSection ?? (_emailFieldSection = Formals.Create<TextFieldSection>()
                    .WithClearBackground()
                    .WithPlaceholder("Email...")
                    .WithNextResponder(PhoneFieldSection));
            }
        }

        public TextFieldSection PhoneFieldSection
        {
            get
            {
                return _phoneFieldSection ?? (_phoneFieldSection = Formals.Create<TextFieldSection>()
                    .WithClearBackground()
                    .WithPlaceholder("Phone Number...")

                    .WithNextResponder(PasswordFieldSection));
            }
        }


        public TextFieldSection PasswordFieldSection
        {
            get
            {
                return _passwordFieldSection ?? (_passwordFieldSection = Formals.Create<TextFieldSection>()
                    .WithClearBackground()
                    .WithPlaceholder("Password...")
                    .WithSecureTextEntry()

                    .WithNextResponder(PasswordConfirmationFieldSection));
            }
        }

        public TextFieldSection PasswordConfirmationFieldSection
        {
            get
            {
                return _passwordConfirmationFieldSection ?? (_passwordConfirmationFieldSection = Formals.Create<TextFieldSection>()
                    .WithClearBackground()
                    .WithPlaceholder("Confirm Password...")
                    .WithSecureTextEntry()

                    .WithNextResponder(
                    () =>
                    {
                        ViewModel.SignUpCommand.Execute(null);
                    }));
            }
        }

        public CallToActionSection SignUpSection
        {
            get
            {
                return _signUpSection ?? (_signUpSection = Formals.Create<CallToActionSection>().WithClearBackground());
            }
        }

        public UIButton SignUpButton
        {
            get { return _signUpButton ?? (_signUpButton = SignUpSection.MainButton); }
        }

        public override string Title => "Create New Account";

        public override float VerticalSectionsSpacing => 8;

        public override void ViewWillAppear(bool animated)
	    {
	        base.ViewWillAppear(animated);

            SetCustomBackground(UIColor.FromPatternImage(UIImage.FromFile("background.png").ImageToFitSize(View.Frame.Size)));
          //  ExtendedLayoutIncludesOpaqueBars = false;
          //  EdgesForExtendedLayout = UIRectEdge.None;
            SignUpButton.SetTitle("Sign Up", UIControlState.Normal);

            
       
            var set = this.CreateBindingSet<SignUpFormView, SignUpFormViewModel>();
	        set.Bind(FirstNameFieldSection.TextField).For(f => f.Text).TwoWay().To(vm => vm.FirstName);
	        set.Bind(LastNameFieldSection.TextField).For(f => f.Text).TwoWay().To(vm => vm.LastName);
	        set.Bind(EmailNameFieldSection.TextField).For(f => f.Text).TwoWay().To(vm => vm.Email);
	        set.Bind(PhoneFieldSection.TextField).For(f => f.Text).TwoWay().To(vm => vm.PhoneNumber);
	        set.Bind(PasswordFieldSection.TextField).For(f => f.Text).TwoWay().To(vm => vm.Password);
	        set.Bind(PasswordConfirmationFieldSection.TextField).For(f => f.Text).TwoWay().To(vm => vm.PasswordConfirmation);
	        set.Bind(_signUpButton).To(vm => vm.SignUpCommand);
            set.Apply();

	}

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(FirstNameFieldSection);
            content.Add(LastNameFieldSection);
            content.Add(EmailNameFieldSection);
            content.Add(PhoneFieldSection);
            content.Add(PasswordFieldSection);
            content.Add(PasswordConfirmationFieldSection);
            content.Add(SignUpSection);
        }

        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


