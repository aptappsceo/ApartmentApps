using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using ResidentAppCross.iOS.Views.TableSources;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class TableSection : SectionViewBase
	{
	    private bool _isLoading;
	    private UIActivityIndicatorView _indicator;

	    public TableSection()
	    {
        }

        public TableSection (IntPtr handle) : base (handle)
		{
        }

	    public UITableView Table => TableView;

        public UITableViewSource Source
        {
            get { return TableView.Source; }
            set { TableView.Source = value; }
        }

	    public override UIEdgeInsets LayoutMargins => UIEdgeInsets.Zero;

	    public UIActivityIndicatorView Indicator
	    {
	        get
	        {
	            if (_indicator == null)
	            {
	                _indicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
	            }
                return _indicator;
	        }
	        set { _indicator = value; }
	    }

	    public void ReloadData()
	    {
	        Table.ReloadData();
	    }

	    public void ReloadDataAnimated(UIViewAnimationOptions opts)
	    {
            UIView.Transition(TableView, 0.35f, opts, () => Table.ReloadData(),
                () => { });
        }

	    public void SetLoading(bool loading)
	    {
	        if (loading)
	        {
	            //TableView.TableHeaderView = Indicator;
	            //UIView.Transition(TableView, Indicator, 0.35f, UIViewAnimationOptions.TransitionFlipFromBottom, () => { });
	        }
	        else
	        {
                //TableView.TableHeaderView = null;
                //UIView.Transition(Indicator, TableView, 0.35f, UIViewAnimationOptions.TransitionFlipFromBottom, () => { });
            }
        }
    }
}
