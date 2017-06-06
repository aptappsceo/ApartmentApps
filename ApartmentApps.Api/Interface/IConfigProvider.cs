using System;

namespace ApartmentApps.Api.Modules
{
    public interface IConfigProvider
    {
        string Title { get; }
        object ConfigObject { get; }
        Type ConfigType { get; }
    }
}