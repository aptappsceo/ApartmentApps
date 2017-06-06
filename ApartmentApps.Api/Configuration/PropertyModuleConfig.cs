using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public class PropertyModuleConfig : PropertyEntity, IModuleConfig
    {
        public bool Enabled { get; set; }
    }
}
