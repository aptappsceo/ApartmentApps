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

	    public void ReloadData()
	    {
	        TableView.ReloadData();
	    }
	}
}
