using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class NotificationService : StandardCrudService<UserAlert>
    {
        public NotificationService(IKernel kernel, IRepository<UserAlert> repository) : base(kernel, repository)
        {
        }
    }
}