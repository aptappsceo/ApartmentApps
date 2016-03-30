using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace ResidentAppCross.iOS.Views.ThemeFramework
{
    public class Theme
    {
        private static Dictionary<UIView, IDisposable> _themeBindings;

        public UIViewStyle Header1Style { get; set; }


        public static Dictionary<UIView, IDisposable> ThemeBindings
        {
            get { return _themeBindings ?? (_themeBindings = new Dictionary<UIView, IDisposable>()); }
            set { _themeBindings = value; }
        }

        public event Action ThemeChanged;


        public void BindAndApply(UILabel label, ThemeSemantic semantic)
        {
        }

        protected virtual void OnThemeChanged()
        {
            ThemeChanged?.Invoke();
        }


    }

    public class UIViewStyle
    {
        public UIFont Font;
    }

    public enum ThemeSemantic
    {
        Header1,
    }

    public static class ThemeUIViewExtensions
    {
        public static void Apply(UILabel label, UIViewStyle style)
        {
        }
    }

}

