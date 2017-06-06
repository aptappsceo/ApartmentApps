using System.ComponentModel;
using ApartmentApps.Data;

namespace ApartmentApps.Portal.Controllers
{
    public class FilterViewModel
    {
        [DisplayName("Operator")]
        public ExpressionOperator ExpressionOperator { get; set; }

        [DisplayName("Value")]
        public string Value { get; set; }
    }
}