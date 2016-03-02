using System;
using ApartmentApps.Client.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;
using UIKit;
using ZXing.Mobile;
using ZXing.QrCode.Internal;

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


            UpdateHeadersAndFooters(request);


            //Hide/Show those depending on the state of the request;

            CommentsTextView.Text = request.Message;
            TenantFullNameLabel.Text = request.UserName;

            //this.EntrancePermissionSwitch.On = request.PermissionToEnter;
        }

	    private void UpdateHeadersAndFooters(MaintenanceBindingModel request)
	    {
	        var status = ViewModel.CurrentRequestStatus;
            HeaderSectionPaused.Hidden = status != RequestStatus.Paused;
	        HeaderSectionPending.Hidden = status == RequestStatus.Paused;

	        FooterSectionPending.Hidden = status != RequestStatus.Started;
	        FooterSectionStart.Hidden = status == RequestStatus.Started;

	    }

     

	    public MaintenanceRequestStatusView () : base ("MaintenanceRequestStatusView", null)
		{
            this.DelayBind(() =>
            {
                var b = this.CreateBindingSet<MaintenanceRequestStatusView, MaintenanceRequestStatusViewModel>();
                //b.Bind(FooterStartButton).To(vm => vm.StartOrResumeCommand);
                b.Apply();
                FooterStartButton.TouchUpInside += (sender, args) =>
                {
                    var view = new AVCaptureScannerViewController(new MobileBarcodeScanningOptions()
                    {
                        
                    },
                    new MobileBarcodeScanner()
                    {
                            
                    });

                    view.OnScannedResult += result =>
                    {
                        NavigationController.PopViewController(true);
                        ViewModel.ScanResult = new QRData()
                        {
                            Data = result.Text,
                            ImageData = result.RawBytes,
                            Timestamp = result.Timestamp
                        };
                        ViewModel.StartOrResumeCommand.Execute(null);
                    };

                    NavigationController.PushViewController(view,true);

                };
            });
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


