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
    public partial class MaitenanceRequest
    {
        private IList<MaintenanceRequestCheckin> _checkins;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<MaintenanceRequestCheckin> Checkins
        {
            get { return this._checkins; }
            set { this._checkins = value; }
        }
        
        private DateTimeOffset? _completionDate;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? CompletionDate
        {
            get { return this._completionDate; }
            set { this._completionDate = value; }
        }
        
        private string _description;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        
        private string _groupId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string GroupId
        {
            get { return this._groupId; }
            set { this._groupId = value; }
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
        
        private MaintenanceRequestCheckin _latestCheckin;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public MaintenanceRequestCheckin LatestCheckin
        {
            get { return this._latestCheckin; }
            set { this._latestCheckin = value; }
        }
        
        private MaitenanceRequestType _maitenanceRequestType;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public MaitenanceRequestType MaitenanceRequestType
        {
            get { return this._maitenanceRequestType; }
            set { this._maitenanceRequestType = value; }
        }
        
        private int? _maitenanceRequestTypeId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? MaitenanceRequestTypeId
        {
            get { return this._maitenanceRequestTypeId; }
            set { this._maitenanceRequestTypeId = value; }
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
        
        private bool? _permissionToEnter;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? PermissionToEnter
        {
            get { return this._permissionToEnter; }
            set { this._permissionToEnter = value; }
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
        
        private int? _propertyId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? PropertyId
        {
            get { return this._propertyId; }
            set { this._propertyId = value; }
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
        
        private MaintenanceRequestStatus _status;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public MaintenanceRequestStatus Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        
        private string _statusId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string StatusId
        {
            get { return this._statusId; }
            set { this._statusId = value; }
        }
        
        private DateTimeOffset? _submissionDate;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? SubmissionDate
        {
            get { return this._submissionDate; }
            set { this._submissionDate = value; }
        }
        
        private string _timeToComplete;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string TimeToComplete
        {
            get { return this._timeToComplete; }
            set { this._timeToComplete = value; }
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
        
        private ApplicationUser _user;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public ApplicationUser User
        {
            get { return this._user; }
            set { this._user = value; }
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
        /// Initializes a new instance of the MaitenanceRequest class.
        /// </summary>
        public MaitenanceRequest()
        {
            this.Checkins = new LazyList<MaintenanceRequestCheckin>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken checkinsSequence = ((JToken)inputObject["Checkins"]);
                if (checkinsSequence != null && checkinsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken checkinsValue in ((JArray)checkinsSequence))
                    {
                        MaintenanceRequestCheckin maintenanceRequestCheckin = new MaintenanceRequestCheckin();
                        maintenanceRequestCheckin.DeserializeJson(checkinsValue);
                        this.Checkins.Add(maintenanceRequestCheckin);
                    }
                }
                JToken completionDateValue = inputObject["CompletionDate"];
                if (completionDateValue != null && completionDateValue.Type != JTokenType.Null)
                {
                    this.CompletionDate = ((DateTimeOffset)completionDateValue);
                }
                JToken descriptionValue = inputObject["Description"];
                if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                {
                    this.Description = ((string)descriptionValue);
                }
                JToken groupIdValue = inputObject["GroupId"];
                if (groupIdValue != null && groupIdValue.Type != JTokenType.Null)
                {
                    this.GroupId = ((string)groupIdValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken latestCheckinValue = inputObject["LatestCheckin"];
                if (latestCheckinValue != null && latestCheckinValue.Type != JTokenType.Null)
                {
                    MaintenanceRequestCheckin maintenanceRequestCheckin2 = new MaintenanceRequestCheckin();
                    maintenanceRequestCheckin2.DeserializeJson(latestCheckinValue);
                    this.LatestCheckin = maintenanceRequestCheckin2;
                }
                JToken maitenanceRequestTypeValue = inputObject["MaitenanceRequestType"];
                if (maitenanceRequestTypeValue != null && maitenanceRequestTypeValue.Type != JTokenType.Null)
                {
                    MaitenanceRequestType maitenanceRequestType = new MaitenanceRequestType();
                    maitenanceRequestType.DeserializeJson(maitenanceRequestTypeValue);
                    this.MaitenanceRequestType = maitenanceRequestType;
                }
                JToken maitenanceRequestTypeIdValue = inputObject["MaitenanceRequestTypeId"];
                if (maitenanceRequestTypeIdValue != null && maitenanceRequestTypeIdValue.Type != JTokenType.Null)
                {
                    this.MaitenanceRequestTypeId = ((int)maitenanceRequestTypeIdValue);
                }
                JToken messageValue = inputObject["Message"];
                if (messageValue != null && messageValue.Type != JTokenType.Null)
                {
                    this.Message = ((string)messageValue);
                }
                JToken permissionToEnterValue = inputObject["PermissionToEnter"];
                if (permissionToEnterValue != null && permissionToEnterValue.Type != JTokenType.Null)
                {
                    this.PermissionToEnter = ((bool)permissionToEnterValue);
                }
                JToken petStatusValue = inputObject["PetStatus"];
                if (petStatusValue != null && petStatusValue.Type != JTokenType.Null)
                {
                    this.PetStatus = ((int)petStatusValue);
                }
                JToken propertyIdValue = inputObject["PropertyId"];
                if (propertyIdValue != null && propertyIdValue.Type != JTokenType.Null)
                {
                    this.PropertyId = ((int)propertyIdValue);
                }
                JToken scheduleDateValue = inputObject["ScheduleDate"];
                if (scheduleDateValue != null && scheduleDateValue.Type != JTokenType.Null)
                {
                    this.ScheduleDate = ((DateTimeOffset)scheduleDateValue);
                }
                JToken statusValue = inputObject["Status"];
                if (statusValue != null && statusValue.Type != JTokenType.Null)
                {
                    MaintenanceRequestStatus maintenanceRequestStatus = new MaintenanceRequestStatus();
                    maintenanceRequestStatus.DeserializeJson(statusValue);
                    this.Status = maintenanceRequestStatus;
                }
                JToken statusIdValue = inputObject["StatusId"];
                if (statusIdValue != null && statusIdValue.Type != JTokenType.Null)
                {
                    this.StatusId = ((string)statusIdValue);
                }
                JToken submissionDateValue = inputObject["SubmissionDate"];
                if (submissionDateValue != null && submissionDateValue.Type != JTokenType.Null)
                {
                    this.SubmissionDate = ((DateTimeOffset)submissionDateValue);
                }
                JToken timeToCompleteValue = inputObject["TimeToComplete"];
                if (timeToCompleteValue != null && timeToCompleteValue.Type != JTokenType.Null)
                {
                    this.TimeToComplete = ((string)timeToCompleteValue);
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
                JToken userValue = inputObject["User"];
                if (userValue != null && userValue.Type != JTokenType.Null)
                {
                    ApplicationUser applicationUser = new ApplicationUser();
                    applicationUser.DeserializeJson(userValue);
                    this.User = applicationUser;
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
