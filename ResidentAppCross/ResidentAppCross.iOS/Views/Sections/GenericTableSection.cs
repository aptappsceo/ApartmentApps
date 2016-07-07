using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class GenericTableSection : SectionViewBase
    {
		public GenericTableSection (IntPtr handle) : base (handle)
		{
		}

	    public GenericTableSection()
	    {
	    }

	    public UITableView Table => _tableView;


    }
}
