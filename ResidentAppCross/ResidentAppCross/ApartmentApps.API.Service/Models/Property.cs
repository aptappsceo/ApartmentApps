﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Client.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class Property
    {
        private IList<Building> _buildings;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<Building> Buildings
        {
            get { return this._buildings; }
            set { this._buildings = value; }
        }
        
        private Corporation _corporation;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Corporation Corporation
        {
            get { return this._corporation; }
            set { this._corporation = value; }
        }
        
        private int? _corporationId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? CorporationId
        {
            get { return this._corporationId; }
            set { this._corporationId = value; }
        }
        
        private int? _id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private IList<MaitenanceRequest> _maitenanceRequests;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<MaitenanceRequest> MaitenanceRequests
        {
            get { return this._maitenanceRequests; }
            set { this._maitenanceRequests = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private IList<PropertyAddon> _propertyAddons;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<PropertyAddon> PropertyAddons
        {
            get { return this._propertyAddons; }
            set { this._propertyAddons = value; }
        }
        
        private int? _state;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? State
        {
            get { return this._state; }
            set { this._state = value; }
        }
        
        private string _timeZone;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string TimeZone
        {
            get { return this._timeZone; }
            set { this._timeZone = value; }
        }
        
        private string _timeZoneIdentifier;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string TimeZoneIdentifier
        {
            get { return this._timeZoneIdentifier; }
            set { this._timeZoneIdentifier = value; }
        }
        
        private IList<ApplicationUser> _users;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<ApplicationUser> Users
        {
            get { return this._users; }
            set { this._users = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        public Property()
        {
            this.Buildings = new LazyList<Building>();
            this.MaitenanceRequests = new LazyList<MaitenanceRequest>();
            this.PropertyAddons = new LazyList<PropertyAddon>();
            this.Users = new LazyList<ApplicationUser>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken buildingsSequence = ((JToken)inputObject["Buildings"]);
                if (buildingsSequence != null && buildingsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken buildingsValue in ((JArray)buildingsSequence))
                    {
                        Building building = new Building();
                        building.DeserializeJson(buildingsValue);
                        this.Buildings.Add(building);
                    }
                }
                JToken corporationValue = inputObject["Corporation"];
                if (corporationValue != null && corporationValue.Type != JTokenType.Null)
                {
                    Corporation corporation = new Corporation();
                    corporation.DeserializeJson(corporationValue);
                    this.Corporation = corporation;
                }
                JToken corporationIdValue = inputObject["CorporationId"];
                if (corporationIdValue != null && corporationIdValue.Type != JTokenType.Null)
                {
                    this.CorporationId = ((int)corporationIdValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken maitenanceRequestsSequence = ((JToken)inputObject["MaitenanceRequests"]);
                if (maitenanceRequestsSequence != null && maitenanceRequestsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken maitenanceRequestsValue in ((JArray)maitenanceRequestsSequence))
                    {
                        MaitenanceRequest maitenanceRequest = new MaitenanceRequest();
                        maitenanceRequest.DeserializeJson(maitenanceRequestsValue);
                        this.MaitenanceRequests.Add(maitenanceRequest);
                    }
                }
                JToken nameValue = inputObject["Name"];
                if (nameValue != null && nameValue.Type != JTokenType.Null)
                {
                    this.Name = ((string)nameValue);
                }
                JToken propertyAddonsSequence = ((JToken)inputObject["PropertyAddons"]);
                if (propertyAddonsSequence != null && propertyAddonsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken propertyAddonsValue in ((JArray)propertyAddonsSequence))
                    {
                        PropertyAddon propertyAddon = new PropertyAddon();
                        propertyAddon.DeserializeJson(propertyAddonsValue);
                        this.PropertyAddons.Add(propertyAddon);
                    }
                }
                JToken stateValue = inputObject["State"];
                if (stateValue != null && stateValue.Type != JTokenType.Null)
                {
                    this.State = ((int)stateValue);
                }
                JToken timeZoneValue = inputObject["TimeZone"];
                if (timeZoneValue != null && timeZoneValue.Type != JTokenType.Null)
                {
                    this.TimeZone = timeZoneValue.ToString(Newtonsoft.Json.Formatting.Indented);
                }
                JToken timeZoneIdentifierValue = inputObject["TimeZoneIdentifier"];
                if (timeZoneIdentifierValue != null && timeZoneIdentifierValue.Type != JTokenType.Null)
                {
                    this.TimeZoneIdentifier = ((string)timeZoneIdentifierValue);
                }
                JToken usersSequence = ((JToken)inputObject["Users"]);
                if (usersSequence != null && usersSequence.Type != JTokenType.Null)
                {
                    foreach (JToken usersValue in ((JArray)usersSequence))
                    {
                        ApplicationUser applicationUser = new ApplicationUser();
                        applicationUser.DeserializeJson(usersValue);
                        this.Users.Add(applicationUser);
                    }
                }
            }
        }
    }
}
