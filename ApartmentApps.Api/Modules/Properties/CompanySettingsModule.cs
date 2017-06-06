using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Api.Modules
{
    public class CompanySettingsModule : Module<CompanySettingsConfig>, IAdminConfigurable
    {
        public CompanySettingsModule(IKernel kernel, IRepository<CompanySettingsConfig> configRepo, IUserContext userContext) : base(kernel, configRepo, userContext)
        {
        }

        public string SettingsController => "CompanySettingsConfig";
    }
}