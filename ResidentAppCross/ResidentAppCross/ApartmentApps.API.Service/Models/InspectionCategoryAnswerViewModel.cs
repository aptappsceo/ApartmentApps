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
    public partial class InspectionCategoryAnswerViewModel
    {
        private IList<InspectionAnswerViewModel> _answers;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<InspectionAnswerViewModel> Answers
        {
            get { return this._answers; }
            set { this._answers = value; }
        }
        
        private int? _categoryId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? CategoryId
        {
            get { return this._categoryId; }
            set { this._categoryId = value; }
        }
        
        private int? _roomId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? RoomId
        {
            get { return this._roomId; }
            set { this._roomId = value; }
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
        
        /// <summary>
        /// Initializes a new instance of the InspectionCategoryAnswerViewModel
        /// class.
        /// </summary>
        public InspectionCategoryAnswerViewModel()
        {
            this.Answers = new LazyList<InspectionAnswerViewModel>();
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type
        /// InspectionCategoryAnswerViewModel
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            JArray answersSequence = null;
            if (this.Answers != null)
            {
                if (this.Answers is ILazyCollection<InspectionAnswerViewModel> == false || ((ILazyCollection<InspectionAnswerViewModel>)this.Answers).IsInitialized)
                {
                    answersSequence = new JArray();
                    outputObject["Answers"] = answersSequence;
                    foreach (InspectionAnswerViewModel answersItem in this.Answers)
                    {
                        if (answersItem != null)
                        {
                            answersSequence.Add(answersItem.SerializeJson(null));
                        }
                    }
                }
            }
            if (this.CategoryId != null)
            {
                outputObject["CategoryId"] = this.CategoryId.Value;
            }
            if (this.RoomId != null)
            {
                outputObject["RoomId"] = this.RoomId.Value;
            }
            if (this.Status != null)
            {
                outputObject["Status"] = this.Status.Value;
            }
            return outputObject;
        }
    }
}
