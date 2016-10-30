using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class Module<TConfig> : IModule where TConfig : ModuleConfig, new()
    {
        public class ConfigRepository : PropertyRepository<TConfig>
        {
            //public ConfigRepository(Func<IQueryable<TConfig>, IDbSet<TConfig>> includes, DbContext context, IUserContext userContext) : base(includes, context, userContext)
            //{
            //}

            public ConfigRepository(DbContext context, IUserContext userContext) : base(context, userContext)
            {
            }
        }

        protected IKernel Kernel { get; }
        private readonly IRepository<TConfig> _configRepo;
        public IUserContext UserContext { get; }

        public Module(IKernel kernel, IRepository<TConfig> configRepo, IUserContext userContext)
        {
            Kernel = kernel;
            _configRepo = configRepo;
            UserContext = userContext;
        }
        public IEnumerable<IModule> Modules
        {
            get { return Kernel.GetAll<IModule>(); }
        }

        public IEnumerable<IModule> EnabledModules
        {
            get { return Modules.Where(p => p.Enabled); }
        }

        public Type ConfigType
        {
            get { return typeof(TConfig); }
        }
        public virtual ModuleConfig ModuleConfig => Config;

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
            return new TConfig() {Enabled = true};
        }

        public virtual bool Enabled => Config.Enabled;
        public virtual string Name => this.GetType().Name.Replace("Module", "");


    }
}