using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IAddonFilter
    {
        bool Filter(ApplicationUser user);
    }

    public interface IPropertyContext
    {
        int PropertyId { get; }

    }
}