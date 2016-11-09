﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Client.Models;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public static partial class ProspectApplicationBindingModelCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<ProspectApplicationBindingModel> DeserializeJson(JToken inputObject)
        {
            IList<ProspectApplicationBindingModel> deserializedObject = new List<ProspectApplicationBindingModel>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                ProspectApplicationBindingModel prospectApplicationBindingModel = new ProspectApplicationBindingModel();
                prospectApplicationBindingModel.DeserializeJson(iListValue);
                deserializedObject.Add(prospectApplicationBindingModel);
            }
            return deserializedObject;
        }
    }
}
