using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.Interfaces;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class SegmentSelectionSection : SectionViewBase
	{
	    private bool _editable;

	    public SegmentSelectionSection()
	    {
	    }

	    public SegmentSelectionSection (IntPtr handle) : base (handle)
	    {
	    }

	    public UILabel Label => _headerTitle;
	    public UISegmentedControl Selector => _segmentSelector;

	    public override void AwakeFromNib()
	    {
	        base.AwakeFromNib();
            Label.Font = AppFonts.SectionHeader;
	        HeightConstraint.Constant = AppTheme.SegmentSectionHeight;
	        Selector.RemoveAllSegments();
            Selector.TintColor = AppTheme.FormControlColor;

        }

        public void HideTitle(bool hide)
	    {
	        _headerHeightConstraint.Constant = hide ? 0 : 60;
	        _headerTitle.Hidden = hide;
	    }

	    public bool Editable
	    {
	        get { return _editable; }
	        set
	        {
	            _editable = value;
	            SegmentSelector.Enabled = value;
	        }
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
