using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrata.Client.GetMitsUnits
{
    public class Identification
    {
        public string IDValue { get; set; }
        public string OrganizationName { get; set; }
    }

    public class Identification2
    {
        public string IDValue { get; set; }
    }

    public class Companies
    {
        public Identification2 Identification { get; set; }
        public string CompanyName { get; set; }
        public string WebSite { get; set; }
    }

    public class PropertyContacts
    {
        public Companies Companies { get; set; }
    }

    public class Management
    {
        public Identification Identification { get; set; }
        public PropertyContacts PropertyContacts { get; set; }
    }

    public class Attributes
    {
        public string IDScopeType { get; set; }
        public string IDRank { get; set; }
    }

    public class Identification3
    {
        public Attributes attributes { get; set; }
        public string IDValue { get; set; }
    }

    public class Attributes2
    {
        public string IDScopeType { get; set; }
        public string IDRank { get; set; }
    }

    public class Identification4
    {
        public Attributes2 attributes { get; set; }
        public string IDValue { get; set; }
        public string OrganizationName { get; set; }
    }

    public class Attributes3
    {
        public string AddressType { get; set; }
    }

    public class AddressInfo
    {
        public Attributes3 attributes { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }

    public class Attributes4
    {
        public string PhoneType { get; set; }
    }

    public class Phone
    {
        public Attributes4 attributes { get; set; }
        public string PhoneDescription { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PropertyID
    {
        public Identification4 Identification { get; set; }
        public string MarketingName { get; set; }
        public string LegalName { get; set; }
        public string WebSite { get; set; }
        public AddressInfo AddressInfo { get; set; }
        public List<Phone> Phone { get; set; }
    }

    public class Attributes5
    {
        public string ILS_IdentificationType { get; set; }
        public string RentalType { get; set; }
    }

    public class ILSIdentification
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string DaylightSaving { get; set; }
        public string TimeZone { get; set; }
        public Attributes5 attributes { get; set; }
    }

    public class OfficeHour
    {
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string Day { get; set; }
    }

    public class Information
    {
        public string StructureType { get; set; }
        public string UnitCount { get; set; }
        public string YearBuilt { get; set; }
        public List<OfficeHour> OfficeHour { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string LeaseLength { get; set; }
        public string DrivingDirections { get; set; }
        public string PropertyAvailabilityURL { get; set; }
    }

    public class Attributes6
    {
        public string Type { get; set; }
        public string Amount { get; set; }
    }

    public class ApplicationFee
    {
        public Attributes6 attributes { get; set; }
    }

    public class Fee
    {
        public List<ApplicationFee> ApplicationFee { get; set; }
    }

    public class Attributes7
    {
        public string IDScopeType { get; set; }
        public string IDRank { get; set; }
    }

    public class Identification5
    {
        public Attributes7 attributes { get; set; }
        public string IDValue { get; set; }
        public string OrganizationName { get; set; }
    }

    public class Building
    {
        public Identification5 Identification { get; set; }
        public string Name { get; set; }
        public object Description { get; set; }
        public string UnitCount { get; set; }
        public string SquareFeet { get; set; }
    }

    public class Attributes8
    {
        public string IDScopeType { get; set; }
        public string IDRank { get; set; }
    }

    public class Identification6
    {
        public Attributes8 attributes { get; set; }
        public string IDValue { get; set; }
    }

    public class Attributes9
    {
        public string RoomType { get; set; }
    }

    public class Room
    {
        public Attributes9 attributes { get; set; }
        public string Count { get; set; }
        public string Comment { get; set; }
    }

    public class Attributes10
    {
        public string Avg { get; set; }
        public string Max { get; set; }
        public string Min { get; set; }
    }

    public class SquareFeet
    {
        public Attributes10 attributes { get; set; }
    }

    public class Attributes11
    {
        public string Max { get; set; }
        public string Min { get; set; }
    }

    public class MarketRent
    {
        public Attributes11 attributes { get; set; }
    }

    public class Attributes12
    {
        public string DepositType { get; set; }
    }

    public class Attributes13
    {
        public string AmountType { get; set; }
    }

    public class Attributes14
    {
        public string Max { get; set; }
        public string Min { get; set; }
    }

    public class ValueRange
    {
        public Attributes14 attributes { get; set; }
    }

    public class Amount
    {
        public Attributes13 attributes { get; set; }
        public ValueRange ValueRange { get; set; }
    }

    public class Deposit
    {
        public Attributes12 attributes { get; set; }
        public Amount Amount { get; set; }
    }

    public class Attributes15
    {
        public string FileID { get; set; }
        public string Active { get; set; }
    }

    public class File
    {
        public Attributes15 attributes { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public string Src { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Rank { get; set; }
    }

    public class Floorplan
    {
        public Identification6 Identification { get; set; }
        public string Name { get; set; }
        public string UnitCount { get; set; }
        public string FloorplanAvailabilityURL { get; set; }
        public string UnitsAvailable { get; set; }
        public string DisplayedUnitsAvailable { get; set; }
        public List<Room> Room { get; set; }
        public SquareFeet SquareFeet { get; set; }
        public MarketRent MarketRent { get; set; }
        public Deposit Deposit { get; set; }
        public List<File> File { get; set; }
        public string Comment { get; set; }
    }

    public class Attributes16
    {
        public string IDScopeType { get; set; }
        public string IDRank { get; set; }
    }

    public class Identification7
    {
        public Attributes16 attributes { get; set; }
        public string IDValue { get; set; }
        public string OrganizationName { get; set; }
    }

    public class Attributes17
    {
        public string BuildingId { get; set; }
        public string FloorPlanId { get; set; }
    }

    public class Attributes18
    {
        public string IDType { get; set; }
        public string IDScopeType { get; set; }
        public string IDRank { get; set; }
    }

    public class Identification8
    {
        public Attributes18 attributes { get; set; }
        public string IDValue { get; set; }
        public string OrganizationName { get; set; }
    }

    public class Attributes19
    {
        public string Total { get; set; }
    }

    public class NumberOccupants
    {
        public Attributes19 attributes { get; set; }
    }

    public class Attributes20
    {
        public string AddressType { get; set; }
    }

    public class Address2
    {
        public Attributes20 attributes { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    public class Unit
    {
        public Attributes17 attributes { get; set; }
        public Identification8 Identification { get; set; }
        public string MarketingName { get; set; }
        public string UnitType { get; set; }
        public string UnitBedrooms { get; set; }
        public string UnitBathrooms { get; set; }
        public string MinSquareFeet { get; set; }
        public string MaxSquareFeet { get; set; }
        public string SquareFootType { get; set; }
        public string UnitRent { get; set; }
        public string MarketRent { get; set; }
        public string UnitOccupancyStatus { get; set; }
        public NumberOccupants NumberOccupants { get; set; }
        public string FloorplanName { get; set; }
        public string BuildingName { get; set; }
        public Address2 Address { get; set; }
    }

    public class Units
    {
        public Unit Unit { get; set; }
    }

    public class Attributes21
    {
        public string Month { get; set; }
        public string Day { get; set; }
        public string Year { get; set; }
    }

    public class VacateDate
    {
        public Attributes21 attributes { get; set; }
    }

    public class Availability
    {
        public string VacancyClass { get; set; }
        public VacateDate VacateDate { get; set; }
        public string UnitAvailabilityURL { get; set; }
    }

    public class Attributes22
    {
        public string AmenityType { get; set; }
    }

    public class Amenity
    {
        public Attributes22 attributes { get; set; }
        public string Description { get; set; }
    }

    public class ILSUnit
    {
       // public Identification7 Identification { get; set; }
        public Units Units { get; set; }
        //public Availability Availability { get; set; }
        //public List<Amenity> Amenity { get; set; }
        //public string FloorLevel { get; set; }
        //public string EffectiveRent { get; set; }
    }

    public class Attributes23
    {
        public string FileID { get; set; }
        public string Active { get; set; }
    }

    public class File2
    {
        public Attributes23 attributes { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Format { get; set; }
        public string Src { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Rank { get; set; }
    }

    public class Property
    {
        //public Identification3 Identification { get; set; }
        //public PropertyID PropertyID { get; set; }
        //public ILSIdentification ILS_Identification { get; set; }
        //public Information Information { get; set; }
        //public Fee Fee { get; set; }
        //public List<object> Amenity { get; set; }
        //public List<object> Policy { get; set; }
        //public List<Building> Building { get; set; }
        //public List<Floorplan> Floorplan { get; set; }
        public List<ILSUnit> ILS_Unit { get; set; }
        //public List<File2> File { get; set; }
    }

    public class PhysicalProperty
    {
        //public Management Management { get; set; }
        public List<Property> Property { get; set; }
    }

    public class Result
    {
        public PhysicalProperty PhysicalProperty { get; set; }
    }

    public class Response
    {
        public string requestId { get; set; }
        public ErrorResponse error { get; set; }
        public Result result { get; set; }
    }

    public class ErrorResponse
    {
        public int code { get; set; }
        public string message { get; set; }
    }
    public class MitsUnitsResponse
    {
        public Response response { get; set; }
    }
}
