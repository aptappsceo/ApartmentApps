using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ApartmentApps.Data;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;

namespace ApartmentApps.Api
{
    //public static class ServiceExtensions
    //{
    //    public static Func<IEnumerable<IService>> GetServices { get; set; }


    //    public static void InvokeEvent<TEventInterface>( Action<TEventInterface> evt) where TEventInterface : class
    //    {
    //        InvokeEvent<TEventInterface>(null, evt);
    //    }

    //    public static void InvokeEvent<TEventInterface>(this IService service, Action<TEventInterface> evt) where TEventInterface : class
    //    {
    //        foreach (var item in GetServices())
    //        {
    //            var item1 = item as TEventInterface;
    //            if (item1 == null) continue;
    //            var filter = item as IAddonFilter;
    //            if (filter != null)
    //            {
    //                if (!filter.Filter())
    //                {
    //                    continue;
    //                }
    //            }
    //            evt(item1);
    //        }
    //    }

    //}
}
