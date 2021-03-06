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
        
        private string _address;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }
        
        private bool? _archived;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? Archived
        {
            get { return this._archived; }
            set { this._archived = value; }
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
        
        private int? _forteClientId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? ForteClientId
        {
            get { return this._forteClientId; }
            set { this._forteClientId = value; }
        }
        
        private string _gender;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Gender
        {
            get { return this._gender; }
            set { this._gender = value; }
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
        
        private string _middleName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string MiddleName
        {
            get { return this._middleName; }
            set { this._middleName = value; }
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
        
        private string _postalCode;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string PostalCode
        {
            get { return this._postalCode; }
            set { this._postalCode = value; }
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
        
        private string _state;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string State
        {
            get { return this._state; }
            set { this._state = value; }
        }
        
        private string _syncId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string SyncId
        {
            get { return this._syncId; }
            set { this._syncId = value; }
        }
        
        private string _thirdPartyId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ThirdPartyId
        {
            get { return this._thirdPartyId; }
            set { this._thirdPartyId = value; }
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
        
        private Unit _unit;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Unit Unit
        {
            get { return this._unit; }
            set { this._unit = value; }
        }
        
        private int? _unitId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? UnitId
        {
            get { return this._unitId; }
            set { this._unitId = value; }
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
                JToken addressValue = inputObject["Address"];
                if (addressValue != null && addressValue.Type != JTokenType.Null)
                {
                    this.Address = ((string)addressValue);
                }
                JToken archivedValue = inputObject["Archived"];
                if (archivedValue != null && archivedValue.Type != JTokenType.Null)
                {
                    this.Archived = ((bool)archivedValue);
                }
                JToken cityValue = inputObject["City"];
                if (cityValue != null && cityValue.Type != JTokenType.Null)
                {
                    this.City = ((string)cityValue);
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
                JToken forteClientIdValue = inputObject["ForteClientId"];
                if (forteClientIdValue != null && forteClientIdValue.Type != JTokenType.Null)
                {
                    this.ForteClientId = ((int)forteClientIdValue);
                }
                JToken genderValue = inputObject["Gender"];
                if (genderValue != null && genderValue.Type != JTokenType.Null)
                {
                    this.Gender = ((string)genderValue);
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
                JToken middleNameValue = inputObject["MiddleName"];
                if (middleNameValue != null && middleNameValue.Type != JTokenType.Null)
                {
                    this.MiddleName = ((string)middleNameValue);
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
                JToken postalCodeValue = inputObject["PostalCode"];
                if (postalCodeValue != null && postalCodeValue.Type != JTokenType.Null)
                {
                    this.PostalCode = ((string)postalCodeValue);
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
                JToken stateValue = inputObject["State"];
                if (stateValue != null && stateValue.Type != JTokenType.Null)
                {
                    this.State = ((string)stateValue);
                }
                JToken syncIdValue = inputObject["SyncId"];
                if (syncIdValue != null && syncIdValue.Type != JTokenType.Null)
                {
                    this.SyncId = ((string)syncIdValue);
                }
                JToken thirdPartyIdValue = inputObject["ThirdPartyId"];
                if (thirdPartyIdValue != null && thirdPartyIdValue.Type != JTokenType.Null)
                {
                    this.ThirdPartyId = ((string)thirdPartyIdValue);
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
                JToken unitValue = inputObject["Unit"];
                if (unitValue != null && unitValue.Type != JTokenType.Null)
                {
                    Unit unit = new Unit();
                    unit.DeserializeJson(unitValue);
                    this.Unit = unit;
                }
                JToken unitIdValue = inputObject["UnitId"];
                if (unitIdValue != null && unitIdValue.Type != JTokenType.Null)
                {
                    this.UnitId = ((int)unitIdValue);
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
