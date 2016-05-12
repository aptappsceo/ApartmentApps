using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.App_Start;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class IncidentReportFormModel
    {

        //[DataType()]
        [DisplayName("Unit")]
        public int UnitId { get; set; }

        public IEnumerable<FormPropertySelectItem> UnitId_Items
        {
            get
            {
                return
                    NinjectWebCommon.Kernel.Get<IRepository<Unit>>()
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, UnitId == p.Id));


            }
        }


        [DisplayName("Type")]
        [Required]
        public IncidentType ReportType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

    }
}