using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IUserContext
    {
        bool IsInRole(string roleName);
        string UserId { get; }
        string Email { get;  }
        string Name { get;  }
        int PropertyId { get; }
        ApplicationUser CurrentUser { get; }
    }
}