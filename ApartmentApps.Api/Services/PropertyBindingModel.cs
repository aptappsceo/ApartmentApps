using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class PropertyBindingModel : BaseViewModel
    {
        private readonly IRepository<Corporation> _corporationRepository;
        public string Name { get; set; }
        [DisplayName("Corporation"), SelectFrom("CorporationId_Items")]
        public int CorporationId { get; set; }

        public PropertyBindingModel()
        {
        }
        [Inject]
        public PropertyBindingModel(IRepository<Corporation> corporationRepository)
        {
            _corporationRepository = corporationRepository;
        }

        public IEnumerable<FormPropertySelectItem> CorporationId_Items
        {
            get
            {
                return
                    _corporationRepository
                        .ToArray()
                        .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, CorporationId == p.Id));


            }
        }

        public PropertyState State { get; set; }

    }
}