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
    public partial class ProspectApplicationBindingModel
    {
        private IList<ActionLinkModel> _actionLinks;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<ActionLinkModel> ActionLinks
        {
            get { return this._actionLinks; }
            set { this._actionLinks = value; }
        }
        
        private string _addressCity;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressCity
        {
            get { return this._addressCity; }
            set { this._addressCity = value; }
        }
        
        private string _addressLine1;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressLine1
        {
            get { return this._addressLine1; }
            set { this._addressLine1 = value; }
        }
        
        private string _addressLine2;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressLine2
        {
            get { return this._addressLine2; }
            set { this._addressLine2 = value; }
        }
        
        private string _addressState;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string AddressState
        {
            get { return this._addressState; }
            set { this._addressState = value; }
        }
        
        private DateTimeOffset? _createdOn;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? CreatedOn
        {
            get { return this._createdOn; }
            set { this._createdOn = value; }
        }
        
        private DateTimeOffset? _desiredMoveInDate;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? DesiredMoveInDate
        {
            get { return this._desiredMoveInDate; }
            set { this._desiredMoveInDate = value; }
        }
        
        private string _email;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }
        
        private string _firstName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }
        
        private string _id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private string _lastName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }
        
        private string _phoneNumber;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string PhoneNumber
        {
            get { return this._phoneNumber; }
            set { this._phoneNumber = value; }
        }
        
        private UserBindingModel _submittedBy;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public UserBindingModel SubmittedBy
        {
            get { return this._submittedBy; }
            set { this._submittedBy = value; }
        }
        
        private int? _zipCode;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? ZipCode
        {
            get { return this._zipCode; }
            set { this._zipCode = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ProspectApplicationBindingModel
        /// class.
        /// </summary>
        public ProspectApplicationBindingModel()
        {
            this.ActionLinks = new LazyList<ActionLinkModel>();
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type ProspectApplicationBindingModel
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            JArray actionLinksSequence = null;
            if (this.ActionLinks != null)
            {
                if (this.ActionLinks is ILazyCollection<ActionLinkModel> == false || ((ILazyCollection<ActionLinkModel>)this.ActionLinks).IsInitialized)
                {
                    actionLinksSequence = new JArray();
                    outputObject["ActionLinks"] = actionLinksSequence;
                    foreach (ActionLinkModel actionLinksItem in this.ActionLinks)
                    {
                        if (actionLinksItem != null)
                        {
                            actionLinksSequence.Add(actionLinksItem.SerializeJson(null));
                        }
                    }
                }
            }
            if (this.AddressCity != null)
            {
                outputObject["AddressCity"] = this.AddressCity;
            }
            if (this.AddressLine1 != null)
            {
                outputObject["AddressLine1"] = this.AddressLine1;
            }
            if (this.AddressLine2 != null)
            {
                outputObject["AddressLine2"] = this.AddressLine2;
            }
            if (this.AddressState != null)
            {
                outputObject["AddressState"] = this.AddressState;
            }
            if (this.CreatedOn != null)
            {
                outputObject["CreatedOn"] = this.CreatedOn.Value;
            }
            if (this.DesiredMoveInDate != null)
            {
                outputObject["DesiredMoveInDate"] = this.DesiredMoveInDate.Value;
            }
            if (this.Email != null)
            {
                outputObject["Email"] = this.Email;
            }
            if (this.FirstName != null)
            {
                outputObject["FirstName"] = this.FirstName;
            }
            if (this.Id != null)
            {
                outputObject["Id"] = this.Id;
            }
            if (this.LastName != null)
            {
                outputObject["LastName"] = this.LastName;
            }
            if (this.PhoneNumber != null)
            {
                outputObject["PhoneNumber"] = this.PhoneNumber;
            }
            if (this.SubmittedBy != null)
            {
                outputObject["SubmittedBy"] = this.SubmittedBy.SerializeJson(null);
            }
            if (this.ZipCode != null)
            {
                outputObject["ZipCode"] = this.ZipCode.Value;
            }
            return outputObject;
        }
    }
}
