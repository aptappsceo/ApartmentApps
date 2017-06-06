namespace ApartmentApps.Portal.Controllers
{
    public class UserSearchViewModel
    {
        public FilterViewModel Email { get; set; } = new FilterViewModel();
        public FilterViewModel FirstName { get; set; } = new FilterViewModel();
        public FilterViewModel LastName { get; set; } = new FilterViewModel();

        //[FilterPath("Unit.Name")]
        //public FilterViewModel UnitName { get; set; } = new FilterViewModel();

    }
}