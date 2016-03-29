using System;
using System.Collections.Generic;
using System.Text;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using ResidentAppCross.iOS.Views.PhotoGallery;
using ResidentAppCross.iOS.Views.TableSources;
using SDWebImage;
using UIKit;

namespace ResidentAppCross.iOS.Views.Sections.CollectionSections
{
    public class GenericCollectionViewSource : UICollectionViewSource
    {

        public object[] Items { get; set; }
        public CollectionDataBinding Binding { get; set; }

        public Type CellType => Binding.CellType;
        public string CellIdentifier => CellType?.Name;
        public Func<UICollectionViewCell> CellFactory { get; set; }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            UICollectionViewCell cell = (UICollectionViewCell) collectionView.DequeueReusableCell(CellIdentifier, indexPath);
            cell.BackgroundColor = UIColor.White;
            var view = cell.ContentView;
            view.TranslatesAutoresizingMaskIntoConstraints = false;
            Binding?.ObjectBind?.Invoke(cell, Items[indexPath.Row],indexPath.Row);
         
            return cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return Items.Length;
        }

    }
}
