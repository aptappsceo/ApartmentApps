using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using CoreGraphics;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class VerticalCollectionSection : SectionViewBase
	{
		public VerticalCollectionSection (IntPtr handle) : base (handle)
		{
		}

	    public VerticalCollectionSection()
	    {
	    }

	    public UICollectionView Collection => _collection;

	    public void SetVerticalTableMode(float itemHeight)
	    {

			var layout = new CollectionViewTableLayout()
	        {
	            ScrollDirection = UICollectionViewScrollDirection.Vertical,
            };

			//layout.EstimatedItemSize = new CGSize(100,100);
            
            Collection.SetCollectionViewLayout(layout,true);
	    }

	}


    public partial class CollectionViewTableLayout : UICollectionViewFlowLayout
    {
        public float ItemHeight { get; set; }

        public override CGSize ItemSize
        {
            get
            {
				return new CGSize(CollectionView.Frame.Size.Width - SectionInset.Left - SectionInset.Right - CollectionView.ContentInset.Left - CollectionView.ContentInset.Right, 0) ;
            }
            set
            {
                
            }
        }

		public override CGSize EstimatedItemSize {
			get {
				return new CGSize (CollectionView.Frame.Size.Width - SectionInset.Left - SectionInset.Right - CollectionView.ContentInset.Left - CollectionView.ContentInset.Right, 120);
			}
			set{ }
		}
    }


}
