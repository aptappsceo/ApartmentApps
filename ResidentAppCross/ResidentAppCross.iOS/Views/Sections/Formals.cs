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

    public static T WithHeight<T>(this T view, float constant, int priority = 700) where T : UIView
    {
        var nsLayoutConstraint = NSLayoutConstraint.Create(view, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null,NSLayoutAttribute.NoAttribute, 1.0f,constant);
        nsLayoutConstraint.Priority = priority;
        view.AddConstraint(nsLayoutConstraint);
        return view;
    }

    public static T WithClearBackground<T>(this T view) where T : UIView
    {
        view.WithBackground(UIColor.Clear);
        return view;
    }

    public static T WithSecureTextEntry<T>(this T view) where T : UITextField
    {
        view.SecureTextEntry = true;
        return view;
    }

    public static T WithNextResponder<T>(this T view, UIView responder) where T : UITextField
    {
        if (responder == null)
        {
            view.ReturnKeyType = UIReturnKeyType.Done;
            view.ShouldReturn = field => view.ResignFirstResponder();
        }
        else
        {
            view.ReturnKeyType = UIReturnKeyType.Next;
            view.ShouldReturn = field => responder.BecomeFirstResponder();
        }
        return view;
    }


    public static T WithNextResponder<T>(this T view, Action responder, UIReturnKeyType key = UIReturnKeyType.Send) where T : UITextField
    {
        view.ReturnKeyType = key;
        view.ShouldReturn = field =>
        {
            responder?.Invoke();
            return true;
        };
        return view;
    }

    public static T WithPlaceholder<T>(this T view, string placeholder) where T : UITextField
    {
        view.Placeholder = placeholder;
        return view;
    }



    public static T WithBackground<T>(this T view, UIColor color) where T : UIView
    {
        view.BackgroundColor = color;
        return view;
    }

    public static T AddTo<T>(this T view, UIView parent) where T : UIView
    {
        parent.Add(view);
        return view;
    }
}