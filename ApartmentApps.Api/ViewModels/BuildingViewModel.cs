using System.ComponentModel;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{
    [DisplayName("Buildings")]
    public class BuildingViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }
}