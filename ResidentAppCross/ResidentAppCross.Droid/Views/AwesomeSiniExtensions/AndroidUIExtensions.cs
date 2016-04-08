using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Database;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Util;
using Android.Views;
using Android.Widget;
using ImageViews.Rounded;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.Interfaces;
using Object = Java.Lang.Object;

namespace ResidentAppCross.Droid.Views.AwesomeSiniExtensions
{
    //Seriously, why can't they introduce fluent api?
    //This mess with ViewGroup.BlahBlah.SomeInteger is so annoying
    public static class AndroidUIExtensions
    {


        public static T WithDimensionsMatchParent<T>(this T view) where T : View
        {
            var ensureLayoutParams = view.EnsureLayoutParams();
            ensureLayoutParams.Width = ViewGroup.LayoutParams.MatchParent;
            ensureLayoutParams.Height = ViewGroup.LayoutParams.MatchParent;
            return view;
        }

        public static T WithDimensionsWrapContent<T>(this T view) where T : View
        {
            var ensureLayoutParams = view.EnsureLayoutParams();
            ensureLayoutParams.Width = ViewGroup.LayoutParams.MatchParent;
            ensureLayoutParams.Height = ViewGroup.LayoutParams.MatchParent;
            return view;
        }

        public static T WithWidthMatchParent<T>(this T view) where T : View
        {
            view.EnsureLayoutParams().Width = ViewGroup.LayoutParams.MatchParent;
            return view;
        }

        public static T WithWidthWrapContent<T>(this T view) where T : View
        {
            view.EnsureLayoutParams().Width = ViewGroup.LayoutParams.WrapContent;
            return view;
        }

        public static T WithHeightMatchParent<T>(this T view) where T : View
        {
            view.EnsureLayoutParams().Height = ViewGroup.LayoutParams.MatchParent;
            return view;
        }

        public static T WithHeightWrapContent<T>(this T view) where T : View
        {
            view.EnsureLayoutParams().Height = ViewGroup.LayoutParams.WrapContent;
            return view;
        }

        public static T WithHeight<T>(this T view, int dpHeight) where T : View
        {
            view.EnsureLayoutParams().Height = dpHeight.ToPx();
            return view;
        }

        public static T WithDimensions<T>(this T view, int dpSize) where T : View
        {
            var ensureLayoutParams = view.EnsureLayoutParams();
            ensureLayoutParams.Height = dpSize.ToPx();
            ensureLayoutParams.Width = dpSize.ToPx();
            return view;
        }

        public static T WithWidth<T>(this T view, int dpWidth) where T : View
        {
            view.EnsureLayoutParams().Width = dpWidth.ToPx();
            return view;
        }
        
        public static T WithStandardPadding<T>(this T view) where T : View
        {
            view.WithPaddingDp(8, 4, 8, 4);
            return view;
        }

        public static T WithPaddingDp<T>(this T view, int left, int top, int right, int bottom) where T : View
        {
            view.SetPadding(left.ToPx(), top.ToPx(), right.ToPx(), bottom.ToPx());
            return view;
        }

        public static T WithLinearGravity<T>(this T view, GravityFlags flags) where T : View
        {
            view.EnsureLinearLayoutParams().Gravity = flags;
            return view;
        }

        public static T WithLinearMargins<T>(this T view, int leftDp, int topDp, int rightDp, int bottomDp) where T : View
        {
            var p = view.EnsureLinearLayoutParams();
            p.BottomMargin = bottomDp.ToPx();
            p.TopMargin = topDp.ToPx();
            p.LeftMargin = leftDp.ToPx();
            p.RightMargin = rightDp.ToPx();
            return view;
        }

        public static T WithLinearWeight<T>(this T view, float weight) where T : View
        {
            view.EnsureLinearLayoutParams().Weight = weight;
            return view;
        }

        public static T WithBackground<T>(this T view, Color color) where T : View
        {
            view.Background = new ColorDrawable(color);
            return view;
        }

        public static T WithDrawableBackground<T>(this T view, Drawable background) where T : View
        {
            view.Background = background;
            return view;
        }

        public static T WithRelativeCopyOfParent<T>(this T view) where T : View
        {
            var layout = view.EnsureRelativeLayoutParams();
            layout.AddRule(LayoutRules.CenterInParent);
            layout.AddRule(LayoutRules.AlignParentTop);
            layout.AddRule(LayoutRules.AlignParentBottom);
            layout.AddRule(LayoutRules.AlignParentLeft);
            layout.AddRule(LayoutRules.AlignParentRight);
            return view;
        }

