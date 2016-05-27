using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public class ModuleConfig : PropertyEntity
    {
        public bool Enabled { get; set; }
        public string Name { get; set; }
    }
}
