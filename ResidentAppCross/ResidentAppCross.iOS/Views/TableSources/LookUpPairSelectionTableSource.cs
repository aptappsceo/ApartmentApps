using System;
using System.Collections.Generic;
using System.Text;
using ApartmentApps.Client.Models;
using Foundation;
using UIKit;

namespace ResidentAppCross.iOS.Views.TableSources
{
    public class LookUpPairSelectionTableSource : UITableViewSource
    {

        public string CellIdentifier => "LookUpPairCell";
        public LookupPairModel[] Items { get; set; }
        public Action<LookupPairModel> OnItemSelected { get; set; }




        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier) ?? new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            var item = Items[indexPath.Row];
            cell.TextLabel.Text = item.Value;
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            OnItemSelected(Items[indexPath.Row]);
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items.Length;
        }
    }
}
