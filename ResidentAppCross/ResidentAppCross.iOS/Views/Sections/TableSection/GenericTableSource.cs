using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;

namespace ResidentAppCross.iOS.Views.TableSources
{
    public class GenericTableSource : UITableViewSource
    {
        public IList Items { get; set; }

        public CollectionDataBinding Binding { get; set; }

        public bool ItemsEditableByDefault { get; set; } = false;
        public bool ItemsMovableByDefault { get; set; } = false;
        public bool ItemsFocusableByDefault { get; set; } = false;
        public int ItemsDefaultIndentation { get; set; } = 0;
        public UITableViewCellAccessory ItemsDefaultAccessory { get; set; } =  UITableViewCellAccessory.None;
        public UITableViewCellEditingStyle ItemsDefaultEditingStyle { get; set; } = UITableViewCellEditingStyle.Delete;
        public string DeleteButtonTitle { get; set; } = "Remove";
        public bool IndentWhileIditing { get; set; } = true;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(Binding.CellIdentifier) ?? Binding?.ObjectCellSelector();
            Binding?.ObjectBind?.Invoke(cell, Items[indexPath.Row]);
            cell.Accessory = Binding.ObjectAccessoryType?.Invoke(Items[indexPath.Row]) ?? ItemsDefaultAccessory;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items?.Count ?? 0;
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return Binding?.ObjectIsEditable?.Invoke(Items[indexPath.Row]) ?? ItemsEditableByDefault;
        }

        public override bool CanFocusRow(UITableView tableView, NSIndexPath indexPath)
        {
            return Binding?.ObjectIsFocusable?.Invoke(Items[indexPath.Row]) ?? ItemsFocusableByDefault;
        }

        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return Binding.ObjectIsMoveable?.Invoke(Items[indexPath.Row]) ?? ItemsMovableByDefault;
        }

        public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return Binding.ObjectEditingStyle?.Invoke(Items[indexPath.Row]) ?? ItemsDefaultEditingStyle;
        }

        public override nint IndentationLevel(UITableView tableView, NSIndexPath indexPath)
        {
            return Binding.ObjectIndentationLevel?.Invoke(Items[indexPath.Row]) ?? ItemsDefaultIndentation;
        }

        public override NSIndexPath WillSelectRow(UITableView tableView, NSIndexPath indexPath)
        {
            return indexPath;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Binding.ObjectItemSelected?.Invoke(Items[indexPath.Row]);
        }

        public override bool ShouldIndentWhileEditing(UITableView tableView, NSIndexPath indexPath)
        {
            return IndentWhileIditing;
        }

        public override string TitleForDeleteConfirmation(UITableView tableView, NSIndexPath indexPath)
        {
            return DeleteButtonTitle;
        }

        public override bool ShouldShowMenu(UITableView tableView, NSIndexPath rowAtindexPath)
        {
            return Binding?.ObjectIsEditable?.Invoke(Items[rowAtindexPath.Row]) ?? ItemsEditableByDefault;
        }

        public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
        {
            Binding.ObjectItemAccessoryClicked?.Invoke(Items[indexPath.Row]);
        }

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return Binding.ObjectActions.Select(
                a => UITableViewRowAction.Create(a.Style, a.Title, (action, path) => a.ObjectHandler(Items[path.Row])))
                .ToArray();
        }
    }

    public class TableCellAction<TData> : TableCellAction
    {
        public Action<TData> Handler
        {
            set { ObjectHandler = (obj) => value((TData)obj); }
        }
    }

    public class TableCellAction
    {
        public string Title { get; set; }
        public Action<object> ObjectHandler { get; set; }
        public UITableViewRowActionStyle Style { get; set; }
    }

    public class TableDataBinding<TCell,TData> : CollectionDataBinding where TCell : UITableViewCell
    {

        public Func<TCell> CellSelector
        {
            set { ObjectCellSelector = value; }
        }

        public Action<TCell, TData> Bind
        {
            set { ObjectBind = (c, o) => value((TCell)c, (TData)o); }
        }

        public Func<TData, bool> IsMoveable
        {
            set { ObjectIsMoveable = o => value((TData)o); }
        }

        public Func<TData, bool> IsFocusable
        {
            set { ObjectIsFocusable = o => value((TData)o); }
        }

        public Func<TData, bool> IsEditable
        {
            set { ObjectIsEditable = o => value((TData)o); }
        }

        public Func<TData, UITableViewCellAccessory> AccessoryType
        {
            set { ObjectAccessoryType = o => value((TData)o); }
        }

        public Func<TData, UITableViewCellEditingStyle> EditingStyle
        {
            set { ObjectEditingStyle = o => value((TData)o); }
        }

        public Func<TData, int> IndentationLevel
        {
            set { ObjectIndentationLevel = o => value((TData)o); }
        }

        public Action<TData> ItemSelected
        {
            set { ObjectItemSelected = o => value((TData)o); }
        }

        public Action<TData> ItemAccessoryClicked
        {
            set { ObjectItemAccessoryClicked = o => value((TData)o); }
        }

        public void AddAction(TableCellAction<TData> action)
        {
            ObjectActions.Add(action);
        }



        public override Type CellType => typeof (TCell);
        public override Type DataType => typeof (TData);
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

        public Func<T, UITableViewCellAccessory> AccessoryType
        {
            set { ObjectAccessoryType = o => value((T)o); }
        }

        public Func<T, UITableViewCellEditingStyle> EditingStyle
        {
            set { ObjectEditingStyle = o => value((T)o); }
        }

        public Func<T, int> IndentationLevel
        {
            set { ObjectIndentationLevel = o => value((T)o); }
        }

        public Action<T> ItemSelected
        {
            set { ObjectItemSelected = o => value((T)o); }
        }



        public override Type CellType => typeof (C);
        public override Type DataType => typeof (T);
    }

    public class CollectionDataBinding
    {
        private string _cellIdentifier;
        private List<Action<object>> _editActions;
        private List<TableCellAction> _objectActions;
        public virtual Type CellType { get; }
        public virtual Type DataType { get; }
        public Action<object, object> ObjectBind { get; set; }
        public Func<object,bool> ObjectIsMoveable { get; set; }
        public Func<object,bool> ObjectIsFocusable { get; set; }
        public Func<object,bool> ObjectIsEditable { get; set; }
        public Func<object, UITableViewCellAccessory> ObjectAccessoryType { get; set; }
        public Func<object, UITableViewCellEditingStyle> ObjectEditingStyle { get; set; }
        public Func<object, int> ObjectIndentationLevel { get; set; }
        public Action<object> ObjectItemSelected { get; set; }
        public Action<object> ObjectItemAccessoryClicked { get; set; }
        public Func<UITableViewCell> ObjectCellSelector { get; set; }

        public List<TableCellAction> ObjectActions
        {
            get { return _objectActions ?? (_objectActions = new List<TableCellAction>()); }
            set { _objectActions = value; }
        }


        public string CellIdentifier
        {
            get { return _cellIdentifier ?? CellType.Name; }
            set { _cellIdentifier = value; }
        }
    }




}
