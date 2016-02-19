using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public partial class LoginView : MvxViewController
    {
        public LoginView() : base("LoginView", null)
        {
        }

        protected LoginView(string nibName, NSBundle bundle) : base(nibName, bundle)
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
            this.CreateBinding(UsernameLabel).For(v=> v.Text ).To((LoginViewModel vm) => vm.Password).Apply();
            // Perform any additional setup after loading the view, typically from a nib.
        }
        
    }
}