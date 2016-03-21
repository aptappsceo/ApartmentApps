using System;
using System.Collections.Generic;
using Foundation;
using ObjCRuntime;
using UIKit;

public static class Formals
{

    public static T Create<T>(bool defaultSetup = true) where T : NSObject
    {
        return (T)Create(typeof(T),defaultSetup);
    }

    public static object Create(Type type, bool defaultSetup = true)
    {

        NSArray arr;
        var nibName = type.Name;
        arr = NSBundle.MainBundle.LoadNib(nibName, null, null);

        var nsObject = Runtime.GetNSObject(arr.ValueAt(0));

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