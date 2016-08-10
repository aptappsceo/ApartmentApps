using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    [Persistant]
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

    [Persistant]
    public class Inspection : PropertyEntity
    {
        public virtual ICollection<InspectionAnswer> InspectionAnswers { get; set; }
    }

    [Persistant]
    public class InspectionAnswer : PropertyEntity
    {
        public int InspectionId { get; set; }

        [ForeignKey("InspectionId")]
        public virtual Inspection Inspection { get; set; }
        
        public int InspectionQuestionId { get; set; }

        [ForeignKey("InspectionQuestionId")]
        public virtual InspectionQuestion InspectionQuestion { get; set; }

        public string Value { get; set; }
    }


    public enum InspectionQuestionType
    {
        YesNo,

    }

    [Persistant]
    public class InspectionQuestion : PropertyEntity
    {
        public string QuestionName { get; set; }
        public InspectionQuestionType QuestionType { get; set; }
    }

}
