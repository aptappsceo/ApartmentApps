using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IUserContext : ITimeZone
    {
        bool IsInRole(string roleName);
        string UserId { get; }
        string Email { get;  }
        string Name { get;  }
        int PropertyId { get; }
        ApplicationUser CurrentUser { get; }
        T GetConfig<T>() where T : class, new();
    }
}