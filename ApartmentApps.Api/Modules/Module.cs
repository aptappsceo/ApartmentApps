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