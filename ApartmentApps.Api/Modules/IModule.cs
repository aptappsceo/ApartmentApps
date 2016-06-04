using System;
using System.Collections.Generic;
using System.Linq;

namespace ApartmentApps.Api.Modules
{
    public static class ModuleExtensions
    {
        public static void Signal<TInterface>(this IEnumerable<IModule> modules, Action<TInterface> item)
        {
            foreach (var module in modules.OfType<TInterface>())
                item(module);
        }
    }
    public interface IModule
    {
        Type ConfigType { get; }
        bool Enabled { get; }
        string Name { get; }
        ModuleConfig ModuleConfig { get; }
    }
}