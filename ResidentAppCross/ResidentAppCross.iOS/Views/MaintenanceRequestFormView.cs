using System;
using System.Collections.Specialized;
using System.Linq;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using ResidentAppCross.iOS.Extensions;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS.Views
{

    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    [NavbarStyling(Hidden = false)]
	public partial class MaintenanceRequestFormView : ViewBase<MaintenanceRequestFormViewModel>
	{

//        public new MaintenanceRequestFormViewModel ViewModel
//        {
//            get { return (MaintenanceRequestFormViewModel)base.ViewModel; }
//            set { base.ViewModel = value; }
//        }

        public override string Title => "Maintenance Request";

        public MaintenanceRequestFormView () : base ("MaintenanceRequestFormView", null)
		{

			this.DelayBind(() =>
				{
					var b = this.CreateBindingSet<MaintenanceRequestFormView, MaintenanceRequestFormViewModel>();
                    
					b.Bind(CommentsTextView).TwoWay().For(v => v.Text).To(vm => vm.Comments);

					ViewModel.ImagesToUpload.RawImages.CollectionChanged += ImagesChanged;

					b.Bind(SelectRequestTypeButton.TitleLabel).For(v => v.Text).To(vm => vm.SelectedRequestType.Value);
					b.Bind(AddPhotoButton).To(vm => vm.AddPhotoCommand);

					SelectRequestTypeButton.TouchUpInside += (sender, ea) =>
					{
						ShowRequestSelection();
					};

					b.Apply();

				});

		}

		private void ImagesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			PhotoContainer.ReloadData();
		}

	

		public void ShowRequestSelection()
		{
		    var selectionTable = new UITableViewController(UITableViewStyle.Grouped)
		    {
		        ModalPresentationStyle = UIModalPresentationStyle.Popover,
		        TableView =
		        {
		            LayoutMargins = new UIEdgeInsets(25, 25, 0, 50),
		            SeparatorColor = UIColor.Gray,
		            SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine
		        }
		    };


		    selectionTable.ExtendedLayoutIncludesOpaqueBars = false;
            selectionTable.EdgesForExtendedLayout = UIRectEdge.None;
			var uiTableViewHeaderFooterView = new UITableViewHeaderFooterView();
			selectionTable.TableView.TableHeaderView = uiTableViewHeaderFooterView;
			uiTableViewHeaderFooterView.TextLabel.Text = "Please, Select Request Type";

			selectionTable.TableView.Source = new LookUpPairSelectionTableSource()
			{
				Items = ViewModel.RequestTypes.ToArray(),
				OnItemSelected = item =>
				{
					ViewModel.SelectedRequestType = item;
				    NavigationController.PopViewController(true);
				}
			};

			selectionTable.TableView.LayoutIfNeeded();
			selectionTable.TableView.LayoutSubviews();

            NavigationController.PushViewController(selectionTable,true);

			//this.PresentViewController(selectionTable, true, null);
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
                (sender, args) => ViewModel.DoneCommand.Execute(null)), 
                true);


            PhotoContainer.RegisterClassForCell(typeof(PhotoGalleryCells), (NSString)PhotoGalleryCells.CellIdentifier);
            PhotoContainer.Source = new PhotoGallerySource(ViewModel.ImagesToUpload);
            PhotoContainer.ReloadData();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}



