	using Foundation;
using System;
	using System.Collections.Generic;
	using System.Linq;
	using Cirrious.FluentLayouts.Touch;
	using CoreGraphics;
	using ResidentAppCross.iOS.Views;
	using UIKit;

namespace ResidentAppCross.iOS
{
    public partial class ContainerSection : SectionViewBase
    {
        public ContainerSection (IntPtr handle) : base (handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            UITapGestureRecognizer labelTap = new UITapGestureRecognizer(() => {
                // Do something in here
                     _labe.Text = "MOTHERK";
            });

            _labe.UserInteractionEnabled = true;
            _labe.AddGestureRecognizer(labelTap);

        }

        

        public void Clear()
        {
            Content.Clear();
        }

        public void Add(SectionViewBase section)
        {
            Content.Add(section);
        }

        private List<UIView> _content;


        public virtual float VerticalSectionsSpacing { get; set; } = 15f;
        /*
        public UIScrollView SectionsContainer
        {
            get
            {
                if (_sectionsContainer == null)
                {

                    _sectionsContainer = new UIScrollView().AddTo(_container);
                    _sectionsContainer.TranslatesAutoresizingMaskIntoConstraints = false;

                    _container.AddConstraints(
                        _sectionsContainer.AtRightOf(_container),
                        _sectionsContainer.AtLeftOf(_container),
                        _sectionsContainer.AtTopOf(_container),
                        _sectionsContainer.AtBottomOf(_container));

                }
                return _sectionsContainer;
            }
            set { _sectionsContainer = value; }
        }
        */
        public virtual void RefreshContent()
        {
            foreach (var subview in _container.Subviews.ToArray())
            {
                subview.RemoveFromSuperview();
            }

            _container.RemoveConstraints(_container.Constraints);

            foreach (var uiView in Content)
            {
                var section = uiView as SectionViewBase;
                if (section != null) section.ParentController = ParentController;

                _container.Add(uiView);
            }

            LayoutContent();
        }

        public virtual void LayoutContent()
        {
            if (!_container.Subviews.Any()) return;

            var constraints = _container.VerticalStackPanelConstraints(
             new Margins(0, 0, 0, 25f, 0, AppTheme.FormSectionVerticalSpacing),
             _container.Subviews).ToArray();

            var subviews = _container.Subviews.ToArray();

            foreach (var source in _container.Subviews.OfType<SectionViewBase>().Where(s => s.ShouldStickSectionBelow))
            {
                var index = Array.IndexOf(subviews, source);
                if (index == subviews.Length - 1) continue;
                var stickedView = subviews[index + 1];
                var constraint = constraints.ToArray().FirstOrDefault(c => (c.View == source && c.SecondItem == stickedView) ||
                    (c.View == stickedView && c.SecondItem == source));
                if (constraint != null)
                {
                    constraint.Constant = 0;
                }
            }
            _container.AddConstraints(constraints);

        }

        public List<UIView> Content
        {
            get { return _content ?? (_content = new List<UIView>()); }
            set { _content = value; }
        }

        public UILabel HeaderLabel => _labe;
    }
}