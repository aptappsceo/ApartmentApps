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
    public partial class InspectionViewModel
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
        
        private string _buildingName;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string BuildingName
        {
            get { return this._buildingName; }
            set { this._buildingName = value; }
        }
        
        private DateTimeOffset? _createDate;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? CreateDate
        {
            get { return this._createDate; }
            set { this._createDate = value; }
        }
        
        private DateTimeOffset? _endDate;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }
        
        private bool? _hasPet;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? HasPet
        {
            get { return this._hasPet; }
            set { this._hasPet = value; }
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
        
        private string _message;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
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
        
        private int? _status;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        
        private UserBindingModel _submissionUser;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public UserBindingModel SubmissionUser
        {
            get { return this._submissionUser; }
            set { this._submissionUser = value; }
        }
        
        private string _title;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
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
        /// Initializes a new instance of the InspectionViewModel class.
        /// </summary>
        public InspectionViewModel()
        {
            this.ActionLinks = new LazyList<ActionLinkModel>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken actionLinksSequence = ((JToken)inputObject["ActionLinks"]);
                if (actionLinksSequence != null && actionLinksSequence.Type != JTokenType.Null)
                {
                    foreach (JToken actionLinksValue in ((JArray)actionLinksSequence))
                    {
                        ActionLinkModel actionLinkModel = new ActionLinkModel();
                        actionLinkModel.DeserializeJson(actionLinksValue);
                        this.ActionLinks.Add(actionLinkModel);
                    }
                }
                JToken buildingNameValue = inputObject["BuildingName"];
                if (buildingNameValue != null && buildingNameValue.Type != JTokenType.Null)
                {
                    this.BuildingName = ((string)buildingNameValue);
                }
                JToken createDateValue = inputObject["CreateDate"];
                if (createDateValue != null && createDateValue.Type != JTokenType.Null)
                {
                    this.CreateDate = ((DateTimeOffset)createDateValue);
                }
                JToken endDateValue = inputObject["EndDate"];
                if (endDateValue != null && endDateValue.Type != JTokenType.Null)
                {
                    this.EndDate = ((DateTimeOffset)endDateValue);
                }
                JToken hasPetValue = inputObject["HasPet"];
                if (hasPetValue != null && hasPetValue.Type != JTokenType.Null)
                {
                    this.HasPet = ((bool)hasPetValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((string)idValue);
                }
                JToken messageValue = inputObject["Message"];
                if (messageValue != null && messageValue.Type != JTokenType.Null)
                {
                    this.Message = ((string)messageValue);
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
                    this.Status = ((int)statusValue);
                }
                JToken submissionUserValue = inputObject["SubmissionUser"];
                if (submissionUserValue != null && submissionUserValue.Type != JTokenType.Null)
                {
                    UserBindingModel userBindingModel = new UserBindingModel();
                    userBindingModel.DeserializeJson(submissionUserValue);
                    this.SubmissionUser = userBindingModel;
                }
                JToken titleValue = inputObject["Title"];
                if (titleValue != null && titleValue.Type != JTokenType.Null)
                {
                    this.Title = ((string)titleValue);
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
