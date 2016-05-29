using System;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

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
  
        private readonly IRepository<TConfig> _configRepo;
        public IUserContext UserContext { get; }

        public Module( IRepository<TConfig> configRepo, IUserContext userContext)
        {
           
            _configRepo = configRepo;
            UserContext = userContext;
        }

        public Type ConfigType
        {
            get { return typeof(TConfig); }
        }
        public ModuleConfig ModuleConfig => Config;

        public TConfig Config
        {
            get
            {


                var config = _configRepo.GetAll().FirstOrDefault();
                if (config == null)
                {
                    config = CreateDefaultConfig();
                    _configRepo.Add(config);
                    _configRepo.Save();
                }
                return config;
            }
        }

        protected virtual TConfig CreateDefaultConfig()
        {
            return new TConfig();
        }

        public bool Enabled => Config.Enabled;
        public virtual string Name => this.GetType().Name.Replace("Module", "");


    }
}