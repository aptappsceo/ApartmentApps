using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ApartmentApps.Api
{
    public interface IEmailService
    {
        Task SendAsync(IdentityMessage message);
    }
}