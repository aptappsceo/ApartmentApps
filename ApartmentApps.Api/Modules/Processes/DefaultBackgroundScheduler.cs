using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentApps.Api
{
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