using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api
{
    public class IncidentReportFormModel : BaseViewModel
    {
        private readonly IRepository<Unit> _unitRepo;
        private readonly IRepository<ApplicationUser> _userRepo;

        public IncidentReportFormModel()
        {
        }

        [Inject]
        public IncidentReportFormModel(IRepository<Unit> unitRepo, IRepository<ApplicationUser> userRepo)
        {
            _unitRepo = unitRepo;
            _userRepo = userRepo;
        }

        //[DataType()]
        [DisplayName("Unit")]
        public int UnitId { get; set; }

        public IEnumerable<FormPropertySelectItem> UnitId_Items
        {
            get
            {
                var items =
                    _unitRepo.ToArray();
                var users = _userRepo;
                return items.Select(p =>
                {
                    if (!string.IsNullOrEmpty(p.CalculatedTitle))
                        return new FormPropertySelectItem(p.Id.ToString(), p.CalculatedTitle, UnitId == p.Id);

                    var name = $"[{ p.Building.Name }] {p.Name}";
                    var user = users.GetAll().FirstOrDefault(x => !x.Archived && x.UnitId == p.Id);
                    if (user != null)
                        name += $" ({user.FirstName} {user.LastName})";

                    return new FormPropertySelectItem(p.Id.ToString(), name, UnitId == p.Id);
                }).OrderByAlphaNumeric(p => p.Value);


            }
        }


        [DisplayName("Type")]
        [Required]
        public IncidentType ReportType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

    }
}