namespace ApartmentApps.Api
{
    public interface IExternalUnitImportInfo
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string UnitNumber { get; set; }
        string BuildingName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string PostalCode { get; set; }
        string Email { get; set; }
        string MiddleName { get; set; }
        bool IsVacant { get; set; }
        string PhoneNumber { get; set; }
    }
}