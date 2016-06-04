using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;

namespace ResidentAppCross.Interfaces
{
    public interface IDisposableContainer
    {
        List<IDisposable> Disposables { get; set; }
    }

    public static class IDisposableContainerExtensions
    {
        public static void DisposeContainer(this IDisposableContainer container)
        {
            foreach (var disposable in container.Disposables)
            {
                disposable.Dispose();
            }
            container.Disposables.Clear();
        }

        public static void DisposeWith(this IDisposable disposable, IDisposableContainer container)
        {
            container.Disposables.Add(disposable);
        }
    }

    public class Disposable : IDisposable
    {
        private Action _handler;

        public Disposable(Action handler)
        {
            _handler = handler;
        }

        public void Dispose()
        {
            _handler?.Invoke();
        }
    }


    public interface IEventAware
    {
        IMvxMessenger EventAggregator { get; set; }
    }

    public static class IEventAwareExtensions
    {
        public static MvxSubscriptionToken SubscribeOnce<T>(this IEventAware subject, Action<T> act) where T : MvxMessage
        {
            MvxSubscriptionToken token = null;
            token = subject.EventAggregator.Subscribe<T>(evt =>
            {
                act(evt);
                token.Dispose();
            },MvxReference.Strong);
            return token;
        }
    }
}
