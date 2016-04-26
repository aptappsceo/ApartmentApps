using System;
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
	public partial class SignUpFormView : ViewBase<SignUpFormViewModel>
	{
		public SignUpFormView () : base ("SignUpFormView", null)
		{
		}

        public SignUpFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        
        }

        public override string Title => "Create New Account";

        public override void ViewWillAppear(bool animated)
	    {
	        base.ViewWillAppear(animated);

            ExtendedLayoutIncludesOpaqueBars = false;
            EdgesForExtendedLayout = UIRectEdge.None;

            var set = this.CreateBindingSet<SignUpFormView, SignUpFormViewModel>();
	        set.Bind(_firstNameField).For(f => f.Text).TwoWay().To(vm => vm.FirstName);
	        set.Bind(_lastNameField).For(f => f.Text).TwoWay().To(vm => vm.LastName);
	        set.Bind(_emailTextField).For(f => f.Text).TwoWay().To(vm => vm.Email);
	        set.Bind(_phoneNumberField).For(f => f.Text).TwoWay().To(vm => vm.PhoneNumber);
	        set.Bind(_passwordField).For(f => f.Text).TwoWay().To(vm => vm.Password);
	        set.Bind(_passwordConfirmationField).For(f => f.Text).TwoWay().To(vm => vm.PasswordConfirmation);
	        set.Bind(_signUpButton).To(vm => vm.SignUpCommand);
            set.Apply();

            _emailTextField.ShouldReturn += (textField) =>{_phoneNumberField.BecomeFirstResponder();return true;};
            _phoneNumberField.ShouldReturn += (textField) =>{_firstNameField.BecomeFirstResponder();return true;};
            _firstNameField.ShouldReturn += (textField) =>{_lastNameField.BecomeFirstResponder();return true;};
            _lastNameField.ShouldReturn += (textField) =>{_passwordField.BecomeFirstResponder();return true;};
            _passwordField.ShouldReturn += (textField) =>{_passwordConfirmationField.BecomeFirstResponder();return true;};
            _passwordConfirmationField.ShouldReturn += (textField) =>{_passwordConfirmationField.ResignFirstResponder();return true;};

	}

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("background.png").ImageToFitSize(View.Frame.Size));

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


