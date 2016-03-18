using System.Collections.Generic;
using Foundation;
using ObjCRuntime;
using UIKit;

public static class Formals
{


    private static Dictionary<string,NSArray> NibCache { get; set; } = new Dictionary<string, NSArray>();

    public static T Create<T>(bool defaultSetup = true) where T : NSObject
    {


        NSArray arr;
        var nibName = typeof(T).Name;

        if (!NibCache.TryGetValue(nibName,out arr))
        {
            NibCache[nibName] = arr = NSBundle.MainBundle.LoadNib(nibName, null, null);
        }


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