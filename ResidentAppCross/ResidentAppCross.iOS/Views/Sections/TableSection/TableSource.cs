using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;

namespace ResidentAppCross.iOS.Views.TableSources
{
    public class TableSource : UITableViewSource
    {

        public object[] Items { get; set; }
        public CollectionDataBinding Binding { get; set; }

        public Type CellType => Binding.CellType;
        public string CellIdentifier => CellType?.Name;
        public Func<UITableViewCell> CellFactory { get; set; }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier) ?? CellFactory?.Invoke() ?? (UITableViewCell)Formals.Create(CellType);
            Binding?.ObjectBind?.Invoke(cell, Items[indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items?.Length ?? 0;
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return Binding?.ObjectIsEditable?.Invoke(Items[indexPath.Row]) ?? false;
        }

        public override bool CanFocusRow(UITableView tableView, NSIndexPath indexPath)
        {
            return Binding?.ObjectIsFocusable?.Invoke(Items[indexPath.Row]) ?? true;
        }

        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return Binding.ObjectIsMoveable?.Invoke(Items[indexPath.Row]) ?? true;
        }

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return new [] { UITableViewRowAction.Create(UITableViewRowActionStyle.Default, "One", (x,a)=> { Debug.WriteLine("doing action1"); }) };
        }
    }

    public class TableCell : UITableViewCell
    {

        public TableCell(string reuseIdentifier) : base(UITableViewCellStyle.Default, reuseIdentifier)
        {
        }

        public string HeaderTitle
        {
            get { return TextLabel.Text; }
            set { TextLabel.Text = value; }
        }
    }

    public class TableDataBinding<C,T> : CollectionDataBinding where C : UITableViewCell
    {

        public Action<C, T> Bind
        {
            set { ObjectBind = (c, o) => value((C)c, (T)o); }
        }

        public Func<T, bool> IsMoveable
        {
            set { ObjectIsMoveable = o => value((T)o); }
        }

        public Func<T, bool> IsFocusable
        {
            set { ObjectIsFocusable = o => value((T)o); }
        }

        public Func<T, bool> IsEditable
        {
            set { ObjectIsEditable = o => value((T)o); }
        }

        public override Type CellType => typeof (C);
        public override Type DataType => typeof (T);
    }

    public class CollectionDataBinding<C,T> : CollectionDataBinding where C : UICollectionViewCell
    {

        public Action<C, T> Bind
        {
            set { ObjectBind = (c, o) => value((C)c, (T)o); }
        }

        public Func<T, bool> IsMoveable
        {
            set { ObjectIsMoveable = o => value((T)o); }
        }

        public Func<T, bool> IsFocusable
        {
            set { ObjectIsFocusable = o => value((T)o); }
        }

        public Func<T, bool> IsEditable
        {
            set { ObjectIsEditable = o => value((T)o); }
        }

        public override Type CellType => typeof (C);
        public override Type DataType => typeof (T);
    }

    public class CollectionDataBinding
    {
        public virtual Type CellType { get; }
        public virtual Type DataType { get; }
        public Action<object, object> ObjectBind { get; set; }
        public Func<object,bool> ObjectIsMoveable { get; set; }
        public Func<object,bool> ObjectIsFocusable { get; set; }
        public Func<object,bool> ObjectIsEditable { get; set; }
    }




}
