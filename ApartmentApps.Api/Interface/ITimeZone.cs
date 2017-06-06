using System;

namespace ApartmentApps.Api
{
    public interface ITimeZone
    {
        DateTime Now { get; }
        DateTime Today { get; }

    }
}