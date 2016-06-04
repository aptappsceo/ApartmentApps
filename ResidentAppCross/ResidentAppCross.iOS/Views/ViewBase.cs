using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.iOS;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Events;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.Interfaces;
using SCLAlertViewLib;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    public class ViewBase<T> : ViewBase where T: IMvxViewModel
    {
        public ViewBase(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public new T ViewModel
        {
            get { return (T)base.ViewModel; }
            set { base.ViewModel = value; }
        }

    } 


    public class ViewBase : MvxViewController, IEventAware, IDisposableContainer
    {
        private static Dictionary<Type, List<ViewAttribute>> _viewAttributes;
        private static Dictionary<Type, List<ViewAttribute>> ViewAttributes =>
        _viewAttributes ?? (_viewAttributes = new Dictionary<Type, List<ViewAttribute>>());


        protected ViewBase(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
            OwnViewAttributes.ForEach(a => a.OnViewConstructing(this));
        }

        private static void LoadViewAttributesFor(Type type)
        {
           
        } 

        protected List<ViewAttribute> OwnViewAttributes
        {
            get
            {
                List<ViewAttribute> attribs;
                if (!ViewAttributes.TryGetValue(ViewType, out attribs))
                {
                    ViewAttributes[ViewType] = attribs = 
                        ViewType.GetCustomAttributes(typeof(ViewAttribute), true).OfType<ViewAttribute>().ToList();
                }
                return attribs;
            }
        }

        private IMvxMessenger _eventAggregator;
        private Type _viewType;

        public Type ViewType => _viewType ?? (_viewType = GetType());

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.OnViewModelEvent<TaskStarted>(evt => this.SetTaskRunning(evt.Label));
            this.OnViewModelEvent<TaskComplete>(evt => this.SetTaskComplete(evt.ShouldPrompt, evt.Label, evt.OnPrompted));
            this.OnViewModelEvent<TaskFailed>(evt => this.SetTaskFailed(evt.ShouldPrompt, evt.Label, evt.Reason, evt.OnPrompted));
            this.OnViewModelEvent<TaskProgressUpdated>(evt => this.SetTaskProgress(evt.ShouldPrompt, evt.Label));
            OwnViewAttributes.ForEach(a=>a.OnViewLoaded(this));
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            OwnViewAttributes.ForEach(a => a.OnViewAppeared(this, animated));
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            OwnViewAttributes.ForEach(a=>a.OnViewWillAppear(this,animated));
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            this.DisposeContainer();
        }

        public List<IDisposable> Disposables { get; set; } = new List<IDisposable>();
    }


    public static class ViewExtensions
    {
        private static SCLAlertView _waitingView;

        public static SCLAlertView WaitingView
        {
            get { return _waitingView ?? (_waitingView = new SCLAlertView()
            {
                ShowAnimationType = SCLAlertViewShowAnimation.FadeIn,
                HideAnimationType = SCLAlertViewHideAnimation.FadeOut,
                CustomViewColor = AppTheme.SecondaryBackgoundColor
            }); }
            set { _waitingView = value; }
        }

        public static NSTimer BackgroundTaskProgressTimer { get; set; }

        public static void SetTaskRunning(this ViewBase view, string label, bool block = true)
        {
            view?.View.EndEditing(true);
            if (block && label != null)
            {
                BackgroundTaskProgressTimer  = NSTimer.CreateScheduledTimer(TimeSpan.FromMilliseconds(ShowProgressAfterMilliseconds),
                    x =>
                    {
                        view.InvokeOnMainThread(() =>
                        {
                            if (!WaitingView.IsVisible || !WaitingView.IsVisible())
                                WaitingView.ShowWaiting(view, "Please, wait", label, null, 0);
                        });
                    });


                //alert.AlertIsDismissed(() => { onPrompted?.Invoke(); });
            }
                //BTProgressHUD.Show("", () => { }, label, -1f, ProgressHUD.MaskType.Black);
        }

        public static double ShowProgressAfterMilliseconds = 300f; 

        public static void SetTaskComplete(this ViewBase view, bool prompt, string label = null,
            Action onPrompted = null)
        {
            if(WaitingView.IsVisible) WaitingView.HideView();
            if (BackgroundTaskProgressTimer != null)
            {
                BackgroundTaskProgressTimer.Dispose();
                BackgroundTaskProgressTimer = null;
            }
            if (prompt)
            {
                view.InvokeOnMainThread(() =>
                {
                    var alert = new SCLAlertView();
                    alert.ShowAnimationType = SCLAlertViewShowAnimation.FadeIn;
                    alert.HideAnimationType = SCLAlertViewHideAnimation.FadeOut;
                    //alert.CustomViewColor = AppTheme.SecondaryBackgoundColor;
                    alert.AlertIsDismissed(() => { onPrompted?.Invoke(); });
                    alert.AddTimerToButtonIndex(0);
                    alert.ShowSuccess(view, "Success", label, "Ok", 2.5f);
                });
            }
            else
            {
                onPrompted?.Invoke();
            }
        }

        public static void SetTaskFailed(this ViewBase view, bool prompt, string label = null, Exception reson = null,
            Action<Exception> onPrompted = null)
        {
            if (WaitingView.IsVisible) WaitingView.HideView(); //Release progress
            if (BackgroundTaskProgressTimer != null) //Release timer
            {
                BackgroundTaskProgressTimer.Dispose();
                BackgroundTaskProgressTimer = null;
            }
            if (prompt)
            {
                view.InvokeOnMainThread(() =>
                {
                    var alert = new SCLAlertView();
                    alert.ShowAnimationType = SCLAlertViewShowAnimation.FadeIn;
                    alert.HideAnimationType = SCLAlertViewHideAnimation.FadeOut;
                    alert.AlertIsDismissed(() => { onPrompted?.Invoke(reson); });
                    //alert.CustomViewColor = AppTheme.SecondaryBackgoundColor;
                    alert.ShowError(view, "Oops!", label, "Ok", 5f);
                });
            }
            else
            {
                onPrompted?.Invoke(reson);
            }
        }

       


        public static void SetTaskProgress(this ViewBase view, bool shouldPrompt, string label)
        {
            view.InvokeOnMainThread(() =>
            {

                if (WaitingView.IsVisible && string.IsNullOrEmpty(label))
                {
                    WaitingView.HideView();
                    return;
                }

                if (!WaitingView.IsVisible)
                    WaitingView.ShowWaiting(view, "Please, wait", label, null, 0);
                else
                    WaitingView.Title = label;
            });
        }



        public static void OnViewModelEvent<TMessage>(this ViewBase view, Action<TMessage> handler)
            where TMessage : MvxMessage
        {
            view.OnEvent<TMessage>(evt =>
            {
                if (evt.Sender == view.ViewModel) handler(evt);
            });
        }

        public static void OnViewModelEventMainThread<TMessage>(this ViewBase view, Action<TMessage> handler)
            where TMessage : MvxMessage
        {
            view.OnEvent<TMessage>(evt =>
            {
                if (evt.Sender == view.ViewModel) view.InvokeOnMainThread(()=> handler(evt));
            });
        }

        public static void OnEvent<TMessage>(this ViewBase view, Action<TMessage> handler) where TMessage : MvxMessage
        {
            view.EventAggregator.Subscribe(handler).DisposeWith(view);
        }


    }

}
