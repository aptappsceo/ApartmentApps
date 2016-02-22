using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public partial class LoginView : ViewBase
    {
        public LoginView() : base("LoginView", null)
        {
        }

        public new LoginViewModel ViewModel 
        {
            get { return (LoginViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationItem.SetHidesBackButton(true, false);

            var b = this.CreateBindingSet<LoginView, LoginViewModel>();
            b.Bind(UsernameTextField).TwoWay().For(v=> v.Text).To(vm => vm.Username);
            b.Bind(PasswordTextField).TwoWay().For(v=> v.Text).To(vm => vm.Password);
            b.Bind(LoginButton).To(vm => vm.LoginCommand);
            b.Apply();

            UsernameTextField.ShouldReturn += (textField) => {
                PasswordTextField.BecomeFirstResponder();
                return true;
            };

            PasswordTextField.ShouldReturn += (textField) => {
                PasswordTextField.ResignFirstResponder();
                return true;
            };

            // Perform any additional setup after loading the view, typically from a nib.
        }
        
    }
}