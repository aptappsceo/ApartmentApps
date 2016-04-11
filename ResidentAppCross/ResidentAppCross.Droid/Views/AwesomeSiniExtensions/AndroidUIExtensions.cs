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

        public static T WithHeightPx<T>(this T view, int pxHeight) where T : View
        {
            view.EnsureLayoutParams().Height = pxHeight;
            return view;
        }

        public static T WithHeight<T>(this T view, int dpHeight) where T : View
        {
            view.WithHeightPx(dpHeight.ToPx());
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

        public static T WithRelativeMargins<T>(this T view, int leftDp, int topDp, int rightDp, int bottomDp) where T : View
        {
            var p = view.EnsureRelativeLayoutParams();
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

        public static T WithBackgroundColor<T>(this T view, Color color) where T : View
        {
            view.Background = AppDrawables.ByColor(color);//new ColorDrawable(color);
            return view;
        }

        public static T WithBackground<T>(this T view, Drawable background) where T : View
        {
            view.Background = background;
            return view;
        }

        public static T WithRelativeBelow<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.Below, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeAbove<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.Above, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeParentAlign<T>(this T view, bool align) where T : View
        {
            view.EnsureRelativeLayoutParams().AlignWithParent = align;
            return view;
        }

        public static T WithoutParentAlign<T>(this T view) where T : View
        {
            view.EnsureRelativeLayoutParams().AlignWithParent = false;
            return view;
        }

        public static int IdCounter = 1;

        public static T WithUniqueId<T>(this T view) where T : View
        {
            if(view.Id == -1) view.Id = IdCounter++;
            return view;
        }

        public static T WithRelativeAlignTop<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignTop, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeAlignBottom<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignBottom, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeAlignLeft<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignLeft, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeAlignRight<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignRight, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeAlignBaseline<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignBaseline, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeAlignStart<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignStart, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeAlignEnd<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignEnd, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeRightOf<T>(this T view, View what) where T : View
        {

            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.RightOf, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeLeftOf<T>(this T view, View what) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.LeftOf, what.WithUniqueId().Id);
            return view;
        }

        public static T WithRelativeAlignParentTop<T>(this T view) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignParentTop);
            return view;
        }

        public static T WithRelativeAlignParentBottom<T>(this T view) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignParentBottom);
            return view;
        }

        public static T WithRelativeAlignParentLeft<T>(this T view) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignParentLeft);
            return view;
        }

        public static T WithRelativeAlignParentRight<T>(this T view) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignParentRight);
            return view;
        }

        public static T WithRelativeAlignParentEnd<T>(this T view) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignParentEnd);
            return view;
        }

        public static T WithRelativeAlignParentStart<T>(this T view) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.AlignParentStart);
            return view;
        }

        public static T WithRelativeCenterInParent<T>(this T view) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.CenterInParent);
            return view;
        }

        public static T WithRelativeCenterHorisontal<T>(this T view) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.CenterHorizontal);
            return view;
        }

        public static T WithRelativeCenterVertical<T>(this T view) where T : View
        {
            view.WithUniqueId().EnsureRelativeLayoutParams().AddRule(LayoutRules.CenterVertical);
            return view;
        }

        public static T AddTo<T>(this T view, ViewGroup parent) where T : View
        {
            parent.AddView(view);
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

        public static FrameLayout.LayoutParams EnsureFrameLayoutParams(this View view)
        {
            return (view.LayoutParameters as FrameLayout.LayoutParams) ?? (FrameLayout.LayoutParams)(view.LayoutParameters = new FrameLayout.LayoutParams(view.EnsureLayoutParams()));
        }

        public static RelativeLayout.LayoutParams EnsureRelativeLayoutParams(this View view)
        {
            return (view.LayoutParameters as RelativeLayout.LayoutParams) ?? (RelativeLayout.LayoutParams)(view.LayoutParameters = new RelativeLayout.LayoutParams(view.EnsureLayoutParams()));
        }

        public static T WithFont<T>(this T view, AppFont font) where T : TextView
        {
            view.SetTextColor(font.Color);
            view.SetTextSizeSp(font.SpSize);
            view.SetTypeface(font.Typeface,font.Style);
            return view;
        }

        public static T WithFontColor<T>(this T view, Color c) where T : TextView
        {
            view.SetTextColor(c);
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

        public static BitmapDrawable ToDrawable(this Bitmap bitmap)
        {
            return new BitmapDrawable(bitmap);
        }

        public static BitmapDrawable WithFilter(this BitmapDrawable drawable, bool filter = true)
        {
            drawable.SetFilterBitmap(filter);
            return drawable;

        }
    }


    public class AppFont
    {
        public int SpSize { get; set; }
        public Color Color { get; set; }
        public TypefaceStyle Style { get; set; } = TypefaceStyle.Normal; 
        public Typeface Typeface { get; set; } 
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