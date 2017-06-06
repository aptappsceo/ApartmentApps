using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class UnitFormModel : BaseViewModel
    {
        private readonly IRepository<Building> _buildingRepo;

        public string Name { get; set; }

        public int BuildingId { get; set; }

        public UnitFormModel()
        {
        }
        [Inject]
        public UnitFormModel(IRepository<Building> buildingRepo)
        {
            _buildingRepo = buildingRepo;
        }


        public IEnumerable<FormPropertySelectItem> BuildingId_Items
        {
            get
            {
                

                return
                    _buildingRepo
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, BuildingId == p.Id));


            }
        }

    }
}