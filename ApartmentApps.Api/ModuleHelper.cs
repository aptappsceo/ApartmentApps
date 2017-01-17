using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ModuleHelper : IModuleHelper
    {
        private IEnumerable<IModule> _allModules;
        private IEnumerable<IModule> _enabledModules;

        public ModuleHelper(IKernel kernel)
        {
            Kernel = kernel;
        }

        public IKernel Kernel { get; set; }
        public IEnumerable<IModule> EnabledModules => _enabledModules ?? (_enabledModules = AllModules.Where(p=>p.Enabled).ToArray());
        public IEnumerable<IModule> AllModules
        {
            get
            {

                return _allModules ?? (_allModules =  Kernel.GetAll<IModule>());
            }
        }

        public void Signal<TInterface>(IEnumerable<IModule> modules, Action<TInterface> item)
        {
            foreach (var module in modules.OfType<TInterface>())
                item(module);
        }

        public void SignalToEnabled<TInterface>( Action<TInterface> item)
        {
            Signal(EnabledModules,item);
        }
        public void SignalToAll<TInterface>( Action<TInterface> item)
        {
            Signal(EnabledModules, item);
        }
    }
    //public static class ModuleHelper
    //{
    //    public static IKernel Kernel { get; set; }
    //    public static IEnumerable<IModule> EnabledModules
    //    {
    //        get
    //        {
    //            return Kernel.GetAll<IModule>().Where(p => p.Enabled);
    //        }
    //    }
    //    public static IEnumerable<IModule> AllModules
    //    {
    //        get { return Kernel.GetAll<IModule>(); }
    //    }
    //    public static void Signal<TInterface>(this IEnumerable<IModule> modules, Action<TInterface> item)
    //    {
    //        foreach (var module in modules.OfType<TInterface>())
    //            item(module);
    //    }


    //}
}