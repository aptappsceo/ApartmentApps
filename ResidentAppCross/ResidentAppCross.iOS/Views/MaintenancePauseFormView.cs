using System;
using System.Collections.Specialized;
using System.Linq;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ObjCRuntime;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using UIKit;
using ZXing.Mobile;

namespace ResidentAppCross.iOS
{
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
	public partial class MaintenancePauseFormView : ViewBase<MaintenancePauseFormViewModel>
	{
		public MaintenancePauseFormView () : base ("MaintenancePauseFormView", null)
		{
            this.DelayBind(() =>
            {
                var b = this.CreateBindingSet<MaintenancePauseFormView, MaintenancePauseFormViewModel>();
                b.Bind(CommentsTextView).TwoWay().For(v => v.Text).To(vm => vm.Comments);
                b.Bind(AddPhotoButton).To(vm => vm.AddPhotoCommand);
                b.Apply();

                ViewModel.ImagesToUpload.RawImages.CollectionChanged += ImagesChanged;

                CommentsTextView.ReturnKeyType = UIReturnKeyType.Done;

                CommentsTextView.ShouldChangeText += (view, range, text) =>
                {
                    if (text == "\n")
                    {
                        CommentsTextView.ResignFirstResponder();
                        return false;
                    }
                    return true;
                };

            });
		}

        private void ImagesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            PhotoContainer.ReloadData();
            PhotoContainer.Hidden = !ViewModel.ImagesToUpload.RawImages.Any();
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
            NavigationController.PushViewController(view, true);
        }

        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            EdgesForExtendedLayout = UIRectEdge.None;
            this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
                "Back",
                UIBarButtonItemStyle.Plain,
                (sender, args) => NavigationController.PopViewController(true)),
                true);

            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem
                ("Done",
                UIBarButtonItemStyle.Plain,
                (sender, args) => PushScannerViewController(()=>ViewModel.DoneCommand.Execute(null))),
                true);

            PhotoContainer.Hidden = !ViewModel.ImagesToUpload.RawImages.Any();
            PhotoContainer.BackgroundColor = UIColor.White;
            PhotoContainer.RegisterClassForCell(typeof(PhotoGalleryCells), (NSString)PhotoGalleryCells.CellIdentifier);
            PhotoContainer.Source = new PhotoGallerySource(ViewModel.ImagesToUpload);
            PhotoContainer.ReloadData();
        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


