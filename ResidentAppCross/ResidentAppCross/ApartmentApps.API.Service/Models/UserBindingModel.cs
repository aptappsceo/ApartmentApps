﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class UserBindingModel
    {
        private string _address;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }
        
        private string _buildingName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string BuildingName
        {
            get { return this._buildingName; }
            set { this._buildingName = value; }
        }
        
        private string _city;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string City
        {
            get { return this._city; }
            set { this._city = value; }
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
        
        private string _fullName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string FullName
        {
            get { return this._fullName; }
            set { this._fullName = value; }
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
        
        private string _imageThumbnailUrl;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ImageThumbnailUrl
        {
            get { return this._imageThumbnailUrl; }
            set { this._imageThumbnailUrl = value; }
        }
        
        private string _imageUrl;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ImageUrl
        {
            get { return this._imageUrl; }
            set { this._imageUrl = value; }
        }
        
        private bool? _isTenant;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsTenant
        {
            get { return this._isTenant; }
            set { this._isTenant = value; }
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
        
        private string _postalCode;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string PostalCode
        {
            get { return this._postalCode; }
            set { this._postalCode = value; }
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
        
        /// <summary>
        /// Initializes a new instance of the UserBindingModel class.
        /// </summary>
        public UserBindingModel()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken addressValue = inputObject["Address"];
                if (addressValue != null && addressValue.Type != JTokenType.Null)
                {
                    this.Address = ((string)addressValue);
                }
                JToken buildingNameValue = inputObject["BuildingName"];
                if (buildingNameValue != null && buildingNameValue.Type != JTokenType.Null)
                {
                    this.BuildingName = ((string)buildingNameValue);
                }
                JToken cityValue = inputObject["City"];
                if (cityValue != null && cityValue.Type != JTokenType.Null)
                {
                    this.City = ((string)cityValue);
                }
                JToken firstNameValue = inputObject["FirstName"];
                if (firstNameValue != null && firstNameValue.Type != JTokenType.Null)
                {
                    this.FirstName = ((string)firstNameValue);
                }
                JToken fullNameValue = inputObject["FullName"];
                if (fullNameValue != null && fullNameValue.Type != JTokenType.Null)
                {
                    this.FullName = ((string)fullNameValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((string)idValue);
                }
                JToken imageThumbnailUrlValue = inputObject["ImageThumbnailUrl"];
                if (imageThumbnailUrlValue != null && imageThumbnailUrlValue.Type != JTokenType.Null)
                {
                    this.ImageThumbnailUrl = ((string)imageThumbnailUrlValue);
                }
                JToken imageUrlValue = inputObject["ImageUrl"];
                if (imageUrlValue != null && imageUrlValue.Type != JTokenType.Null)
                {
                    this.ImageUrl = ((string)imageUrlValue);
                }
                JToken isTenantValue = inputObject["IsTenant"];
                if (isTenantValue != null && isTenantValue.Type != JTokenType.Null)
                {
                    this.IsTenant = ((bool)isTenantValue);
                }
                JToken lastNameValue = inputObject["LastName"];
                if (lastNameValue != null && lastNameValue.Type != JTokenType.Null)
                {
                    this.LastName = ((string)lastNameValue);
                }
                JToken phoneNumberValue = inputObject["PhoneNumber"];
                if (phoneNumberValue != null && phoneNumberValue.Type != JTokenType.Null)
                {
                    this.PhoneNumber = ((string)phoneNumberValue);
                }
                JToken postalCodeValue = inputObject["PostalCode"];
                if (postalCodeValue != null && postalCodeValue.Type != JTokenType.Null)
                {
                    this.PostalCode = ((string)postalCodeValue);
                }
                JToken unitNameValue = inputObject["UnitName"];
                if (unitNameValue != null && unitNameValue.Type != JTokenType.Null)
                {
                    this.UnitName = ((string)unitNameValue);
                }
            }
        }
    }
}