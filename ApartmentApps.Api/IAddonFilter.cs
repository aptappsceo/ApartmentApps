using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IAddonFilter
    {
        bool Filter();
    }

    public interface IUserContext
    {
        string UserId { get; }
        string Email { get;  }
        string Name { get;  }
        int PropertyId { get; }
        ApplicationUser CurrentUser { get; }
    }
}