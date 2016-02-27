﻿using System;
using System.Collections.Specialized;
using System.Linq;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using ResidentAppCross.iOS.Extensions;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
	public partial class MaintenanceRequestFormView : ViewBase
	{
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

//					PetTypeSelection.RemoveAllSegments();
//
//                    PetTypeSelection.InsertSegment("No Pet",0,false);
//                    PetTypeSelection.InsertSegment("Yes, Contained",1,false);
//                    PetTypeSelection.InsertSegment("Yes, Free",2,false);

				});

		}

		private void ImagesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			PhotoContainer.ReloadData();
		}

		public new MaintenanceRequestFormViewModel ViewModel
		{
			get { return (MaintenanceRequestFormViewModel) base.ViewModel; }
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

			this.NavigationController.SetNavigationBarHidden(false, true);
			this.NavigationController.NavigationBar.BarTintColor = new UIColor(20f/255,92f/255,153f/255,1f);
			this.Title = "Maintenance Request";

			this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
				UIImage.FromBundle("HomeIcon"), UIBarButtonItemStyle.Plain, (sender, args) => {
					NavigationController.PopViewController(true);
				}), true);


			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem("Done"
					, UIBarButtonItemStyle.Plain
					, (sender, args) => {
						ViewModel.DoneCommand.Execute(null);
					})
				, true);


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


