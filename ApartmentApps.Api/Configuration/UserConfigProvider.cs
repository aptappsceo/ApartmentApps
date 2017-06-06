using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class UserConfigProvider<TConfig> : ConfigProvider<TConfig> where TConfig : class, IUserEntity,  new()
    {
        private readonly IKernel _kernel;

        public UserConfigProvider(IRepository<TConfig> configRepo, IKernel kernel) : base(configRepo)
        {
            _kernel = kernel;
        }

        public TConfig ConfigForUser(string userId)
        {
            var config = _kernel.Get<PropertyRepository<TConfig>>();
            var userConfig = config.FirstOrDefault(x => x.UserId == userId);
            if (userConfig == null)
            {
                var defaultConfig = CreateDefaultConfig();
                defaultConfig.UserId = userId;
                _configRepo.Add(defaultConfig);
                _configRepo.Save();
                return defaultConfig;
            }
            return userConfig;

        }

    }
}