        public static int ToPx(this int dPixels)
        {
            return 
                (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, dPixels, Application.Context.Resources.DisplayMetrics);
//            var scale = Application.Context.Resources.DisplayMetrics.Density;
//            return (int)(dPixels * scale + 0.5f);
        }

        public static void SetTextSizeSp(this TextView textView, int sPixels)
        {
            textView.SetTextSize(ComplexUnitType.Sp, sPixels);
        }

        public static ViewGroup.LayoutParams EnsureLayoutParams(this View view)
        {
            return view.LayoutParameters ?? (view.LayoutParameters = new ViewGroup.LayoutParams(0,0));
        }

        public static LinearLayout.LayoutParams EnsureLinearLayoutParams(this View view)
        {
            return (view.LayoutParameters as LinearLayout.LayoutParams) ?? (LinearLayout.LayoutParams)(view.LayoutParameters = new LinearLayout.LayoutParams(view.EnsureLayoutParams()));
        }

        public static RelativeLayout.LayoutParams EnsureRelativeLayoutParams(this View view)
        {
            return (view.LayoutParameters as RelativeLayout.LayoutParams) ?? (RelativeLayout.LayoutParams)(view.LayoutParameters = new RelativeLayout.LayoutParams(view.EnsureLayoutParams()));
        }

        public static T WithFont<T>(this T view, AppFont font) where T : TextView
        {
            view.SetTextColor(font.Color);
            view.SetTextSizeSp(font.SpSize);
            return view;
        }


        public static IDisposable BindTo<T>(this Spinner spinner, IList<T> items, Func<T,string> titleSelector,Context context)
        {
            var adapter = new SpinnerSelectionSectionAdapter<T>(context,-1)
            {
                TitleSelector = titleSelector
            };

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            foreach (var item in items)
            {
                adapter.Add(item);
            }

            spinner.Adapter = adapter;

            EventHandler<AdapterView.ItemSelectedEventArgs> selectedAction = (sender, args) =>
            {
               Console.WriteLine("selected " + spinner.SelectedItem);
            };

            spinner.ItemSelected += selectedAction;

            return new Disposable(() =>
            {
               // spinner.ItemSelected -= selectedAction;
            });
        }



    }


    public struct AppFont
    {
        public int SpSize { get; set; }
        public Color Color { get; set; }
    }

    public class SpinnerSelectionSectionAdapter<T> : ArrayAdapter<T>
    {

        public Func<T, string> TitleSelector { get; set; }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //return base.GetView(position, convertView, parent);

            TextView textview;

            if (convertView == null)
            {
                textview = new TextView(Context)
                {
                    Gravity = GravityFlags.CenterVertical | GravityFlags.Right
                }
                    .WithFont(AppFonts.SectionHeadline)
                    .WithWidthMatchParent()
                    .WithHeightWrapContent();
                textview.SetSingleLine(true);
                textview.Ellipsize = TextUtils.TruncateAt.Marquee;

            }
            else
            {
                textview = (TextView) convertView;
            }

            var item = GetItem(position);
            textview.Text = TitleSelector?.Invoke(item);

//            var drawable = ContextCompat.GetDrawable(Context, Resource.Drawable.L_LocationOk);
//            drawable.SetBounds(0,0,20, parent.MeasuredHeight);
//            textview.SetCompoundDrawables(drawable,null,null,null);

            //if (TitleSelector != null) textview.Text = TitleSelector(item);

            return textview;
        }


        #region Trololo constructors

        public SpinnerSelectionSectionAdapter(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public SpinnerSelectionSectionAdapter(Context context, int textViewResourceId) : base(context, textViewResourceId)
        {
        }

        public SpinnerSelectionSectionAdapter(Context context, int resource, int textViewResourceId) : base(context, resource, textViewResourceId)
        {
        }

        public SpinnerSelectionSectionAdapter(Context context, int textViewResourceId, T[] objects) : base(context, textViewResourceId, objects)
        {
        }

        public SpinnerSelectionSectionAdapter(Context context, int resource, int textViewResourceId, T[] objects) : base(context, resource, textViewResourceId, objects)
        {
        }

        public SpinnerSelectionSectionAdapter(Context context, int textViewResourceId, IList<T> objects) : base(context, textViewResourceId, objects)
        {
        }

        public SpinnerSelectionSectionAdapter(Context context, int resource, int textViewResourceId, IList<T> objects) : base(context, resource, textViewResourceId, objects)
        {
        }

        #endregion
    }


}