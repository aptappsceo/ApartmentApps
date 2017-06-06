using System;
using System.Collections.Generic;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public interface IModuleHelper
    {
        IKernel Kernel { get; set; }
        IEnumerable<IModule> EnabledModules { get; }
        IEnumerable<IModule> AllModules { get; }
        void Signal<TInterface>(IEnumerable<IModule> modules, Action<TInterface> item);
        void SignalToEnabled<TInterface>( Action<TInterface> item);
        void SignalToAll<TInterface>(Action<TInterface> item);

    }
}