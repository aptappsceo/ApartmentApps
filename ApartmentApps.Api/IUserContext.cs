using System;
using System.Threading;
using System.Threading.Tasks;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IUserContext : ITimeZone
    {
        bool IsInRole(string roleName);
        string UserId { get; }
        string Email { get;  }
        string Name { get;  }
        int PropertyId { get; }
        ApplicationUser CurrentUser { get; }
        T GetConfig<T>() where T : class, new();
    }

    public interface IBackgroundScheduler
    {
        void QueueBackgroundItem(Action<CancellationToken> backgroundAction);
        void QueueBackgroundItem(Func<CancellationToken,Task> backgroundAction);

    }

    public class DefaultBackgroundScheduler : IBackgroundScheduler
    {
        public void QueueBackgroundItem(Action<CancellationToken> backgroundAction)
        {
            backgroundAction(CancellationToken.None);
        }

        public void QueueBackgroundItem(Func<CancellationToken, Task> backgroundAction)
        {
            backgroundAction(CancellationToken.None);
        }
    }
}