using System;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api.Modules
{
    public class ConfigProvider<TConfig> : IConfigProvider where TConfig : class,  new()
    {
        protected readonly IRepository<TConfig> _configRepo;
        private readonly DbContext _context;
        private readonly IUserContext _userContext;
        public Type ConfigType => typeof(TConfig);
        public ConfigProvider(IRepository<TConfig> configRepo)
        {
            _configRepo = configRepo;
        }



        private TConfig _config;

        public virtual TConfig Config
        {
            get
            {

                if (_config == null)
                {
                    _config = _configRepo.GetAll().AsNoTracking().FirstOrDefault();
                    if (_config == null)
                    {
                        _config = CreateDefaultConfig();
                        _configRepo.Add(_config);
                        _configRepo.Save();
                    }
                }

                return _config;
            }
        }

        protected virtual TConfig CreateDefaultConfig()
        {
            return new TConfig() {  };
        }

        public virtual string Title => ConfigType.Name;
        public object ConfigObject => Config;
    }
}