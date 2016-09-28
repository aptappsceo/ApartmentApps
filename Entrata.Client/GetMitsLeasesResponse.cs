using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entrata.Client.GetMitsLeases
{
    public class Attributes
    {
        public string ResidentType { get; set; }
    }

    public class Attributes2
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
    }

    public class Identification
    {

        public int IDValue { get; set; }
        public string OrganizationName { get; set; }
    }

    public class Attributes3
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
    }

    public class Identification2
    {

        public string IDValue { get; set; }
    }

    public class LeaseID
    {
        public List<Identification2> Identification { get; set; }
    }

    public class Attributes4
    {
        public string ReferenceType { get; set; }
    }

    public class Attributes5
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
    }

    public class Identification3
    {

        public int IDValue { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Attributes6
    {
        public string AddressType { get; set; }
    }

    public class Address
    {

        public string Email { get; set; }
    }

    public class Attributes7
    {
        public string PhoneType { get; set; }
    }

    public class Phone
    {

        public string PhoneNumber { get; set; }
    }

    public class ContactInfo
    {
        public List<Identification3> Identification { get; set; }
        public Name Name { get; set; }
        public List<Address> Address { get; set; }
        public List<Phone> Phone { get; set; }
    }

    public class Reference
    {

        public ContactInfo ContactInfo { get; set; }
    }

    public class Name2
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class Attributes8
    {
        public string AddressType { get; set; }
    }

    public class Address2
    {

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string CountryName { get; set; }
    }

    public class Residence
    {
        public Address2 Address { get; set; }
    }

    public class Attributes9
    {
        public string PhoneType { get; set; }
    }

    public class Phone2
    {

        //public string PhoneNumber { get; set; }
    }

    public class Attributes10
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
    }

    public class Identification4
    {

        public string IDValue { get; set; }
    }

    public class Attributes11
    {
        public string AddressType { get; set; }
    }

    public class Address3
    {

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    public class Employer
    {
        public Identification4 Identification { get; set; }
        public string CompanyName { get; set; }
        public Address3 Address { get; set; }
    }

    public class Name3
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Attributes12
    {
        public string PhoneType { get; set; }
    }

    public class Phone3
    {
        public string PhoneNumber { get; set; }
    }

    public class Supervisor
    {
        public Name3 Name { get; set; }
        public Phone3 Phone { get; set; }
    }

    public class Attributes13
    {
        public string Frequency { get; set; }
    }

    public class Salary
    {

        public string Amount { get; set; }
    }

    public class Attributes14
    {
        public string Start { get; set; }
    }

    public class Occupation
    {
        public Employer Employer { get; set; }
        public Supervisor Supervisor { get; set; }
        public Salary Salary { get; set; }

        public string Title { get; set; }
    }

    public class Finances
    {
        public Occupation Occupation { get; set; }
    }

    public class Attributes15
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
    }

    public class Identification5
    {

        public int IDValue { get; set; }
    }

    public class GuarantorFor
    {
        public Identification5 Identification { get; set; }
    }

    public class Tenant
    {

        public Identification Identification { get; set; }
        public LeaseID LeaseID { get; set; }
        public List<Reference> Reference { get; set; }
        public Name2 Name { get; set; }
        public Residence Residence { get; set; }
        public List<Phone2> Phone { get; set; }
        public Finances Finances { get; set; }
        public GuarantorFor GuarantorFor { get; set; }
    }

    public class Attributes16
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
        public int IsMonthToMonth { get; set; }
    }

    public class Identification6
    {

        public string IDValue { get; set; }
    }

    public class Attributes17
    {
        public string Start { get; set; }
        public string Frequency { get; set; }
        public string End { get; set; }
    }

    public class Attributes18
    {
        public string ChargeType { get; set; }
    }

    public class Attributes19
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
    }

    public class Identification7
    {

        public int IDValue { get; set; }
    }

    public class Charge
    {
        [JsonProperty("@attributes")]
        public Attributes18 Attributes { get; set; }
        public Identification7 Identification { get; set; }
        public string Label { get; set; }
        public string Amount { get; set; }
    }

    public class ChargeSet
    {

        public List<Charge> Charge { get; set; }
    }

    public class AccountingData
    {
        public List<ChargeSet> ChargeSet { get; set; }
    }

    public class Attributes20
    {
        public string Date { get; set; }
        public string EventType { get; set; }
    }

    public class LeaseEvent
    {

        public string Description { get; set; }

        [JsonProperty("@attributes")]
        public Attributes20 Attributes { get; set; }
    }

    public class LeaseEvents
    {
        public List<LeaseEvent> LeaseEvent { get; set; }
    }

    public class Attributes21
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
    }

    public class Identification8
    {

        public int IDValue { get; set; }
    }

    public class Name4
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Owner
    {
        public Identification8 Identification { get; set; }
        public Name4 Name { get; set; }
    }

    public class Vehicle
    {
        public string Color { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseState { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Owner Owner { get; set; }
        public int Year { get; set; }
    }

    public class ParkingStorage
    {
        public List<Vehicle> Vehicle { get; set; }
    }

    public class Attributes22
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
    }

    public class Identification9
    {

        public string IDValue { get; set; }
        public string OrganizationName { get; set; }
    }

    public class Attributes23
    {
        public string AddressType { get; set; }
    }

    public class Address4
    {

        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class Attributes24
    {
        public string PhoneType { get; set; }
    }

    public class Phone4
    {

        public string PhoneDescription { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Property
    {
        public Identification9 Identification { get; set; }
        public string MarketingName { get; set; }
        public List<Address4> Address { get; set; }
        public List<Phone4> Phone { get; set; }
    }

    public class Status
    {
        public string ApprovalStatus { get; set; }
    }

    public class Attributes25
    {
        public string IDType { get; set; }
        public string IDRank { get; set; }
        public string IDScopeType { get; set; }
    }

    public class Identification10
    {

        public string IDValue { get; set; }
    }

    public class Attributes26
    {
        public int Total { get; set; }
    }

    public class CurrentNumberOccupants
    {
        public Attributes26 OccupantsValue { get; set; }
        public int Value { get; set; }
    }

    public class Attributes27
    {
        public string AddressType { get; set; }
    }

    public class Address5
    {

        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    public class Unit
    {
        public Identification10 Identification { get; set; }
        public string MarketingName { get; set; }
        public string UnitType { get; set; }
        public string UnitBedrooms { get; set; }
        public string UnitBathrooms { get; set; }
        public string MinSquareFeet { get; set; }
        public string MaxSquareFeet { get; set; }
        public string SquareFootType { get; set; }
        public string MarketRent { get; set; }
        public string UnitEconomicStatus { get; set; }
        public string UnitLeasedStatus { get; set; }
        public CurrentNumberOccupants CurrentNumberOccupants { get; set; }
        public string FloorplanName { get; set; }
        public string BuildingName { get; set; }
        public Address5 Address { get; set; }
    }

    public class Attributes28
    {
        public string PetType { get; set; }
        public int Count { get; set; }
        public int Weight { get; set; }
    }

    public class Pet
    {

    }

    public class Pets
    {
        public List<Pet> Pet { get; set; }
    }

    public class LALease
    {
        public Identification6 Identification { get; set; }
        public AccountingData AccountingData { get; set; }
        public LeaseEvents LeaseEvents { get; set; }
        public ParkingStorage ParkingStorage { get; set; }
        public Property Property { get; set; }
        public List<Status> Status { get; set; }
        public Unit Unit { get; set; }
        public Pets Pets { get; set; }
    }

    public class LeaseApplication
    {
        public List<Tenant> Tenant { get; set; }
        public List<LALease> LA_Lease { get; set; }
    }

    public class Result
    {
        public LeaseApplication LeaseApplication { get; set; }
    }

    public class Response
    {
        public string requestId { get; set; }
        public int code { get; set; }
        public Result result { get; set; }
    }

    public class GetMitsLeasesResponse
    {
        public Response response { get; set; }
    }
}
