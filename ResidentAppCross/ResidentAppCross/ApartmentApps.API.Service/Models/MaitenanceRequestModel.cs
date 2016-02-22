﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class MaitenanceRequestModel
    {
        private string _comments;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Comments
        {
            get { return this._comments; }
            set { this._comments = value; }
        }
        
        private IList<string> _images;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<string> Images
        {
            get { return this._images; }
            set { this._images = value; }
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
        
        /// <summary>
        /// Initializes a new instance of the MaitenanceRequestModel class.
        /// </summary>
        public MaitenanceRequestModel()
        {
            this.Images = new LazyList<string>();
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type MaitenanceRequestModel
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.Comments != null)
            {
                outputObject["Comments"] = this.Comments;
            }
            JArray imagesSequence = null;
            if (this.Images != null)
            {
                if (this.Images is ILazyCollection<string> == false || ((ILazyCollection<string>)this.Images).IsInitialized)
                {
                    imagesSequence = new JArray();
                    outputObject["Images"] = imagesSequence;
                    foreach (string imagesItem in this.Images)
                    {
                        if (imagesItem != null)
                        {
                            imagesSequence.Add(imagesItem);
                        }
                    }
                }
            }
            if (this.MaitenanceRequestTypeId != null)
            {
                outputObject["MaitenanceRequestTypeId"] = this.MaitenanceRequestTypeId.Value;
            }
            return outputObject;
        }
    }
}