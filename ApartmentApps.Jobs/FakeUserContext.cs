using ApartmentApps.Api;
using ApartmentApps.Data;

namespace ApartmentApps.Jobs
{
    public class FakeUserContext : IUserContext
    {
        private readonly ApplicationDbContext _dbContext;

        public FakeUserContext(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private ApplicationUser _currentUser;

        public bool IsInRole(string roleName)
        {
            return true;
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