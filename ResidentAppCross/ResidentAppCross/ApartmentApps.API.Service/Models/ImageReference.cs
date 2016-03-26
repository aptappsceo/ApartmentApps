﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class ImageReference
    {
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
        
        private string _thumbnailUrl;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string ThumbnailUrl
        {
            get { return this._thumbnailUrl; }
            set { this._thumbnailUrl = value; }
        }
        
        private string _url;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ImageReference class.
        /// </summary>
        public ImageReference()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
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
                JToken thumbnailUrlValue = inputObject["ThumbnailUrl"];
                if (thumbnailUrlValue != null && thumbnailUrlValue.Type != JTokenType.Null)
                {
                    this.ThumbnailUrl = ((string)thumbnailUrlValue);
                }
                JToken urlValue = inputObject["Url"];
                if (urlValue != null && urlValue.Type != JTokenType.Null)
                {
                    this.Url = ((string)urlValue);
                }
            }
        }
    }
}
