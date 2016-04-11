using System;

namespace ApartmentApps.Api
{
    public static class DateTimeUtil
    {
        public static DateTime Now(this TimeZoneInfo zone, DateTime time)
        {
            return TimeZoneInfo.ConvertTime(time, zone);
        }
        public static DateTime Now(this TimeZoneInfo zone)
        {
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, zone);
        }
    }
}