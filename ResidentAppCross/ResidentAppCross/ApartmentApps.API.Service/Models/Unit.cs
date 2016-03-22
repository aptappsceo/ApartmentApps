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
    public partial class Unit
    {
        private Building _building;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Building Building
        {
            get { return this._building; }
            set { this._building = value; }
        }
        
        private int? _buildingId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? BuildingId
        {
            get { return this._buildingId; }
            set { this._buildingId = value; }
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
        
        private double? _latitude;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public double? Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; }
        }
        
        private double? _longitude;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public double? Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; }
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
        
        private IList<Tenant> _tenants;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<Tenant> Tenants
        {
            get { return this._tenants; }
            set { this._tenants = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Unit class.
        /// </summary>
        public Unit()
        {
            this.MaitenanceRequests = new LazyList<MaitenanceRequest>();
            this.Tenants = new LazyList<Tenant>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken buildingValue = inputObject["Building"];
                if (buildingValue != null && buildingValue.Type != JTokenType.Null)
                {
                    Building building = new Building();
                    building.DeserializeJson(buildingValue);
                    this.Building = building;
                }
                JToken buildingIdValue = inputObject["BuildingId"];
                if (buildingIdValue != null && buildingIdValue.Type != JTokenType.Null)
                {
                    this.BuildingId = ((int)buildingIdValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken latitudeValue = inputObject["Latitude"];
                if (latitudeValue != null && latitudeValue.Type != JTokenType.Null)
                {
                    this.Latitude = ((double)latitudeValue);
                }
                JToken longitudeValue = inputObject["Longitude"];
                if (longitudeValue != null && longitudeValue.Type != JTokenType.Null)
                {
                    this.Longitude = ((double)longitudeValue);
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
                JToken tenantsSequence = ((JToken)inputObject["Tenants"]);
                if (tenantsSequence != null && tenantsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken tenantsValue in ((JArray)tenantsSequence))
                    {
                        Tenant tenant = new Tenant();
                        tenant.DeserializeJson(tenantsValue);
                        this.Tenants.Add(tenant);
                    }
                }
            }
        }
    }
}
