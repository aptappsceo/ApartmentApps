using System.Threading.Tasks;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface ICreateUser
    {
        Task<ApplicationUser> CreateUser(string email, string password);
    }
}