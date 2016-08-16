using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{

    // Models used as parameters to AccountController actions.
    public class UserBindingModel : BaseViewModel
    {

        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public bool IsTenant { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool Archived { get; set; }
    }
}
