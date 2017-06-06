using System.ComponentModel.DataAnnotations;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{
    public class UserListModel : BaseViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [DataType("Hidden")]
        public bool Archived { get; set; }

    }
}