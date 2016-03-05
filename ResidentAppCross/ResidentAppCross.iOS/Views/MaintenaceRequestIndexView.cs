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
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class MaintenaceRequestIndexView : ViewBase
	{
		public MaintenaceRequestIndexView () : base ("MaintenaceRequestIndexView", null)
		{
		}

        public new MaintenanceRequestIndexViewModel ViewModel
        {
            get { return (MaintenanceRequestIndexViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

	    public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            //var context = this.CreateBindingSet<MaintenaceRequestIndexView,MaintenanceRequestIndexViewModel>();
            ListWebView.ShouldStartLoad += ShouldStartLoad;


        }

	    private bool ShouldStartLoad(UIWebView webview, NSUrlRequest request, UIWebViewNavigationType navigationtype)
	    {
	        var url = request.Url.ToString();
	        if (url == ViewModel.Url) return true;
	        return ShouldTransition(webview, request, navigationtype);
	    }

	    private bool ShouldTransition(UIWebView webview, NSUrlRequest request, UIWebViewNavigationType navigationtype)
	    {
	        ViewModel.RequestAction(request.Url.ToString());
	        return false;
	    }


	    public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.SetNavigationBarHidden(false, true);
            var s = "Bearer " + App.ApartmentAppsClient.AparmentAppsDelegating.AuthorizationKey;

            var request2 = new NSMutableUrlRequest(NSUrl.FromString(ViewModel.Url));
            request2.Headers = request2.Headers ?? NSDictionary.FromObjectAndKey(FromObject(s), FromObject("Authorization"));

            var headers = request2.Headers;
            NSUrlCache.SharedCache.RemoveAllCachedResponses();
            ListWebView.LoadRequest(request2);

        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


