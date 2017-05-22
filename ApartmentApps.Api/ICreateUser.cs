using System;
using System.Threading.Tasks;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface ITimeZone
    {
        DateTime Now { get; }
        DateTime Today { get; }

    }
    public interface ICreateUser
    {
        Task<ApplicationUser> CreateUser(string email, string password, string firstName, string lastName);
    }
}