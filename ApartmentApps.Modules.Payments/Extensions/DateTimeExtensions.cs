using System;

namespace ApartmentApps.Api.Modules
{
    public static class DateTimeExtensions
    {

        public static DateTime Offset(this DateTime source, int days, int months, int years)
        {
            return source.AddYears(years).AddMonths(months).AddDays(days);
        }

        public static DateTime ToCorrectedDateTime(this DateTime source)
        {
            var lastDay = DateTime.DaysInMonth(source.Year, source.Month);
            var dif = source.Day - lastDay;
            if (dif > 0)
            {
                return source.Subtract(TimeSpan.FromDays(dif));
            }

            return source;
        }
    }
}