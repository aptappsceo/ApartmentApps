using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public class UserModuleConfig : UserEntity, IModuleConfig
    {
        public bool Enabled { get; set; }
    }
}