using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UIKit;

namespace ResidentAppCross.iOS.Views.Attributes
{

    public class ViewAttribute : Attribute
    {
        public virtual void OnViewConstructing(ViewBase viewBase) { }
        public virtual void OnViewLoaded(ViewBase viewBase) { }
        public virtual void OnViewAppeared(ViewBase viewBase, bool animated) { }
        public virtual void OnViewWillAppear(ViewBase viewBase, bool animated) { }
    }

    public class StatusBarStyling : ViewAttribute
    {

        public UIStatusBarStyle Style { get; set; } = UIStatusBarStyle.BlackOpaque;
        public bool Hidden { get; set; } = false;
        public bool Animated { get; set; } = true;
        public override void OnViewLoaded(ViewBase viewBase)
        {
            base.OnViewLoaded(viewBase);
            UIApplication.SharedApplication.SetStatusBarHidden(Hidden, Animated);
            if (Hidden) return;
            UIApplication.SharedApplication.SetStatusBarStyle(Style, Animated);
        }
    }

    public class NavbarStyling : ViewAttribute
    {

        public bool Animated { get; set; } = true;
        public bool Hidden { get; set; } = false;
        public UIColor BackgroundColor { get; set; } = AppTheme.SecondaryBackgoundColor;
        public UIColor ForegroundColor { get; set; } = AppTheme.SecondaryForegroundColor;

        public override void OnViewWillAppear(ViewBase viewBase, bool animated)
        {
            base.OnViewWillAppear(viewBase, animated);
            var navController = viewBase.NavigationController;
            var navBar = navController?.NavigationBar;
            if (navBar == null)
            {
                Debug.WriteLine("Warning: View Misses Nav Controller or Nav Bar");
                return;
            }

            navController.SetNavigationBarHidden(Hidden, Animated);
            if (Hidden) return;

            navBar.BarTintColor = BackgroundColor;
            navBar.TintColor = ForegroundColor;
            var attribs = navBar.TitleTextAttributes ?? new UIStringAttributes();
            attribs.ForegroundColor = ForegroundColor;
            navBar.TitleTextAttributes = attribs;
        }

        public static void ApplyToNavigationController(UINavigationController controller, bool animated = true, bool hidden = false, UIColor backgroundColor = null, UIColor foregroundColor = null)
        {
            if (backgroundColor == null) backgroundColor = AppTheme.SecondaryBackgoundColor;
            if (foregroundColor == null) foregroundColor = AppTheme.SecondaryForegroundColor;

            controller.SetNavigationBarHidden(hidden, animated);
            if (hidden) return;

            var navBar = controller?.NavigationBar;
            if (navBar == null)
            {
                Debug.WriteLine("Warning: View Misses Nav Controller or Nav Bar");
                return;
            }

            navBar.BarTintColor = backgroundColor;
            navBar.TintColor = foregroundColor;
            var attribs = navBar.TitleTextAttributes ?? new UIStringAttributes();
            attribs.ForegroundColor = foregroundColor;
            navBar.TitleTextAttributes = attribs;
        }

    }

    public class Edges : ViewAttribute
    {

        private UIRectEdge _edgesForExtendedLayout;

        public Edges(UIRectEdge edgesForExtendedLayout)
        {
            _edgesForExtendedLayout = edgesForExtendedLayout;
        }

        public override void OnViewAppeared(ViewBase viewBase, bool animated)
        {
            base.OnViewAppeared(viewBase,animated);
        }
    }

}
