using System;

namespace ApartmentApps.Api.Modules
{
    public interface IWebJob
    {
        TimeSpan Frequency { get; }

        int JobStartHour { get; }
        int JobStartMinute { get; }

        void Execute(ILogger logger);
    }
}