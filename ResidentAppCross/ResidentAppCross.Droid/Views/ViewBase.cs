using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using AndroidHUD;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Events;
using ResidentAppCross.Interfaces;

namespace ResidentAppCross.Droid.Views
{

    public abstract class ViewBase<T> : ViewBase where T : IMvxViewModel
    {
        public new T ViewModel
        {
            get { return (T)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }

    public abstract class ViewBase : MvxFragmentActivity, IDisposableContainer
    {
        private IMvxMessenger _eventAggregator;

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.OnViewModelEvent<TaskStarted>(evt => this.SetTaskRunning(evt.Label));
            this.OnViewModelEvent<TaskComplete>(evt => this.SetTaskComplete(evt.ShouldPrompt, evt.Label, evt.OnPrompted));
            this.OnViewModelEvent<TaskFailed>(evt => this.SetTaskFailed(evt.ShouldPrompt, evt.Label, evt.Reason, evt.OnPrompted));
            this.OnViewModelEvent<TaskProgressUpdated>(evt => this.SetTaskProgress(evt.ShouldPrompt, evt.Label));
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            this.DisposeContainer();
        }

        public List<IDisposable> Disposables { get; set; } = new List<IDisposable>();
    }



    public static class ViewExtensions
    {
        private static NotificationDialog _progressDialog;

        public static NotificationDialog CurrentDialog
        {
            get { return _progressDialog; }
            set { _progressDialog = value; }
        }

        public static NotificationDialog GetOrCreateDialog(Activity targetActivity)
        {

            if (targetActivity == null) return null;


            if (targetActivity == CurrentDialog?.SourceActivity)
            {
                return CurrentDialog;
            }


            DismissCurrentDialog();
            CurrentDialog = new NotificationDialog()
            {
                SourceActivity = targetActivity
            };

            CurrentDialog.Show(targetActivity.FragmentManager, "notification");
            CurrentDialog.OnceOnDismiss(()=>CurrentDialog = null);
            return CurrentDialog;
            ///CurrentDialog = ;
        }

        public static void DismissCurrentDialog()
        {
            CurrentDialog?.Dismiss();
            CurrentDialog = null;
        }

        public static void SetTaskRunning(this ViewBase view, string label, bool block = true)
        {

            if (block && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(view);
                dialog.Mode = NotificationDialogMode.Progress;
                dialog.TitleText = label;
                dialog.SubTitleText = "Please, Wait";
                dialog.ShouldDismissWhenClickedOutside = false;
            }
            else
            {
                DismissCurrentDialog();
            }

            //if(block) AndHUD.Shared.Show(view, label, -1, MaskType.Black, centered: true);
        }

        public static void SetTaskProgress(this ViewBase view, bool prompt, string label)
        {
            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(view);
                dialog.Mode = NotificationDialogMode.Progress;
                dialog.TitleText = label;
                dialog.SubTitleText = "Please, Wait";
                dialog.ShouldDismissWhenClickedOutside = false;
            }
            else
            {
                DismissCurrentDialog();
            }
        }

        public static void SetTaskComplete(this ViewBase view,bool prompt, string label = null, Action onPrompted = null)
        {

            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(view);
                dialog.Mode = NotificationDialogMode.Complete;
                dialog.TitleText = label;
                dialog.SubTitleText = null;
                dialog.ShouldDismissWhenClickedOutside = true;
                dialog.OnceOnDismiss(onPrompted);
                dialog.SetActions(new [] { new NotificationDialogItem() {Action = () => { }, Title=  "Ok", ShouldDismiss = true}});
            }
            else
            {
                DismissCurrentDialog();
            }

        }

        public static void SetTaskFailed(this ViewBase view, bool prompt, string label = null,Exception reason = null,  Action<Exception> onPrompted = null)
        {
            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(view);
                dialog.Mode = NotificationDialogMode.Failed;
                dialog.TitleText = "Oops!";
                dialog.SubTitleText = label;
                dialog.ShouldDismissWhenClickedOutside = true;
                if(onPrompted != null) dialog.OnceOnDismiss(()=>onPrompted?.Invoke(reason));
            }
            else
            {
                DismissCurrentDialog();
            }
        }

        public static void OnViewModelEvent<TMessage>(this ViewBase view, Action<TMessage> handler) where TMessage : MvxMessage
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