using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using CoreGraphics;
using Foundation;
using ResidentAppCross.Resources;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public class HomeMenuTableSource : UITableViewSource
    {

        public HomeMenuItemViewModel[] Items { get; set; }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            HomeMenuTableCell cell = tableView.DequeueReusableCell(HomeMenuTableCell.CellIdentifier) as HomeMenuTableCell;
            if (cell == null)
            {
                cell = new HomeMenuTableCell(new NSString(HomeMenuTableCell.CellIdentifier));
            }
            var item = Items[indexPath.Row];
            cell.MainLabel.Text = item.Name;

            cell.IconView.Image = AppTheme.GetTemplateIcon(item.Icon, SharedResources.Size.S,true);
            cell.IconView.TintColor = AppTheme.SecondaryBackgoundColor;
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

    public class HomeMenuTableCell : UITableViewCell
    {
        public const string CellIdentifier = "HomeMenuCell";

        public HomeMenuTableCell(NSString cellId) : base (UITableViewCellStyle.Default, cellId)
        {
            MainLabel = new UILabel(new CGRect(44 + 15f + 8f, 0, ContentView.Frame.Width, 44))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
            };

            IconView = new UIImageView(new CGRect(15f,0, 44, 44).PadInside(6f,6f));

            ContentView.AddSubview(MainLabel);
            ContentView.AddSubview(IconView);
        }

        public UILabel MainLabel { get; set; }
        public UIImageView IconView { get; set; }
    }

}
