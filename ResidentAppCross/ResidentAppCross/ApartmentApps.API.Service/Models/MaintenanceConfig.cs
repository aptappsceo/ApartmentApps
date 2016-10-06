﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class MaintenanceConfig
    {
        private bool? _enabled;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
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
        
        private int? _propertyId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? PropertyId
        {
            get { return this._propertyId; }
            set { this._propertyId = value; }
        }
        
        private bool? _supervisorMode;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? SupervisorMode
        {
            get { return this._supervisorMode; }
            set { this._supervisorMode = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the MaintenanceConfig class.
        /// </summary>
        public MaintenanceConfig()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken enabledValue = inputObject["Enabled"];
                if (enabledValue != null && enabledValue.Type != JTokenType.Null)
                {
                    this.Enabled = ((bool)enabledValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken propertyIdValue = inputObject["PropertyId"];
                if (propertyIdValue != null && propertyIdValue.Type != JTokenType.Null)
                {
                    this.PropertyId = ((int)propertyIdValue);
                }
                JToken supervisorModeValue = inputObject["SupervisorMode"];
                if (supervisorModeValue != null && supervisorModeValue.Type != JTokenType.Null)
                {
                    this.SupervisorMode = ((bool)supervisorModeValue);
                }
            }
        }
    }
}
