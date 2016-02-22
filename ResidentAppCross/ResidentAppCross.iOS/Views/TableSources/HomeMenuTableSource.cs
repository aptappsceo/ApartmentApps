using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public class HomeMenuTableSource : UITableViewSource
    {

        public HomeMenuItemViewModel[] Items { get; set; }
        public string CellIdentifier { get; set; } = "HomeMenuCell";


        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            var item = Items[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default,CellIdentifier);
            }

            cell.TextLabel.Text = item.Name;
            cell.ImageView.Image = UIImage.FromBundle(item.Icon.ToString());
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            var item = Items[indexPath.Row];
            item.Command.Execute(null);
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items.Length;
        }
    }
}
