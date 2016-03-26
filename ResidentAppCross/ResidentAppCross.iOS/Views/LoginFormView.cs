﻿
using System;
using ApartmentApps.Client;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.PictureChooser.iOS;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using UIKit;

namespace ResidentAppCross.iOS
{

    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class LoginFormView : ViewBase
    {
        public LoginFormView() : base("LoginFormView", null)
        {
        }

        public new LoginFormViewModel ViewModel
        {
            get { return (LoginFormViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            LoginTextField.SetLeftIcon("HouseIcon");
            PasswordTextField.SetLeftIcon("OfficerIcon");
            View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("background.png").ImageToFitSize(View.Frame.Size));
            this.NavigationController.SetNavigationBarHidden(true, false);


            NSTextAttachment attachment = new NSTextAttachment();
            attachment.Image = UIImage.FromBundle("PayIcon");
            NSAttributedString str = NSAttributedString.CreateFrom(attachment);
            var myString = new NSMutableAttributedString("Ok Here We Go");

            myString.Insert(str, 0);

           
            LoginButton.SetAttributedTitle(myString,UIControlState.Normal);

        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            _textFieldsContainer.Layer.CornerRadius = 8f;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //Hide nav bar

            var b = this.CreateBindingSet<LoginFormView, LoginFormViewModel>();
            b.Bind(LoginTextField).TwoWay().For(v => v.Text).To(vm => vm.Username);
            b.Bind(PasswordTextField).TwoWay().For(v => v.Text).To(vm => vm.Password);
            b.Bind(LoginButton).To(vm => vm.LoginCommand);
            //b.Bind(ForgotPasswordButton).To(vm => vm.RemindPasswordCommand);
            b.Bind(_signUpButton).To(vm => vm.SignUpCommand);
            b.Apply();


            ForgotPasswordButton.SetTitle("Selected Endpoint: Azure",UIControlState.Selected | UIControlState.Normal | UIControlState.Focused);

            ForgotPasswordButton.TouchUpInside += (sender, args) =>
            {
                var controller = new UIAlertController();
                controller.Title = "Select Endpoint";
                controller.AddAction(UIAlertAction.Create("Default (Azure)", UIAlertActionStyle.Default, x =>
                {
                    ForgotPasswordButton.SetTitle("Selected Endpoint: Azure", UIControlState.Selected | UIControlState.Normal | UIControlState.Focused);

                    Mvx.Resolve<IApartmentAppsAPIService>().BaseUri =
                        new Uri("http://apartmentappsapiservice.azurewebsites.net");
                }));

                controller.AddAction(UIAlertAction.Create("82.151.208.56 (Sini PC)", UIAlertActionStyle.Default,
                    x =>
                    {
                        ForgotPasswordButton.SetTitle("Selected Endpoint: Sini PC", UIControlState.Selected | UIControlState.Normal | UIControlState.Focused);

                        Mvx.Resolve<IApartmentAppsAPIService>().BaseUri = new Uri("http://82.151.208.56.xip.io:54683");
                    }));

                controller.AddAction(UIAlertAction.Create("Open Test Form", UIAlertActionStyle.Default,
                    x =>
                    {
                        ViewModel.OpenTestFormCommand.Execute(null);
                    }));


                this.PresentViewController(controller, true, () => { });
            };

            LoginTextField.ShouldReturn += (textField) =>
            {
                PasswordTextField.BecomeFirstResponder();
                return true;
            };

            PasswordTextField.ShouldReturn += (textField) =>
            {
                PasswordTextField.ResignFirstResponder();
                return true;
            };


            // Perform any additional setup after loading the view, typically from a nib.
        }

    }
}
