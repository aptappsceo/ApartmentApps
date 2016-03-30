using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public class BaseForm<T> : ViewBase<T>, IScrollableView where T : ViewModelBase
    {
        private UIScrollView _sectionsContainer;
        private KeyboardViewScroller _scroll;
        private List<UIView> _content;
        private List<NSObject> _notificatioHandlers;
        private NSObject keyboardShowObserver;
        private NSObject keyboardHideObserver;
        private bool _heyboardShown;
        private List<UIGestureRecognizer> _sectionsContainerGestureRecognizers;
        private bool _sectionContainerGesturesEnabled = true;

        public BaseForm(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public BaseForm() : base(null, null)
        {
        }

        public virtual UIView HeaderView { get; set; }
        public virtual UIView FooterView { get; set; }

        public virtual float VerticalSectionsSpacing { get; set; } = 15f;


        public List<UIGestureRecognizer> SectionsContainerGestureRecognizers
        {
            get { return _sectionsContainerGestureRecognizers ?? (_sectionsContainerGestureRecognizers = new List<UIGestureRecognizer>(SectionsContainer.GestureRecognizers)); }
            set { _sectionsContainerGestureRecognizers = value; }
        }


        public bool SectionContainerGesturesEnabled
        {
            get { return _sectionContainerGesturesEnabled; }
            set
            {
                _sectionContainerGesturesEnabled = value;
                if (value)
                {
                    foreach (
                        var recognizer in
                            SectionsContainerGestureRecognizers.Except(SectionsContainer.GestureRecognizers))
                    {
                        SectionsContainer.AddGestureRecognizer(recognizer);
                    }
                }
                else
                {
                    foreach (var uiGestureRecognizer in SectionsContainer.GestureRecognizers)
                    {
                        SectionsContainer.RemoveGestureRecognizer(uiGestureRecognizer);
                    }
                }

            }
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


                    //                    if (HeaderView != null)
                    //                    {
                    //                        
                    //                    }


                    View.AddConstraints(
                        _sectionsContainer.AtRightOf(View),
                        _sectionsContainer.AtLeftOf(View));

                    if (HeaderView == null)
                    {
                        View.AddConstraints(_sectionsContainer.AtTopOf(View));
                    }
                    else
                    {
                        View.Add(HeaderView);
                        View.AddConstraints(
                         HeaderView.AtRightOf(View),
                         HeaderView.AtLeftOf(View),
                         HeaderView.AtTopOf(View),
                         _sectionsContainer.Below(HeaderView));
                    }


                    if (FooterView == null)
                    {
                        View.AddConstraints(_sectionsContainer.AtBottomOf(View));
                    }
                    else
                    {
                        View.Add(FooterView);
                        View.AddConstraints(
                         FooterView.AtRightOf(View),
                         FooterView.AtLeftOf(View),
                         FooterView.AtBottomOf(View),
                         _sectionsContainer.Above(FooterView));
                    }

                }
                return _sectionsContainer;
            }
            set { _sectionsContainer = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SectionsContainer.AddGestureRecognizer(new UITapGestureRecognizer(SectionContainerTapped));
            BindForm();
            RefreshContent();
        }

        private void SectionContainerTapped()
        {
            foreach (var uiView in Content.OfType<IFormTapListener>()) uiView.FormTapped();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            RegisterNotificationHandlers();
            foreach (var uiView in Content.OfType<IFormEventsListener>()) uiView.FormDidAppear();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            foreach (var uiView in Content.OfType<IFormEventsListener>()) uiView.FormDidDisappear();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            foreach (var uiView in Content.OfType<IFormEventsListener>()) uiView.FormWillAppear();

//            keyboardShowObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, (notification) => {
//
//                NSValue nsKeyboardBounds = (NSValue)notification.UserInfo.ObjectForKey(UIKeyboard.BoundsUserInfoKey);
//                RectangleF keyboardBounds = nsKeyboardBounds.RectangleFValue;
//                var height = View.Bounds.Height - keyboardBounds.Height;
//                if (NavigationController != null && NavigationController.TabBarController != null && NavigationController.TabBarController.TabBar != null)
//                {
//                    // Re-add tab bar height since it is hidden under keyboard but still excluded from View.Bounds.Height.
//                    height += NavigationController.TabBarController.TabBar.Frame.Height;
//                }
//
//                SectionsContainer.Frame = new CGRect(SectionsContainer.Frame.Location, new SizeF((float) View.Bounds.Width, (float) height));
//            });
//
//            keyboardHideObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, (notification) => {
//
//                UIApplication.EnsureUIThread();
//                SectionsContainer.Frame = new CGRect(SectionsContainer.Frame.Location,  View.Bounds.Size);
//            });
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UnregisterNotificationHandlers();
            foreach (var uiView in Content.OfType<IFormEventsListener>()) uiView.FormWillDisappear();
        }

        protected List<NSObject> NotificatioHandlers
        {
            get { return _notificatioHandlers ?? (_notificatioHandlers = new List<NSObject>()); }
            set { _notificatioHandlers = value; }
        }

        public float ShownKeyboardHeight { get; set; }

        public bool HeyboardShown
        {
            get { return _heyboardShown; }
            set
            {
                if (_heyboardShown == value) return;
                _heyboardShown = value;
                foreach (var result in Content.OfType<ISoftKeyboardEventsListener>())
                {
                    if (value) result.DidShowKeyboard();
                    else result.DidHideKeyboard();
                }
            }
        }

        protected virtual void RegisterNotificationHandlers()
        {
            NotificatioHandlers.Add(NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification,
                new Action<NSNotification>(
                    notification =>
                    {
                        CGRect overridenRect = CGRect.Empty;

                        foreach (var result in Content.OfType<ISoftKeyboardEventsListener>())
                        {
                            result.WillShowKeyboard(ref overridenRect);
                        }

                        ShownKeyboardHeight = (float) UIKeyboard.FrameBeginFromNotification(notification).Height;
                        var duration = UIKeyboard.AnimationDurationFromNotification(notification);
                        UIViewAnimationCurve curve =
                            (UIViewAnimationCurve) UIKeyboard.AnimationCurveFromNotification(notification);

                        if (overridenRect != CGRect.Empty)
                        {
                            ScrollViewTo(overridenRect, duration, curve);
                        }
                        else
                        {
                            ScrollViewBy(ShownKeyboardHeight, duration, curve);
                        }
                    })));

            NotificatioHandlers.Add(NSNotificationCenter.DefaultCenter.AddObserver(
                UIKeyboard.DidChangeFrameNotification,
                notification => { }));

            NotificatioHandlers.Add(NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification,
                new Action<NSNotification>(
                    notification =>
                    {
                        //foreach (var uiView in Content.OfType<IFormEventsListener>()) uiView.WillHideNotification();

                        CGRect overridenRect = CGRect.Empty;

                        foreach (var result in Content.OfType<ISoftKeyboardEventsListener>())
                        {
                            result.WillHideKeyboard(ref overridenRect);
                        }

                        var suppliedHeight = (float) UIKeyboard.FrameBeginFromNotification(notification).Height;
                        var duration = UIKeyboard.AnimationDurationFromNotification(notification);
                        UIViewAnimationCurve curve =
                            (UIViewAnimationCurve) UIKeyboard.AnimationCurveFromNotification(notification);


                        var frame = SectionsContainer.Frame;
                        frame.Height += ShownKeyboardHeight;
                        SectionsContainer.Frame = frame;

                        if (overridenRect != CGRect.Empty)
                        {
                            ScrollViewTo(overridenRect, duration, curve);
                        }
                        else
                        {
                            ScrollViewBy(-ShownKeyboardHeight, duration, curve);
                        }
                    })));


            NotificatioHandlers.Add(NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification,
                notification =>
                {
                    var frame = SectionsContainer.Frame;
                    frame.Height -= ShownKeyboardHeight;
                    SectionsContainer.Frame = frame;

                    HeyboardShown = true;
                }));
            NotificatioHandlers.Add(NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidHideNotification,
                notification => { HeyboardShown = false; }));


            NotificatioHandlers.Add(NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillChangeFrameNotification,
                notification =>
                {
                    var suppliedHeight = (float)UIKeyboard.FrameBeginFromNotification(notification).Height;
  
                }));
        }


        private void ScrollViewBy(float height, double duration, UIViewAnimationCurve curve)
        {
            UIView.BeginAnimations(null);
            UIView.SetAnimationDuration(duration);
            UIView.SetAnimationCurve(curve);
            var frame = SectionsContainer.ContentOffset;
            frame.Y += height;
            if (frame.Y < 0) frame.Y = 0;
//            else if (frame.Y > SectionsContainer.ContentSize.Height)
//                frame.Y = SectionsContainer.ContentSize.Height - SectionsContainer.Frame.Height;
            SectionsContainer.ContentOffset = frame;
            UIView.CommitAnimations();
        }

        private void ScrollViewTo(CGRect rect, double duration, UIViewAnimationCurve curve)
        {
            UIView.BeginAnimations(null);
            UIView.SetAnimationDuration(duration);
            UIView.SetAnimationCurve(curve);
            var frame = SectionsContainer.ContentOffset;
            frame.Y = rect.Y;
            SectionsContainer.ContentOffset = frame;
            UIView.CommitAnimations();
        }


        protected virtual void UnregisterNotificationHandlers()
        {
            foreach (var notificatioHandler in NotificatioHandlers.ToArray())
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(notificatioHandler);
            }
            NotificatioHandlers.Clear();
        }

        public virtual void BindForm()
        {
        }

        public virtual void UnbindForm()
        {
        }

        public virtual void RefreshContent()
        {
            foreach (var subview in SectionsContainer.Subviews.ToArray())
            {
                subview.RemoveFromSuperview();
            }

            SectionsContainer.RemoveConstraints(SectionsContainer.Constraints);

            Content.Clear();
            GetContent(Content);

            foreach (var uiView in Content)
            {
                var section = uiView as SectionViewBase;
                if (section != null) section.ParentController = this;

                SectionsContainer.Add(uiView);
            }

            LayoutContent();
        }

        public virtual void LayoutContent()
        {
            if (!SectionsContainer.Subviews.Any()) return;

            var constraints = SectionsContainer.VerticalStackPanelConstraints(
             new Margins(0, 0, 0, 25f, 0, AppTheme.FormSectionVerticalSpacing),
             SectionsContainer.Subviews).ToArray();

            var subviews = SectionsContainer.Subviews.ToArray();

            foreach (var source in SectionsContainer.Subviews.OfType<SectionViewBase>().Where(s=>s.ShouldStickSectionBelow))
            {
                var index = Array.IndexOf(subviews,source);
                if(index == subviews.Length-1) continue;
                var stickedView = subviews[index + 1];
                var constraint = constraints.ToArray().FirstOrDefault(c => (c.View == source && c.SecondItem == stickedView) ||
                    (c.View == stickedView && c.SecondItem == source));
                if (constraint != null)
                {
                    constraint.Constant = 0;
                }
            }

            SectionsContainer.AddConstraints(constraints);
        }

        public List<UIView> Content
        {
            get { return _content ?? (_content = new List<UIView>()); }
            set { _content = value; }
        }

        public virtual void GetContent(List<UIView> content)
        {
        }

        public CGSize ScrollableViewContentSize => SectionsContainer.ContentSize;



        public void ScrollRectToVisible(CGRect rect)
        {
            UIView.BeginAnimations(null);
            UIView.SetAnimationDuration(0.3);

            var frame = SectionsContainer.ContentOffset;
            frame.Y = rect.Y;
            SectionsContainer.ContentOffset = frame;
            UIView.CommitAnimations();
        }
    }


    public interface IScrollableView
    {
        CGSize ScrollableViewContentSize { get; }
        void ScrollRectToVisible(CGRect rect);
    }
}