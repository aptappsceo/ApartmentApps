using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Commands;
using ResidentAppCross.Events;

namespace ResidentAppCross.ViewModels
{
    public class ViewModelBase : MvxViewModel
    {
        private IMvxMessenger _eventAggregator;
        private static Stack<Action<object>> _configurationStack;

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }

        public void ShowViewModel<T>(Action<T> configuration) where T : ViewModelBase
        {
            ConfigurationStack.Push(obj => { configuration((T) obj); });
            ShowViewModel<T>(new { requiresInit = true });
        }

        private static Stack<Action<object>> ConfigurationStack
        {
            get { return _configurationStack ?? (_configurationStack = new Stack<Action<object>>()); }
            set { _configurationStack = value; }
        }

        public void Init(bool requiresInit = false)
        {
            if (!requiresInit) return;
            var config = ConfigurationStack.Pop();
            config(this);
        }
        
    }

    public static class ViewModelExtensions
    {
        public static void Publish<TMessage>(this ViewModelBase viewModel, TMessage message) where TMessage : MvxMessage
        {
            viewModel.EventAggregator.Publish(message);
        }
    }


    public static class ViewModelTaskExtensions
    {
        public static TaskCommand TaskCommand(this ViewModelBase viewModel, Func<ITaskCommandContext,Task> action, Func<bool> canExecute = null)
        {
            return new TaskCommand(viewModel, action, canExecute);
        }

        public static void StartTask(this ViewModelBase viewModel, string label)
        {
            viewModel.Publish(new TaskStarted(viewModel) { Label = label});
        }

        public static void CompleteTask(this ViewModelBase viewModel)
        {
            viewModel.Publish(new TaskComplete(viewModel) { });
        }

        public static void CompleteTaskWithPrompt(this ViewModelBase viewModel, string message, Action onPrompt = null)
        {
            viewModel.Publish(new TaskComplete(viewModel) { Label =  message, ShouldPrompt = true, OnPrompted = onPrompt});
        }

        public static void FailTaskWithPrompt(this ViewModelBase viewModel, string message, Action<Exception> onPrompt = null)
        {
            viewModel.Publish(new TaskFailed(viewModel) { Label =  message, ShouldPrompt = true, OnPrompted = onPrompt});
        }

        public static void FailTaskWithPrompt(this ViewModelBase viewModel, Exception reason, Action<Exception> onPrompt = null)
        {
            viewModel.Publish(new TaskFailed(viewModel) { Reason = reason, ShouldPrompt = true, OnPrompted = onPrompt});
        }

    }
}
