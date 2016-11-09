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
    public partial class AddBankAccountBindingModel
    {
        private string _accountHolderName;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string AccountHolderName
        {
            get { return this._accountHolderName; }
            set { this._accountHolderName = value; }
        }
        
        private string _accountNumber;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string AccountNumber
        {
            get { return this._accountNumber; }
            set { this._accountNumber = value; }
        }
        
        private string _friendlyName;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string FriendlyName
        {
            get { return this._friendlyName; }
            set { this._friendlyName = value; }
        }
        
        private bool _isSavings;
        
        /// <summary>
        /// Required.
        /// </summary>
        public bool IsSavings
        {
            get { return this._isSavings; }
            set { this._isSavings = value; }
        }
        
        private string _routingNumber;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string RoutingNumber
        {
            get { return this._routingNumber; }
            set { this._routingNumber = value; }
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
        
        private IList<UserLookupBindingModel> _users;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<UserLookupBindingModel> Users
        {
            get { return this._users; }
            set { this._users = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the AddBankAccountBindingModel class.
        /// </summary>
        public AddBankAccountBindingModel()
        {
            this.Users = new LazyList<UserLookupBindingModel>();
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
            if (this.AccountHolderName == null)
            {
                throw new ArgumentNullException("AccountHolderName");
            }
            if (this.AccountNumber == null)
            {
                throw new ArgumentNullException("AccountNumber");
            }
            if (this.FriendlyName == null)
            {
                throw new ArgumentNullException("FriendlyName");
            }
            if (this.RoutingNumber == null)
            {
                throw new ArgumentNullException("RoutingNumber");
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
            outputObject["IsSavings"] = this.IsSavings;
            if (this.RoutingNumber != null)
            {
                outputObject["RoutingNumber"] = this.RoutingNumber;
            }
            if (this.UserId != null)
            {
                outputObject["UserId"] = this.UserId;
            }
            JArray usersSequence = null;
            if (this.Users != null)
            {
                if (this.Users is ILazyCollection<UserLookupBindingModel> == false || ((ILazyCollection<UserLookupBindingModel>)this.Users).IsInitialized)
                {
                    usersSequence = new JArray();
                    outputObject["Users"] = usersSequence;
                    foreach (UserLookupBindingModel usersItem in this.Users)
                    {
                        if (usersItem != null)
                        {
                            usersSequence.Add(usersItem.SerializeJson(null));
                        }
                    }
                }
            }
            return outputObject;
        }
    }
}
