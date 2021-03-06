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
    public partial class UserInfoViewModel
    {
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
        
        private string _fullName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string FullName
        {
            get { return this._fullName; }
            set { this._fullName = value; }
        }
        
        private bool? _hasRegistered;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? HasRegistered
        {
            get { return this._hasRegistered; }
            set { this._hasRegistered = value; }
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
        
        private string _lastName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }
        
        private string _loginProvider;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string LoginProvider
        {
            get { return this._loginProvider; }
            set { this._loginProvider = value; }
        }
        
        private PropertyConfig _propertyConfig;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public PropertyConfig PropertyConfig
        {
            get { return this._propertyConfig; }
            set { this._propertyConfig = value; }
        }
        
        private IList<string> _roles;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<string> Roles
        {
            get { return this._roles; }
            set { this._roles = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the UserInfoViewModel class.
        /// </summary>
        public UserInfoViewModel()
        {
            this.Roles = new LazyList<string>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken emailValue = inputObject["Email"];
                if (emailValue != null && emailValue.Type != JTokenType.Null)
                {
                    this.Email = ((string)emailValue);
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
                JToken hasRegisteredValue = inputObject["HasRegistered"];
                if (hasRegisteredValue != null && hasRegisteredValue.Type != JTokenType.Null)
                {
                    this.HasRegistered = ((bool)hasRegisteredValue);
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
                JToken lastNameValue = inputObject["LastName"];
                if (lastNameValue != null && lastNameValue.Type != JTokenType.Null)
                {
                    this.LastName = ((string)lastNameValue);
                }
                JToken loginProviderValue = inputObject["LoginProvider"];
                if (loginProviderValue != null && loginProviderValue.Type != JTokenType.Null)
                {
                    this.LoginProvider = ((string)loginProviderValue);
                }
                JToken propertyConfigValue = inputObject["PropertyConfig"];
                if (propertyConfigValue != null && propertyConfigValue.Type != JTokenType.Null)
                {
                    PropertyConfig propertyConfig = new PropertyConfig();
                    propertyConfig.DeserializeJson(propertyConfigValue);
                    this.PropertyConfig = propertyConfig;
                }
                JToken rolesSequence = ((JToken)inputObject["Roles"]);
                if (rolesSequence != null && rolesSequence.Type != JTokenType.Null)
                {
                    foreach (JToken rolesValue in ((JArray)rolesSequence))
                    {
                        this.Roles.Add(((string)rolesValue));
                    }
                }
            }
        }
    }
}
