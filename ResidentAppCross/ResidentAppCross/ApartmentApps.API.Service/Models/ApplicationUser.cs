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
    public partial class ApplicationUser
    {
        private int? _accessFailedCount;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? AccessFailedCount
        {
            get { return this._accessFailedCount; }
            set { this._accessFailedCount = value; }
        }
        
        private IList<IdentityUserClaim> _claims;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<IdentityUserClaim> Claims
        {
            get { return this._claims; }
            set { this._claims = value; }
        }
        
        private string _devicePlatform;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string DevicePlatform
        {
            get { return this._devicePlatform; }
            set { this._devicePlatform = value; }
        }
        
        private string _deviceToken;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string DeviceToken
        {
            get { return this._deviceToken; }
            set { this._deviceToken = value; }
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
        
        private bool? _emailConfirmed;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? EmailConfirmed
        {
            get { return this._emailConfirmed; }
            set { this._emailConfirmed = value; }
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
        
        private bool? _lockoutEnabled;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? LockoutEnabled
        {
            get { return this._lockoutEnabled; }
            set { this._lockoutEnabled = value; }
        }
        
        private DateTimeOffset? _lockoutEndDateUtc;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? LockoutEndDateUtc
        {
            get { return this._lockoutEndDateUtc; }
            set { this._lockoutEndDateUtc = value; }
        }
        
        private IList<IdentityUserLogin> _logins;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<IdentityUserLogin> Logins
        {
            get { return this._logins; }
            set { this._logins = value; }
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
        
        private string _passwordHash;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string PasswordHash
        {
            get { return this._passwordHash; }
            set { this._passwordHash = value; }
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
        
        private bool? _phoneNumberConfirmed;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? PhoneNumberConfirmed
        {
            get { return this._phoneNumberConfirmed; }
            set { this._phoneNumberConfirmed = value; }
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
        
        private IList<IdentityUserRole> _roles;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<IdentityUserRole> Roles
        {
            get { return this._roles; }
            set { this._roles = value; }
        }
        
        private string _securityStamp;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string SecurityStamp
        {
            get { return this._securityStamp; }
            set { this._securityStamp = value; }
        }
        
        private Tenant _tenant;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Tenant Tenant
        {
            get { return this._tenant; }
            set { this._tenant = value; }
        }
        
        private string _timeZone;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string TimeZone
        {
            get { return this._timeZone; }
            set { this._timeZone = value; }
        }
        
        private bool? _twoFactorEnabled;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? TwoFactorEnabled
        {
            get { return this._twoFactorEnabled; }
            set { this._twoFactorEnabled = value; }
        }
        
        private IList<UserAlert> _userAlerts;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<UserAlert> UserAlerts
        {
            get { return this._userAlerts; }
            set { this._userAlerts = value; }
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
        /// Initializes a new instance of the ApplicationUser class.
        /// </summary>
        public ApplicationUser()
        {
            this.Claims = new LazyList<IdentityUserClaim>();
            this.Logins = new LazyList<IdentityUserLogin>();
            this.MaitenanceRequests = new LazyList<MaitenanceRequest>();
            this.Roles = new LazyList<IdentityUserRole>();
            this.UserAlerts = new LazyList<UserAlert>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken accessFailedCountValue = inputObject["AccessFailedCount"];
                if (accessFailedCountValue != null && accessFailedCountValue.Type != JTokenType.Null)
                {
                    this.AccessFailedCount = ((int)accessFailedCountValue);
                }
                JToken claimsSequence = ((JToken)inputObject["Claims"]);
                if (claimsSequence != null && claimsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken claimsValue in ((JArray)claimsSequence))
                    {
                        IdentityUserClaim identityUserClaim = new IdentityUserClaim();
                        identityUserClaim.DeserializeJson(claimsValue);
                        this.Claims.Add(identityUserClaim);
                    }
                }
                JToken devicePlatformValue = inputObject["DevicePlatform"];
                if (devicePlatformValue != null && devicePlatformValue.Type != JTokenType.Null)
                {
                    this.DevicePlatform = ((string)devicePlatformValue);
                }
                JToken deviceTokenValue = inputObject["DeviceToken"];
                if (deviceTokenValue != null && deviceTokenValue.Type != JTokenType.Null)
                {
                    this.DeviceToken = ((string)deviceTokenValue);
                }
                JToken emailValue = inputObject["Email"];
                if (emailValue != null && emailValue.Type != JTokenType.Null)
                {
                    this.Email = ((string)emailValue);
                }
                JToken emailConfirmedValue = inputObject["EmailConfirmed"];
                if (emailConfirmedValue != null && emailConfirmedValue.Type != JTokenType.Null)
                {
                    this.EmailConfirmed = ((bool)emailConfirmedValue);
                }
                JToken firstNameValue = inputObject["FirstName"];
                if (firstNameValue != null && firstNameValue.Type != JTokenType.Null)
                {
                    this.FirstName = ((string)firstNameValue);
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
                JToken lastNameValue = inputObject["LastName"];
                if (lastNameValue != null && lastNameValue.Type != JTokenType.Null)
                {
                    this.LastName = ((string)lastNameValue);
                }
                JToken lockoutEnabledValue = inputObject["LockoutEnabled"];
                if (lockoutEnabledValue != null && lockoutEnabledValue.Type != JTokenType.Null)
                {
                    this.LockoutEnabled = ((bool)lockoutEnabledValue);
                }
                JToken lockoutEndDateUtcValue = inputObject["LockoutEndDateUtc"];
                if (lockoutEndDateUtcValue != null && lockoutEndDateUtcValue.Type != JTokenType.Null)
                {
                    this.LockoutEndDateUtc = ((DateTimeOffset)lockoutEndDateUtcValue);
                }
                JToken loginsSequence = ((JToken)inputObject["Logins"]);
                if (loginsSequence != null && loginsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken loginsValue in ((JArray)loginsSequence))
                    {
                        IdentityUserLogin identityUserLogin = new IdentityUserLogin();
                        identityUserLogin.DeserializeJson(loginsValue);
                        this.Logins.Add(identityUserLogin);
                    }
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
                JToken passwordHashValue = inputObject["PasswordHash"];
                if (passwordHashValue != null && passwordHashValue.Type != JTokenType.Null)
                {
                    this.PasswordHash = ((string)passwordHashValue);
                }
                JToken phoneNumberValue = inputObject["PhoneNumber"];
                if (phoneNumberValue != null && phoneNumberValue.Type != JTokenType.Null)
                {
                    this.PhoneNumber = ((string)phoneNumberValue);
                }
                JToken phoneNumberConfirmedValue = inputObject["PhoneNumberConfirmed"];
                if (phoneNumberConfirmedValue != null && phoneNumberConfirmedValue.Type != JTokenType.Null)
                {
                    this.PhoneNumberConfirmed = ((bool)phoneNumberConfirmedValue);
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
                JToken rolesSequence = ((JToken)inputObject["Roles"]);
                if (rolesSequence != null && rolesSequence.Type != JTokenType.Null)
                {
                    foreach (JToken rolesValue in ((JArray)rolesSequence))
                    {
                        IdentityUserRole identityUserRole = new IdentityUserRole();
                        identityUserRole.DeserializeJson(rolesValue);
                        this.Roles.Add(identityUserRole);
                    }
                }
                JToken securityStampValue = inputObject["SecurityStamp"];
                if (securityStampValue != null && securityStampValue.Type != JTokenType.Null)
                {
                    this.SecurityStamp = ((string)securityStampValue);
                }
                JToken tenantValue = inputObject["Tenant"];
                if (tenantValue != null && tenantValue.Type != JTokenType.Null)
                {
                    Tenant tenant = new Tenant();
                    tenant.DeserializeJson(tenantValue);
                    this.Tenant = tenant;
                }
                JToken timeZoneValue = inputObject["TimeZone"];
                if (timeZoneValue != null && timeZoneValue.Type != JTokenType.Null)
                {
                    this.TimeZone = timeZoneValue.ToString(Newtonsoft.Json.Formatting.Indented);
                }
                JToken twoFactorEnabledValue = inputObject["TwoFactorEnabled"];
                if (twoFactorEnabledValue != null && twoFactorEnabledValue.Type != JTokenType.Null)
                {
                    this.TwoFactorEnabled = ((bool)twoFactorEnabledValue);
                }
                JToken userAlertsSequence = ((JToken)inputObject["UserAlerts"]);
                if (userAlertsSequence != null && userAlertsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken userAlertsValue in ((JArray)userAlertsSequence))
                    {
                        UserAlert userAlert = new UserAlert();
                        userAlert.DeserializeJson(userAlertsValue);
                        this.UserAlerts.Add(userAlert);
                    }
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
