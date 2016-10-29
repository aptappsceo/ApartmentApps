using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentApps.Data;

namespace ApartmentApps.Portal.Extensions
{
    public static class JSDateTimeExtensions
    {
           public static long ToEpochDate(this DateTime dt)
            {
                var epoch = new DateTime(1970, 1, 1);
                return dt.Subtract(epoch).Ticks;
            }
    }
}