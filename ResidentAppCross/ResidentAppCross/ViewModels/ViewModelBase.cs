using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace ResidentAppCross.ViewModels
{
    public class ViewModelBase : MvxViewModel
    {
        private IMvxMessenger _eventAggregator;

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }
    }

    public static class ViewModelExtensions
    {
        public static void Publish<TMessage>(this ViewModelBase viewModel, TMessage message) where TMessage : MvxMessage
        {
            viewModel.EventAggregator.Publish(message);
        }
    }
}
