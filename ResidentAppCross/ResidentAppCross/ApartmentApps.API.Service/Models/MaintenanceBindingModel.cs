﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class MaintenanceBindingModel
    {
        private string _buildingName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string BuildingName
        {
            get { return this._buildingName; }
            set { this._buildingName = value; }
        }
        
        private IList<string> _checkins;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<string> Checkins
        {
            get { return this._checkins; }
            set { this._checkins = value; }
        }
        
        private string _message;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
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
        
        private int? _petStatus;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? PetStatus
        {
            get { return this._petStatus; }
            set { this._petStatus = value; }
        }
        
        private DateTimeOffset? _scheduleDate;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? ScheduleDate
        {
            get { return this._scheduleDate; }
            set { this._scheduleDate = value; }
        }
        
        private string _status;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        
        private string _tenantFullName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string TenantFullName
        {
            get { return this._tenantFullName; }
            set { this._tenantFullName = value; }
        }
        
        private string _unitName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string UnitName
        {
            get { return this._unitName; }
            set { this._unitName = value; }
        }
        
        private string _userId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }
        
        private string _userName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string UserName
        {
            get { return this._userName; }
            set { this._userName = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the MaintenanceBindingModel class.
        /// </summary>
        public MaintenanceBindingModel()
        {
            this.Checkins = new LazyList<string>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken buildingNameValue = inputObject["BuildingName"];
                if (buildingNameValue != null && buildingNameValue.Type != JTokenType.Null)
                {
                    this.BuildingName = ((string)buildingNameValue);
                }
                JToken checkinsSequence = ((JToken)inputObject["Checkins"]);
                if (checkinsSequence != null && checkinsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken checkinsValue in ((JArray)checkinsSequence))
                    {
                        this.Checkins.Add(checkinsValue.ToString(Newtonsoft.Json.Formatting.Indented));
                    }
                }
                JToken messageValue = inputObject["Message"];
                if (messageValue != null && messageValue.Type != JTokenType.Null)
                {
                    this.Message = ((string)messageValue);
                }
                JToken nameValue = inputObject["Name"];
                if (nameValue != null && nameValue.Type != JTokenType.Null)
                {
                    this.Name = ((string)nameValue);
                }
                JToken petStatusValue = inputObject["PetStatus"];
                if (petStatusValue != null && petStatusValue.Type != JTokenType.Null)
                {
                    this.PetStatus = ((int)petStatusValue);
                }
                JToken scheduleDateValue = inputObject["ScheduleDate"];
                if (scheduleDateValue != null && scheduleDateValue.Type != JTokenType.Null)
                {
                    this.ScheduleDate = ((DateTimeOffset)scheduleDateValue);
                }
                JToken statusValue = inputObject["Status"];
                if (statusValue != null && statusValue.Type != JTokenType.Null)
                {
                    this.Status = ((string)statusValue);
                }
                JToken tenantFullNameValue = inputObject["TenantFullName"];
                if (tenantFullNameValue != null && tenantFullNameValue.Type != JTokenType.Null)
                {
                    this.TenantFullName = ((string)tenantFullNameValue);
                }
                JToken unitNameValue = inputObject["UnitName"];
                if (unitNameValue != null && unitNameValue.Type != JTokenType.Null)
                {
                    this.UnitName = ((string)unitNameValue);
                }
                JToken userIdValue = inputObject["UserId"];
                if (userIdValue != null && userIdValue.Type != JTokenType.Null)
                {
                    this.UserId = ((string)userIdValue);
                }
                JToken userNameValue = inputObject["UserName"];
                if (userNameValue != null && userNameValue.Type != JTokenType.Null)
                {
                    this.UserName = ((string)userNameValue);
                }
            }
        }
    }
}
