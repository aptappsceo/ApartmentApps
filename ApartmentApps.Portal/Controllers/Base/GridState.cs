namespace ApartmentApps.Portal.Controllers
{
    public class GridState
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public string OrderBy { get; set; }
        public bool Descending { get; set; }
    }
}