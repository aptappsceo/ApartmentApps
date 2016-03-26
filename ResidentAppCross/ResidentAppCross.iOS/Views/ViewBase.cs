using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AlertView;
using BigTed;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Events;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.Interfaces;
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
        public static void SetTaskRunning(this ViewBase view, string label, bool block = true)
        {
            if (block)
                BTProgressHUD.Show("", () => { }, label, -1f, ProgressHUD.MaskType.Black);
        }

        public static void SetTaskComplete(this ViewBase view, bool prompt, string label = null,
            Action onPrompted = null)
        {
            BTProgressHUD.Dismiss();
            if (prompt)
            {

                var alertView = new UIAlertView(null,label,null ,"Continue");
                //alertView.DismissWithClickedButtonIndex(alertView.CancelButtonIndex,true);
                alertView.Clicked += (sender, args) =>
                {
                    if (args.ButtonIndex == alertView.CancelButtonIndex)
                    {
                        onPrompted?.Invoke();
                    }
                };

                alertView.Show();
//                var alertWithBody = MBAlertView.AlertWithBody(label, "Continue", () => onPrompted?.Invoke());
//                alertWithBody.BackgroundAlpha = 0.7f;
//                alertWithBody.AddToDisplayQueue();
            }
        }

        public static void SetTaskFailed(this ViewBase view, bool prompt, string label = null, Exception reson = null,
            Action<Exception> onPrompted = null)
        {
            BTProgressHUD.Dismiss();
            if (prompt)
            {
                var alertWithBody = MBAlertView.AlertWithBody(label, "Ok", () =>
                {
                    onPrompted?.Invoke(reson);
                });
                alertWithBody.BackgroundAlpha = 0.7f;
                alertWithBody.AddToDisplayQueue();
            }
        }

        public static void OnViewModelEvent<TMessage>(this ViewBase view, Action<TMessage> handler)
            where TMessage : MvxMessage
        {
            view.OnEvent<TMessage>(evt =>
            {
                if (evt.Sender == view.ViewModel) handler(evt);
            });
        }

        public static void OnEvent<TMessage>(this ViewBase view, Action<TMessage> handler) where TMessage : MvxMessage
        {
            view.EventAggregator.Subscribe(handler).DisposeWith(view);
        }


    }

}
