using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using ResidentAppCross.Interfaces;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class SegmentSelectionSection : SectionViewBase
	{
	    public SegmentSelectionSection()
	    {
	    }

	    public SegmentSelectionSection (IntPtr handle) : base (handle)
		{
		}

	    public UILabel Label => _headerTitle;
	    public UISegmentedControl Selector => _segmentSelector;


	    public void HideTitle(bool hide)
	    {
	        _headerHeightConstraint.Constant = hide ? 0 : 60;
	        _headerTitle.Hidden = hide;
	    }

	    public void BindTo<T>(ObservableCollection<T> items, Func<T,string> keySelector, Action<T> itemSelected, int startIndex)
	    {
	        if (BindingDisposable != null)
	        {
	            BindingDisposable.Dispose();
	            BindingDisposable = null;
	        }

            SegmentSelector.RemoveAllSegments();

            var i = 0;

	        foreach (var item in items)
	        {
	            SegmentSelector.InsertSegment(keySelector(item),i++,true);
	        }

	        SegmentSelector.SelectedSegment = startIndex;

	        EventHandler segmentSelectorOnValueChanged = (sender, args) =>
	        {
	            itemSelected(items[(int)SegmentSelector.SelectedSegment]);
	        };

	        SegmentSelector.ValueChanged += segmentSelectorOnValueChanged;

	        BindingDisposable = new Disposable(() =>
	        {
	            SegmentSelector.ValueChanged -= segmentSelectorOnValueChanged;
	        });

	    }

	    public Disposable BindingDisposable { get; set; }
	}
}
