﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using ApartmentApps.Client.Models;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class PropertyEntrataInfo
    {
        private string _endpoint;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Endpoint
        {
            get { return this._endpoint; }
            set { this._endpoint = value; }
        }
        
        private string _entrataPropertyId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string EntrataPropertyId
        {
            get { return this._entrataPropertyId; }
            set { this._entrataPropertyId = value; }
        }
        
        private string _password;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }
        
        private Property _property;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Property Property
        {
            get { return this._property; }
            set { this._property = value; }
        }
        
        private int? _propertyId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? PropertyId
        {
            get { return this._propertyId; }
            set { this._propertyId = value; }
        }
        
        private string _username;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the PropertyEntrataInfo class.
        /// </summary>
        public PropertyEntrataInfo()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken endpointValue = inputObject["Endpoint"];
                if (endpointValue != null && endpointValue.Type != JTokenType.Null)
                {
                    this.Endpoint = ((string)endpointValue);
                }
                JToken entrataPropertyIdValue = inputObject["EntrataPropertyId"];
                if (entrataPropertyIdValue != null && entrataPropertyIdValue.Type != JTokenType.Null)
                {
                    this.EntrataPropertyId = ((string)entrataPropertyIdValue);
                }
                JToken passwordValue = inputObject["Password"];
                if (passwordValue != null && passwordValue.Type != JTokenType.Null)
                {
                    this.Password = ((string)passwordValue);
                }
                JToken propertyValue = inputObject["Property"];
                if (propertyValue != null && propertyValue.Type != JTokenType.Null)
                {
                    Property property = new Property();
                    property.DeserializeJson(propertyValue);
                    this.Property = property;
                }
                JToken propertyIdValue = inputObject["PropertyId"];
                if (propertyIdValue != null && propertyIdValue.Type != JTokenType.Null)
                {
                    this.PropertyId = ((int)propertyIdValue);
                }
                JToken usernameValue = inputObject["Username"];
                if (usernameValue != null && usernameValue.Type != JTokenType.Null)
                {
                    this.Username = ((string)usernameValue);
                }
            }
        }
    }
}