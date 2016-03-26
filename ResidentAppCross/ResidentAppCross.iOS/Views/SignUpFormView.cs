using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
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

        public override void ViewWillAppear(bool animated)
	    {
	        base.ViewWillAppear(animated);

            ExtendedLayoutIncludesOpaqueBars = false;
            EdgesForExtendedLayout = UIRectEdge.None;

            var set = this.CreateBindingSet<SignUpFormView, SignUpFormViewModel>();

	        set.Bind(_firstLastNameTextField).For(f => f.Text).TwoWay().To(vm => vm.FirstLastName);
	        set.Bind(_emailTextField).For(f => f.Text).TwoWay().To(vm => vm.Email);
	        set.Bind(_birthdayField).For(f => f.Text).TwoWay().To(vm => vm.BirthdayTitle);
	        set.Bind(_usernameField).For(f => f.Text).TwoWay().To(vm => vm.Username);
	        set.Bind(_passwordField).For(f => f.Text).TwoWay().To(vm => vm.Password);
	        set.Bind(_passwordConfirmationField).For(f => f.Text).TwoWay().To(vm => vm.PasswordConfirmation);
	        set.Bind(_signUpButton).To(vm => vm.SignUpCommand);
            set.Apply();

            _birthdayField.EditingDidBegin += (sender, args) =>
            {
                _birthdayField.ResignFirstResponder();
                _birthdayField.EndEditing(true);
                ViewModel.SelectBirthdayCommand.Execute(null);
            };

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


