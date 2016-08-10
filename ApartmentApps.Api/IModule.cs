using System;

namespace ApartmentApps.Api.Modules
{
    public interface IModule
    {
        Type ConfigType { get; }
        bool Enabled { get; }
        string Name { get; }
        ModuleConfig ModuleConfig { get; }
    }
}