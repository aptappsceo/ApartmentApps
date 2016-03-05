using System;
using System.Collections.Specialized;
using System.Linq;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
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

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
        }

        public MaintenanceRequestFormView () : base ("MaintenanceRequestFormView", null)
		{
			this.DelayBind(() =>
				{
					var b = this.CreateBindingSet<MaintenanceRequestFormView, MaintenanceRequestFormViewModel>();
					b.Bind(CommentsTextView).TwoWay().For(v => v.Text).To(vm => vm.Comments);
                    b.Bind(SelectRequestTypeButton).For("Title").To(vm => vm.SelectRequestTypeActionTitle);
                    b.Bind(AddPhotoButton).To(vm => vm.AddPhotoCommand);
				    b.Bind(EntrancePermissionSwitch).TwoWay().To(vm => vm.EntrancePermission);
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

					SelectRequestTypeButton.TouchUpInside += (sender, ea) => ShowRequestSelection2();

                    PetTypeSelection.ValueChanged += PetTypeSelection_ValueChanged;

                    PhotoContainer.Hidden = !ViewModel.ImagesToUpload.RawImages.Any();

                });

		}

        private void PetTypeSelection_ValueChanged(object sender, EventArgs e)
        {
            ViewModel.SelectedPetStatus = (int)PetTypeSelection.SelectedSegment;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            PhotoContainer.BackgroundColor = UIColor.White;
            PetTypeSelection.SelectedSegment = ViewModel.SelectedPetStatus ?? -1;
        }

        private void ImagesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			PhotoContainer.ReloadData();
            PhotoContainer.Hidden = !ViewModel.ImagesToUpload.RawImages.Any();
		}


        public void ShowRequestSelection2()
        {
            var selectionTable = new UITableViewController(UITableViewStyle.Grouped)
            {
                ModalPresentationStyle = UIModalPresentationStyle.Popover,
                TableView =
                {
                    //LayoutMargins = new UIEdgeInsets(25, 25, 0, 50),
                    SeparatorColor = UIColor.Gray,
                    SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine
                }
            };

            var tableView = selectionTable.TableView;
            var source = new MvxStandardTableViewSource(tableView, "TitleText Value");
            tableView.Source = source;
            var searchBar = new UISearchBar()
            {
                AutocorrectionType = UITextAutocorrectionType.Yes,
                KeyboardType = UIKeyboardType.WebSearch
            };
            tableView.TableHeaderView = searchBar;
            searchBar.SizeToFit();
            searchBar.Placeholder = "Search...";
            searchBar.OnEditingStopped += (sender, args) =>
            {
                searchBar.ResignFirstResponder();
            };

            var b = this.CreateBindingSet<MaintenanceRequestFormView, MaintenanceRequestFormViewModel>();

            b.Bind(source).To(vm => vm.RequestTypesFiltered);
            b.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.UpdateRequestTypeSelection);
            b.Bind(searchBar).For(searchBar.Text).TwoWay().To(vm => vm.RequestTypeSearchText);
            b.Apply();

            selectionTable.EdgesForExtendedLayout = UIRectEdge.None;

            selectionTable.Title = "Select Type";

            source.SelectedItemChanged += (i, e) => { NavigationController.PopViewController(true); };
            NavigationController.PushViewController(selectionTable, true);
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

            var searchBar = new UISearchBar()
            {
                AutocorrectionType = UITextAutocorrectionType.Yes,
                KeyboardType = UIKeyboardType.WebSearch
            };

            selectionTable.TableView.TableHeaderView = searchBar;
            searchBar.SizeToFit();
            searchBar.Placeholder = "Search...";
            searchBar.OnEditingStopped += (sender, args) =>
            {
                searchBar.ResignFirstResponder();
            };


		    var source = new LookUpPairSelectionTableSource()
		    {
		        Items = ViewModel.RequestTypes.ToArray(),
		        OnItemSelected = item =>
		        {
		            ViewModel.UpdateRequestTypeSelection.Execute(item);
		            NavigationController.PopViewController(true);
		        }
		    };
		    selectionTable.TableView.Source = source;

            var b = this.CreateBindingSet<MaintenanceRequestFormView, MaintenanceRequestFormViewModel>();

            b.Bind(source).To(vm => vm.RequestTypesFiltered);
            b.Bind(searchBar).For(searchBar.Text).TwoWay().To(vm => vm.RequestTypeSearchText);

            b.Apply();


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



