namespace ApartmentApps.Api
{
    public class ExternalUnitImportInfo : IExternalUnitImportInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UnitNumber { get; set; }
        public string BuildingName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string MiddleName { get; set; }
        public bool IsVacant { get; set; }
        public string PhoneNumber { get; set; }

    }
}