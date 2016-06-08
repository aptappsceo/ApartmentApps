using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Portal.Controllers
{
    public class BaseViewModel
    {
        [DataType("Hidden")]
        public string Id { get; set; }
    }
}