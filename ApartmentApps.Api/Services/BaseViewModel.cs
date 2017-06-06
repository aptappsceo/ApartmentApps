using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Forms;

namespace ApartmentApps.Portal.Controllers
{
    public class BaseViewModel
    {
        [DataType("Hidden")]
        public string Id { get; set; }

        [AutoformIgnore]
        [DataType("Hidden")]
        public string Title { get; set; } //Let this be some user friendly name for the item. This is used for autoform to auto-extract selectables

        public List<ActionLinkModel> ActionLinks { get; set; } = new List<ActionLinkModel>();
    }
}