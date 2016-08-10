using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Modules.Inspections
{
    //[Persistant]
    public class InspectionsModuleConfig : ModuleConfig
    {
        
    }
    public class InspectionsModule : Module<InspectionsModuleConfig>
    {
        private readonly IRepository<Inspection> _inspections;

        public InspectionsModule(IRepository<Inspection> inspections, IKernel kernel, IRepository<InspectionsModuleConfig> configRepo, IUserContext userContext) : base(kernel, configRepo, userContext)
        {
            _inspections = inspections;
        }
    }

    //[Persistant]
    public class Inspection
    {
        
    }
   

}
