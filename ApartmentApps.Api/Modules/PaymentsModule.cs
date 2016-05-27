using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api.Modules
{
    public class PaymentsModule : Module<PaymentsConfig>
    {
        public PaymentsModule(IRepository<PaymentsConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
        }
    }

    public class MessagingModule : Module<MessagingConfig>
    {
        public MessagingModule(IRepository<MessagingConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
        }
    }
    public class CourtesyModule : Module<CourtesyConfig>
    {
        public CourtesyModule(IRepository<CourtesyConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
        }
    }

    public class MaintenanceModule : Module<MaintenanceConfig>
    {
        public MaintenanceModule(IRepository<MaintenanceConfig> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
        }
    }
    [ModuleConfiguration]
    public class CourtesyConfig : ModuleConfig
    {
    }

    [ModuleConfiguration]
    public class MaintenanceConfig : ModuleConfig
    {
    }

    [ModuleConfiguration]
    public class MessagingConfig : ModuleConfig
    {
    }
}