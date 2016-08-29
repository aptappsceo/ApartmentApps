	using Foundation;
using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.InteropServices;
	using Cirrious.FluentLayouts.Touch;
	using CoreGraphics;
	using ObjCRuntime;
	using ResidentAppCross.iOS.Views;
	using UIKit;

namespace ResidentAppCross.iOS
{
    public partial class ContainerSection : SectionViewBase
    {
        public ContainerSection (IntPtr handle) : base (handle)
        {
        }

        public void ReplaceContent(params UIView[] content)
        {
            Content = content;
            UpdateContent();
        }

        private void UpdateContent()
        {
            if (!Collapsed)
            {
                DematerializeContent();
                MaterializeContent();
                UpdateIntrisincSizeAnimated(null);
            }
        }

        public UIView[] GetContent()
        {
            return Content;
        }

        public void Expand()
        {
            Collapsed = false;
            MaterializeContent();
            UpdateButton();
            UpdateIntrisincSizeAnimated(null);
        }

        public void Collapse()
        {
            Collapsed = true;
            UpdateIntrisincSizeAnimated(DematerializeContent);
            UpdateButton();
            //Dematerialize content
        }


        private void DematerializeContent()
        {
            foreach (var subview in _container.Subviews.ToArray())
            {
                subview.RemoveFromSuperview();
            }
            _container.RemoveConstraints(_container.Constraints);
        }

        public float HeaderHeight = 60f;

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            _intrisinctContentSize = new CGSize(0, 0);
            _collapseButton.TouchUpInside += (sender, args) =>
            {
                if(Collapsed) Expand();
                else Collapse();
            };
            ClipsToBounds = true;
            
            //this.WithHeight(500);



            AutosizesSubviews = false;
            _container.AutosizesSubviews = false;
            TranslatesAutoresizingMaskIntoConstraints = false;
            _container.TranslatesAutoresizingMaskIntoConstraints = false;

            HeaderLabel.WithHeight(HeaderHeight);
            _collapseButton.WithHeight(HeaderHeight);

            LayoutMargins = UIEdgeInsets.Zero;

            HeaderLabel.Font = AppFonts.SectionHeader;
            HeaderLabel.TextColor = UIColor.White;
            _collapseButton.SetTitleColor(UIColor.Cyan, UIControlState.Normal);
            BackgroundColor = AppTheme.SecondaryBackgoundColor;

            UpdateButton();

        }

        private void UpdateButton()
        {
                _collapseButton.SetTitle(Collapsed ? "Open" : "Close");
        }

        public override CGSize IntrinsicContentSize => _intrisinctContentSize;

        public bool Collapsed
        {
            get { return _collapsed; }
            set
            {
                _collapsed = value;
            }
        }


        private CGSize _intrisinctContentSize;
        private bool _collapsed = true;
        private UIView[] _content;

        public override NSLayoutConstraint HeightConstraint => null;

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

        private void UpdateIntrisincSizeAnimated(Action onComplete)
        {
            UIView.Animate(0.2f, () =>
            {
                UpdateIntrisincSize();
            }, () =>
            {
                onComplete?.Invoke();   
            });
        }

        private void UpdateIntrisincSize()
        {

            nfloat h = HeaderHeight; //label

            if (!Collapsed)
            {
                h += AppTheme.FormSectionVerticalSpacing * (Content.Length + 1);

                foreach (var subview in Content)
                {
                    h += subview.SystemLayoutSizeFittingSize(UILayoutFittingCompressedSize).Height;
                }
            }

            _intrisinctContentSize = new CGSize(-1, h);

            InvalidateIntrinsicContentSize();
            if (Superview != null)
            {
                Superview.SetNeedsLayout();
                Superview.LayoutIfNeeded();
            }


             
        }

        public virtual void MaterializeContent()
        {
            _container.TranslatesAutoresizingMaskIntoConstraints = false;
            this.TranslatesAutoresizingMaskIntoConstraints = false;

            DematerializeContent();

            if (!Collapsed)
            {

                foreach (var uiView in Content)
                {
                    var section = uiView as SectionViewBase;
                    if (section != null) section.ParentController = ParentController;

                    _container.Add(uiView);
                }
            }


            /*
            var height = HeaderLabel.Frame.Height;

            foreach (var subview in _container.Subviews)
            {
                height += subview.Frame.Height;
            }

            HeightConstraint.Constant = height;
            */

            LayoutContent();
        }



        public virtual void LayoutContent()
        {
            if (_container.Subviews.Any())
            {

                var constraints = _container.VerticalStackPanelConstraints(
                    new Margins(8f, 0, 8f, 0f, 0, AppTheme.FormSectionVerticalSpacing),
                    _container.Subviews).ToArray();

                var subviews = _container.Subviews.ToArray();

                foreach (
                    var source in _container.Subviews.OfType<SectionViewBase>().Where(s => s.ShouldStickSectionBelow))
                {
                    var index = Array.IndexOf(subviews, source);
                    if (index == subviews.Length - 1) continue;
                    var stickedView = subviews[index + 1];
                    var constraint =
                        constraints.ToArray().FirstOrDefault(c => (c.View == source && c.SecondItem == stickedView) ||
                                                                  (c.View == stickedView && c.SecondItem == source));
                    if (constraint != null)
                    {
                        constraint.Constant = 0;
                    }
                }
                _container.AddConstraints(constraints);


               //_container.UpdateConstraintsIfNeeded();
               // _container.LayoutSubviews();
            }

           

            // _container.ResizeHeightToFitSubviews();
            // resizeToFitSubviews();
            // LayoutIfNeeded();
        }

        public UIView[] Content
        {
            get { return _content ?? new UIView[0]; } //nullsafe
            set { _content = value; }
        }

        public UILabel HeaderLabel => _labe;
    }
}

public static class LayoutingExtensions
{


    public static void ResizeHeightToFitSubviews(this UIView view)
    {
        double h = 0;
        foreach (var subview in view.Subviews)
        {
            var fh = subview.Frame.Y + subview.Frame.Height;
            h = Math.Max(fh, h);
        }

        view.Frame = new CGRect(
                view.Frame.X, view.Frame.Y, view.Frame.Width, h
            );
    }
}