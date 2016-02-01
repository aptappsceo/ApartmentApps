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
        private IList<MaitenanceAction> _actions;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<MaitenanceAction> Actions
        {
            get { return this._actions; }
            set { this._actions = value; }
        }
        
        private DateTimeOffset? _date;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? Date
        {
            get { return this._date; }
            set { this._date = value; }
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
        
        private ApplicationUser _worker;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public ApplicationUser Worker
        {
            get { return this._worker; }
            set { this._worker = value; }
        }
        
        private string _workerId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string WorkerId
        {
            get { return this._workerId; }
            set { this._workerId = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the MaitenanceRequest class.
        /// </summary>
        public MaitenanceRequest()
        {
            this.Actions = new LazyList<MaitenanceAction>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken actionsSequence = ((JToken)inputObject["Actions"]);
                if (actionsSequence != null && actionsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken actionsValue in ((JArray)actionsSequence))
                    {
                        MaitenanceAction maitenanceAction = new MaitenanceAction();
                        maitenanceAction.DeserializeJson(actionsValue);
                        this.Actions.Add(maitenanceAction);
                    }
                }
                JToken dateValue = inputObject["Date"];
                if (dateValue != null && dateValue.Type != JTokenType.Null)
                {
                    this.Date = ((DateTimeOffset)dateValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
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
                JToken workerValue = inputObject["Worker"];
                if (workerValue != null && workerValue.Type != JTokenType.Null)
                {
                    ApplicationUser applicationUser2 = new ApplicationUser();
                    applicationUser2.DeserializeJson(workerValue);
                    this.Worker = applicationUser2;
                }
                JToken workerIdValue = inputObject["WorkerId"];
                if (workerIdValue != null && workerIdValue.Type != JTokenType.Null)
                {
                    this.WorkerId = ((string)workerIdValue);
                }
            }
        }
    }
}
