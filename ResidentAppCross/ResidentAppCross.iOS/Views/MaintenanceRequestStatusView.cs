using System;
using ApartmentApps.Client.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class MaintenanceRequestStatusView : ViewBase<MaintenanceRequestStatusViewModel>
	{

        /* 
        //TODO: README
        //TODO: README
        //TODO: README
            

        // if you want to make it work quick and dirty, fallback to the following method
        // to update all kinds of labels.
        */

        private void OnRequestChanged(MaintenanceBindingModel request)
        {

            //How to show photos
            //1. Populate ViewModel.AttachedPhotos
            //2. Uncomment the following code.

            //            PhotoContainer.RegisterClassForCell(typeof(PhotoGalleryCells), (NSString)PhotoGalleryCells.CellIdentifier);
            //            PhotoContainer.Source = new PhotoGallerySource(ViewModel.AttachedPhotos);
            //            PhotoContainer.ReloadData();


            //TODO: Important note:
            //View has 2 headers and 2 footers


            var headerWhenRequestIsPaused = HeaderSectionPaused;
            var headerForAnyOtherCase = HeaderSectionPending;

            var footerWhenInProgress = FooterSectionPending;
            var footerWhenPausedOrNeverStarted = FooterSectionStart;

            UpdateHeadersAndFooters(request);


            //Hide/Show those depending on the state of the request;

            this.CommentsTextView.Text = request.Message;
            this.TenantFullNameLabel.Text = request.UserName;
            
            //this.EntrancePermissionSwitch.On = request.PermissionToEnter;
        }

	    private void UpdateHeadersAndFooters(MaintenanceBindingModel request)
	    {
	        RequestStatus status;
	        Enum.TryParse(request.Status, out status);

	        HeaderSectionPaused.Hidden = true;
            
	    }

        public enum RequestStatus
	    {
	        Complete,
            Paused,
            Scheduled,
            Started,
            Submitted
	    }

	    public MaintenanceRequestStatusView () : base ("MaintenanceRequestStatusView", null)
		{
		}

	    public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
	        ViewModel.PropertyChanged += (sender, args) =>
	        {
	            if (args.PropertyName == "Request")
	            {
	                this.OnRequestChanged(ViewModel.Request);
	            }
	        };
		}

	    public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


