using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentApps.Api
{
    public interface IBackgroundScheduler
    {
        void QueueBackgroundItem(Action<CancellationToken> backgroundAction);
        void QueueBackgroundItem(Func<CancellationToken,Task> backgroundAction);

    }
}