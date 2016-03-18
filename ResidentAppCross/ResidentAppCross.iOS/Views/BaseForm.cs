using System.Collections.Generic;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public class BaseForm<T> : ViewBase<T> where T : ViewModelBase
    {
        private UIScrollView _sectionsContainer;

        public BaseForm(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public BaseForm() : base (null,null)
        {
        }

        public UIScrollView SectionsContainer
        {
            get
            {
                if (_sectionsContainer == null)
                {
                    EdgesForExtendedLayout = UIRectEdge.None;
                    View.BackgroundColor = AppTheme.DeepBackgroundColor;

                    _sectionsContainer = new UIScrollView().AddTo(View);
                    _sectionsContainer.TranslatesAutoresizingMaskIntoConstraints = false;
                    View.AddConstraints(
                        _sectionsContainer.WithSameWidth(View),
                        _sectionsContainer.WithSameHeight(View),
                        _sectionsContainer.AtTopOf(View),
                        _sectionsContainer.AtLeftOf(View)
                        );
                }
                return _sectionsContainer;
            }
            set { _sectionsContainer = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BindForm();
            RefreshContent();

        }

        public virtual void BindForm()
        {
        }

        public virtual void UnbindForm()
        {
        }

        public virtual void RefreshContent()
        {

            foreach (var subview in SectionsContainer.Subviews)
            {
                subview.RemoveFromSuperview();
            }

            SectionsContainer.RemoveConstraints(SectionsContainer.Constraints);

            List<UIView> content = new List<UIView>();

            GetContent(content);

            foreach (var uiView in content)
            {
                var section = uiView as SectionViewBase;
                if (section != null) section.ParentController = this;

                SectionsContainer.Add(uiView);
            }

            foreach (var uiView in content)
            {
                SectionsContainer.Add(uiView);
            }

            var constraints = SectionsContainer.VerticalStackPanelConstraints(
                new Margins(0, 0, 0, 20, 0, 15),
                SectionsContainer.Subviews);

            SectionsContainer.AddConstraints(constraints);

        }

        public virtual void GetContent(List<UIView> content)
        {
            
        }

    }
}