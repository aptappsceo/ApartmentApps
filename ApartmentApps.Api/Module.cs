using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class Module<TConfig, TUserConfig> : Module<TConfig>, IUserConfigurable<TUserConfig> where TConfig : class, IModuleConfig, new() where TUserConfig : class, IUserEntity, new()
    {
        public IRepository<TUserConfig> UserConfigRepo { get; set; }

        private TUserConfig _userConfig;

        public Type UserConfigType => typeof(TUserConfig);

        public TUserConfig UserConfig
        {
            get
            {
                if (_userConfig == null)
                {
                    _userConfig = UserConfigRepo.GetAll().AsNoTracking().FirstOrDefault();//GetAll().AsNoTracking().FirstOrDefault();
                    if (_userConfig == null)
                    {
                        _userConfig = CreateDefaultUserConfig();
                        UserConfigRepo.Add(_userConfig);
                        UserConfigRepo.Save();
                    }
                }

                return _userConfig;

            }
        }

        protected virtual TUserConfig CreateDefaultUserConfig()
        {
            return new TUserConfig()
            {
                UserId = UserContext.UserId
            };
        }

        public Module(IKernel kernel, IRepository<TConfig> configRepo, IRepository<TUserConfig> userConfigRepo, IUserContext userContext) : base(kernel, configRepo, userContext)
        {
            UserConfigRepo = userConfigRepo;
        }
    }
    public interface IConfigProvider
    {
        string Title { get; }
        object ConfigObject { get; }
        Type ConfigType { get; }
    }

    public class UserConfigProvider<TConfig> : ConfigProvider<TConfig> where TConfig : class, IUserEntity,  new()
    {
        private readonly IKernel _kernel;

        public UserConfigProvider(IRepository<TConfig> configRepo, IKernel kernel) : base(configRepo)
        {
            _kernel = kernel;
        }

        public void ConfigForUser(string userId)
        {
            var config = _kernel.Get<PropertyRepository<TConfig>>();
            var userConfig = config.FirstOrDefault(x => x.UserId == userId);
            if (userConfig == null)
            {
                var defaultConfig = CreateDefaultConfig();
                defaultConfig.UserId = userId;
                _configRepo.Add(defaultConfig);
                _configRepo.Save();
            }

        }

    }
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
    public class Module<TConfig> : ConfigProvider<TConfig>, IModule where TConfig : class, IModuleConfig, new()
    {
        protected IKernel Kernel { get; }
        protected IModuleHelper ModuleHelper { get; set; }

        private readonly IRepository<TConfig> _configRepo;
        public IUserContext UserContext { get; }

        public Module(IKernel kernel, IRepository<TConfig> configRepo, IUserContext userContext) : base(configRepo)
        {
            Kernel = kernel;
            _configRepo = configRepo;
            UserContext = userContext;
            ModuleHelper = kernel.Get<IModuleHelper>();
        }
        public IEnumerable<IModule> Modules => Kernel.GetAll<IModule>();

        public IEnumerable<IModule> EnabledModules => Modules.Where(p => p.Enabled);

  
        public virtual IModuleConfig ModuleConfig => Config;

        protected override TConfig CreateDefaultConfig()
        {
            return new TConfig() {Enabled = true};
        }

        public virtual bool Enabled => Config.Enabled;
        public virtual string Name => this.GetType().Name.Replace("Module", "");


    }
}