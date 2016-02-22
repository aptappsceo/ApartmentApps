using System;
using System.Linq;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
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

                b.Bind(CommentsTextField).TwoWay().For(v => v.Text).To(vm => vm.Comments);
                b.Bind(RequestTypeSelectionButton).For(v => v.TitleLabel.Text).To(vm => vm.SelectedRequestType);
                RequestTypeSelectionButton.TouchUpInside += (sender, ea) =>
                {
                    ShowRequestSelection();
                };
                b.Apply();
                RequestTypeSelectionButton.TitleLabel.Text = "Select >";
            });

		}

	    public new MaintenanceRequestViewModel ViewModel
	    {
	        get { return (MaintenanceRequestViewModel) base.ViewModel; }
	        set { base.ViewModel = value; }
	    }


	    public void ShowRequestSelection()
	    {
            var selectionTable = new UITableViewController(UITableViewStyle.Plain);
            selectionTable.TableView.Source = new LookUpPairSelectionTableSource()
            {
                Items = ViewModel.RequestTypes.ToArray(),
                OnItemSelected = item =>
                {
                    ViewModel.SelectedRequestType = item;
                    selectionTable.DismissViewController(true,()=> {});
                }
            };
            selectionTable.ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen;
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


