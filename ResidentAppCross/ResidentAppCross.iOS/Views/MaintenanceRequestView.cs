using System;
using System.Collections.Specialized;
using System.Linq;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using ResidentAppCross.iOS.Extensions;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class MaintenanceRequestView : ViewBase
	{
		public MaintenanceRequestView () : base ("MaintenanceRequestView", null)
		{

            this.DelayBind(() =>
            {
                var b = this.CreateBindingSet<MaintenanceRequestView, MaintenanceRequestViewModel>();

                // b.Bind(CommentsTextField).TwoWay().For(v => v.Text).To(vm => vm.Comments);
                PhotosContainer.HeightAnchor.ConstraintEqualTo(150);

                ViewModel.ImagesToUpload.RawImages.CollectionChanged += ImagesChanged;

                b.Bind(RequestTypeSelectionButton.TitleLabel).For(v => v.Text).To(vm => vm.SelectedRequestType.Value);
                b.Bind(AddPhotoButton).To(vm => vm.AddPhotoCommand);

                RequestTypeSelectionButton.TouchUpInside += (sender, ea) =>
                {
                    ShowRequestSelection();
                };

                b.Apply();


            });

		}

        private void ImagesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ImageAdded(e.NewItems[0] as ImageBundleItemViewModel);
            }
        }

	    private void ImageAdded(ImageBundleItemViewModel newItem)
	    {
            var imageView = new UIImageView();
            imageView.Image = newItem.Data.ToImage();
            PhotosContainer.AddArrangedSubview(imageView);
            View.LayoutIfNeeded();
            View.LayoutSubviews();
	    }

	    public new MaintenanceRequestViewModel ViewModel
	    {
	        get { return (MaintenanceRequestViewModel) base.ViewModel; }
	        set { base.ViewModel = value; }
	    }

        public void ShowRequestSelection()
	    {
	        var selectionTable = new UITableViewController(UITableViewStyle.Grouped)
	        {
	            ModalPresentationStyle = UIModalPresentationStyle.FullScreen,
	            TableView =
	            {
	                LayoutMargins = new UIEdgeInsets(25, 25, 0, 50),
	                SeparatorColor = UIColor.Gray,
	                SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine
	            }
            };
            var uiTableViewHeaderFooterView = new UITableViewHeaderFooterView();
            selectionTable.TableView.TableHeaderView = uiTableViewHeaderFooterView;
            uiTableViewHeaderFooterView.TextLabel.Text = "Please, Select Request Type";

            selectionTable.TableView.Source = new LookUpPairSelectionTableSource()
            {
                Items = ViewModel.RequestTypes.ToArray(),
                OnItemSelected = item =>
                {
                    ViewModel.SelectedRequestType = item;
                    selectionTable.DismissViewController(true,()=> {});
                }
            };

            selectionTable.TableView.LayoutIfNeeded();
            selectionTable.TableView.LayoutSubviews();

            this.PresentViewController(selectionTable, true, null);
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


