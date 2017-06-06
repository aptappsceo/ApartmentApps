using System.Collections.Generic;
using ApartmentApps.Forms;

namespace ApartmentApps.Portal.Controllers
{
    public interface IFillActions
    {
        void FillActions(List<ActionLinkModel> actions, object viewModel);
    }
}