using System;
using System.Linq;
using System.Threading.Tasks;
using ApartmentApps.Client.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform.iOS;
using ObjCRuntime;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;
using SharpMobileCode.ModalPicker;
using UIKit;
using ZXing;
using ZXing.Mobile;
using ZXing.QrCode.Internal;

namespace ResidentAppCross.iOS
{

    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
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

            SelectRepairDateButton.TitleLabel.Text = request.ScheduleDate?.ToString("g") ?? "Select Date";
            SelectRepairDateButton.SizeToFit();

            PhotoContainer.Hidden = true;
            PhotoTitleLabel.Text = "No Photos Attached.";

            var lastCheckin = request.Checkins.LastOrDefault();
            RepairDateChangeTitleLabel.Text = lastCheckin;
            RepairDateChangeDateLabel.Text = "";

            TenantAddressFirstLineLabel.Text = request.BuildingName+" "+request.BuildingAddress;
            TenantAddressFirstLineLabel.Text = request.BuildingCity+" "+request.BuildingState;

            PhotoContainer.BackgroundColor = UIColor.White;
            PetSelection.SelectedSegment = ViewModel.SelectedPetStatus;

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



        public MaintenanceRequestStatusView() : base("MaintenanceRequestStatusView", null)
        {
            this.DelayBind(() =>
            {
                var b = this.CreateBindingSet<MaintenanceRequestStatusView, MaintenanceRequestStatusViewModel>();
                //b.Bind(FooterStartButton).To(vm => vm.StartOrResumeCommand);
                b.Bind(SelectRepairDateButton).For("Title").To(vm => vm.SelectScheduleDateActionLabel);
                b.Bind(FooterPauseButton).To(vm=>vm.PauseCommmand);
                b.Apply();
                SelectRepairDateButton.TouchUpInside += ShowScheduleDatePicker;
                FooterStartButton.TouchUpInside += (sender, args) => PushScannerViewController(() => ViewModel.StartOrResumeCommand.Execute(null));
      
                FooterFinishButton.TouchUpInside += (sender, args) => PushScannerViewController(() => ViewModel.FinishCommmand.Execute(null));
            });
        }

        private void PushScannerViewController(Action onScanned)
        {

            if (ObjCRuntime.Runtime.Arch == Arch.SIMULATOR)
            {
                ViewModel.ScanResult = new QRData()
                {
                    Data = "Simulated Text",
                    ImageData = new byte[0],
                    Timestamp = DateTime.Now.Ticks
                };
                onScanned();
                return;
            }

            var view = new AVCaptureScannerViewController(
            new MobileBarcodeScanningOptions()
            {
            },
            new MobileBarcodeScanner()
            {
            });
            view.OnScannedResult += _ =>
            {
                NavigationController.PopViewController(true);
                ViewModel.ScanResult = new QRData()
                {
                    Data = _.Text,
                    ImageData = _.RawBytes,
                    Timestamp = _.Timestamp
                };

                onScanned?.Invoke();
            };
            NavigationController.PushViewController(view,true);
        }

        public async void ShowScheduleDatePicker(object sender, EventArgs eventArgs)
        {
            var modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Select A Date", this)
            {
                HeaderBackgroundColor = AppTheme.SecondaryBackgoundColor,
                HeaderTextColor = UIColor.White,
                TransitioningDelegate = new ModalPickerTransitionDelegate(),
                ModalPresentationStyle = UIModalPresentationStyle.Custom
            };

            modalPicker.DatePicker.Mode = UIDatePickerMode.DateAndTime;

            modalPicker.OnModalPickerDismissed += (s, ea) =>
            {
                modalPicker.DismissModalViewController(true);
                ViewModel.ScheduleMaintenanceCommand.Execute(modalPicker.DatePicker.Date.ToDateTimeUtc());
            };

            await PresentViewControllerAsync(modalPicker, true);

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
