using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public interface IMenuItemProvider
    {
        void PopulateMenuItems(List<MenuItemViewModel> menuItems);
    }

    public interface IAdminConfigurable : IModule
    {
        string SettingsController { get; }
    }
    public class MenuItemViewModel
    {
        public decimal Index { get; set; }
        private List<MenuItemViewModel> _children;

        public List<MenuItemViewModel> Children
        {
            get { return _children ?? (_children = new List<MenuItemViewModel>()); }
            set { _children = value; }
        }

        public bool HasChildren { get { return _children != null && _children.Count > 0; } }

        public string Label { get; set; }
        public string Icon { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public object RouteParams { get; set; }
        public MenuItemViewModel(string label, string icon,  decimal index = 0)
        {
            Label = label;
            Icon = icon;
            Index = index;
        }

        public MenuItemViewModel(string label, string icon, string action, string controller, object routeParams, decimal index = 0)
        {
            Label = label;
            Icon = icon;
            Action = action;
            Controller = controller;
            RouteParams = routeParams;
            Index = index;
        }

        public MenuItemViewModel(string label, string icon, string action, string controller, decimal index = 0)
        {
            Label = label;
            Icon = icon;
            Action = action;
            Controller = controller;
            Index = index;
        }
    }
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

        public virtual TConfig Config
        {
            get
            {


                var config = _configRepo.GetAll().AsNoTracking().FirstOrDefault();
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
            return new TConfig() {Enabled = true};
        }

        public virtual bool Enabled => Config.Enabled;
        public virtual string Name => this.GetType().Name.Replace("Module", "");


    }
}