using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public static class Modules
    {
        public static IKernel Kernel { get; set; }
        public static IEnumerable<IModule> EnabledModules
        {
            get
            {
                return Kernel.GetAll<IModule>().Where(p => p.Enabled);
            }
        }
        public static IEnumerable<IModule> AllModules
        {
            get { return Kernel.GetAll<IModule>(); }
        }
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