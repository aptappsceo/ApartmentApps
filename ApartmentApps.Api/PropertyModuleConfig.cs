using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public interface IModuleConfig
    {
        bool Enabled { get; set; }
    }
    public class PropertyModuleConfig : PropertyEntity, IModuleConfig
    {
        public bool Enabled { get; set; }
    }

    public class UserModuleConfig : UserEntity, IModuleConfig
    {
        public bool Enabled { get; set; }
    }

    public class GlobalModuleConfig : IBaseEntity, IModuleConfig
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Enabled { get; set; }
    }
}
