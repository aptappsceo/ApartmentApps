﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class IdentityUserClaim
    {
        private string _claimType;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ClaimType
        {
            get { return this._claimType; }
            set { this._claimType = value; }
        }
        
        private string _claimValue;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ClaimValue
        {
            get { return this._claimValue; }
            set { this._claimValue = value; }
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
        
        private string _userId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the IdentityUserClaim class.
        /// </summary>
        public IdentityUserClaim()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken claimTypeValue = inputObject["ClaimType"];
                if (claimTypeValue != null && claimTypeValue.Type != JTokenType.Null)
                {
                    this.ClaimType = ((string)claimTypeValue);
                }
                JToken claimValueValue = inputObject["ClaimValue"];
                if (claimValueValue != null && claimValueValue.Type != JTokenType.Null)
                {
                    this.ClaimValue = ((string)claimValueValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken userIdValue = inputObject["UserId"];
                if (userIdValue != null && userIdValue.Type != JTokenType.Null)
                {
                    this.UserId = ((string)userIdValue);
                }
            }
        }
    }
}
