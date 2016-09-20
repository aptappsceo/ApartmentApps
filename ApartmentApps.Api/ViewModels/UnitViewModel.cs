using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.ViewModels
{
    public class UnitFormModel : BaseViewModel
    {

        public string Name { get; set; }

        public int BuildingId { get; set; }

        public UnitFormModel()
        {
        }


        public IEnumerable<FormPropertySelectItem> BuildingId_Items
        {
            get
            {
                return
                    Modules.ModuleHelper.Kernel.Get<IRepository<Building>>()
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, BuildingId == p.Id));


            }
        }

    }
    public class UnitViewModel :BaseViewModel
    {
        public string Name { get; set; }
        public string BuildingName { get; set; }


        [DataType("Hidden")]
        public double Latitude { get; set; }
        [DataType("Hidden")]
        public double Longitude { get; set; }

        public int BuildingId { get; set; }


    }
}