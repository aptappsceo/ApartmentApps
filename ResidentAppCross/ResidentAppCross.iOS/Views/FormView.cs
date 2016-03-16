using System;

using UIKit;
using ResidentAppCross.iOS.Views;
using System.Diagnostics;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using ObjCRuntime;
using ResidentAppCross.iOS.Views.Attributes;

namespace ResidentAppCross.iOS
{
	[NavbarStyling]
	public partial class FormView : ViewBase<FormViewModel>
	{
		public FormView () : base (null,null)
		{
		}

	    bool hidden = false;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = AppTheme.PrimaryForegroundColor;

            var scrollView = new UIScrollView().AddTo(View);
		    scrollView.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddConstraints(
                    scrollView.WithSameWidth(View),    
                    scrollView.WithSameHeight(View),
                    scrollView.AtTopOf(View),
                    scrollView.AtLeftOf(View)
                );

            scrollView.BackgroundColor = UIColor.Brown;
            

            var button = new UIButton().WithHeight(60f).AddTo(scrollView);    
            button.SetTitle("Toggle",UIControlState.Disabled | UIControlState.Focused | UIControlState.Normal | UIControlState.Highlighted | UIControlState.Reserved | UIControlState.Selected);
            button.BackgroundColor = UIColor.Orange;
            button.TranslatesAutoresizingMaskIntoConstraints = false;

            //ExtendedLayoutIncludesOpaqueBars = false;

            //
            var form = Formals.Create<ExampleSectionView>().AddTo(scrollView);
            form.HeightConstraint.Constant = 200;
            form.ScrollTextViewToTop();
            form.SetHeaderLabelText("Section 1");

            var firstSection = form;
            button.TouchUpInside += (sender, args) =>
            {
                hidden = !hidden;
                firstSection.HeightConstraint.Constant = hidden ? 0 : 200;
                firstSection.LayoutIfNeeded();
                scrollView.LayoutIfNeeded();
                scrollView.LayoutSubviews();
            };

            form = Formals.Create<ExampleSectionView>().AddTo(scrollView);
		    form.HeightConstraint.Constant = 200;
            form.SetHeaderLabelText("Section 2");

            form = Formals.Create<ExampleSectionView>().AddTo(scrollView);
		    form.HeightConstraint.Constant = 200;
            form.SetHeaderLabelText("Section 3");

            form = Formals.Create<ExampleSectionView>().AddTo(scrollView);
		    form.HeightConstraint.Constant = 200;
            form.SetHeaderLabelText("Section 4");

            form = Formals.Create<ExampleSectionView>().AddTo(scrollView);
		    form.HeightConstraint.Constant = 200;
            form.SetHeaderLabelText("Section 5");


            var constraints = scrollView.VerticalStackPanelConstraints(
                                            new Margins(0, 0, 0, 20, 0, 15),
                                            scrollView.Subviews);

            scrollView.AddConstraints(constraints);




        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


public static class Formals
{
    public static T Create<T>(bool defaultSetup = true) where T : NSObject
    {
        var arr = NSBundle.MainBundle.LoadNib(typeof (T).Name, null, null);
        var nsObject = Runtime.GetNSObject<T>(arr.ValueAt(0));

        if (defaultSetup)
        {
            var view = nsObject as UIView;
            if (view != null)
            {
                view.TranslatesAutoresizingMaskIntoConstraints = false;
            }
        }


        return nsObject;
    }

    public static T WithHeight<T>(this T view, float constant) where T : UIView
    {
        var nsLayoutConstraint = NSLayoutConstraint.Create(view, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null,NSLayoutAttribute.NoAttribute, 1.0f,constant);
        nsLayoutConstraint.Priority = 700;
        view.AddConstraint(nsLayoutConstraint);
        return view;
    }

    public static T AddTo<T>(this T view, UIView parent) where T : UIView
    {
        parent.Add(view);
        return view;
    }
}