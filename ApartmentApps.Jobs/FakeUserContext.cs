using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using Ninject;

namespace ApartmentApps.Jobs
{
    public class FakeUserContext : IUserContext
    {
        private readonly ApplicationDbContext _dbContext;


        private ApplicationUser _currentUser;

        public bool IsInRole(string roleName)
        {
            return true;
        }
        private IKernel _kernel;

        public FakeUserContext(ApplicationDbContext context, IKernel kernel)
        {
            _kernel = kernel;
            _dbContext = context;
        }
        public ConfigProvider<T> GetConfigProvider<T>() where T : class, new()
        {
            return _kernel.Get<ConfigProvider<T>>();
        }

        public T GetConfig<T>() where T : class, new()
        {
            return GetConfigProvider<T>().Config;
        }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int PropertyId { get; set; }

        public void SetProperty(int propertyId)
        {
            
        }

        public ApplicationUser CurrentUser
        {
            get { return _currentUser ?? (_currentUser = _dbContext.Users.Find(UserId)); }
            set { _currentUser = value; }
        }
    }
}