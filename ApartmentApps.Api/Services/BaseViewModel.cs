using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Forms;

namespace ApartmentApps.Portal.Controllers
{
    public class BaseViewModel
    {
        [DataType("Hidden")]
        public string Id { get; set; }

        public List<ActionLinkModel> ActionLinks { get; set; } = new List<ActionLinkModel>();
    }
}