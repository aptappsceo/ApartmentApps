using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Portal.Controllers
{
    public class BaseViewModel
    {
        [DataType("Hidden")]
        public object Id { get; set; }
    }
}