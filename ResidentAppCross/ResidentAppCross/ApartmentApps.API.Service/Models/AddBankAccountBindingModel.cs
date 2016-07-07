﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class AddBankAccountBindingModel
    {
        private string _accountHolderName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string AccountHolderName
        {
            get { return this._accountHolderName; }
            set { this._accountHolderName = value; }
        }
        
        private string _accountNumber;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string AccountNumber
        {
            get { return this._accountNumber; }
            set { this._accountNumber = value; }
        }
        
        private string _friendlyName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string FriendlyName
        {
            get { return this._friendlyName; }
            set { this._friendlyName = value; }
        }
        
        private bool? _isSavings;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsSavings
        {
            get { return this._isSavings; }
            set { this._isSavings = value; }
        }
        
        private string _routingNumber;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string RoutingNumber
        {
            get { return this._routingNumber; }
            set { this._routingNumber = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the AddBankAccountBindingModel class.
        /// </summary>
        public AddBankAccountBindingModel()
        {
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type AddBankAccountBindingModel
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.AccountHolderName != null)
            {
                outputObject["AccountHolderName"] = this.AccountHolderName;
            }
            if (this.AccountNumber != null)
            {
                outputObject["AccountNumber"] = this.AccountNumber;
            }
            if (this.FriendlyName != null)
            {
                outputObject["FriendlyName"] = this.FriendlyName;
            }
            if (this.IsSavings != null)
            {
                outputObject["IsSavings"] = this.IsSavings.Value;
            }
            if (this.RoutingNumber != null)
            {
                outputObject["RoutingNumber"] = this.RoutingNumber;
            }
            return outputObject;
        }
    }
}